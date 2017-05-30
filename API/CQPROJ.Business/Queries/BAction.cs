using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BAction
    {
        private DBContextModel db = new DBContextModel();

        public Object GetActions()
        {
            var actions = db.TblActions
                 .Select(x => new { x.ID, x.Hour, x.Description, UserId =  x.UserFK });
            return actions;
        }

        /*
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
                if (sec != null)
                {
                    return sec;
                }
                else
                {
                    return "[]";
                }
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
                if (stud != null)
                {
                    return stud;
                }
                else
                {
                    return "[]";
                }

            }
            catch (Exception)
            {
                return "[]";
            }
        }

        /*public Object GetActionAssistant(int id)
        {
            try
            {
                var assistID = db.TblSchAssistants.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
                var assist = db.TblActions.Select(x => new { x.ID, x.Hour, x.Description, x.UserFK, x.TblUsers.Name, x.TblUsers.Email }).Where(x => x.UserFK == assistID.UserFK).FirstOrDefault();
                if (assist != null)
                {
                    return assist;
                }else
                {
                    return "[]";
                }

            }
            catch (Exception)
            {
                return "[]";
            }
        }*/
    }
}
