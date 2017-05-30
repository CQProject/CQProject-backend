using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        // GET task/
        [HttpGet]
        [Route("task")]
        public Object Get()
        {
            var tasks = new BTask().GetTasks();
            return tasks;
        }

        // GET task/:id
        [HttpGet]
        [Route("task/{id}")]
        public Object Get(int id)
        {
            var task = new BTask().GetTask(id);
            return task;
        }
    }
}