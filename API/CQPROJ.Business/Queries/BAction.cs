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
        public static Object GetPagesByUser(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return Math.Ceiling((float)db.TblActions.Where(x => x.UserFK == userID).Count() / 50);
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetActionsbyUser(int userID, int pageID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    List<TblActions> actions = db.TblActions.Where(x => x.UserFK == userID).OrderByDescending(x => x.ID).Skip(50 * pageID).Take(50).ToList();
                    if (actions.Count() == 0) { return null; }
                    return actions;
                }
            }
            catch (ArgumentException) { return null; }
        }
    }
}
