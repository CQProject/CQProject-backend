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
        [HttpGet]
        [Route("evaluations/teacher/{id}")]
        public Object GetbyTeacher(int id)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6) && !payload.rol.Contains(2)) ||
                (payload.rol.Contains(2) && payload.aud!=id))
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


        //POST evaluation/
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
        [HttpPut]
        [Route("evaluation")]
        public Object Put([FromBody]TblEvaluations evaluation)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BEvaluation.EditEvaluation( evaluation))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar a avaliação" };
        }
    }
}