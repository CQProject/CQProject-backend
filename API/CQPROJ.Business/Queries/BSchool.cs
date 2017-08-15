using System.Collections.Generic;
using System.Linq;
using System;
using CQPROJ.Data.DB.Models;
using System.Data.Entity;

namespace CQPROJ.Business.Queries
{
    public class BSchool
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetSchools()
        {
            return new { result = true, data = db.TblSchools };
        }

        public static Object GetSchool(int schoolID)
        {
            try
            {
                return new { result = true, data = db.TblSchools.Find(schoolID) };
            }
            catch (Exception) { return new { result = false, info = "Escola não encontrada." }; }
        }

        public static Boolean CreateSchool(TblSchools school)
        {
            try
            {
                db.TblSchools.Add(school);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return  false; }
        }

        public static Boolean EditSchool(TblSchools school)
        {
            try
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
