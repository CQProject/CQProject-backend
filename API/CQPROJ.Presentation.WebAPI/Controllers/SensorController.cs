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
        [HttpGet]
        [Route("sensor/floor/{floorid}")]
        public Object SensorByFloor(int floorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var sensors = BSensor.GetSensorsByFloor(floorid);
            if (sensors == null)
            {
                return new { result = false, info = "Não existem sensores no piso." };
            }
            return new { result = true, data = sensors };
        }

        // GET sensor/last/:sensorid
        [HttpGet]
        [Route("sensor/last/{sensorid}")]
        public Object LastRecord(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
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
        [HttpGet]
        [Route("sensor/history/{sensorid}")]
        public Object History(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
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
        [HttpGet]
        [Route("sensor/resume/{sensorid}")]
        public Object Resume(int sensorid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
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
        [HttpPut]
        [Route("sensor")]
        public Object PutProfile([FromBody]TblSensors sensor)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
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
