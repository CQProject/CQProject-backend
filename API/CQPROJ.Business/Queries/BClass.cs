
using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
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
            return db.TblClassUsers.Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 2)).Select(x=>x.UserFK).ToList();
            
        }

        public static Object GetStudentsByClass(int classID)
        {
            return db.TblClassUsers.Where(x => x.ClassFK == classID && db.TblUserRoles.Any(y => y.UserFK == x.UserFK && y.RoleFK == 1)).Select(x => x.UserFK).ToList();

        }
    }
}
