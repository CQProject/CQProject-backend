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
        /// <summary>
        /// Mostra as tarefas de um utilizador a realizar no presente dia ||
        /// Autenticação: Sim
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Mostra as tarefas de um dia de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dayweek"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Lista detalhes de uma tarefa já feita ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Cria uma nova tarefa ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("task")]
        public Object Post([FromBody]TblTasks task)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BTask.CreateTask(task, payload.aud))
            {
                return new { result = false, info = "Não foi possível adicionar a tarefa" };
            }
            return new { result = true };
        }

        //POST done
        /// <summary>
        /// Marca uma tarefa como feita ||
        /// Autenticação: Sim [ apenas o próprio associado à tarefa ]
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("done/{taskid}")]
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
        /// <summary>
        /// Altera uma tarefa ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("task")]
        public Object Put([FromBody]TblTasks task)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BTask.EditTask(task,payload.aud))
            {
                return new { result = false, info = "Não foi possível alterar a tarefa" };
            }
            return new { result = true };
        }

        // DELETE tesk/:taskid
        /// <summary>
        /// Altera uma tarefa ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("task/{taskid}")]
        public Object Delete(int taskid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BTask.DeleteTask(taskid))
            {
                return new { result = false, info = "Não foi possível eliminar a tarefa" };
            }
            return new { result = true };
        }
    }
}