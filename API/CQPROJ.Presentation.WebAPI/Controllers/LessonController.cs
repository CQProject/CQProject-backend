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
    public class LessonController : ApiController
    {
        // GET lesson/:id
        [HttpGet]
        [Route("lesson/{id}")]
        public Object Get(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetAllLessonsBySchedule(id);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = new { page = id, info = lesson } };
        }

        //POST lesson/
        [HttpPost]
        [Route("lesson")]
        public Object Post([FromBody]Lesson lesson)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(2))
            {
                return new { result = false, info = "Não autorizado." };
            }

            BLesson.CreateLesson(lesson);
            return new { result = true };
        }
    }
}