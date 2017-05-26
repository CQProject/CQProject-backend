using System.Collections.Generic;
using System.Linq;
using CQPROJ.Data.BD.Models;
using System;

namespace CQPROJ.Business.Queries
{
    public class BSchool
    {
        private DBContextModel db = new DBContextModel();

        //public Object GetSchoolHome()
        //{
        //    var schoolHome = db.TblSchoolLayout.Select(s => new { s.Name, s.Logo, s.ProfilePicture, s.Acronym }).FirstOrDefault();
        //    return schoolHome;
        //}

        //public Object GetSchoolAbout()
        //{
        //    var schoolAbout = db.TblSchoolLayout.FirstOrDefault();
        //    return schoolAbout;
        //}
    }
}
