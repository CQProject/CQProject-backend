using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQPROJ.Data.DB.Models;
using System.Data.Entity;

namespace CQPROJ.Business.Queries
{
    public class BRoom
    {

        private static DBContextModel db = new DBContextModel();

        public static Object GetRoomsBySchool(int schoolID)
        {
            try
            {
                var floors = db.TblFloors.Where(y => y.SchoolFK == schoolID);
                List<TblRooms> rooms = new List<TblRooms>();
                foreach (var floor in floors)
                {
                    rooms.Concat(db.TblRooms.Where(x => x.FloorFK == floor.ID));
                }
                if (rooms.Count() == 0) { return null; }
                return rooms;
            }
            catch (Exception) { return null; }
        }

        public static Object GetRoomsByFloor(int floorID)
        {
            try
            {
                var rooms = db.TblRooms.Where(x => x.FloorFK == floorID);
                if (rooms.Count() == 0) { return null; }
                return rooms;
            }
            catch (Exception) { return null; }
        }

        public static Object GetRoom(int roomID)
        {
            try
            {
                return db.TblRooms.Find(roomID);
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateRoom(TblRooms room)
        {
            try
            {
                db.TblRooms.Add(room);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditRoom(TblRooms room)
        {
            try
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
