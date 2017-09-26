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
        /// Mostra os documentos de um utilizador
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
            
            var docs = BDocument.GetDocumentsbyUser(userid);

            if (docs == null)
            {
                return new { result = true, info="Não foram encontrados documentos do utilizador." };
            }
            return new { result = true, data = docs };
        }

        // GET document/user/:id
        /// <summary>
        /// Mostra os documentos de uma turma
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
                var docs = BDocument.GetDocumentsbyClassStudent(classid);
                if (docs == null)
                {
                    return new { result = false, info = "Não foram encontrados documentos desta turma." };
                }
                return new { result = true, data = docs };
            }
            else
            {
                var docs = BDocument.GetDocumentsbyClass(classid);
                if (docs == null)
                {
                    return new { result = false, info = "Não foram encontrados documentos desta turma." };
                }
                return new { result = true, data = docs };
            }
        }

        //POST document/
        /// <summary>
        /// Cria um documento novo
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("document")]
        public Object Post([FromBody]TblDocuments document)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BDocument.CreateDocument(document))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível inserir o documento" };
        }

        // PUT document/
        /// <summary>
        /// Altera um documento
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("document")]
        public Object Put([FromBody]TblDocuments document)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BDocument.EditDocument(document))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar o documento" };
        }
    }
}