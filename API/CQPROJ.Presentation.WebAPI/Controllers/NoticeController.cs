using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class NoticeController : ApiController
    {
        // GET notice/news
        /// <summary>
        /// Apresenta os ultimos 4 anuncios publicados||
        /// Autenticação: Não
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("notice/news")]
        public Object GetNews()
        {
            var notices = BNotice.GetNews();

            if (notices == null)
            {
                return new { result = false, info = "Não foram encontrados anuncios." };
            }
            return new { result = true, data = notices };
        }

        // GET notice/school/:schoolid/:pageid
        /// <summary>
        /// Apresenta os ultimos 12 anuncios da referida pagina duma escola ||
        /// Autenticação: Não
        /// </summary>
        /// <param name="schoolid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("notice/school/{schoolid}/{pageid}")]
        public Object GetNoticesBySchool(int schoolid, int pageid)
        {
            var notices = BNotice.GetNoticeBySchool(schoolid, pageid-1);

            if (notices == null)
            {
                return new { result = false, info = "Não foram encontrados anuncios." };
            }
            return new { result = true, data = notices };
        }

        // POST notice
        /// <summary>
        /// Cria um novo anuncio ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="newnotice"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("notice")]
        public Object PostNotice([FromBody]TblNotices newnotice)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BNotice.CreateNotice(newnotice, payload.aud))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar o anuncio." };
        }

        // PUT notice
        /// <summary>
        /// Edita um anuncio ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="editednotice"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("notice")]
        public Object PutNotice([FromBody]TblNotices editednotice)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BNotice.EditNotice(editednotice, payload.aud))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados do anuncio." };
        }

        // DELETE notice/:noticeid
        /// <summary>
        /// Elimina um anuncio ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="noticeid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("notice/{noticeid}")]
        public Object DeleteNotice(int noticeid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BNotice.DeleteNotice(noticeid, payload.aud))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível eliminar anuncio." };
        }
    }
}
