using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.IUser;
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

        public List<Object> GetStudents(int id)
        {

            var student = db.TblUserRoles.Select(x => x).Where(x => x.RoleFK == 1);

            var toSend = new List<Object>();
            int max = id * 50 + 50;
            for(var i = id*50; i < max; i++) { 

                var user = db.TblUsers.Find(i+1);

                toSend.Add(new
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Photo = user.Photo
                });
            }
            return toSend;
        }

        public Object GetStudent(int id)
        {

            var student = db.TblUserRoles.Find(id, 1);

            if (student == null)
            {
                return new { Result = "Failed" };
            }


            var user = db.TblUsers.Find(id);
            var guardian = db.TblParenting.Select(x => x).Where(x => x.StudentFK == id);

            return new
            {
                Id = user.ID,
                DateOfBirth = user.DateOfBirth,
                GuardianFK = guardian.Select(x=>x.GuardianFK),
                Photo = user.Photo,
                Name = user.Name,
                Email = user.Email,
                RegisterDate = user.RegisterDate,
                IsActive = user.IsActive
            };
        }

        public int CreateStudent(User student)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(student.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers
            {
                CitizenCard = student.CitizenCard,
                Email = student.Email,
                FiscalNumber = student.FiscalNumber,
                Name = student.Name,
                Password = passHashed,
                Photo = student.Photo,
                IsActive = true,
                Function = student.Function,
                DateOfBirth = student.DateOfBirth,
                RegisterDate = date

            };

            db.TblUsers.Add(user);
            db.SaveChanges();

            TblUserRoles userRoles = new TblUserRoles
            {
                UserFK = user.ID,
                RoleFK = 1
            };
            db.TblUserRoles.Add(userRoles);
            db.SaveChanges();

            return user.ID;
        }

        public Object EditStudent(int id, User student)
        {
            var stud = db.TblUserRoles.Find(id, 4);

            if (stud == null | student == null)
            {
                return new { Result = "Failed" };
            }

            TblUsers user = db.TblUsers.Find(id);

            user.CitizenCard = student.CitizenCard;
            user.Email = student.Email;
            user.FiscalNumber = student.FiscalNumber;
            user.Name = student.Name;
            user.Photo = student.Photo;
            user.DateOfBirth = student.DateOfBirth;

            db.SaveChanges();

            return new { Result = "Success" };
        }

    }
}
