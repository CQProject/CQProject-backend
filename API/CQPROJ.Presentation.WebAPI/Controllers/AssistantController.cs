using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class AssistantController : ApiController
    {
        // GET assistant/
        [HttpGet]
        [Route("assistant")]
        public Object Get()
        {
            //var role = new BAccount().confirmToken(this.Request);
            
            var assistant = new BAssistant().GetAssistants();
            return assistant;
        }

        // GET assistant/:id
        [HttpGet]
        [Route("assistant/{id}")]
        public Object Get(int id)
        {
            var assistant = new BAssistant().GetAssistant(id);
            return assistant;
        }

        //POST assistant/
        [HttpPost]
        [Route("assistant")]
        public void Post([FromBody]User assistant)
        {
            new BAssistant().CreateAssistant(assistant);
        }

        // PUT assistant/id
        [HttpPut]
        [Route("assistant/{id}")]
        public Object Put(int id,[FromBody]User assistant)
        {
            return new BAssistant().EditAssistant(id,assistant);
        }
    }
}