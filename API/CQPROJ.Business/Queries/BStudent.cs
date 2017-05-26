using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.EStudent;
using CQPROJ.Data.BD.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace CQPROJ.Business.Queries
{
    public class BStudent
    {
        private DBContextModel db = new DBContextModel();

        //public Object GetStudent(int id)
        //{
        //    var student = db.TblStudents
        //            .Select(x => new {
        //                Photo = x.Photo,
        //                DataOfBirth = x.DataOfBirth,
        //                ID =x.ID,
        //                TblActions = x.TblUsers.TblActions
        //                    .Select(y=>new {
        //                        Desc =y.Description,
        //                        hour = y.Hour
        //                    })
        //            })
        //            .Where(x => x.ID.Equals(id));
        //    return student;
        //}

        //public void CreateStudent(Student cs)
        //{
        //    var pass = new PasswordHasher();
        //    var passHashed = pass.HashPassword(cs.Password);
        //    var date = DateTime.Now;
        //    var dOfBirth = Convert.ToDateTime(cs.DateOfBirth);

        //    var guardianFK = db.TblGuardians.Select(x => x).Where(x => x.TblUsers.Name.Equals(cs.GuardianName)).Where(x => x.PhoneNumber == cs.PhoneNumber).FirstOrDefault();

        //    TblUsers user = new TblUsers { Name = cs.Name, Email = cs.Email, Password = passHashed, CreatedDate = date, IsActive = true };
        //    db.TblUsers.Add(user);

        //    TblStudents student = new TblStudents { DataOfBirth = dOfBirth, Photo = cs.Photo, UserFK = user.ID, GuardianFK = guardianFK.Id };
        //    db.TblStudents.Add(student);
        //    db.SaveChanges();
        //}
    }
}
