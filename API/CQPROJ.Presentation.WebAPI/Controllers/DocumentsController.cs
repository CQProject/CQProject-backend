using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class DocumentsController : ApiController
    {

        // GET documents/user/:id
        [HttpGet]
        [Route("documents/user/{id}")]
        public Object Get(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if ((!info.rol.Contains(3) && !info.rol.Contains(6) && !info.rol.Contains(2))  || (info.rol.Contains(2) && info.aud != id))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            var documents = new BDocuments().GetClassDocuments(id);

            return new { result = true, info = documents };
        }

        /*//POST documents/
        [HttpPost]
        [Route("documents")]
        public void Post([FromBody]Document document)
        {
            new BDocuments().CreateClassDocument(document);
        }*/
    }
}