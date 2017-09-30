using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BSubject
    {
        public static Object GetSubject(int subjectID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSubjects.Find(subjectID);
                }
            }
            catch (Exception) { return null; }
        }

        public static object GetSubjectList()
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblSubjects.ToList();
                }
            }
            catch (Exception) { return null; }
        }

        public static bool CreateSubject(TblSubjects subject)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSubjects.Add(subject);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool EditSubject(TblSubjects subject)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(subject).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static bool DeleteSubject(int subjectid)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var subject = db.TblSubjects.Find(subjectid);
                    db.TblSubjects.Remove(subject);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
