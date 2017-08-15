using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ActionController : ApiController
    {
        // GET action/pages/:userid
        [HttpGet]
        [Route("action/pages/{userid}")]
        public Object Page(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
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
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
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