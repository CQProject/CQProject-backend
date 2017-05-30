using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ActionController : ApiController
    {


        // GET action
        [HttpGet]
        [Route("action")]
        public Object Get()
        {
            var actions = new BAction().GetActions();
            return actions;
        }
        /*
        // GET action/:id
        [HttpGet]
        [Route("action/{id}")]
        public Object Get(int id)
        {
            var action = new BAction().GetAction(id);
            return action;
        }


        // GET action/secretary/:id
        [HttpGet]
        [Route("action/secretary/{id}")]
        public Object secretary(int id)
        {
            var action = new BAction().GetActionSecretary(id);
            return action;
        }

        // GET action/student/:id
        [HttpGet]
        [Route("action/student/{id}")]
        public Object student(int id)
        {
            var action = new BAction().GetActionStudent(id);
            return action;
        }

        /*
        // GET action/assistant/:id
        [HttpGet]
        [Route("action/assistant/{id}")]
        public Object assistant(int id)
        {
            var action = new BAction().GetActionAssistant(id);
            return action;
        }*/
    }
}