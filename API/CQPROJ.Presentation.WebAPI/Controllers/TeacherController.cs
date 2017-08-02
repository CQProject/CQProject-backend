using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Business.Entities.Payload;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        // GET teacher/
        [HttpGet]
        [Route("teacher")]
        public Object Get()
        {
            var teachers = new BTeacher().GetTeachers();
            return teachers;
        }

        // GET teacher/:id
        [HttpGet]
        [Route("teacher/{id}")]
        public Object Get(int id)
        {
            var teacher = new BTeacher().GetTeacher(id);
            return teacher;
        }

        // POST teacher/
        [HttpPost]
        [Route("teacher")]
        public Object Post([FromBody]User teacher)
        {
            Payload payload = new BAccount().confirmToken(this.Request);

            switch (payload.rol)
            {
                case "3":
                    new BTeacher().CreateTeacher(teacher);
                    return new { Result = "Great Success" };
                case "6":
                    new BTeacher().CreateTeacher(teacher);
                    return new { Result = "Great Success" };
                default:
                    return new { Result = "Not Great Success - Unauthorized" };
            }

        }

        // PUT teacher/id
        [HttpPut]
        [Route("teacher/{id}")]
        public Object Put(int id, [FromBody]User teacher)
        {
            return new BTeacher().EditTeacher(id, teacher);
        }
    }
}