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
        /// <summary>
        /// Mostra os encarregados de educação de um estudante ||
        /// Autenticação: Sim
        /// [
        ///     admin,
        ///     secretary,
        ///     teacher,
        ///     guardian, se for enc. educação do referido estudante
        ///     student, se for relaivo aos proprios enc. educação 
        /// ]
        /// </summary>
        /// <param name="studentid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("guardian/{studentid}")]
        public Object GetGuardians(int studentid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4)
                || (payload.rol.Contains(1) && payload.aud != studentid))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var guardians = BParenting.GetGuardians(studentid);
            if (guardians == null)
            {
                return new { result = false, info = "Não foram encontrados Enc.Educação do Estudante." };
            }
            if (payload.rol.Contains(5) && !guardians.Contains(payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = true, data = guardians };
        }

        /// <summary>
        /// Mostra os encarregados de educação de um estudante ||
        /// Autenticação: Sim
        /// [
        ///     admin,
        ///     secretary,
        ///     teacher,
        ///     guardian (se for os seus próprios educandos)
        ///     student, se for educando do referido enc. educação
        /// ]
        /// </summary>
        /// <param name="guardianid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("children/{guardianid}")]
        public Object GetChildren(int guardianid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(4)
                || (payload.rol.Contains(5) && guardianid != payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var children = BParenting.GetChildren(guardianid);
            if (children == null)
            {
                return new { result = false, info = "Não foram encontrados educandos." };
            }
            if (payload.rol.Contains(1) && !children.Contains(payload.aud))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = true, data = children };
        }

        //POST parenting/
        /// <summary>
        /// Cria uma relação entre o encarregado de educação e o estudante ||
        /// Autenticação: Sim
        /// [
        ///     admin,
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="parenting"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("parenting")]
        public Object Add([FromBody]Parenting parenting)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BParenting.AddParenting(parenting.GuardianID, parenting.StudentID, payload.aud))
            {
                return new { result = false, info = "Não foi possível adicionar o Enc.Educação ao Estudante." };
            }
            return new { result = true };
        }

        //DELETE parenting/
        /// <summary>
        /// Apaga a relação entre o encarregado de educação e o estudante ||
        /// Autenticação: Sim
        /// [
        ///     admin,
        ///     secretary 
        /// ]
        /// </summary>
        /// <param name="parenting"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("parenting")]
        public Object Remove([FromBody]Parenting parenting)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BParenting.RemoveParenting(parenting.GuardianID, parenting.StudentID, payload.aud))
            {
                return new { result = false, info = "Não foi possível remover o Enc.Educação do Estudante." };
            }
            return new { result = true };
        }
    }
}
