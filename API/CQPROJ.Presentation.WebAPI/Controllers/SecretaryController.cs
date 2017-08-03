using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SecretaryController : ApiController
    {

        // GET secretary/
        [HttpGet]
        [Route("secretary/page/{id}")]
        public Object Page(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var secretaries = BSecretary.GetSecretaries(id);

            if (secretaries == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success", data = new { page = id, info = secretaries } };
        }

        // GET secretary/:id
        [HttpGet]
        [Route("secretary/profile/{id}")]
        public Object Profile(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var secretary = BSecretary.GetSecretary(id);

            if (secretary == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success", data = secretary };
        }

        //POST secretary/
        [HttpPost]
        [Route("secretary")]
        public Object Post([FromBody]User secretary)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            BSecretary.CreateSecretary(secretary);

            return new { result = "success" };
        }

        // PUT secretary/id
        [HttpPut]
        [Route("secretary/{id}")]
        public Object Put(int id, [FromBody]User secretary)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            return BSecretary.EditSecretary(id, secretary);
        }
    }
}