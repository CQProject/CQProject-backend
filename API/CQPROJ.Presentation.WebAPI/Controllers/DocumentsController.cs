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
        public Object GetbyUser(int id)
        {
            IPayload info = BAccount.confirmToken(this.Request);

            if (info == null || 
                (!info.rol.Contains(3) && !info.rol.Contains(6) && !info.rol.Contains(2) || 
                (info.rol.Contains(2) && info.aud != id)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            var docs = BDocuments.GetDocumentsbyUser(id);
            if (docs == null)
            {
                return new { result = true, info="nã foi" };
            }
            return new { result = true, data = docs };
        }
    }
}