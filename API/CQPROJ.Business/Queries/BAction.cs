//using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BAction
    {
        //private DBContextModel db = new DBContextModel();

        //public Object GetActions()
        //{
        //    var actions = db.TblActions
        //         .Select(x => new { x.ID, x.Hour, x.Description, UserId =  x.UserFK });
        //    return actions;
        //}

        //public Object GetAction(int id)
        //{
        //    try
        //    {
        //        var action = db.TblActions.Select(x => new { x.ID, x.Hour, x.Description, x.UserFK }).Where(x => x.ID == id).FirstOrDefault();
        //        var user = db.TblUsers.Select(y => new { y.ID, y.Name, y.Email, y.Function }).Where(x => x.ID == action.ID).FirstOrDefault();
        //        return new
        //        {
        //            Id = action.ID,
        //            ExecutionHour = action.Hour,
        //            Description = action.Description,
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new {  };
        //    }
        //}
    }
}
