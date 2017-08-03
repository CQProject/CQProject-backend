
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

        //public Object GetClasses()
        //{
        //    //It is necessary to filter by the Current Year
        //    var classes = db.TblClasses.Select(x => new { x.ID, x.SchoolYear, x.Year, x.ClassDesc });

        //    return classes;
        //}

        //public Object GetClass(int id)
        //{
        //    var classes = db.TblClasses.Select(x => new { x.ID, x.SchoolYear, x.Year, x.ClassDesc }).Where(x => x.ID == id).FirstOrDefault();
        //    var students = db.TblStudents.Select(s => new { s.ID, s.UserFK });
        //    var schedules = db.TblSchedules.Select(y => new { y.ID, y.ClassFK, y.TeacherFK, y.Subject, y.StartingTime, y.EndingTime }).Where(y=>y.ClassFK==classes.ID);
        //    var listStds = new List<Object>();
        //    var listSche = new List<Object>();
        //    var toSend = new List<Object>();

        //    foreach(var stud in students)
        //    {
        //        var user = db.TblUsers.Select(x => new { x.ID, x.Name }).Where(x => x.ID == stud.UserFK).FirstOrDefault();
        //        var cs = db.TblClassStudents.Select(c => new { c.ClassFK, c.StudentFK }).Where(c => c.StudentFK == stud.ID).Where(c => c.ClassFK == classes.ID);
        //        listStds.Add(new {
        //            StudId = stud.ID,
        //            StudName = user.Name
        //        });
        //    }
        //    foreach(var sche in schedules)
        //    {
        //        var teacher = db.TblTeachers.Select(x => new { x.ID, x.UserFK }).Where(x => x.ID == sche.TeacherFK).FirstOrDefault();
        //        var user = db.TblUsers.Select(y => new { y.ID, y.Name }).Where(y => y.ID == teacher.UserFK).FirstOrDefault();
        //        listSche.Add(new {
        //            Schedule = sche.ID,
        //        });
        //    }

        //    toSend.Add(new {
        //        Id = classes.ID,
        //        SchoolYear = classes.SchoolYear,
        //        ClassDesc = classes.ClassDesc,
        //        Students = listStds,
        //        Schedules = listSche
        //    });

        //    return toSend;
        //}


        public Object GetClassesByTeacher(int id)
        {

            var classes = db.TblClassUsers.Select(x => x).Where(x => x.UserFK == id);

            var toSend = new List<Object>();

            foreach (var clas in classes)
            {
                var classInfo = db.TblClasses.Find(clas.ClassFK);

                toSend.Add(new
                {
                    ID = clas.ClassFK,
                    Year = classInfo.Year,
                    ClassDesc = classInfo.ClassDesc,
                });
            }
            return toSend;

        }
    }
}
