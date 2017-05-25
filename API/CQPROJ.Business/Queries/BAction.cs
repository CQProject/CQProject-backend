using CQPROJ.Data.BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BAction
    {
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetActions()
        {
            var sec = db.TblActions.Select(x => new { x.ID, x.Hour,  x.Description, x.UserFK , x.TblUsers.Name, x.TblUsers.Email, x.TblUsers.Function });
            return sec;
        }

        public Object GetAction(int id)
        {
            var action = db.TblActions.Select(x => new { x.ID, x.Hour, x.Description, x.UserFK, x.TblUsers.Name, x.TblUsers.Email, x.TblUsers.Function }).Where(x => x.ID == id).FirstOrDefault();
            return action;
        }

        public Object GetActionSecretary(int id)
        {
            try
            {
                var secID = db.TblSecretaries.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                var sec = db.TblActions.Select(x => new { x.ID, x.Hour, x.Description, x.UserFK, x.TblUsers.Name, x.TblUsers.Email }).Where(x => x.UserFK == secID.UserFK).FirstOrDefault();
                return sec;
            }
            catch (Exception)
            {
                return "[]";
            }
        }

        public Object GetActionStudent(int id)
        {
            try
            {
                var studID = db.TblStudents.Select(x => x).Where(x => x.ID == id).FirstOrDefault();
                var stud = db.TblActions.Select(x => new { x.ID, x.Hour, x.Description, x.UserFK, x.TblUsers.Name, x.TblUsers.Email }).Where(x => x.UserFK == studID.UserFK).FirstOrDefault();
                return stud;

            }
            catch (Exception)
            {
                return "[]";
            }
        }
    }
}
