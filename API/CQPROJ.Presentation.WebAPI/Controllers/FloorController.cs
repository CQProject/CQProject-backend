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
    }
}
