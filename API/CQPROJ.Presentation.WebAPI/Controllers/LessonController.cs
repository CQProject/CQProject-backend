using CQPROJ.Business.Entities;
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
            var assistant = new BLesson().GetTeacherLesson(id);
            return assistant;
        }

        //POST lesson/
        [HttpPost]
        [Route("lesson")]
        public void Post([FromBody]Lesson lesson)
        {
            new BLesson().CreateLesson(lesson);
        }
    }
}