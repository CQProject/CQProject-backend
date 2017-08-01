using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
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

        //POST secretary/
        [HttpPost]
        [Route("secretary")]
        public Object Post([FromBody]User secretary)
        {
            return new BSecretary().CreateSecretary(secretary);
        }

        // PUT secretary/id
        [HttpPut]
        [Route("secretary/{id}")]
        public Object Put(int id, [FromBody]User secretary)
        {
            return new BSecretary().EditSecretary(id, secretary);
        }
    }
}