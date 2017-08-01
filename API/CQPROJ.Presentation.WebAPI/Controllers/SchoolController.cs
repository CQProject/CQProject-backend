using System;
using System.Collections.Generic;
using System.Web.Http;
using CQPROJ.Business.Queries;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school/Home
        [HttpGet]
        public Object Home()
        {
            var school = new BSchool().GetSchoolHome();
            return school;
        }
    }
}