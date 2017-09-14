using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ScheduleController : ApiController
    {

        // GET schedule/teacher/{teacherid}
        [HttpGet]
        [Route("schedule/teacher/{teacherid}")]
        public Object ScheduleByTeacher(int teacherid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||
                (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)) ||
                (payload.rol.Contains(2) && payload.aud != teacherid))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByTeacher(teacherid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/class/:classid
        [HttpGet]
        [Route("schedule/class/{classid}")]
        public Object ScheduleByClass(int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(5)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByClass(classid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/room/:roomid
        [HttpGet]
        [Route("schedule/room/{roomid}")]
        public Object GetScheduleByRoom(int roomid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var schedule = BSchedule.GetScheduleByRoom(roomid);

            if (schedule == null)
            {
                return new { result = false, info = "Aulas não encontradas." };
            }

            return new { result = true, data = schedule };
        }

        // GET schedule/room/:roomid
        [HttpGet]
        [Route("schedule/profile/{scheduleid}")]
        public Object GetSchedule(int scheduleid)
        {
            var schedule = BSchedule.GetSchedule(scheduleid);
            if (schedule == null)
            {
                return new { result = false, info = "Aula não encontrada." };
            }

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((!payload.rol.Contains(3) && !payload.rol.Contains(6)) && !payload.cla.Contains((schedule.ClassFK) ?? default(int))))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return new { result = true, data = schedule };
        }

        // GET subject/:subjectid
        [HttpGet]
        [Route("subject/{subjectid}")]
        public Object GetSubjectById(int subjectid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var subject = BSchedule.GetSubject(subjectid);

            if (subject == null)
            {
                return new { result = false, info = "Disciplina não encontrada." };
            }

            return new { result = true, data = subject };
        }

        //POST schedule
        [HttpPost]
        [Route("schedule")]
        public Object Post([FromBody]TblSchedules schedule)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.CreateSchedule(schedule))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a aula." };
        }

        // PUT schedule
        [HttpPut]
        [Route("schedule")]
        public Object PutProfile([FromBody]TblSchedules schedule)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BSchedule.EditSchedule(schedule))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados da aula." };
        }
    }
}