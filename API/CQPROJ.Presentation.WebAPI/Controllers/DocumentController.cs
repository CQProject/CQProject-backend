using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class DocumentController : ApiController
    {
        // GET document/user/:id
        /// <summary>
        /// Mostra os documentos de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     teacher (se for o próprio), 
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("document/user/{userid}")]
        public Object DocumentsbyUser(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || 
                (!payload.rol.Contains(3) && !payload.rol.Contains(6) && !payload.rol.Contains(2) || 
                (payload.rol.Contains(2) && payload.aud != userid)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            return BDocument.GetDocumentsbyUser(userid);
        }

        // GET document/user/:id
        /// <summary>
        /// Mostra os documentos de uma turma ||
        /// Autenticação: Sim
        /// [   admin, 
        ///     secretary, 
        ///     student (se pertencer à turma), 
        ///     teacher (se pertencer à turma), 
        ///     guardian (se tiver educandos na turma) 
        /// ]
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("document/class/{classid}")]
        public Object DocumentsbyClass(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5) || payload.rol.Contains(2)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if(payload.rol.Contains(1) || payload.rol.Contains(5))
            {
                return BDocument.GetDocumentsbyClassStudent(classid);
            }
            else
            {
                return BDocument.GetDocumentsbyClass(classid);
            }
        }

        //POST document/
        /// <summary>
        /// Cria um documento novo ||
        /// Autenticação: Sim
        /// [   admin, 
        ///     secretary,  
        ///     teacher
        /// ]
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("document")]
        public Object Post([FromBody]TblDocuments document)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BDocument.CreateDocument(document, payload.aud);
        }

        // PUT document/
        /// <summary>
        /// Altera um documento ||
        /// Autenticação: Sim
        /// [   admin (se o tiver inserido), 
        ///     secretary (se o tiver inserido),  
        ///     teacher (se o tiver inserido)
        /// ]
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("document")]
        public Object Put([FromBody]TblDocuments document)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)) || (payload.aud!=document.UserFK))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BDocument.EditDocument(document, payload.aud);
        }

        // DELETE document/:documentid
        /// <summary>
        /// Elimina um documento ||
        /// Autenticação: Sim
        /// [   admin (se o tiver inserido), 
        ///     secretary (se o tiver inserido),  
        ///     teacher (se o tiver inserido)
        /// ]
        /// </summary>
        /// <param name="documentid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("document/{documentid}")]
        public Object Delete(int documentid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BDocument.DeleteDocument(documentid, payload.aud);
        }
    }
}