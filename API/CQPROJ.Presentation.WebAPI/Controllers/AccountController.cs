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
            var info = BAccount.Login(userRequest,client);

            if ( info == null)
            {
                return new { result = false };
            }
            else
            {
                return new { result = true, data = info };
            }
        }

        // GET account/verifytoken/
        [HttpGet]
        [Route("account/verifytoken")]
        public Object verifytoken()
        {
            Uri client = this.Request.RequestUri;

            if (BAccount.confirmToken(this.Request) == null)
            {
                return new { result = true, data = false };
            }
            return new { result = true, data = true };
        }

        // PUT account/:id
        public void Put(int id, [FromBody]string value)
        {

        }
    }
}