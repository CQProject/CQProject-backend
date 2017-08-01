using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CQPROJ.Data.DB.Models;
using CQPROJ.Business.Entities.IUser;

namespace CQPROJ.Business.Queries
{
    public class BAssistant
    {

        private DBContextModel db = new DBContextModel();

        public Object GetAssistants()
        {
            var assistant = db.TblUserRoles.Select(x=>x).Where(x=>x.RoleFK==4);      

            var toSend = new List<Object>();
            foreach (var assist in assistant)
            {
                var user = db.TblUsers.Find(assist.UserFK);

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

        public Object GetAssistant(int id)
        {

            var assistant = db.TblUserRoles.Find(id, 4);

            if (assistant == null)
            {
                return new { Result = "Failed" };
            }

            var user = db.TblUsers
            .Find(id);

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

        public void CreateAssistant(User assistant)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(assistant.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers {
                Address = assistant.Address,
                CitizenCard = assistant.CitizenCard,
                Curriculum = assistant.Curriculum,
                Email = assistant.Email,
                FiscalNumber = assistant.FiscalNumber,
                Name = assistant.Name,
                Password = passHashed,
                PhoneNumber = assistant.PhoneNumber,
                Photo = assistant.Photo,
                IsActive = true,
                Function = assistant.Function,
                DateOfBirth = assistant.DateOfBirth,
                RegisterDate = date
                
            };

            db.TblUsers.Add(user);
            db.SaveChanges();

            TblUserRoles userRoles = new TblUserRoles
            {
                UserFK = user.ID,
                RoleFK = 4
            };
            db.TblUserRoles.Add(userRoles);
            db.SaveChanges();
        }

        public Object EditAssistant(int id,User assistant)
        {

            var assist = db.TblUserRoles.Find(id, 4);

            if (assist == null | assistant == null)
            {
                return new { Result = "Failed" };
            }

            TblUsers user = db.TblUsers.Find(id);

            user.Name = assistant.Name;
            user.Email = assistant.Email;
            user.Address = assistant.Address;
            user.CitizenCard = assistant.CitizenCard;
            user.Curriculum = assistant.Curriculum;
            user.FiscalNumber = assistant.FiscalNumber;
            user.PhoneNumber = assistant.PhoneNumber;
            user.Photo = assistant.Photo;
            user.Function = assistant.Function;
            user.DateOfBirth = assistant.DateOfBirth;

            db.SaveChanges();

            return new { Result = "Success" };
        }
    }
}
