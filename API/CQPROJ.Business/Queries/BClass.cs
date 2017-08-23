
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
    public class BClass
    {
        private static DBContextModel db = new DBContextModel();


        public static List<int> GetClassesByUser(int userID)
        {
            try
            {
                var classes = db.TblClassUsers.Where(x => x.UserFK == userID).Select(x => x.ClassFK).ToList();
                if (classes.Count() == 0) { return null; }
                return classes;
            }
            catch (Exception) { return null; }
        }

        public static List<int> GetTeachersByClass(int classID)
        {
            try
            {
                var classes = db.TblClassUsers
                    .Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 2))
                    .Select(x => x.UserFK).ToList();
                if (classes.Count() == 0) { return null; }
                return classes;
            }
            catch (Exception) { return null; }
        }

        public static List<int> GetStudentsByClass(int classID)
        {
            try
            {
                var students = db.TblClassUsers
                    .Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 1))
                    .Select(x => x.UserFK).ToList();
                if (students.Count() == 0) { return null; }
                return students;
            }
            catch (Exception) { return null; }
        }

        public static Object GetClassesBySchool(int schoolID)
        {
            try
            {
                var classes = db.TblClasses.Where(x => x.SchoolFK == schoolID).ToList();
                if (classes.Count() == 0) { return null; }
                return classes;
            }
            catch (Exception) { return null; }
        }

        public static Object GetClassProfile(int classID)
        {
            try
            {
                return db.TblClasses.Where(x => x.ID == classID).ToList();
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateClass(TblClasses newClass)
        {
            try
            {
                db.TblClasses.Add(newClass);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditClass(TblClasses alteredClass)
        {
            try
            {
                db.Entry(alteredClass).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean AddUser(int classID, int userID)
        {
            try
            {
                db.TblClassUsers.Add(new TblClassUsers { ClassFK = classID, UserFK = userID });
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static Boolean RemoveUser(int classID, int userID)
        {
            try
            {
                db.TblClassUsers.Remove(db.TblClassUsers.Find(classID, userID));
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public static Boolean HasUser(int classID, int userID)
        {
            return db.TblClassUsers.Any(x => x.UserFK == userID && x.ClassFK == classID);
        }
    }
}
