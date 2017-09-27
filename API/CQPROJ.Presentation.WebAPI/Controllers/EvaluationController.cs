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

            var evaluations = BEvaluation.GetEvaluationsbyClass(id);
            if (evaluations == null)
            {
                return new { result = false, info = "Não foram encontradas avaliações para esta turma." };
            }
            return new { result = true, data = evaluations };
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

            var evaluations = BEvaluation.GetEvaluationsbyTeacher(id);
            if (evaluations == null)
            {
                return new { result = false, info = "Não foram encontradas avaliações para esta disciplina." };
            }
            return new { result = true, data = evaluations };
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
                var grade = BEvaluation.GetGradeToStudent(evaluationid, payload.aud);
                if (grade == null)
                {
                    return new { result = false, info = "Não foi encontrada avaliação." };
                }
                return new { result = true, data = grade };
            }
            else
            {
                if (payload.rol.Contains(5))
                {
                    var grades = BEvaluation.GetGradesToGuardian(evaluationid, payload.aud);
                    if (grades == null)
                    {
                        return new { result = false, info = "Não foi encontrada avaliação." };
                    }
                    return new { result = true, data = grades };
                }
                else
                {
                    if (payload.rol.Contains(2))
                    {
                        if (!BEvaluation.VerifyTeacher(evaluationid, payload.aud))
                        {
                            return new { result = false, info = "Não foi encontrada avaliação." };
                        }
                    }
                    var grades = BEvaluation.GetGradesToTeacher(evaluationid);
                    if (grades == null)
                    {
                        return new { result = false, info = "Não foi encontrada avaliação." };
                    }
                    return new { result = true, data = grades };
                }
            }
        }


        //POST evaluation/
        /// <summary>
        /// Cria uma avaliação  ||
        /// Autenticação: Sim
        /// [   teacher
        /// ]
        /// </summary>
        /// <param name="evaluation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("evaluation")]
        public Object Post([FromBody]TblEvaluations evaluation)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BEvaluation.CreateEvaluation(evaluation))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a avaliação" };
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

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && evaluation.TeacherFK!=payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BEvaluation.EditEvaluation(evaluation))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar a avaliação" };
        }
    }
}