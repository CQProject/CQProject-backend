using CQPROJ.Business.Entities;
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

        // GET documents/:id
        [HttpGet]
        [Route("documents/{id}")]
        public Object Get(int id)
        {
            var documents = new BDocuments().GetClassDocuments(id);
            return documents;
        }

        //POST assistant/
        [HttpPost]
        [Route("documents")]
        public void Post([FromBody]Document document)
        {
            new BDocuments().CreateClassDocument(document);
        }
    }
}