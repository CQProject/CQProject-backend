
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


        public static Object GetClassesByUser(int userID)
        {
            return db.TblClassUsers.Where(x => x.UserFK == userID).Select(x => x.ClassFK).ToList();
        }

        public static Object GetTeachersByClass(int classID)
        {
            return db.TblClassUsers.Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 2)).Select(x => x.UserFK).ToList();
        }

        public static Object GetStudentsByClass(int classID)
        {
            return db.TblClassUsers.Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 1)).Select(x => x.UserFK).ToList();
        }

        public static Object GetClassesBySchool(int schoolID)
        {
            return db.TblClasses.Where(x => x.SchoolFK == schoolID).ToList();
        }

        public static Object GetClassProfile(int classID)
        {
            return db.TblClasses.Where(x => x.ID == classID).ToList();
        }

        public static Boolean CreateClass(TblClasses new_class)
        {
            try
            {
                db.TblClasses.Add(new_class);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean EditClass(int id, TblClasses new_class)
        {
            try
            {
                TblClasses alteredclass = db.TblClasses.Find(id);
                if (alteredclass == null)
                {
                    return false;
                }
                db.Entry(alteredclass).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
