using CQPROJ.Data.BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BTask
    {
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetTasks()
        {
            var tasks = db.TblTasks.Select(x => new {
                x.ID,
                x.Description,
                x.DayOfWeek,
                x.Hour,
                x.Weekly,
                Secretary = db.TblSecretaries.Select(y => new { y.Id, y.TblUsers.Name, y.TblUsers.Email}).Where( y=>y.Id==x.SecretaryFK),
                Assistant = db.TblSchAssistants.Select(z => new { z.Id, z.TblUsers.Name, z.TblUsers.Email }).Where(z => z.Id == x.SchAssistantFK)
            });
            return tasks;
        }

        public Object GetTask(int id)
        {
            var task = db.TblTasks.Select(x => new {
                x.ID,
                x.Description,
                x.DayOfWeek,
                x.Hour,
                x.Weekly,
                Secretary = db.TblSecretaries.Select(y => new { y.Id, y.TblUsers.Name, y.TblUsers.Email }).Where(y => y.Id == x.SecretaryFK),
                Assistant = db.TblSchAssistants.Select(z => new { z.Id, z.TblUsers.Name, z.TblUsers.Email }).Where(z => z.Id == x.SchAssistantFK)
            }).Where( x=>x.ID==id);

            return task;
        }

        //tasks por secretario ou tasks por assistant ?

        public void CreateTask()
        {

        }
    }
}
