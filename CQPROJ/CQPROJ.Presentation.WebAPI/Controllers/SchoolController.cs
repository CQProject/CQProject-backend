using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business;
using System.Web.Script.Serialization;

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
            var json = new JavaScriptSerializer().Serialize(school);
            return json;
        }

    }
}