using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BTask
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetMyTasks(int userID)
        {
            var today = DateTime.Now;
            var tasks = db.TblTasks.Where(x => x.DayOfWeek == (int)today.DayOfWeek && x.UserFK == userID);
            if (tasks.Count() == 0) { return null; }
            return tasks;
        }

        public static Object GetTasks(int userID, int dayofweek)
        {
            var tasks = db.TblTasks.Where(x => x.DayOfWeek == dayofweek && x.UserFK == userID);
            if (tasks.Count() == 0) { return null; }
            return tasks;
        }

        public static Object GetRealizations(int taskID)
        {
            var realizations = db.TblDone.Where(x => x.TaskFK == taskID);
            if (realizations.Count() == 0) { return null; }
            return realizations;
        }

        public static Boolean CreateTask(TblTasks task)
        {
            try
            {
                db.TblTasks.Add(task);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditTask(TblTasks task)
        {
            try
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Object DoneTask(int taskID, int userID)
        {
            try
            {
                if (db.TblTasks.Any(x => x.ID == taskID && x.UserFK == userID))
                {
                    db.TblDone.Add(new TblDone { Hour = DateTime.Now, TaskFK = taskID });
                    db.SaveChanges();
                    return new { result = false, info = "Não autorizado." };
                }
                return new { result = true };
            }
            catch (Exception) { return new { result = false, info = "Não foi possivel registar a realização." }; }
        }
    }
}
