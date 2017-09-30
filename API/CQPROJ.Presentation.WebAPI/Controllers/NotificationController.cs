using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class NotificationController : ApiController
    {
        // GET notification/sent/:pageid
        /// <summary>
        /// Lista as notificações enviadas de forma paginada
        /// </summary>
        /// <param name="pageid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("notification/sent/{pageid}")]
        public Object NotifsSent(int pageid)
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
        /// <summary>
        /// Retorna o número de notificações por ler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("notification/unreadcount")]
        public Object NotifsUnreadCount()
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var notifications = BNotification.GetUnreadCount(payload.aud);

            if( notifications == 0)
            {
                return new { result = false, info = "Não foram encontrados resultados." };
            }

            return new { result = true, data = notifications };
        }

        // GET notification/message/:notifid
        /// <summary>
        /// Mostra os detalhes de uma notificação selecionada
        /// </summary>
        /// <param name="notifid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("notification/message/{notifid}")]
        public Object NotifMessage(int notifid)
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

        // GET notification/received/:pageid
        /// <summary>
        /// Mostra as notificações recebidade de forma paginada
        /// </summary>
        /// <param name="pageid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("notification/received/{pageid}")]
        public Object NotifsReceived(int pageid)
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

        // GET notification/page/:pageid
        /// <summary>
        /// Mostra as validações enviadas numa notificação
        /// </summary>
        /// <param name="notifid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("validation/notification/{notifid}")]
        public Object ValidsByNotif(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var validations = BNotification.GetValidationsByNotification(notifid);

            if (validations == null)
            {
                return new { result = false, info = "Não foram encontrados destinatários." };
            }
            return new { result = true, data = validations };
        }


        //POST notification/send
        /// <summary>
        /// Envia notificações para um utilizador
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("notification/user")]
        public Object SendToUser([FromBody]NotificationUser notification)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||  payload.rol.Contains(1))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var result = BNotification.SendNotificationToUser(notification,payload.aud);
            if (!result)
            {
                return new { result = false, info = "Não foi possivel enviar a notificação." };
            }
            return new { result = true };
        }

        //POST notification/send
        /// <summary>
        /// Envia uma notificação para todos os membros de uma turma
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("notification/class")]
        public Object SendToClass([FromBody]NotificationClass notification)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || payload.rol.Contains(1) || payload.rol.Contains(4) || payload.rol.Contains(5))
            {
                return new { result = false, info = "Não autorizado." };
            }
            var result = BNotification.SendNotificationToClass(notification,payload.aud);
            if (!result)
            {
                return new { result = false, info = "Não foi possivel enviar a notificação." };
            }
            return new { result = true };
        }

        //PUT notification/read/:notifid
        /// <summary>
        /// Marca como lida uma notificação
        /// </summary>
        /// <param name="notifid"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("notification/read/{notifid}")]
        public Object Read(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var result = BNotification.ReadNotification(notifid, payload.aud);
            if (!result)
            {
                return new { result = false, info = "Não foi possivel marcar como lida a notificação." };
            }
            return new { result = true };
        }

        //PUT notification/accept/:notifid
        /// <summary>
        /// Aceita a validação de uma notificação
        /// </summary>
        /// <param name="notifid"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("notification/accept/{notifid}")]
        public Object Accept(int notifid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            var result = BNotification.AcceptNotification(notifid, payload.aud);
            if (!result)
            {
                return new { result = false, info = "Não foi possivel aceitar a notificação." };
            }
            return new { result = true };
        }
    }
}