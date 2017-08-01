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
    public class ScheduleController : ApiController
    {

        // GET schedule
        [HttpGet]
        [Route("schedule/{id}")]
        public Object Get(int id)
        {
            return new BSchedule().GetTeacherSchedule(id);
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