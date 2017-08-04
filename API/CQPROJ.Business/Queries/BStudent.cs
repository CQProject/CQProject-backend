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
        private static DBContextModel db = new DBContextModel();

        public static List<Object> GetStudents(int id)
        {


            List<TblUserRoles> students;
            try
            {
                students = db.TblUserRoles.Select(x => x).Where(x => x.RoleFK == 1).OrderBy(x => x.UserFK).Skip(50 * id).Take(50).ToList();
            }
            catch (Exception)
            {
                students = db.TblUserRoles.Select(x => x).Where(x => x.RoleFK == 1).OrderBy(x => x.UserFK).Skip(50 * id).ToList();
            }


            var toSend = new List<Object>();
            foreach(var student in students) { 

                var user = db.TblUsers.Find(student.UserFK);

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

        public static Object GetStudent(int id)
        {

            var student = db.TblUserRoles.Find(id, 1);

            if (student == null)
            {
                return null;
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

        public static int CreateStudent(User student)
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

        public static Object EditStudent(int id, User student)
        {
            var stud = db.TblUserRoles.Find(id, 4);

            if (stud == null | student == null)
            {
                return new { Result = "failed" };
            }

            TblUsers user = db.TblUsers.Find(id);

            user.CitizenCard = student.CitizenCard;
            user.Email = student.Email;
            user.FiscalNumber = student.FiscalNumber;
            user.Name = student.Name;
            user.Photo = student.Photo;
            user.DateOfBirth = student.DateOfBirth;

            db.SaveChanges();

            return new { result = "success" };
        }

    }
}
