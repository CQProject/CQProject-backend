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
                    if (eval.Count() == 0) {
                        return new { result = false, info = "Não existem avaliações para esta turma." };
                    }
                    return new { result = true, data = eval };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foram encontradas avaliações para esta turma." }; }
        }

        public static Object GetEvaluationsbyTeacher(int teacherID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var eval = db.TblEvaluations.Where(x => x.TeacherFK == teacherID).ToList();
                    if (eval.Count() == 0) {
                        return new { result = false, info = "Não existem avaliações do professor." };
                    }
                    return new { result = true, data = eval };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foram encontradas avaliações do professor." }; }
        }

        public static object GetGradeToStudent(int evaluationID, int studentID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return new { result = true, data = db.TblEvaluationStudents.Where(x => x.EvaluationFK == evaluationID && x.StudentFK == studentID).FirstOrDefault() };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foi encontrada avaliação." }; }
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
                    if (grades.Count() == 0) {
                        return new { result = false, info = "Não existe avaliação." };
                    }
                    return new { result = true, data = grades };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foi encontrada avaliação." }; }
        }

        public static object GetGradesToTeacher(int evaluationID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var grades = db.TblEvaluationStudents.Where(x => x.EvaluationFK == evaluationID).ToList();
                    if (grades.Count() == 0) {
                        return new { result = false, info = "Não existe avaliação." };
                    }
                    return new { result = true, data = grades };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Não foi encontrada avaliação." }; }
        }

        public static Object CreateEvaluation(TblEvaluations evaluation, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblEvaluations.Add(evaluation);
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(evaluation.ClassFK);
                    BAction.SetActionToUser(String.Format("Adicionou uma avaliação na turma '{0}' da escola '{1}'", cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível registar a avaliação" }; }
        }

        public static Object EditEvaluation(TblEvaluations evaluation, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(evaluation).State = EntityState.Modified;
                    db.SaveChanges();

                    var cla = db.TblClasses.Find(evaluation.ClassFK);
                    BAction.SetActionToUser(String.Format("Editou uma avaliação na turma '{0}' da escola '{1}'", cla.Year + cla.ClassDesc, db.TblSchools.Find(cla.SchoolFK).Name), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível alterar a avaliação" }; }
        }

        public static Object CreateGrade(TblEvaluationStudents grade)
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
                            return new { result = true };
                        }
                        return new { result = false, info = "O aluno associado à avaliação não pertence à turma." };
                    }
                    return new { result = false, info = "O utilizador associado à avaliação não é uma aluno." };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível atribuir a nota." }; }
        }

        public static Object EditGrade(TblEvaluationStudents grade)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(grade).State = EntityState.Modified;
                    db.SaveChanges();
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível alterar a nota da avaliação" }; }
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
