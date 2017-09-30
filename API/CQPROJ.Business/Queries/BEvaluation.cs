using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BEvaluation
    {
        public static Object GetEvaluationsbyClass(int classID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var eval = db.TblEvaluations.Where(x => x.ClassFK == classID).ToList();
                    if (eval.Count() == 0) { return null; }
                    return eval;
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static Object GetEvaluationsbyTeacher(int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var eval = db.TblEvaluations.Where(x => x.TeacherFK == teacherID).ToList();
                    if (eval.Count() == 0) { return null; }
                    return eval;
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static object GetGradeToStudent(int evaluationID, int studentID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblEvaluationStudents.Where(x => x.EvaluationFK == evaluationID && x.StudentFK == studentID).FirstOrDefault();
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static object GetGradesToGuardian(int evaluationID, int guardianID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var availableStudents = BParenting.GetChildren(guardianID);
                    List<TblEvaluationStudents> grades = new List<TblEvaluationStudents>();
                    availableStudents.ForEach(studentID =>
                    {
                        var grade = db.TblEvaluationStudents.Where(x => x.EvaluationFK == evaluationID && x.StudentFK == studentID).FirstOrDefault();
                        if (grade != null)
                        {
                            grades.Add(grade);
                        }
                    });
                    if (grades.Count() == 0) { return null; }
                    return grades;
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static object GetGradesToTeacher(int evaluationID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var grades = db.TblEvaluationStudents.Where(x => x.EvaluationFK == evaluationID).ToList();
                    if (grades.Count() == 0) { return null; }
                    return grades;
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static Boolean CreateEvaluation(TblEvaluations evaluation)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblEvaluations.Add(evaluation);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditEvaluation(TblEvaluations evaluation)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(evaluation).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static int CreateGrade(TblEvaluationStudents grade)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    if(db.TblUserRoles.Any(x=>x.UserFK==grade.StudentFK && x.RoleFK == 1))
                    {
                        if(db.TblClassUsers.Any(x=>x.ClassFK== db.TblClasses.Find(db.TblEvaluations.Find(grade.EvaluationFK).ClassFK).ID && x.UserFK == grade.StudentFK))
                        {
                            db.TblEvaluationStudents.Add(grade);
                            db.SaveChanges();
                            return 3;
                        }
                        return 2;
                    }
                    return 1;
                }
            }
            catch (Exception) { return 0; }
        }

        public static Boolean EditGrade(TblEvaluationStudents grade)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(grade).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool VerifyTeacher(int evaluationID, int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblEvaluations.Any(x=> x.TeacherFK == teacherID && x.ID==evaluationID);
                }
            }
            catch (Exception) { return false; }
        }
    }
}
