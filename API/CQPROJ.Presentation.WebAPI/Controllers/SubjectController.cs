using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SubjectController : ApiController
    {
        /// <summary>
        /// Apresenta a lista de disciplinas do sistema  ||
        /// Autenticação: Sim
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("subject/list")]
        public Object GetSubjectList()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var subject = BSubject.GetSubjectList();

            if (subject == null)
            {
                return new { result = false, info = "Lista de disciplinas não encontrada." };
            }

            return new { result = true, data = subject };
        }

        // GET subject/:subjectid
        /// <summary>
        /// Apresenta uma disciplina  ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="subjectid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("subject/{subjectid}")]
        public Object GetSubjectById(int subjectid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var subject = BSubject.GetSubject(subjectid);

            if (subject == null)
            {
                return new { result = false, info = "Disciplina não encontrada." };
            }

            return new { result = true, data = subject };
        }

        /// <summary>
        /// Cria uma disciplina  ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("subject")]
        public Object PostSubject([FromBody]TblSubjects subject)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSubject.CreateSubject(subject))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a hora aula." };
        }

        /// <summary>
        /// Altera uma disciplina  ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("subject")]
        public Object PutSubject([FromBody]TblSubjects subject)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSubject.EditSubject(subject))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar a hora de aula." };
        }

        // DELETE subject/:subjectid
        /// <summary>
        /// Elimina uma disciplina  ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="subjectid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("subject/{subjectid}")]
        public Object DeleteSubject(int subjectid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSubject.DeleteSubject(subjectid))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível eliminar a hora de aula." };
        }
    }
}