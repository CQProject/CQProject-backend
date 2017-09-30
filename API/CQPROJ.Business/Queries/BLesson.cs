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
                    var schedules = db.TblSchedules.Where(x => x.ClassFK == classID && x.SubjectFK == subjectID).ToList();
                    var lessons = new List<TblLessons>();
                    foreach (var schedule in schedules)
                    {
                        lessons = lessons.Concat(db.TblLessons.Where(x => x.ScheduleFK == schedule.ID).ToList()).ToList();
                    }
                    if (lessons.Count() == 0) { return null; }
                    return lessons;
                }
            }
            catch (Exception) { return null; }
        }


        public static TblLessonStudents GetLessonToStudent(int lessonID, int studentID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblLessonStudents.Find(lessonID, studentID);
                }
            }
            catch (Exception) { return null; }
        }

        public static List<TblLessonStudents> GetLessonToTeacher(int lessonID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var students = db.TblLessonStudents.Where(x => x.LessonFK == lessonID).ToList();
                    if (students.Count() == 0) { return null; }
                    return students;
                }
            }
            catch (Exception) { return null; }
        }

        public static List<TblLessonStudents> GetLessonToGuardian(int lessonID, int guardianID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var availableStudents = BParenting.GetChildren(guardianID);
                    List<TblLessonStudents> students = new List<TblLessonStudents>();
                    availableStudents.ForEach(studentID =>
                    {
                        var aux = db.TblLessonStudents.Where(x => x.LessonFK == lessonID && x.StudentFK == studentID).FirstOrDefault();
                        if (aux != null)
                        {
                            students.Add(aux);
                        }
                    });
                    if (students.Count() == 0) { return null; }
                    return students;
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateLesson(TblLessons lesson,int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblLessons.Add(lesson);
                    db.SaveChanges();
                    
                        var schedule = db.TblSchedules.Find(lesson.ScheduleFK);
                    var clas = db.TblClasses.Find(schedule.ClassFK);
                    BAction.SetActionToUser(String.Format("Adicionou uma lição à disciplina '{0}' da turma '{1}' da escola '{2}'", db.TblSubjects.Find(schedule.SubjectFK).Name, clas.Year +clas.ClassDesc ,db.TblSchools.Find(clas.SchoolFK).Name), userID);
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

        public static Boolean EditLesson(TblLessons lesson, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(lesson).State = EntityState.Modified;
                    db.SaveChanges();

                    var schedule = db.TblSchedules.Find(lesson.ScheduleFK);
                    var clas = db.TblClasses.Find(schedule.ClassFK);
                    BAction.SetActionToUser(String.Format("Editou a lição à disciplina '{0}' da turma '{1}' da escola '{2}'", db.TblSubjects.Find(schedule.SubjectFK).Name, clas.Year + clas.ClassDesc, db.TblSchools.Find(clas.SchoolFK).Name), userID);
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

        public static int GetClassbyLesson(TblLessonStudents lesson)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSchedules.Find(db.TblLessons.Find(lesson.LessonFK).ScheduleFK).ClassFK ?? default(int);
                }
            }
            catch (Exception) { return 0; }
        }
    }
}
