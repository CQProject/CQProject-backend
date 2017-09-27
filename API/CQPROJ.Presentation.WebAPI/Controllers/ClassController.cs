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
        // GET class/teacher/:teacherid
        /// <summary>
        /// Mostra as turmas de um professor ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     teacher (se for o próprio)
        /// ]
        /// </summary>
        /// <param name="teacherid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Mostra as turmas de um estudante ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     student (se for o próprio),
        ///     guardian (se o estudante for um educando seu)
        /// ]
        /// </summary>
        /// <param name="studentid"></param>
        /// <returns></returns>
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

        // GET class/primary/:schoolid
        /// <summary>
        /// Mostra todas as turmas de ensino primário de um centro escolar ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("class/primary/{schoolid}")]
        public Object ClassesPrimaryBySchool(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesPrimaryBySchool(schoolid);

            if (classes == null)
            {
                return new { result = false, info = "Escola 1º ciclo sem turmas." };
            }
            return new { result = true, data = classes };
        }

        // GET class/kindergarten/:schoolid
        /// <summary>
        /// Mostra todas as turmas de jardim de infância de um centro escolar ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("class/kindergarten/{schoolid}")]
        public Object ClassesKindergartenBySchool(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var classes = BClass.GetClassesKindergartenBySchool(schoolid);

            if (classes == null)
            {
                return new { result = false, info = "Jardim de infância sem turmas." };
            }
            return new { result = true, data = classes };
        }

        // GET student/class/:classid
        /// <summary>
        /// Mostra todos os alunos de uma turma ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     student (se pertencer à turma), 
        ///     teacher (se pertencer à turma), 
        ///     guardian (se tiver educandos na turma) 
        /// ]
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Mostra os professores de uma turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     student (se pertencer à turma), 
        ///     teacher (se pertencer à turma), 
        ///     guardian (se tiver educandos na turma) 
        /// ]
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Mostra o perfil de uma turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary,
        ///     student (se pertencer à turma), 
        ///     teacher (se pertencer à turma), 
        ///     guardian (se tiver educandos na turma) 
        /// ]
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Cria uma nova turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="newclass"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Adiciona um utilizador a uma turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="classuser"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Remove um utilizador de uma turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="classuser"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Altera os dados de uma turma  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="editedclass"></param>
        /// <returns></returns>
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