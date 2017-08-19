using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class NotificationController : ApiController
    {
        // GET notification/sent/:pageid
        [HttpGet]
        [Route("notification/sent/{pageid}")]
        public Object GetSentNotifs(int pageid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var notifications = BNotification.GetSentNotifications(payload.aud, pageid);
            if (notifications == null)
            {
                return new { result = false, info = "Não enviou mensagens." };
            }
            return new { result = true, data = notifications };
        }

        // GET notification/unread/
        [HttpGet]
        [Route("notification/unread")]
        public Object GetUnreadNotifs()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var notifications = BNotification.GetUnreadNotifications(payload.aud);
            if (notifications == null)
            {
                return new { result = false, info = "Não tem mensagens por lêr." };
            }
            return new { result = true, data = notifications };
        }

        // GET notification/unread/
        [HttpGet]
        [Route("notification/unreadcount")]
        public Object GetUnreadCount()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = true, data = BNotification.GetUnreadCount(payload.aud) };
        }

        // GET notification/message/:notifid
        [HttpGet]
        [Route("notification/message/{notifid}")]
        public Object GetUnreadNotifs(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var notifications = BNotification.GetNotification(notifid);
            if (notifications == null)
            {
                return new { result = false, info = "Não tem mensagens por lêr." };
            }
            return new { result = true, data = notifications };
        }

        // GET notification/page/:pageid
        [HttpGet]
        [Route("notification/page/{pageid}")]
        public Object GetReadNotifs(int pageid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var notifications = BNotification.GetReceivedNotifications(pageid, payload.aud);
            if (notifications == null)
            {
                return new { result = false, info = "Não recebeu mensagens." };
            }
            return new { result = true, data = notifications };
        }


        //POST notification/send
        [HttpPost]
        [Route("notification/send")]
        public Object Send([FromBody]Notification notification)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BNotification.SendNotification(notification) };
        }

        //PUT notification/read/:notifid
        [HttpPut]
        [Route("notification/read/{notifid}")]
        public Object Read(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BNotification.ReadNotification(notifid, payload.aud) };
        }

        //PUT notification/accept/:notifid
        [HttpPut]
        [Route("notification/accept/{notifid}")]
        public Object Accept(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            return new { result = BNotification.AcceptNotification(notifid, payload.aud) };
        }
    }
}