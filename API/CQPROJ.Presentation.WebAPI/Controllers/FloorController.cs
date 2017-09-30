using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class FloorController : ApiController
    {
        // GET room/school/:schoolid
        /// <summary>
        /// Mostra todos os pisos de uma escola ||
        /// Autenticação: Sim [
        /// admin,
        /// assistant
        /// ]
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("floor/school/{schoolid}")]
        public Object FloorBySchool(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var floors = BFloor.GetFloorsBySchool(schoolid);
            if (floors == null)
            {
                return new { result = false, info = "Não foram enconstrados pisos na escola." };
            }
            return new { result = true, data = floors };
        }

        // GET floor/single/:floorid
        /// <summary>
        /// Mostra os detalhes de um piso ||
        /// Autenticação: Sim [
        /// admin,
        /// assistant
        /// ]
        /// </summary>
        /// <param name="floorid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("floor/single/{floorid}")]
        public Object Single(int floorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var floor = BFloor.GetFloor(floorid);
            if (floor == null)
            {
                return new { result = false, info = "Não foi enconstrao piso." };
            }
            return new { result = true, data = floor };
        }

        // POST floor/
        /// <summary>
        /// Cria um novo piso ||
        /// Autenticação: Sim [
        /// admin
        /// ]
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("floor")]
        public Object Post([FromBody]TblFloors floor)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BFloor.CreateFloor(floor))
            {
                return new { result = false, info = "Não foi possível registar o piso." };
            }
            return new { result = true };
        }

        // PUT floor/
        /// <summary>
        /// Altera um piso ||
        /// Autenticação: Sim [
        /// admin
        /// ]
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("floor")]
        public Object Put([FromBody]TblFloors floor)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BFloor.EditFloor(floor))
            {
                return new { result = false, info = "Não foi possível editar o piso." };
            }
            return new { result = true };
        }

        // DELETE floor/:floorid
        /// <summary>
        /// Elimina um piso ||
        /// Autenticação: Sim [
        /// admin
        /// ]
        /// </summary>
        /// <param name="floorid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("floor/{floorid}")]
        public Object Delete(int floorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BFloor.DeleteFloor(floorid))
            {
                return new { result = false, info = "Não foi possível eliminar o piso." };
            }
            return new { result = true };
        }
    }
}
