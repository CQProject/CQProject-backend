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
    public class TimeController : ApiController
    {
        // GET /time/primary/{schoolid}
        /// <summary>
        /// Mostra o horário de uma escola primária
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

        // GET /time/kindergarten/{schoolid}
        /// <summary>
        /// Mostra o horário de um jardim escola
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

        // GET /time/single/{timeid}
        /// <summary>
        /// Retorna o tempo com o ID selecionado
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
    }
}
