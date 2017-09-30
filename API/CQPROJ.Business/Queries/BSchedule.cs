using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;


namespace CQPROJ.Business.Queries
{
    public class BSchedule
    {
        public static Object GetScheduleByTeacher(int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.TeacherFK == teacherID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.ClassFK == classID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByRoom(int roomID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.Where(x => x.RoomFK == roomID).ToList();
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
                }
            }
            catch (Exception) { return null; }
        }

        public static TblSchedules GetSchedule(int scheduleID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSchedules.Find(scheduleID);
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateSchedule(TblSchedules schedule)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSchedules.Add(schedule);
                    db.SaveChanges();
                   
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditSchedule(TblSchedules schedule,int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(schedule).State = EntityState.Modified;
                    db.SaveChanges();

                    var clas = db.TblClasses.Find(schedule.ClassFK);
                    BAction.SetActionToUser(String.Format("Editou o horário de uma aula da turma '{0}'", clas.Year+clas.ClassDesc), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteSchedule(int scheduleid, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedule = db.TblSchedules.Find(scheduleid);
                    db.TblSchedules.Remove(schedule);
                    db.SaveChanges();

                    var clas = db.TblClasses.Find(schedule.ClassFK);
                    BAction.SetActionToUser(String.Format("Removeu o horário de uma aula da turma '{0}'", clas.Year + clas.ClassDesc), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
