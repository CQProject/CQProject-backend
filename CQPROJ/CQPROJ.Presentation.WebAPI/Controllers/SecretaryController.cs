using CQPROJ.Business.Entities;
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
            var secretaries = new Secretary().GetSecretaries();
            return secretaries;
        }

        // GET secretary/:id
        [HttpGet]
        [Route("secretary/{id}")]
        public Object Get(int? id)
        {
            var secretary = new Secretary().GetSecretary(5);
            return secretary;
        }

        //POST secretary/ tem de ser void
        [HttpPost]
        public void Post([FromBody]CreateSecretary secretary)
        {
            
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