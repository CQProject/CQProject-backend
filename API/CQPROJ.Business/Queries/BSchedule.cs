using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.ISchedule;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BSchedule
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetTeacherSchedule(int teacherID)
        {
            var schedule = db.TblSchedules.Select(x => x).Where(x => x.TeacherFK == teacherID);

            var toSend = new List<Object>();
            foreach (var sched in schedule)
            {
                toSend.Add(new
                {
                    ID = sched.ID,
                    DayOfWeek = sched.DayOfWeek,
                    Duration = sched.Duration,
                    StartingTime = sched.StartingTime,
                    Subject = sched.Subject
                });
            }
            return toSend;
        }

        public static Object GetClassSchedule(int classFK)
        {
            var schedule = db.TblSchedules.Select(x => x).Where(x => x.ClassFK == classFK);

            var toSend = new List<Object>();
            foreach (var sched in schedule)
            {
                toSend.Add(new
                {
                    ID = sched.ID,
                    DayOfWeek = sched.DayOfWeek,
                    Duration = sched.Duration,
                    StartingTime = sched.StartingTime,
                    Subject = sched.Subject
                });
            }
            return toSend;
        }

        public static Object GetScheduleRoom(int roomFK)
        {
            var schedule = db.TblSchedules.Select(x => x).Where(x => x.RoomFK == roomFK);

            var toSend = new List<Object>();
            foreach (var sched in schedule)
            {
                toSend.Add(new
                {
                    ID = sched.ID,
                    DayOfWeek = sched.DayOfWeek,
                    Duration = sched.Duration,
                    StartingTime = sched.StartingTime,
                    Subject = sched.Subject
                });
            }
            return toSend;
        }

        public static void CreateSchedule(Schedule schedule)
        {
            TblSchedules sched = new TblSchedules
            {
                ClassFK = schedule.ClassFK,
                DayOfWeek = schedule.DayOfWeek,
                Duration = schedule.Duration,
                RoomFK = schedule.RoomFK,
                StartingTime = schedule.StartingTime,
                Subject = schedule.Subject,
                TeacherFK = schedule.TeacherFK
            };

            db.TblSchedules.Add(sched);
            db.SaveChanges();
        }

        public static bool VerifyTeacher(int teacherID,int lessonID)
        {
            var schedule = db.TblSchedules.Where(x => x.TeacherFK == teacherID).Select(x => x.ID);

            var lesson = db.TblLessons.Find(lessonID);

            if(schedule.Any(x=>x == lesson.ScheduleFK))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Object GetStudentSchedule(int id)
        //{

        //    var schedule = db.TblSchedules.Select(x => x).Where(x => x.ClassFK == id);

        //    var toSend = new List<Object>();
        //    foreach (var sched in schedule)
        //    {
        //        toSend.Add(new
        //        {
        //            ID = sched.ID,
        //            DayOfWeek = sched.DayOfWeek,
        //            Duration = sched.Duration,v
        //            StartingTime = sched.StartingTime,
        //            Subject = sched.Subject
        //        });
        //    }
        //    return toSend;
        //}
    }
}
