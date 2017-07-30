using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.EStudent;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        //// GET student/
        //[HttpGet]
        //[Route("student")]
        //public Object Get()
        //{
        //    var students = new BStudent().GetStudents();
        //    return students;
        //}

        //// GET student/:id
        //[HttpGet]
        //[Route("student/{id}")]
        //public Object GetStudent(int id)
        //{
        //    var student = new BStudent().GetStudent(id);
        //    return student;
        //}
    
        //// POST student
        //[HttpPost]
        //[Route("student")]
        //public void Post([FromBody]Student cs)
        //{
        //    new BStudent().CreateStudent(cs);
        //}

        //// PUT student/:id
        //[HttpPut]
        //[Route("student/{id}")]
        //public Object Put(int id, [FromBody]Student student) //----!!!!!!!!!!! Por Testar
        //{
        //    return new BStudent().EditStudent(id, student);
        //}

        ////// DELETE api/<controller>/5
        ////public void Delete(int id)
        ////{
        ////}
    }
}