using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
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
                    var schedules = db.TblSchedules.Select(x => x).Where(x => x.TeacherFK == teacherID);
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
                    var schedules = db.TblSchedules.Select(x => x).Where(x => x.ClassFK == classID);
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
                    var schedules = db.TblSchedules.Select(x => x).Where(x => x.RoomFK == roomID);
                    if (schedules.Count() == 0) { return null; }
                    return schedules;
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

        public static Boolean EditSchedule(TblSchedules schedule)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(schedule).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
