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

        // GET lesson/student/:id
        [HttpGet]
        [Route("lesson/student/{lessonid}/{studentid}")]
        public Object GetLessonsByStudent(int lessonid,int studentid)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if ((!info.rol.Contains(3) && !info.rol.Contains(6) && !info.rol.Contains(2) && info.aud!=studentid && !BGuardian.GetGuardians(studentid).Contains(info.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetAllLessonsByStudent(lessonid, studentid);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = lesson };
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

        // PUT lesson/id
    /*    [HttpPut]
        [Route("lesson/{id}")]
        public Object Put(int id, [FromBody]Lesson lesson)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!info.rol.Contains(3) && !info.rol.Contains(6) ) verifyTeacher no schedule
            {
                return new { result = false, info = "Não autorizado." };
            }

            return BLesson.EditLesson(id, lesson);
        }*/
    }
}