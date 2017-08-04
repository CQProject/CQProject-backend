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
        // GET lesson/schedule/:id
        [HttpGet]
        [Route("lesson/schedule/{id}")]
        public Object GetLessonsBySchedule(int id)
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

            return new { result = true, data = lesson };
        }

        // GET lesson/teacher/:id
        [HttpGet]
        [Route("lesson/teacher/{id}")]
        public Object GetLessonsByTeacher(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetAllLessonsByTeacher(id);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = lesson };
        }

        // GET lesson/all/{id}
        [HttpGet]
        [Route("lesson/all/{id}")]
        public Object Page(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetAllLessons(id);

            if (lesson == null)
            {
                return new { result = false, info = "Número da página não contém nenhuma lição." };
            }

            return new { result = true, data = new { page = id, info = lesson } };
        }

        // GET lesson/profile/:id
        [HttpGet]
        [Route("lesson/profile/{id}")]
        public Object GetLessonsByID(int id)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetLessonProfile(id);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = lesson };
        }

        //POST lesson/
        [HttpPost]
        [Route("lesson")]
        public Object PostLesson([FromBody]Lesson lesson)
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