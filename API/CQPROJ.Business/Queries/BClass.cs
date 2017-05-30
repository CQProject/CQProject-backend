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
        private DBContextModel db = new DBContextModel();

        public Object GetClasses()
        {
            //It is necessary to filter by the Current Year
            var classes = db.TblClasses.Select(x => new { x.ID, x.SchoolYear, x.Year, x.ClassDesc });
            
            return classes;
        }

        public Object GetClass(int id)
        {
            var classes = db.TblClasses.Select(x => new { x.ID, x.SchoolYear, x.Year, x.ClassDesc }).Where(x => x.ID == id);
            return classes;
        }
    }
}
