using System.Collections.Generic;
using System.Linq;
using System;
using CQPROJ.Data.DB.Models;
using System.Data.Entity;

namespace CQPROJ.Business.Queries
{
    public class BSchool
    {
        public static Object GetSchools()
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return new { result = true, data = db.TblSchools };
                }
            }
            catch (Exception) { return new { result = true, info = "Não foram encontradas escolas" }; }
        }

        public static Object GetSchool(int schoolID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return new { result = true, data = db.TblSchools.Find(schoolID) };
                }
            }
            catch (Exception) { return new { result = false, info = "Escola não encontrada." }; }
        }

        public static Boolean CreateSchool(TblSchools school)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSchools.Add(school);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditSchool(TblSchools school)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.Entry(school).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
