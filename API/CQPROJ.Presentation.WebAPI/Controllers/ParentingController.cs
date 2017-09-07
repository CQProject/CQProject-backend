using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ParentingController : ApiController
    {
        //Get guardian/:studentid
        [HttpGet]
        [Route("guardian/{studentid}")]
        public Object GetGuardians(int studentid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(2) && !payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var guardians = BParenting.GetGuardians(studentid);
            if (guardians==null)
            {
                return new { result = false, info = "Não foram encontrados Enc.Educação do Estudante." };
            }
            return new { result = true, data = guardians};
        }

        //POST guardian/
        [HttpPost]
        [Route("guardian")]
        public Object Create([FromBody]Guardian guardian)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BParenting.CreateGuardian(guardian);
        }

        //POST parenting/
        [HttpPost]
        [Route("parenting")]
        public Object Add([FromBody]Parenting parenting)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BParenting.AddParenting(parenting.GuardianID, parenting.StudentID))
            {
                return new { result = false, info = "Não foi possível adicionar o Enc.Educação ao Estudante." };
            }
            return new { result = true };
        }

        //DELETE parenting/
        [HttpDelete]
        [Route("parenting")]
        public Object Remove([FromBody]Parenting parenting)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BParenting.RemoveParenting(parenting.GuardianID, parenting.StudentID))
            {
                return new { result = false, info = "Não foi possível remover o Enc.Educação do Estudante." };
            }
            return new { result = true };
        }
    }
}
