using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business;
using Newtonsoft.Json;
using CQPROJ.Presentation.WebAPI.Interfaces;
using System.Data.Entity.Infrastructure;
using System.Web.Helpers;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET school/home
        [HttpGet]
        public Object Home()
        {
            var school = new School().GetSchool();
            return school;
        }

        [HttpPost]
        public Object Post([FromBody]string[] values)
        {
            var jsonReceived = Json.parse(Json.stringfy());
            
            return username;
        }

    }
}