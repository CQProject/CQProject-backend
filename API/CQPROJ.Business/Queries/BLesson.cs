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
        private static DBContextModel db = new DBContextModel();

        public static Object GetAllLessonsBySchedule(int id)
        {

            var lessons = db.TblLessons.Select(x => x).Where(x => x.ScheduleFK == id);

           var toSend = new List<Object>();
            foreach (var lesson in lessons)
            {
                toSend.Add(new
                {
                    ID = lesson.ID,
                    Day = lesson.Day,
                    Homework = lesson.Homework,
                    Observations = lesson.Observations,
                    Summary = lesson.Summary
                });
            }
            return toSend;

        }

        public static Object GetAllLessonsByTeacher(int teacherID)
        {
            var schedules = db.TblSchedules.Select(x => x).Where(x => x.TeacherFK == teacherID);

            var toSend = new List<Object>();
            foreach (var schedule in schedules)
            {
                var les = db.TblLessons.Find(schedule.ID);

                toSend.Add(new
                {
                    ID = les.ID,
                    Day = les.Day,
                    Homework = les.Homework,
                    Observations = les.Observations,
                    Summary = les.Summary
                });
            }
            return toSend;

        }

        public static Object GetAllLessons(int pageID)
        {
            List<TblLessons> lessons;
            try
            {
                lessons = db.TblLessons.Select(x => x).OrderBy(x => x.ID).Skip(50 * pageID).Take(50).ToList();
            }
            catch (Exception)
            {
                lessons = db.TblLessons.Select(x => x).OrderBy(x => x.ID).Skip(50 * pageID).ToList();
            }

            var toSend = new List<Object>();
            foreach (var lesson in lessons)
            {
                toSend.Add(new
                {
                    ID = lesson.ID,
                    Day = lesson.Day,
                    Homework = lesson.Homework,
                    Observations = lesson.Observations,
                    Summary = lesson.Summary
                });
            }
            return toSend;

        }

        public static Object GetLessonProfile(int id)
        {

            var lesson = db.TblLessons.Find(id);

            return new
            {
                ID = lesson.ID,
                Observations = lesson.Observations,
                Summary = lesson.Summary
            };

        }

        /**************************************NOT SURE**************************************************/
        public static void CreateLesson(Lesson lesson)
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
