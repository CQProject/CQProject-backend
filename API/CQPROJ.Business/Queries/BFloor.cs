using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BFloor
    {
        private static DBContextModel db = new DBContextModel();

        public static Object GetFloorsBySchool(int schoolID)
        {
            try
            {
                var floors = db.TblFloors.Where(x => x.SchoolFK == schoolID);
                if (floors.Count() == 0) { return null; }
                return floors;
            }
            catch (Exception) { return null; }
        }

        public static Object GetFloor(int floorID)
        {
            try
            {
                return db.TblFloors.Find(floorID);
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateFloor(TblFloors floor)
        {
            try
            {
                db.TblFloors.Add(floor);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditFloor(TblFloors floor)
        {
            try
            {
                db.Entry(floor).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
