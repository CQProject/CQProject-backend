using CQPROJ.Business.Entities.IAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using System.Web;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class AccountController : ApiController
    {

        // POST account/login/
        [HttpPost]
        [Route("account/login")]
        public Object Login([FromBody]Login userRequest)
        {
            
            Uri client = this.Request.RequestUri;
            var info = new BAccount().Login(userRequest,client);

            if( info == null)
            {
                return new { result = "failed" };
            }
            else
            {
                return new { result = "success", data = info };
            }
        }

        [HttpGet]
        [Route("account/verifytoken")]
        public Object verifytoken()
        {
            Uri client = this.Request.RequestUri;
            bool verified = BAccount.confirmValidationToken(this.Request);

            return new { result = true, data = verified };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}