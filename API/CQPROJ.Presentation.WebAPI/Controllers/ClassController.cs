using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.Payload;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ClassController : ApiController
    {

        // todos os profs, secretarios e admins


        // GET class/teachers/:id
        [HttpGet]
        [Route("class/teachers/{id}")]
        public Object ClassesByTeacher(int id)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(2) || payload.rol.Contains(5)) && !payload.cla.Contains(id)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var teachers = BClass.GetTeachersByClass(id);

            if (teachers == null)
            {
                return new { result = false, info = "Sem turma atribuída." };
            }
            return new { result = true, data = teachers };
        }

        // GET class/students/:id
        [HttpGet]
        [Route("class/students/{id}")]
        public Object ClassByStudent(int id)
        {
            Payload payload = BAccount.confirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
               ((payload.rol.Contains(1) || payload.rol.Contains(2) || payload.rol.Contains(5)) && !payload.cla.Contains(id)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetStudentsByClass(id);

            if (classes == null)
            {
                return new { result = false, info = "Sem turma atribuída." };
            }
            return new { result = true, data = classes };
        }




        //// GET secretary/:id
        //[HttpGet]
        //[Route("class/{id}")]
        //public Object Get(int id)
        //{
        //    var classByID = new BClass().GetClass(id);
        //    return classByID;
        //}

        // GET class/:id
        /*[HttpGet]
        [Route("class/{id}")]
        public Object Get(int id)
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (!roles.Contains(3) && !roles.Contains(6) && !roles.Contains(2))
            {
                return new { Result = "Not Great Success - Unauthorized" };

            }

            var classes = new BClass().GetClassesByTeacher(id);
            return classes;
        }*/
    }
}