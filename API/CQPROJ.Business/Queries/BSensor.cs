using CQPROJ.Data.DB.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BSensor
    {
        public static Object GetSensorsByRoom(int roomID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensors = db.TblSensors.Where(x => x.RoomFK == roomID).ToList();
                    if (sensors.Count() == 0) { return null; }
                    return sensors;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetSensorLastValue(int sensorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensor = db.TblRecords.Where(x => x.SensorFK == sensorID).OrderByDescending(x => x.ID).FirstOrDefault();
                    if (sensor.Hour == null) { return null; }
                    return sensor;
                }
            }
            catch (Exception) { return null; }
        }

        public static object GetSensorHistoric(int sensorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensors = db.TblRecords.Where(x => x.SensorFK == sensorID).OrderByDescending(x => x.ID).Take(60).ToList();
                    if (sensors.Count() == 0) { return null; }
                    return sensors;
                }
            }
            catch (Exception) { return null; }
        }

        public static object GetSensorResume(int sensorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensors = db.TblRecords.Where(x => x.SensorFK == sensorID).OrderByDescending(x => x.ID).Take(60).ToList();
                    if (sensors.Count() == 0) { return null; }

                    return new
                    {
                        LuminosityAVG = Math.Round((float)(sensors.Sum(x => x.Luminosity) / 60), 2),
                        TemperatureAVG = Math.Round((float)(sensors.Sum(x => x.Temperature) / 60), 2),
                        EnergyAVG = Math.Round((float)(sensors.Sum(x => x.Energy) / 60), 2),
                        HumidityAVG = Math.Round((float)(sensors.Sum(x => x.Humidity) / 60), 2),
                    };
                }
            }
            catch (Exception) { return null; }
        }

        public static Boolean CreateSesnor(TblSensors sensor)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblSensors.Add(sensor);
                    db.SaveChanges();
                    var room = db.TblRooms.Find(sensor.RoomFK);
                    room.HasSensor = true;
                    db.Entry(room).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean EditSesnor(TblSensors sensor)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var old= db.TblSensors.Find(sensor.ID);
                    if (old.RoomFK != sensor.RoomFK)
                    {
                        var oldroom = db.TblRooms.Find(old.RoomFK);
                        if(db.TblSensors.Where(x=>x.RoomFK== oldroom.ID).Count() <= 1)
                        {
                            oldroom.HasSensor = false;
                            db.Entry(oldroom).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        var room = db.TblRooms.Find(sensor.RoomFK);
                        room.HasSensor = true;
                        db.Entry(room).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    db.Entry(sensor).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean RemoveSensor(int sensorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensor = db.TblSensors.Find(sensorID);
                    var room = db.TblRooms.Find(sensor.RoomFK);
                    if (db.TblSensors.Where(x => x.RoomFK == room.ID).Count() <= 1)
                    {
                        room.HasSensor = false;
                        db.Entry(room).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    db.TblSensors.Remove(sensor);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
