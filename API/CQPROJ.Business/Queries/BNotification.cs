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
            try
            {
                var notifications = db.TblNotifications
                    .Where(x => x.UserFK == userID)
                    .OrderByDescending(x => x.ID)
                    .Skip(50 * pageID)
                    .Take(50);
                if (notifications.Count() == 0) { return null; }
                return notifications;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int GetUnreadCount(int userID)
        {
            try
            {
                return db.TblValidations.Where(x => x.ReceiverFK == userID && x.Read == false).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Object GetReceivedNotifications(int pageID, int userID)
        {
            try
            {
                var validations = db.TblValidations
                    .Where(x => x.ReceiverFK == userID)
                    .OrderByDescending(x => x.NotificationFK)
                    .Skip(50 * pageID)
                    .Take(50);
                if (validations.Count() == 0) { return null; }
                return validations;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Object GetValidationsByNotification(int notifID)
        {
            try
            {
                var validations = db.TblValidations
                    .Where(x => x.NotificationFK == notifID);
                if (validations.Count() == 0) { return null; }
                return validations;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Object GetNotification(int notifID)
        {
            try
            {
                return db.TblNotifications.Find(notifID);
            }
            catch (Exception) { return null; }
        }

        public static Boolean SendNotificationToUser(NotificationUser notification)
        {
            try
            {
                TblNotifications notif = new TblNotifications
                {
                    Description = notification.Description,
                    Hour = DateTime.Now,
                    Subject = notification.Subject,
                    Urgency = notification.Urgency,
                    Approval = notification.Approval,
                    UserFK = notification.SenderFK
                };
                db.TblNotifications.Add(notif);
                db.SaveChanges();

                TblValidations valid = new TblValidations
                {
                    ReceiverFK = notification.ReceiverFK,
                    Accepted = false,
                    Read = false
                };
                db.TblValidations.Add(valid);
                db.SaveChanges();

                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean SendNotificationToClass(NotificationClass notification)
        {
            try
            {
                TblNotifications notif = new TblNotifications
                {
                    Description = notification.Description,
                    Hour = DateTime.Now,
                    Subject = notification.Subject,
                    Urgency = notification.Urgency,
                    Approval= notification.Approval,
                    UserFK = notification.SenderFK
                };
                db.TblNotifications.Add(notif);
                db.SaveChanges();

                var students = BClass.GetStudentsByClass(notification.ClassFK);
                foreach(var student in students)
                {
                    TblValidations valid = new TblValidations
                    {
                        ReceiverFK = BParenting.GetGuardians(student).FirstOrDefault(),
                        StudentFK = student,
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
                var valid = db.TblValidations.Find(userID, notifID);
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
