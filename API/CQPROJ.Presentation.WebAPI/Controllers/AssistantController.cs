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
            int[] roles = BAccount.confirmToken(this.Request);

            if (roles.Length == 0)
            {
                return new { Result = "Unauthorized" };
            }

            var assistant = new BAssistant().GetAssistants();
            return assistant;
        }

        // GET assistant/:id
        [HttpGet]
        [Route("assistant/{id}")]
        public Object Get(int id)
        {

            int[] roles = BAccount.confirmToken(this.Request);

            if (roles.Length == 0)
            {
                return new { Result = "Unauthorized" };
            }

            var assistant = new BAssistant().GetAssistant(id);
            return assistant;
        }

        //POST assistant/
        [HttpPost]
        [Route("assistant")]
        public Object Post([FromBody]User assistant)
        {

            int[] roles = BAccount.confirmToken(this.Request);

            if (!roles.Contains(3) && !roles.Contains(6))
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
        {

            int[] roles = BAccount.confirmToken(this.Request);

            if (roles.Length == 0)
            {
                return new { Result = "Unauthorized" };
            }

            new BAssistant().EditAssistant(id,assistant);
            return new { Result = "Great Success" };
        }
    }
}