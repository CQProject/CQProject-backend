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

        public static Object GetAllLessonsByStudent(int LessonID, int studentID)
        {
            try
            {
                var lessons = db.TblLessonStudents.Find(LessonID, studentID);

                return lessons;
            }
            catch (Exception)
            {
                return null;
            }

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

        public static Object EditLesson(int id,Lesson lesson)
        {
            try
            {
                var lessonFind = db.TblLessons.Find(id);

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

                return new { result = true };
            }
            catch (Exception)
            {
                return new { result = false, data = "Lição não encontrada" };
            }
        }
    }
}
