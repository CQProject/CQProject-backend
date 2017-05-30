using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.EStudent;
using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CQPROJ.Business.Queries
{
    public class BStudent
    {
        private DBContextModel db = new DBContextModel();

        public List<Object> GetStudents()
        {
            var students = db.TblStudents
                .Select(x => new { x.ID, x.Photo, x.UserFK });
            var toSend = new List<Object>();
            foreach (var sec in students)
            {
                var user = db.TblUsers
                    .Select(x => new { x.ID, x.Name, x.Email })
                    .Where(x => x.ID == sec.UserFK)
                    .FirstOrDefault();
                toSend.Add(new
                {
                    ID = sec.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Photo = sec.Photo
                });
            }
            return toSend;
        }

        public Object GetStudent(int id)
        {
            var student = db.TblStudents
                        .Select(x => new { x.DataOfBirth, x.ID, x.GuardianFK, x.Photo, x.UserFK })
                        .Where(x => x.ID == id)
                        .FirstOrDefault();
            var user = db.TblUsers
                .Select(x => new { x.ID, x.Name, x.Email, x.CreatedDate, x.IsActive })
                .Where(x => x.ID == student.UserFK)
                .FirstOrDefault();
            return new
            {
                Id = student.ID,
                DateOfBirth = student.DataOfBirth,
                GuardianFK = student.GuardianFK,
                Photo = student.Photo,
                UserFK = student.UserFK,
                Name= user.Name,
                Email=user.Email,
                CreatedDate = user.CreatedDate,
                IsActive = user.IsActive,
            };
        }

        public void CreateStudent(Student cs)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(cs.Password);
            var date = DateTime.Now;
            var dOfBirth = Convert.ToDateTime(cs.DateOfBirth);

            var guardianFK = db.TblUsers
                            .Select(x => new { x.Name, x.ID, x.Email })
                            .Where(x => x.Name.Equals(cs.GuardianName))
                            .Where(x=> x.Email.Equals(cs.GuardianEmail))
                            .FirstOrDefault();
            var guardian = db.TblGuardians
                            .Select(x => new { x.UserFK, x.ID })
                            .Where(x => x.UserFK == guardianFK.ID)
                            .FirstOrDefault();

            TblUsers user = new TblUsers { Name = cs.Name, Email = cs.Email, Password = passHashed, CreatedDate = date, IsActive = true };
            db.TblUsers.Add(user);
            db.SaveChanges();
            TblStudents student = new TblStudents { DataOfBirth = dOfBirth, Photo = cs.Photo, UserFK = user.ID, GuardianFK = guardian.ID };
            db.TblStudents.Add(student);
            db.SaveChanges();
        }
    }
}
