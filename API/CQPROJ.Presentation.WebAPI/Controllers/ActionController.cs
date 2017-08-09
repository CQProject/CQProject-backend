using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Business.Entities.Payload;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ActionController : ApiController
    {
        // GET action/pages/:userid
        [HttpGet]
        [Route("action/pages/{userid}")]
        public Object Page(int userid)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null || (!info.rol.Contains(3) && !info.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            return new { result = true, data = BAction.GetPagesByUser(userid) };
        }

        // GET action/page/:userid/:pageid
        [HttpGet]
        [Route("action/page/{userid}/{pageid}")]
        public Object GetByUser(int userid, int pageid)
        {
            Payload info = BAccount.confirmToken(this.Request);

            if (info == null || (!info.rol.Contains(3) && !info.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var actions = BAction.GetActionsbyUser(userid, pageid);

            if (actions == null)
            {
                return new { result = false, info = "Impossível carregar página." };
            }

            return new { result = true, data = new { page = pageid, info = actions } };
        }
    }
}