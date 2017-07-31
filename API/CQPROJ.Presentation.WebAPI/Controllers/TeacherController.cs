using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IUser;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        //// GET teacher/
        //[HttpGet]
        //[Route("teacher")]
        //public Object Get()
        //{
        //    var teachers = new BTeacher().GetTeachers();
        //    return teachers;
        //}

        //// GET teacher/:id
        //[HttpGet]
        //[Route("teacher/{id}")]
        //public Object Get(int id)
        //{
        //    var teacher = new BTeacher().GetTeacher(id);
        //    return teacher;
        //}

        //// POST teacher/
        //[HttpPost]
        //[Route("teacher")]
        //public Object Post([FromBody]Teacher teacher)
        //{
        //    var teach = new BTeacher().CreateTeacher(teacher);
        //    return teach;
        //}

        //// PUT teacher/id
        //[HttpPut]
        //[Route("teacher/{id}")]
        //public Object Put(int id, [FromBody]Teacher teacher)
        //{
        //    return new BTeacher().EditTeacher(id, teacher);
        //}
    }
}