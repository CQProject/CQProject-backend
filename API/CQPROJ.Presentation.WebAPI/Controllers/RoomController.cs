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
        // GET room/school/:schoolid
        /// <summary>
        /// Mostra todos as salas de uma escola
        /// </summary>
        /// <param name="schoolid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("room/school/{schoolid}")]
        public Object RoomBySchool(int schoolid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.GetRoomsBySchool(schoolid);
            if (rooms == null)
            {
                return new { result = false, info = "Não foram enconstradas salas na escola." };
            }
            return new { result = true, data = rooms };
        }

        // GET room/floor/:floorid
        /// <summary>
        /// Mostra todas as salas de um andar
        /// </summary>
        /// <param name="floorid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("room/floor/{floorid}")]
        public Object RoomByFloor(int floorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.GetRoomsByFloor(floorid);
            if (rooms == null)
            {
                return new { result = false, info = "Não foram enconstradas salas no piso." };
            }
            return new { result = true, data = rooms };
        }

        // GET room/single/:roomid
        /// <summary>
        /// Mostra os detalhes de uma sala
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("room/single/{roomid}")]
        public Object Single(int roomid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var rooms = BRoom.GetRoom(roomid);
            if (rooms == null)
            {
                return new { result = false, info = "Não foi enconstrada sala." };
            }
            return new { result = true, data = rooms };
        }

        // POST room/
        /// <summary>
        /// Cria uma nova sala
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("room")]
        public Object Post([FromBody]TblRooms room)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BRoom.CreateRoom(room))
            {
                return new { result = false, info = "Não foi possível registar a sala." };
            }
            return new { result = true };
        }

        // PUT room/
        /// <summary>
        /// Altera uma sala
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("room")]
        public Object Put([FromBody]TblRooms room)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BRoom.EditRoom(room))
            {
                return new { result = false, info = "Não foi possível editar a sala." };
            }
            return new { result = true};
        }
    }
}
