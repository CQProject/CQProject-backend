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
            var token = new BAccount().Login(userRequest,client);

            if( token == null)
            {
                return new { Result = "Failed" };
            }
            else
            {
                return new { Result = "Success", Token = token };
            }
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