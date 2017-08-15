using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Data.DB.Models;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        // GET task/todo
        [HttpGet]
        [Route("task/todo")]
        public Object GetSentNotifs()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var tasks = BTask.GetMyTasks(payload.aud);
            if (tasks == null)
            {
                return new { result = false, info = "Não tem tarefas." };
            }
            return new { result = true, data = tasks };
        }

        // GET task/user/:userid/:dayweek
        [HttpGet]
        [Route("task/user/{userid}/{dayweek}")]
        public Object GetTasks(int userid, int dayweek)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var tasks = BTask.GetTasks(userid, dayweek);
            if (tasks == null)
            {
                return new { result = false, info = "Não tem tarefas." };
            }
            return new { result = true, data = tasks };
        }

        // GET task/done/:taskid
        [HttpGet]
        [Route("task/done/{taskid}")]
        public Object GetRealizations(int taskid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var tasks = BTask.GetRealizations(taskid);
            if (tasks == null)
            {
                return new { result = false, info = "Não tem tarefas realizadas." };
            }
            return new { result = true, data = tasks };
        }

        //POST task
        [HttpPost]
        [Route("task")]
        public Object Post([FromBody]TblTasks task)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BTask.CreateTask(task) };
        }

        //POST done
        [HttpPost]
        [Route("done")]
        public Object Done(int taskid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BTask.DoneTask(taskid, payload.aud);
        }

        //PUT task
        [HttpPut]
        [Route("task")]
        public Object Put([FromBody]TblTasks task)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BTask.EditTask(task) };
        }
    }
}