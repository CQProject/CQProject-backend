using CQPROJ.Business.Entities.IUser;
using CQPROJ.Data.DB.Models;
//using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BTeacher
    {
        private DBContextModel db = new DBContextModel();

        public Object GetTeachers()
        {
            var teachers = db.TblUserRoles.Select(x => x).Where(x => x.RoleFK == 2);

            var toSend = new List<Object>();
            foreach (var teacher in teachers)
            {
                var user = db.TblUsers.Find(teacher.UserFK);

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

        public Object GetTeacher(int id)
        {
            var teacher = db.TblUserRoles.Find(id, 2);

            if (teacher == null)
            {
                return new { Result = "Failed" };
            }

            var user = db.TblUsers.Find(id);

            return new
            {
                Id = user.ID,
                Photo = user.Photo,
                FiscalNumber = user.FiscalNumber,
                CitizenCard = user.CitizenCard,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Name = user.Name,
                Email = user.Email,
                RegisterDate = user.RegisterDate,
                Function = user.Function,
                Curriculum = user.Curriculum
            };
        }

        public void CreateTeacher(User teacher)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(teacher.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers
            {
                Address = teacher.Address,
                CitizenCard = teacher.CitizenCard,
                Curriculum = teacher.Curriculum,
                Email = teacher.Email,
                FiscalNumber = teacher.FiscalNumber,
                Name = teacher.Name,
                Password = passHashed,
                PhoneNumber = teacher.PhoneNumber,
                Photo = teacher.Photo,
                IsActive = true,
                Function = teacher.Function,
                DateOfBirth = teacher.DateOfBirth,
                RegisterDate = date

            };

            db.TblUsers.Add(user);
            db.SaveChanges();

            TblUserRoles userRoles = new TblUserRoles
            {
                UserFK = user.ID,
                RoleFK = 2
            };
            db.TblUserRoles.Add(userRoles);
            db.SaveChanges();
        }

        public Object EditTeacher(int id, User teachers)
        {

            var teacher = db.TblUserRoles.Find(id, 2);

            if (teacher == null | teachers == null)
            {
                return new { Result = "Failed" };
            }

            TblUsers user = db.TblUsers.Find(id);

            user.Name = teachers.Name;
            user.Email = teachers.Email;
            user.Address = teachers.Address;
            user.CitizenCard = teachers.CitizenCard;
            user.Curriculum = teachers.Curriculum;
            user.FiscalNumber = teachers.FiscalNumber;
            user.PhoneNumber = teachers.PhoneNumber;
            user.Photo = teachers.Photo;
            user.Function = teachers.Function;
            user.DateOfBirth = teachers.DateOfBirth;

            db.SaveChanges();

            return new { Result = "Success" };
        }
        
    }
}
