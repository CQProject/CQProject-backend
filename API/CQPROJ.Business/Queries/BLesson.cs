using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BLesson
    {
        private DBContextModel db = new DBContextModel();

        public Object GetTeacherLesson(int id)
        {

            var lesson = db.TblLessons.Find(id);

            if (lesson == null)
            {
                return new { Result = "Failed" };
            }

            return new
            {
                Id = lesson.ID,
                Day = lesson.Day,
                Homework = lesson.Homework,
                Observations = lesson.Observations,
                Summary = lesson.Summary
            };

        }

        /**************************************NOT SURE**************************************************/
        public void CreateLesson(Lesson lesson)
        {

            TblLessons les = new TblLessons
            {
                Day = lesson.Day,
                Homework = lesson.Homework,
                Observations = lesson.Observations,
                Summary = lesson.Summary,
                ScheduleFK = lesson.ScheduleFK

            };

            db.TblLessons.Add(les);
            db.SaveChanges();
        }
    }
}
