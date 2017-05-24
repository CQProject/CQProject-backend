using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.ESecretary;
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
        [Route("secretary")]
        public Object Get()
        {
            var secretaries = new BSecretary().GetSecretaries();
            return secretaries;
        }

        // GET secretary/:id
        [HttpGet]
        [Route("secretary/{id}")]
        public Object Get(int id)
        {
            var secretary = new BSecretary().GetSecretary(id);
            return secretary;
        }

        //POST secretary/ tem de ser void
        [HttpPost]
        [Route("secretary")]
        public void Post([FromBody]Secretary secretary)
        {
            new BSecretary().CreateSecretary(secretary);
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