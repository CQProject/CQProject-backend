using CQPROJ.Business.Entities;
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    var eval = db.TblEvaluations.Where(x => x.ClassFK == classID);
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
                    var eval = db.TblEvaluations.Where(x => x.TeacherFK == teacherID);
                    if (eval.Count() == 0) { return null; }
                    return eval;
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
    }
}
