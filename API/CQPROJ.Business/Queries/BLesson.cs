using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BLesson
    {
        public static Object GetLessonsBySubject(int subjectID, int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var schedules = db.TblSchedules.ToList().Where(x => x.ClassFK == classID && x.SubjectFK == subjectID);
                    var lessons = new List<TblLessons>();
                    foreach (var schedule in schedules)
                    {
                        lessons.Concat(db.TblLessons.Where(x => x.ScheduleFK == schedule.ID));
                    }
                    if (lessons.Count() == 0) { return null; }
                    return lessons;
                }
            }
            catch (Exception) { return null; }
        }


        public static Object GetLessonToStudent(int lessonID, int studentID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var lesson = db.TblLessons.Find(lessonID);
                    var lessonUser = db.TblLessonStudents.Find(lessonID, studentID);
                    return new
                    {
                        ID = lesson.ID,
                        Day = lesson.Day,
                        Summary = lesson.Summary,
                        Observations = lesson.Observations,
                        Homework = lesson.Homework,
                        Presence = lessonUser.Presence,
                        Behavior = lessonUser.Behavior,
                        Material = lessonUser.Material,
                        ScheduleFK = lesson.ScheduleFK
                    };
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetLessonToTeacher(int lessonID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var lesson = db.TblLessons.Find(lessonID);
                    var lessonUser = db.TblLessonStudents.ToList().Where(x => x.LessonFK == lessonID);
                    return new
                    {
                        lesson = lesson,
                        students = lessonUser
                    };
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateLesson(TblLessons lesson)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblLessons.Add(lesson);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean RegisterFaults(TblLessonStudents lesson)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblLessonStudents.Add(lesson);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditLesson(TblLessons lesson)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(lesson).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditFaults(TblLessonStudents lesson)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(lesson).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean VerifyTeacher(TblLessons lesson, int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSchedules.Find(lesson.ScheduleFK).TeacherFK == teacherID ? true : false;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean VerifyTeacher(TblLessonStudents lesson, int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSchedules.Find(db.TblLessons.Find(lesson.LessonFK).ScheduleFK).TeacherFK == teacherID ? true : false;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
