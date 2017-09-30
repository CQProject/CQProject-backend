using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class TimeController : ApiController
    {
        // GET /time/primary/:schoolid
        /// <summary>
        /// Mostra as horas de aulas de uma escola primária ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("time/primary/{schoolid}")]
        public Object TimeByPrimary(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var time = BTime.GetTimeBySchool(schoolid, false);

            if (time == null)
            {
                return new { result = false, info = "Horários não encontrados." };
            }

            return new { result = true, data = time };
        }

        // GET /time/kindergarten/:schoolid
        /// <summary>
        /// Mostra as horas de aulas de um jardim escola ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("time/kindergarten/{schoolid}")]
        public Object TimeByKindergarten(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var time = BTime.GetTimeBySchool(schoolid, true);

            if (time == null)
            {
                return new { result = false, info = "Horários não encontrados." };
            }

            return new { result = true, data = time };
        }

        // GET /time/single/:timeid
        /// <summary>
        /// Retorna o horário de uma hora de aulas ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="timeid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("time/single/{timeid}")]
        public Object SingleTime(int timeid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var time = BTime.GetTime(timeid);

            if (time == null)
            {
                return new { result = false, info = "Horário não encontrado." };
            }

            return new { result = true, data = time };
        }

        // POST time
        /// <summary>
        /// Cria uma nova hora de aulas ||
        /// Autenticação: Sim [ admin ]
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("time")]
        public Object Post([FromBody]TblTimes time)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BTime.CreateTime(time))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível registar a hora de aulas." };
        }

        // PUT time
        /// <summary>
        /// Edita uma hora de aulas ||
        /// Autenticação: Sim [ admin ]
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("time")]
        public Object Put([FromBody]TblTimes time)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BTime.EditTime(time))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar a hora de aulas." };
        }

        // DELETE time/:timeid
        /// <summary>
        /// Elimina uma hora de aulas ||
        /// Autenticação: Sim [ admin ]
        /// </summary>
        /// <param name="timeid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("time/{timeid}")]
        public Object Delete(int timeid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (BTime.DeleteTime(timeid))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível eliminar a hora de aulas." };
        }
    }
}
