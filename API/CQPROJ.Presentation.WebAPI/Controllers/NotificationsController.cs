using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class NotificationsController : ApiController
    {
        // GET notifications/sent/:id
        [HttpGet]
        [Route("notifications/sent/{id}")]
        public Object GetSentNotifs(int id)
        {


            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (info.aud != id)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var notifications = BNotifications.GetSentNotifications(id);
            return new { result = true, data = notifications };
        }

        // GET notifications/unread/:id
        [HttpGet]
        [Route("notifications/unread/{id}")]
        public Object GetUnreadNotifs(int id)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (info.aud != id)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var notifications = BNotifications.GetUnreadNotifications(id);
            return new { result = true, data = notifications };
        }

        // GET notifications/read/:id
        [HttpGet]
        [Route("notifications/read/{id}")]
        public Object GetReadNotifs(int id)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (info.aud != id)
            {
                return new { result = false, info = "Não autorizado." };
            }


            var notifications = BNotifications.GetReadNotifications(id);
            return new { result = true, data = notifications };
        }

        //POST notifications/send
        [HttpPost]
        [Route("notifications/send")]
        public Object Post([FromBody]Notification notification)
        {

            Payload info = BAccount.confirmToken(this.Request);

            if (info == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            BNotifications.SendNotification(notification);

            return new { result = true };
        }

        // GET notifications/message/:id
       /* [HttpGet]
        [Route("notifications/message/{id}")]
        public Object GetNotifMessage(int id)
        {
            var notifications = new BNotifications().GetNotificationMessage(id);
            return notifications;
        }*/
    }
}