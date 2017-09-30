using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BAction
    {
        public static Object GetPagesByUser(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return new
                    {
                        result = true,
                        data = Math.Ceiling((float)db.TblActions.Where(x => x.UserFK == userID).Count() / 50)
                    };
                }
            }
            catch (Exception) { return new { result = false, info = "Impossível carregar página." }; }
        }

        public static Object GetActionsbyUser(int userID, int pageID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    List<TblActions> actions = db.TblActions.Where(x => x.UserFK == userID).OrderByDescending(x => x.ID).Skip(50 * pageID).Take(50).ToList();
                    if (actions.Count() == 0) { return null; }
                    return new
                    {
                        result = true,
                        data = new
                        {
                            page = pageID,
                            info = actions
                        }
                    };
                }
            }
            catch (ArgumentException) { return new { result = false, info = "Impossível carregar página." }; }
        }

        public static Boolean SetActionToUser(String action, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblActions.Add(new TblActions { Description = action, Hour = DateTime.Now, UserFK = userID });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (ArgumentException) { return false; }
        }
    }
}
