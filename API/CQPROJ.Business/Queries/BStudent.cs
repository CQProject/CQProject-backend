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
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetStudent(int id)
        {
            var stud = db.TblStudents.Select(x => x).Where(x => x.ID.Equals(id));
            var student = stud.Select(x => new { x.Photo, x.DataOfBirth });
            return student;
        }

        public void PostStudent(Student cs) {
            var pass = new PasswordHasher();
            var password = pass.HashPassword(cs.Password);

            var guardianFK = db.TblGuardians.Select(x => x).Where(x => x.TblUsers.Name.Equals(cs.GuardianName)).Where(x => x.PhoneNumber == cs.PhoneNumber).FirstOrDefault();

            TblUsers user = new TblUsers { Name = cs.Name, Email = cs.Email, CreatedDate = DateTime.Now, IsActive = true, Password = password };
            db.TblUsers.Add(user);

            

            TblStudents student = new TblStudents { DataOfBirth = cs.DateOfBirth, Photo = cs.Photo, UserFK = user.ID, GuardianFK = guardianFK.Id };
            db.TblStudents.Add(student);
            db.SaveChanges();
        }
    }
}
