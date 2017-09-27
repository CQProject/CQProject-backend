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
    public class SensorController : ApiController
    {
        // GET sensor/floor/:floorid
        /// <summary>
        /// Mostra os detalhes do sensor de uma sala  ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     assistant
        /// ]
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sensor/room/{roomid}")]
        public Object SensorByFloor(int roomid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var sensors = BSensor.GetSensorsByRoom(roomid);
            if (sensors == null)
            {
                return new { result = false, info = "Não existem sensores na sala." };
            }
            return new { result = true, data = sensors };
        }

        // GET sensor/last/:sensorid
        /// <summary>
        /// Mostra os últimos valores registados por um sensor ||
        /// Autenticação: Sim
        /// [   
        ///     admin, 
        ///     assistant
        /// ]
        /// </summary>
        /// <param name="sensorid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sensor/last/{sensorid}")]
        public Object LastRecord(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var sensors = BSensor.GetSensorLastValue(sensorid);
            if (sensors == null)
            {
                return new { result = false, info = "Não existem registos do sensor." };
            }
            return new { result = true, data = sensors };
        }

        // GET room/history/:sensorid
        /// <summary>
        /// Mostra os registos do histórico de um sensor ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="sensorid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sensor/history/{sensorid}")]
        public Object History(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var sensors = BSensor.GetSensorHistoric(sensorid);
            if (sensors == null)
            {
                return new { result = false, info = "Não existem registos do sensor." };
            }
            return new { result = true, data = sensors };
        }

        // GET sensor/resume/:sensorid
        /// <summary>
        /// Mostra o resumo dos registos de um sensor ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     assistant
        /// ]
        /// </summary>
        /// <param name="sensorid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("sensor/resume/{sensorid}")]
        public Object Resume(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(4)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var sensors = BSensor.GetSensorResume(sensorid);
            if (sensors == null)
            {
                return new { result = false, info = "Não foi possivel cacular média das leituras do sensor." };
            }
            return new { result = true, data = sensors };
        }

        //POST sensor/
        /// <summary>
        /// Cria um novo sensor ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sensor")]
        public Object Post([FromBody]TblSensors sensor)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BSensor.CreateSesnor(sensor))
            {
                return new { result = false, info = "Não foi possível registar a turma." };
            }
            return new { result = true };
        }

        // PUT sensor/
        /// <summary>
        /// Altera um sensor ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("sensor")]
        public Object PutProfile([FromBody]TblSensors sensor)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BSensor.EditSesnor(sensor))
            {
                return new { result = false, info = "Não foi possível alterar dados do sensor." };
            }
            return new { result = true };
        }

        // DELETE sesnor/:sensorid
        /// <summary>
        /// Apaga o sensor selecionado ||
        /// Autenticação: Sim
        /// [   
        ///     admin
        /// ]
        /// </summary>
        /// <param name="sensorid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("sensor/{sensorid}")]
        public Object RemoveUser(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||  !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BSensor.RemoveSensor(sensorid))
            {
                return new { result = false, info = "Não foi possível remover o sensor." };
            }
            return new { result = true };
        }
    }
}
