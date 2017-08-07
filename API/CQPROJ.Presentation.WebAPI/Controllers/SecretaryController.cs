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


            //seguir exemplo
            if (info == null || (!info.rol.Contains(3) && !info.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var secretaries = BSecretary.GetSecretaries(id);

            if (secretaries == null)
            {
                return new { result = false, info = "Número da página não contém nenhum utilizador." };
            }

            return new { result = true, data = new { page = id, info = secretaries } };
        }

        // GET secretary/:id
        [HttpGet]
        [Route("secretary/profile/{id}")]
        public Object Profile(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var secretary = BSecretary.GetSecretary(id);

            if (secretary == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }

            return new { result = true, data = secretary };
        }

        //POST secretary/
        [HttpPost]
        [Route("secretary")]
        public Object Post([FromBody]User secretary)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            BSecretary.CreateSecretary(secretary);

            return new { result = true };
        }

        // PUT secretary/id
        [HttpPut]
        [Route("secretary/{id}")]
        public Object Put(int id, [FromBody]User secretary)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BSecretary.EditSecretary(id, secretary);
        }
    }
}