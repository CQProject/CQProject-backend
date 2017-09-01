using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class LessonController : ApiController
    {
        // GET lesson/subject/:subjectid
        [HttpGet]
        [Route("lesson/list/{subjectid}/{classid}")]
        public Object LessonsBySubject(int subjectid, int classid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4) ||
                ((payload.rol.Contains(1) || payload.rol.Contains(2) || payload.rol.Contains(5)) && !payload.cla.Contains(classid)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetLessonsBySubject(subjectid, classid);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = lesson };
        }

        // GET lesson/profile/:lessonid
        [HttpGet]
        [Route("lesson/profile/{lessonid}")]
        public Object GetLessonsByID(int lessonid)
        {
            // Mesmos direitos das schedules

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.cla.Contains(4))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (payload.rol.Contains(1) || payload.rol.Contains(5))
            {
                var lesson = BLesson.GetLessonToStudent(lessonid, payload.aud);
                if (lesson == null)
                {
                    return new { result = false, info = "Nenhuma lição encontrada." };
                }
                return new { result = true, data = lesson };
            }
            else
            {
                var lesson = BLesson.GetLessonToTeacher(lessonid);
                if (lesson == null)
                {
                    return new { result = false, info = "Nenhuma lição encontrada." };
                }
                return new { result = true, data = lesson };
            }
        }

        //POST lesson/profile/
        [HttpPost]
        [Route("lesson/summary")]
        public Object PostLesson([FromBody]TblLessons lesson)
        {

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && !BLesson.VerifyTeacher(lesson, payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BLesson.CreateLesson(lesson) };
        }

        //POST lesson/faults/
        [HttpPost]
        [Route("lesson/faults")]
        public Object PostFaults([FromBody]TblLessonStudents lesson)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && !BLesson.VerifyTeacher(lesson, payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BLesson.RegisterFaults(lesson) };
        }

        // PUT lesson/
        [HttpPut]
        [Route("lesson/summary")]
        public Object PutLesson([FromBody]TblLessons lesson)
        {

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && !BLesson.VerifyTeacher(lesson, payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BLesson.EditLesson(lesson) };
        }

        // PUT lesson/
        [HttpPut]
        [Route("lesson/faults")]
        public Object PutFaults([FromBody]TblLessonStudents lesson)
        {

            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(2) || (payload.rol.Contains(2) && !BLesson.VerifyTeacher(lesson, payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BLesson.EditFaults(lesson) };
        }
    }
}