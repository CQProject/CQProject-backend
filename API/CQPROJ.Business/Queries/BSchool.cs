using System.Collections.Generic;
using System.Linq;
using System;
using CQPROJ.Data.DB.Models;

namespace CQPROJ.Business.Queries
{
    public class BSchool
    {
        private DBContextModel db = new DBContextModel();

        public Object GetSchoolHome()
        {
            var schoolHome = db.TblSchools.Select(s => new { s.Name, s.Logo, s.ProfilePicture, s.Acronym }).FirstOrDefault();
            return schoolHome;
        }
    }
}
