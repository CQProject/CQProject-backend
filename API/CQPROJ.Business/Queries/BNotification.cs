using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BNotification
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetSentNotifications(int userID, int pageID)
        {
            var notifications = db.TblNotifications
                .Where(x => x.UserFK == userID)
                .OrderByDescending(x => x.ID)
                .Skip(50 * pageID)
                .Take(50);
            if (notifications.Count() == 0) { return null; }
            return notifications;
        }

        public static int GetUnreadCount(int userID)
        {
            return db.TblValidations.Where(x => x.UserFK == userID && x.Read == false).Count();
        }

        public static Object GetReceivedNotifications(int pageID, int userID)
        {
            var validations = db.TblValidations
                .Where(x => x.UserFK == userID)
                .OrderByDescending(x => x.NotificationFK)
                .Skip(50 * pageID)
                .Take(50);
            if (validations.Count() == 0) { return null; }
            return validations;
        }

        public static Object GetNotification(int notifID)
        {
            try
            {
                return db.TblNotifications.Find(notifID);
            }
            catch (Exception) { return null; }
        }

        public static Boolean SendNotification(Notification notification)
        {
            try
            {
                var date = DateTime.Now;
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
                    TblValidations valid = new TblValidations
                    {
                        NotificationFK = notif.ID,
                        UserFK = receiver,
                        Accepted = false,
                        Read = false
                    };
                    db.TblValidations.Add(valid);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean ReadNotification(int notifID, int userID)
        {
            try
            {
                var valid=db.TblValidations.Find(userID, notifID);
                valid.Read = true;
                db.Entry(valid).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean AcceptNotification(int notifID, int userID)
        {
            try
            {
                var valid = db.TblValidations.Find(userID, notifID);
                valid.Accepted = true;
                db.Entry(valid).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

    }
}
