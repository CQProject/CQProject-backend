using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ClassController : ApiController
    {

        // todos os profs, secretarios e admins


        // GET class/teacher/:teacherid
        [HttpGet]
        [Route("class/teacher/{teacherid}")]
        public Object ClassesByTeacher(int teacherid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6) && !payload.rol.Contains(2)) || (payload.rol.Contains(2) && payload.aud != teacherid))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesByUser(teacherid);

            if (classes == null)
            {
                return new { result = false, info = "Sem turma atribuída." };
            }
            return new { result = true, data = classes };
        }

        // GET class/student/:studentid
        [HttpGet]
        [Route("class/student/{studentid}")]
        public Object ClassesByStudent(int studentid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(2) || payload.rol.Contains(4) ||
                (payload.rol.Contains(1) && payload.aud != studentid) ||
                (payload.rol.Contains(5) && !BParenting.GetGuardians(studentid).Contains(payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesByUser(studentid);

            if (classes == null)
            {
                return new { result = false, info = "Sem turma atribuída." };
            }
            return new { result = true, data = classes };
        }

        // GET class/school/:schoolid
        [HttpGet]
        [Route("class/school/{schoolid}")]
        public Object ClassesBySchool(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesBySchool(schoolid);

            if (classes == null)
            {
                return new { result = false, info = "Escola sem turmas." };
            }
            return new { result = true, data = classes };
        }

        // GET student/class/:classid
        [HttpGet]
        [Route("student/class/{classid}")]
        public Object StudentsByClass(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
               ((payload.rol.Contains(1) || payload.rol.Contains(2) || payload.rol.Contains(5)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var students = BClass.GetStudentsByClass(classid);

            if (students == null)
            {
                return new { result = false, info = "Turma sem alunos." };
            }
            return new { result = true, data = students };
        }

        // GET teacher/class/:classid
        [HttpGet]
        [Route("teacher/class/{classid}")]
        public Object TeachersByClass(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
               ((payload.rol.Contains(1) || payload.rol.Contains(2) || payload.rol.Contains(5)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var teachers = BClass.GetTeachersByClass(classid);

            if (teachers == null)
            {
                return new { result = false, info = "Turma sem professores." };
            }
            return new { result = true, data = teachers };
        }

        // GET class/profile/:classid
        [HttpGet]
        [Route("class/profile/{classid}")]
        public Object Profile(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5) || payload.rol.Contains(2)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classs = BClass.GetClassProfile(classid);

            if (classs == null)
            {
                return new { result = false, info = "Turma inexistente." };
            }
            return new { result = true, data = classs };
        }

        //POST class/profile
        [HttpPost]
        [Route("class/profile")]
        public Object Post([FromBody]TblClasses newclass)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BClass.CreateClass(newclass))
            {
                return new { result = true };
            }
            return new { result = false, info="Não foi possível registar a turma." };
        }

        // POST class/user/
        [HttpPost]
        [Route("class/user")]
        public Object AddUser([FromBody]ClassUser classuser)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BClass.AddUser(classuser.ClassID, classuser.UserID))
            {
                return new { result = false, info = "Não foi possível adicionar o utilizador à turma." };
            }
            return new { result = true };
        }

        // DELETE class/user/
        [HttpDelete]
        [Route("class/user")]
        public Object RemoveUser([FromBody]ClassUser classuser)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BClass.RemoveUser(classuser.ClassID, classuser.UserID))
            {
                return new { result = false, info = "Não foi possível remover o utilizador à turma." };
            }
            return new { result = true };
        }

        // PUT class/profile/
        [HttpPut]
        [Route("class/profile")]
        public Object PutProfile([FromBody]TblClasses editedclass)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BClass.EditClass(editedclass))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados da turma." };
        }
    }
}