using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET student/
        [HttpGet]
        [Route("student/page/{id}")]
        public Object Page(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var students = BStudent.GetStudents(id);

            if (students == null)
            {
                return new { result = false, info = "Número da página não contém nenhum utilizador." };
            }

            return new { result = true, data = new { page = id, info = students } };
        }

        // GET student/:id
        [HttpGet]
        [Route("student/profile/{id}")]
        public Object Profile(int id)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var student = BStudent.GetStudent(id);

            if (student == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }

            return new { result = true, data = student };
        }

        /*// POST student
        [HttpPost]
        [Route("student")]
        public void Post([FromBody]User student,[FromBody]User[] guardian)
        {
            //int stud = new BStudent().CreateStudent(student);
            //for(var i = 0; i < guardian.length;i++){
            //create guardian and add parenting
            //}
        }

        // PUT student/:id
        [HttpPut]
        [Route("student/{id}")]
        public Object Put(int id, [FromBody]User student)
        {
            //return new BStudent().EditStudent(id, student);
        }*/

        ////// DELETE api/<controller>/5
        ////public void Delete(int id)
        ////{
        ////}
    }
}