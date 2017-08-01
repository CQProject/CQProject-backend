using CQPROJ.Business.Entities;
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
        private DBContextModel db = new DBContextModel();

        public Object GetTeacherSchedule(int id)
        {
            var schedule = db.TblSchedules.Select(x => x).Where(x => x.TeacherFK == id);

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
