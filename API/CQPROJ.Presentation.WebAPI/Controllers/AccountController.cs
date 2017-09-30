using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class AccountController : ApiController
    {

        // POST account/login/
        /// <summary>
        /// Autenticação de um utilizador ||
        /// Autenticação: Não
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("account/login")]
        public Object Login([FromBody]Login userRequest)
        {
            return BAccount.Login(userRequest, Request.RequestUri);
        }

        // GET account/verifytoken/
        /// <summary>
        /// Verifica a validade do token de um utilizador ||
        /// Autenticação: Não
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("account/verifytoken")]
        public Object VerifyToken()
        {
            if (BAccount.ConfirmToken(Request) != null)
            {
                return new { result = true, data = true };
            }
            return new { result = true, data = false };
        }
    }
}