using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
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

        // GET student/class/:id
        [HttpGet]
        [Route("student/class/{id}")]
        public Object ClassByStudent(int id)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || payload.rol.Contains(2) || payload.rol.Contains(4) ||
                (payload.rol.Contains(1) && payload.aud != id) ||
                (payload.rol.Contains(5) && !BParenting.GetGuardians(id).Contains(payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesByUser(id);

            if (classes == null)
            {
                return new { result = false, info = "Sem turma atribuída." };
            }
            return new { result = true, data = classes };
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

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
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

        // POST student
        [HttpPost]
        [Route("student")]
        public Object Post([FromBody]Student_Guardian users)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            int studentID = BStudent.CreateStudent(users.Student);

            foreach (var user in users.Guardian)
            {
                BParenting.CreateGuardian(user, studentID);
            }

            return new { result = true };
        }

        //// PUT student/:id
        //[HttpPut]
        //[Route("student/{id}")]
        //public Object Put(int id, [FromBody]User student)
        //{
        //    //return new BStudent().EditStudent(id, student);
        //}

        ////// DELETE api/<controller>/5
        ////public void Delete(int id)
        ////{
        ////}
    }
}