using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class EvaluationController : ApiController
    {

        // MESMOS rights que schedules

        // GET evaluations/class/:id
        /// <summary>
        /// Mostra as avaliações de uma turma  ||
        /// Autenticação: Sim
        /// [   admin, 
        ///     secretary, 
        ///     student (se pertencer à turma), 
        ///     teacher (se pertencer à turma), 
        ///     guardian (se tiver educandos na turma) 
        /// ]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("evaluations/class/{id}")]
        public Object GetbyClass(int id)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5) || payload.rol.Contains(2)) && !payload.cla.Contains(id)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BEvaluation.GetEvaluationsbyClass(id);
        }

        // GET evaluations/teacher/:id
        /// <summary>
        /// Mostra as avaliações de uma disciplina  ||
        /// Autenticação: Sim
        /// [   admin, 
        ///     secretary, 
        ///     teacher (se for o próprio)
        /// ]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("evaluations/teacher/{id}")]
        public Object GetbyTeacher(int id)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6) && !payload.rol.Contains(2)) ||
                (payload.rol.Contains(2) && payload.aud != id))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BEvaluation.GetEvaluationsbyTeacher(id);
        }

        // GET grades/evaluation/:evaluationid
        /// <summary>
        /// Mostra a nota numa avaliação de um utilizador  ||
        /// Autenticação: Sim
        /// [   admin, 
        ///     secretary, 
        ///     student, 
        ///     teacher, 
        ///     guardian 
        /// ]
        /// </summary>
        /// <param name="evaluationid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("grades/evaluation/{evaluationid}")]
        public Object GetGrades(int evaluationid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (payload.rol.Contains(1))
            {
                return BEvaluation.GetGradeToStudent(evaluationid, payload.aud);
            }
            else
            {
                if (payload.rol.Contains(5))
                {
                    return BEvaluation.GetGradesToGuardian(evaluationid, payload.aud);
                }
                else
                {
                    if (payload.rol.Contains(2) && !BEvaluation.VerifyTeacher(evaluationid, payload.aud))
                    {
                        return new { result = false, info = "Não foi encontrada avaliação." };
                    }
                    return BEvaluation.GetGradesToTeacher(evaluationid);
                }
            }
        }


        //POST evaluation/
        /// <summary>
        /// Cria uma avaliação  ||
        /// Autenticação: Sim
        /// [   teacher (se pertencer à turma)
        /// ]
        /// </summary>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("evaluation")]
        public Object Post([FromBody]TblEvaluations evaluation)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || !BClass.HasUser(evaluation.ClassFK, payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BEvaluation.CreateEvaluation(evaluation, payload.aud);
        }

        // PUT evaluation/
        /// <summary>
        /// Altera uma avaliação  ||
        /// Autenticação: Sim
        /// [   
        ///     teacher (se for uma avaliação criada pelo próprio), 
        /// ]
        /// </summary>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("evaluation")]
        public Object Put([FromBody]TblEvaluations evaluation)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && evaluation.TeacherFK != payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BEvaluation.EditEvaluation(evaluation, payload.aud);
        }

        /// <summary>
        /// Atribui nota a um aluno  ||
        /// Autenticação: Sim
        /// [   
        ///     teacher (se for uma avaliação criada pelo próprio), 
        /// ]
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("grade")]
        public Object PostGrade([FromBody]TblEvaluationStudents grade)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || !BEvaluation.VerifyTeacher(grade.EvaluationFK, payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BEvaluation.CreateGrade(grade);
        }

        /// <summary>
        /// Edita a nota de um aluno  ||
        /// Autenticação: Sim
        /// [   
        ///     teacher (se for uma avaliação criada pelo próprio), 
        /// ]
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("grade")]
        public Object PutGrade([FromBody]TblEvaluationStudents grade)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || !BEvaluation.VerifyTeacher(grade.EvaluationFK, payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BEvaluation.EditGrade(grade);
        }
    }
}