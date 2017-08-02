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
    public class EvaluationController : ApiController
    {
        //POST evaluation/
        [HttpPost]
        [Route("evaluation")]
        public void Post([FromBody]Evaluation evaluation)
        {
            new BEvaluation().CreateEvaluation(evaluation);
        }
    }
}