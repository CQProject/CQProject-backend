using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ClassController : ApiController
    {

        // todos os profs, secretarios e admins


        // GET class/teachers/:id
        [HttpGet]
        [Route("class/teacher/{id}")]
        public Object ClassesByTeacher(int id)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6) && !payload.rol.Contains(2)) || (payload.rol.Contains(2) && payload.aud != id))
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

        // GET class/students/:id
        [HttpGet]
        [Route("class/students/{id}")]
        public Object ClassesByStudent(int id)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

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

        // GET class/school/:id
        [HttpGet]
        [Route("class/school/{id}")]
        public Object ClassesBySchool(int id)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(3) || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesBySchool(id);

            if (classes == null)
            {
                return new { result = false, info = "Escola sem turmas." };
            }
            return new { result = true, data = classes };
        }

        // GET class/students/:id
        [HttpGet]
        [Route("class/profile/{id}")]
        public Object Profile(int id)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5) || payload.rol.Contains(2)) && !payload.cla.Contains(id)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classs = BClass.GetClassProfile(id);

            if (classs == null)
            {
                return new { result = false, info = "Turma inexistente." };
            }
            return new { result = true, data = classs };
        }

        //POST class/
        [HttpPost]
        [Route("class")]
        public Object Post([FromBody]TblClasses newclass)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BClass.CreateClass(newclass))
            {
                return new { result = true };
            }
            return new { result = false, info="Não foi possível registar a turma" };
        }

        // PUT class/id
        [HttpPut]
        [Route("class/{id}")]
        public Object Put(int id, [FromBody]TblClasses newclass)
        {
            IPayload payload = BAccount.confirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BClass.EditClass(id, newclass))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados da turma" };
        }
    }
}