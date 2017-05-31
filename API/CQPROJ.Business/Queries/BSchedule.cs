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

        public Object GetSchedule(int id)
        {
            try
            {
                var schedule = db.TblSchedules
                                .Select(x => new { x.ID, x.ClassFK, x.DayOfTheWeek, x.EndingTime, x.StartingTime, x.Subject, x.TeacherFK })
                                .FirstOrDefault();
                var claxx = db.TblClasses.Select(x => new { x.ID, x.ClassDesc, x.Year })
                            .Where(x => x.ID == schedule.ClassFK)
                            .FirstOrDefault();
                var teacher = db.TblTeachers.Select(x => new { x.ID, x.UserFK })
                                .Where(x => x.ID == schedule.TeacherFK)
                                .FirstOrDefault();
                var userTeacher = db.TblUsers.Select(x => new { x.ID, x.Name })
                                    .Where(x => x.ID == teacher.UserFK)
                                    .FirstOrDefault();
                return new
                {
                    Id = schedule.ID,
                    Subject = schedule.Subject,
                    DayOfWeek = schedule.DayOfTheWeek,
                    StartingTime = schedule.StartingTime,
                    EndingTime = schedule.EndingTime,
                    TeacherID = teacher.ID,
                    TeacherName = userTeacher.Name,
                    ClassID = claxx.ID,
                    ClassYearDesc = claxx.Year +" "+claxx.ClassDesc
                };
            }
            catch (Exception)
            {
                return new { };
            }
        }

        public Object EditSchedule(int id, Schedule schedule)
        {
            return null;
        }
    }
}
