using System;
using System.Collections.Generic;
using System.Web.Http;
using CQPROJ.Presentation.WebAPI.Interfaces;
using CQPROJ.Business.Queries;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET school/Home
        [HttpGet]
        public Object Home()
        {
            var school = new School().GetSchoolHome();
            return school;
        }

        // GET school/About
        [HttpGet]
        public Object About()
        {
            var school = new School().GetSchoolAbout();
            return school;
        }

        /*
        [HttpPost]
        [Route("school")]
        public Object getPost([FromBody]ITeste test)
        {
            var user = test.ID;
            var name = test.Name;
            return name;
        }*/
    }
}