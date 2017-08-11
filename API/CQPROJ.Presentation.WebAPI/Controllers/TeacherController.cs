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
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var teachers = BTeacher.GetTeachers(id);


            if (teachers == null)
            {
                return new { result = false, info = "Número da página não contém nenhum utilizador." };
            }

            return new { result = true, data = new { page = id, info = teachers } };
        }

        // GET teacher/class/:id
        [HttpGet]
        [Route("teacher/class/{id}")]
        public Object TeachersByClass(int id)
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

        // GET teacher/:id
        [HttpGet]
        [Route("teacher/profile/{id}")]
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

            var teacher = BTeacher.GetTeacher(id);

            if (teacher == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }

            return new { result = true, data = teacher };
        }

        // POST teacher/
        [HttpPost]
        [Route("teacher")]
        public Object Post([FromBody]User teacher)
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

            BTeacher.CreateTeacher(teacher);

            return new { Result = true };
        }

        
        // PUT teacher/id
        [HttpPut]
        [Route("teacher/{id}")]
        public Object Put(int id, [FromBody]User teacher)
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

            return BTeacher.EditTeacher(id, teacher);
        }
    }
}