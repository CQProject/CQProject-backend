using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQPROJ.Data.BD.Models;

namespace CQPROJ.Business
{
    public class School
    {
        private ModelsDbContext db = new ModelsDbContext();

        public IEnumerable<TblSchoolLayout> GetSchool()
        {
            var school = from oneSchool in db.TblSchoolLayout select oneSchool;
            return school;
        }
    }
}
