using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BTask
    {
        public static Object GetMyTasks(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var today = DateTime.Now;
                    var tasks = db.TblTasks.Where(x => x.DayOfWeek == (int)today.DayOfWeek && x.UserFK == userID).ToList();
                    if (tasks.Count() == 0) { return null; }
                    return tasks;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetTasks(int userID, int dayofweek)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var tasks = db.TblTasks.Where(x => x.DayOfWeek == dayofweek && x.UserFK == userID).ToList();
                    if (tasks.Count() == 0) { return null; }
                    return tasks;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetRealizations(int taskID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var realizations = db.TblDone.Where(x => x.TaskFK == taskID).ToList();
                    if (realizations.Count() == 0) { return null; }
                    return realizations;
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateTask(TblTasks task, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblTasks.Add(task);
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Criou a tarefa '{0}' ao utilizador '{1}'", task.Description, db.TblUsers.Find(task.UserFK).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditTask(TblTasks task, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Editou a tarefa '{0}' ao utilizador '{1}'", task.Description, db.TblUsers.Find(task.UserFK).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Object DoneTask(int taskID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    if (db.TblTasks.Any(x => x.ID == taskID && x.UserFK == userID))
                    {
                        db.TblDone.Add(new TblDone { Hour = DateTime.Now, TaskFK = taskID });
                        db.SaveChanges();
                        return new { result = false, info = "Não autorizado." };
                    }

                    BAction.SetActionToUser(String.Format("Realizou a tarefa '{0}'", db.TblTasks.Find(taskID).Description), userID);
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possivel registar a realização." }; }
        }

        public static bool DeleteTask(int taskid)
        {
            throw new NotImplementedException();
        }
    }
}
