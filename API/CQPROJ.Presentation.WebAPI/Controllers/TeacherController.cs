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
        [Route("teacher/page/{id}")]
        public Object Page(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var teachers = BTeacher.GetTeachers(id);


            if (teachers == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success", data = new { page = id, info = teachers } };
        }

        // GET teacher/:id
        [HttpGet]
        [Route("teacher/profile/{id}")]
        public Object Profile(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            var teacher = BTeacher.GetTeacher(id);

            if (teacher == null)
            {
                return new { result = "failed" };
            }

            return new { result = "success", data = teacher };
        }

        // POST teacher/
        [HttpPost]
        [Route("teacher")]
        public Object Post([FromBody]User teacher)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            BTeacher.CreateTeacher(teacher);

            return new { Result = "success" };
        }

        
        // PUT teacher/id
        [HttpPut]
        [Route("teacher/{id}")]
        public Object Put(int id, [FromBody]User teacher)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = "unauthorized" };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = "unauthorized" };
            }

            return BTeacher.EditTeacher(id, teacher);
        }
    }
}