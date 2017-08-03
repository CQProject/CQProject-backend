using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;
using System.Text.RegularExpressions;
using CQPROJ.Business.Entities.Payload;

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
        public Object Post([FromBody]User assistant)
        {

            Payload payload = new BAccount().confirmToken(this.Request);


            if (payload == null)
            {
                return new { Result = "Unauthorized" };
            }

            Match result = Regex.Match(payload.rol, @"(3|6)$", RegexOptions.IgnoreCase); // faz match com um único 1 ou 3

            if (!result.Success)
            {
                return new { Result = "Unauthorized" };
            }

            new BAssistant().CreateAssistant(assistant);
            return new { Result = "Great Success" };
        }

        // PUT assistant/id
        [HttpPut]
        [Route("assistant/{id}")]
        public Object Put(int id,[FromBody]User assistant)
        { Payload payload = new BAccount().confirmToken(this.Request);


            if (payload == null)
            {
                return new { Result = "Unauthorized" };
            }

            Match result = Regex.Match(payload.rol, @"(3|6)$", RegexOptions.IgnoreCase); // faz match com um único 1 ou 3

            if (!result.Success)
            {
                return new { Result = "Unauthorized" };
            }

            new BAssistant().EditAssistant(id,assistant);
            return new { Result = "Great Success" };
        }
    }
}