using CQPROJ.Data.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BSensor
    {
        public static Object GetSensorsByFloor(int floorID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var sensors = db.TblSensors.Where(x => x.FloorFK == floorID);
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
                    var sensor = db.TblRecords.Where(x => x.SensorFK == sensorID).LastOrDefault();
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
                    var sensors = db.TblRecords.Where(x => x.SensorFK == sensorID).OrderByDescending(x => x.ID).Take(60);
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
                    var sensors = db.TblRecords.Where(x => x.SensorFK == sensorID).OrderByDescending(x => x.ID).Take(60);
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
                    db.TblSensors.Remove(db.TblSensors.Find(sensorID));
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
