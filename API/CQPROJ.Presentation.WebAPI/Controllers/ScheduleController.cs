using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ScheduleController : ApiController
    {

        // GET schedule/teacher/{id}
        [HttpGet]
        [Route("schedule/teacher/{id}")]

        // Secretários, admins e professor se o id do header corresponder ao pedido

        public Object GetTeachersSchedule(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetTeacherSchedule(id);

            if (schedule == null)
            {
                return new { result = false, info = "Aula não encontrada." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/class/{id}
        [HttpGet]
        [Route("schedule/class/{id}")]

        // Secretários, admins, professores e alunos ou encarregados se estiverem relacioandos à turma

        public Object GetClassSchedule(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetClassSchedule(id);

            if (schedule == null)
            {
                return new { result = false, info = "Aula não encontrada." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/room/{id}
        [HttpGet]
        [Route("schedule/room/{id}")]

        // Secretários, admins

        public Object GetScheduleRoom(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

           var schedule = BSchedule.GetScheduleRoom(id);

            if (schedule == null)
            {
                return new { result = false, info = "Aula não encontrada." };
            }

            return new { result = true, data = schedule };
        }

        //// PUT secretary/id
        //[HttpPut]
        //[Route("schedule/{id}")]
        //public Object Put(int id, [FromBody]Schedule schedule)
        //{
        //    return new BSchedule().EditSchedule(id, schedule);
        //}

    }
}