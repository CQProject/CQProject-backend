using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Business.Entities.Payload;
using System.Text.RegularExpressions;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        // GET teacher/
        [HttpGet]
        [Route("teacher")]
        public Object Get()
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (roles.Length == 0)
            {
                return new { Result = "Unauthorized" };
            }

            var teachers = new BTeacher().GetTeachers();
            return teachers;
        }

        // GET teacher/:id
        [HttpGet]
        [Route("teacher/{id}")]
        public Object Get(int id)
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (roles.Length == 0)
            {
                return new { Result = "Unauthorized" };
            }

            var teacher = new BTeacher().GetTeacher(id);
            return teacher;
        }

        // POST teacher/
        [HttpPost]
        [Route("teacher")]
        public Object Post([FromBody]User teacher)
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (!roles.Contains(3) && !roles.Contains(6))
            {
                return new { Result = "Not Great Success - Unauthorized" };
               
            }

            new BTeacher().CreateTeacher(teacher);
            return new { Result = "Great Success" };
        }

        // PUT teacher/id
        [HttpPut]
        [Route("teacher/{id}")]
        public Object Put(int id, [FromBody]User teacher)
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (!roles.Contains(3) && !roles.Contains(6))
            {
                return new { Result = "Not Great Success - Unauthorized" };

            }

            new BTeacher().EditTeacher(id, teacher);
            return new { Result = "Great Success" };
        }
    }
}