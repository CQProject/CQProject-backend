using CQPROJ.Business.Entities.IUser;
using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CQPROJ.Business.Queries
{
    public class BSecretary
    {
        private DBContextModel db = new DBContextModel();

        public List<Object> GetSecretaries()
        {
            var secs = db.TblUserRoles.Select(x => x).Where(x => x.RoleFK == 3);

            var toSend = new List<Object>();

            foreach (var sec in secs)
            {
                var user = db.TblUsers.Find(sec.UserFK);

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

        public Object GetSecretary(int id)
        {

            var secretary = db.TblUserRoles.Find(id, 3);

            if (secretary == null)
            {
                return new { Result = "Failed" };
            }

            var user = db.TblUsers.Find(id);

            return new
            {
                Id = user.ID,
                Name = user.Name,
                Email = user.Email,
                Photo = user.Photo,
                FiscalNumber = user.FiscalNumber,
                CitizenCard = user.CitizenCard,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RegisterDate = user.RegisterDate,
                Curriculum = user.Curriculum,
                Function = user.Function
            };

        }

        public Object CreateSecretary(User secretary)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(secretary.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers {
                Name = secretary.Name,
                Email = secretary.Email,
                Password = passHashed,
                IsActive = true,
                Function = secretary.Function,
                Address = secretary.Address,
                CitizenCard = secretary.CitizenCard,
                Curriculum = secretary.Curriculum,
                FiscalNumber = secretary.FiscalNumber,
                Photo = secretary.Photo,
                PhoneNumber = secretary.PhoneNumber,
                DateOfBirth = secretary.DateOfBirth,
                RegisterDate = date
            };
            db.TblUsers.Add(user);
            db.SaveChanges();

            TblUserRoles userRoles = new TblUserRoles { UserFK=user.ID, RoleFK=3 };
            db.TblUserRoles.Add(userRoles);
            db.SaveChanges();

            return new { Result = "Success" };
        }

        public Object EditSecretary(int id, User secretary)
        {

            var sec = db.TblUserRoles.Find(id, 3);

            if (sec == null)
            {
                return new { Result = "Failed" };
            }

            TblUsers user = db.TblUsers.Find(id);

            user.Name = secretary.Name;
            user.Email = secretary.Email;
            user.FiscalNumber = secretary.FiscalNumber;
            user.CitizenCard = secretary.CitizenCard;
            user.PhoneNumber = secretary.PhoneNumber;
            user.Address = secretary.Address;
            user.Photo = secretary.Photo;
            user.Curriculum = secretary.Curriculum;

            db.SaveChanges();
            return new { Result = "Success" };
        }

        /*public Object RegistAction()
        {

        }*/
    }
}
