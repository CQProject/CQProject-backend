using CQPROJ.Business.Entities;
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
            var notifications = new BNotifications().GetSentNotifications(id);
            return notifications;
        }

        // GET notifications/unread/:id
        [HttpGet]
        [Route("notifications/unread/{id}")]
        public Object GetUnreadNotifs(int id)
        {
            var notifications = new BNotifications().GetUnreadNotifications(id);
            return notifications;
        }

        // GET notifications/read/:id
        [HttpGet]
        [Route("notifications/read/{id}")]
        public Object GetReadNotifs(int id)
        {
            var notifications = new BNotifications().GetReadNotifications(id);
            return notifications;
        }

        //POST notifications/send
        [HttpPost]
        [Route("notifications/send")]
        public void Post([FromBody]Notification notification)
        {
            new BNotifications().SendNotification(notification);
        }

        // GET notifications/message/:id
        [HttpGet]
        [Route("notifications/message/{id}")]
        public Object GetNotifMessage(int id)
        {
            var notifications = new BNotifications().GetNotificationMessage(id);
            return notifications;
        }
    }
}