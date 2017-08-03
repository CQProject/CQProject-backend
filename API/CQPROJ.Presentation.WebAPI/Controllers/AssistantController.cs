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
        [Route("assistant/page/{id}")]
        public Object Page(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var assistant = BAssistant.GetAssistantsPage(id);

            if (assistant == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success",data = new { page = id, info = assistant} };
        }

        // GET assistant/:id
        [HttpGet]
        [Route("assistant/profile/{id}")]
        public Object Profile(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var assistant = BAssistant.GetAssistant(id);

            if (assistant == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success", data = assistant };
        }

        //POST assistant/
        [HttpPost]
        [Route("assistant")]
        public Object Post([FromBody]User assistant)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            BAssistant.CreateAssistant(assistant);

            return new { result = "success" };
  
        }

        // PUT assistant/id
        [HttpPut]
        [Route("assistant/{id}")]
        public Object Put(int id,[FromBody]User assistant)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            return BAssistant.EditAssistant(id,assistant);
        }
    }
}