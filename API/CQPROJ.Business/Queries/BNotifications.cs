using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BNotifications
    {
        private DBContextModel db = new DBContextModel();

        public Object GetSentNotifications(int id)
        {

            var notifications = db.TblNotifications.Select(x => x).Where(x => x.UserFK == id);

            var toSend = new List<Object>();
            foreach (var notification in notifications)
            {
                toSend.Add(new
                {
                    Hour = notification.Hour,
                    ID = notification.ID,
                    Subject = notification.Subject,
                    Urgency = notification.Urgency
                });
            }
            return toSend;
        }

        public Object GetUnreadNotifications(int userID)
        {
            var validations = db.TblValidations.Select(x => x).Where(x => x.UserFK == userID && x.Read == false);
            var toSend = new List<Object>();
            foreach (var validation in validations)
            {
                toSend.Add(new
                {
                    NotificationFK = validation.NotificationFK,
                    Read = validation.Read,
                    Accepted = validation.Accepted
                });
            }
            return toSend;
        }

        public Object GetReadNotifications(int userID)
        {
            var validations = db.TblValidations.Select(x => x).Where(x => x.UserFK == userID && x.Read == true);
            var toSend = new List<Object>();
            foreach (var validation in validations)
            {
                toSend.Add(new
                {
                    NotificationFK = validation.NotificationFK,
                    Read = validation.Read,
                    Accepted = validation.Accepted
                });
            }
            return toSend;
        }
        //var toSend = new List<Object>();
        //    foreach (var validation in validations)
        //    {
        //        var notification = db.TblNotifications.Find(validation.NotificationFK);
        //        toSend.Add(new
        //        {
        //            Hour = notification.Hour,
        //            ID = notification.ID,
        //            Subject = notification.Subject,
        //            Urgency = notification.Urgency
        //        });
        //    }
        //public Object GetReadNotifications(int userID)
        //{
        //    var validations = db.TblValidations.Select(x => x).Where(x => x.UserFK == userID && x.Read == true);

        //    var toSend = new List<Object>();
        //    foreach (var validation in validations)
        //    {
        //        var notification = db.TblNotifications.Find(validation.NotificationFK);
        //        toSend.Add(new
        //        {
        //            Hour = notification.Hour,
        //            ID = notification.ID,
        //            Subject = notification.Subject,
        //            Urgency = notification.Urgency
        //        });
        //    }
        //    return toSend;
        //}

        public void SendNotification(Notification notification)
        {
            var date = DateTime.Now;

            try
            {
                TblNotifications notif = new TblNotifications
                {
                Description = notification.Description,
                Hour = date,
                Subject = notification.Subject,
                Urgency = notification.Urgency,
                UserFK = notification.SenderFK
                };

                db.TblNotifications.Add(notif);
                db.SaveChanges();

            
                foreach (var receiver in notification.ReceiverFK)
                {

                    var user = db.TblUsers.Find(receiver);

                    TblValidations valid = new TblValidations
                    {
                        NotificationFK = notif.ID,
                        UserFK = user.ID,
                        Accepted = false,
                        Read = false
                    };

                    db.TblValidations.Add(valid);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
            }      
        }

        public Object GetNotificationMessage(int id)
        {
            var notifications = db.TblNotifications.Select(x => x).Where(x => x.ID == id).FirstOrDefault();

            return new
            {
                notifications.Description
            };
        }

    }
}
