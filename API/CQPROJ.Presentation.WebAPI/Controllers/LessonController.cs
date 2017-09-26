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
        /// <summary>
        /// Mostra as lições de uma disciplina de uma turma
        /// </summary>
        /// <param name="subjectid"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
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

        // GET lesson/student/:lessonid
        /// <summary>
        /// Mostra a lição selecionada, vista de estudante
        /// </summary>
        /// <param name="lessonid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("lesson/student/{lessonid}")]
        public Object GetLessonsByStudent(int lessonid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);
            if (payload == null || !payload.rol.Contains(1))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetLessonToStudent(lessonid, payload.aud);
            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }
            return new { result = true, data = lesson };
        }

        // GET lesson/teacher/:lessonid
        /// <summary>
        /// Mostra a lição selecionada, vista de professor
        /// </summary>
        /// <param name="lessonid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("lesson/teacher/{lessonid}")]
        public Object GetLessonsByTeacher(int lessonid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);
            var lesson = BLesson.GetLessonToTeacher(lessonid);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }
            if (payload == null || 
                payload.cla.Contains(1) || payload.rol.Contains(4) || payload.rol.Contains(5) || 
                (payload.rol.Contains(2) && !BLesson.VerifyTeacher(lesson.First(), payload.aud)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = true, data = lesson };
        }

        // GET lesson/guardian/:lessonid
        /// <summary>
        /// Mostra a lição selecionada, vista de encarregado de educação
        /// </summary>
        /// <param name="lessonid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("lesson/guardian/{lessonid}")]
        public Object GetLessonsByGuardian(int lessonid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);
            if (payload == null || !payload.rol.Contains(5))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var lesson = BLesson.GetLessonToGuardian(lessonid, payload.aud);

            if (lesson == null)
            {
                return new { result = false, info = "Nenhuma lição encontrada." };
            }

            return new { result = true, data = lesson };

        }

        //POST lesson/profile/
        /// <summary>
        /// Cria uma lição
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Marca as faltas numa lição
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Altera os detalhes de uma lição
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Altera as faltas marcadas para uma lição
        /// </summary>
        /// <param name="lesson"></param>
        /// <returns></returns>
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