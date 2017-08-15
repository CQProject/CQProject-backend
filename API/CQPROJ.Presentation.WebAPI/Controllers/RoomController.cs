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
    public class RoomController : ApiController
    {
        // GET notification/sent/:pageid
        [HttpGet]
        [Route("room/{schoolid}")]
        public Object Get(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.GetRoomsBySchool(schoolid);
            if (rooms == null)
            {
                return new { result = false, info = "Não foram enconstrados pisos." };
            }
            return new { result = true, data = rooms };
        }

        // POST notification/sent/:pageid
        [HttpPost]
        [Route("room/")]
        public Object Post([FromBody]TblRooms room)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.CreateRoom(room);
            if (rooms == null)
            {
                return new { result = false, info = "Não foi possível registar a sala." };
            }
            return new { result = true, data = rooms };
        }

        // PUT room/
        [HttpPut]
        [Route("room/")]
        public Object Put([FromBody]TblRooms room)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.EditRoom(room);
            if (rooms == null)
            {
                return new { result = false, info = "Não foi possível registar a sala." };
            }
            return new { result = true, data = rooms };
        }
    }
}
