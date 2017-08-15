using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BSchedule
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetScheduleByTeacher(int teacherID)
        {
            try
            {
                var schedules = db.TblSchedules.Select(x => x).Where(x => x.TeacherFK == teacherID);
                if (schedules.Count() == 0) { return null; }
                return schedules;
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByClass(int classID)
        {
            try
            {
                var schedules = db.TblSchedules.Select(x => x).Where(x => x.ClassFK == classID);
                if (schedules.Count() == 0) { return null; }
                return schedules;
            }
            catch (Exception) { return null; }
        }

        public static Object GetScheduleByRoom(int roomID)
        {
            try
            {
                var schedules = db.TblSchedules.Select(x => x).Where(x => x.RoomFK == roomID);
                if (schedules.Count() == 0) { return null; }
                return schedules;
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateSchedule(TblSchedules schedule)
        {
            try
            {
                db.TblSchedules.Add(schedule);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditSchedule(TblSchedules schedule)
        {
            try
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
