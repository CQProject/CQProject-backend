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

        /*public Object GetAssistants()
        {
            var assistant = db.TblUsers.Select(x=>x);
            var toSend = new List<Object>();
            foreach (var assist in assistant)
            {
                var user = db.TblUserRoles
                    .Select(x=>x)
                    .Where(x => x.UserFK == assist.ID)
                    .Where(x=> x.RoleFK == 4)
                    .FirstOrDefault();


                toSend.Add(new
                {
                    ID = assist.ID,
                    Name = assist.Name,
                    Email = assist.Email,
                    Photo = assist.Photo
                });
            }
            return toSend;
        }*/

        //public Object GetAssistant(int id)
        //{
        //    var assistant = db.TblSchAssistants
        //                    .Select(x => new { x.ID, x.UserFK, x.Photo, x.StartWorkTime, x.EndWorkTime, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address })
        //                    .Where(x => x.ID == id)
        //                    .FirstOrDefault();
        //    var user = db.TblUsers
        //                .Select(x => new { x.ID, x.Name, x.Email, x.IsActive })
        //                .Where(x => x.ID.Equals(assistant.UserFK))
        //                .FirstOrDefault();

        //    return new
        //    {
        //        Id = assistant.ID,
        //        Photo = assistant.Photo,
        //        StartWorkTime = assistant.StartWorkTime,
        //        EndWorkTime = assistant.EndWorkTime,
        //        FiscalNumber = assistant.FiscalNumber,
        //        CitizenCard = assistant.CitizenCard,
        //        PhoneNumber = assistant.PhoneNumber,
        //        Address = assistant.Address,
        //        Name = user.Name,
        //        Email = user.Email,
        //        IsActive = user.IsActive
        //    };
        //}

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
                Function = "Assistant",
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
            db.SaveChanges();
        }

        //public Object EditAssistant(int id, Assistant assistant)
        //{
        //    try
        //    {
        //        var assist = db.TblSchAssistants.Select(x => x).Where(x => x.ID == id).FirstOrDefault();
        //        var user = db.TblUsers.Select(x => x).Where(x => x.ID == assist.UserFK).FirstOrDefault();
        //        user.Name = assistant.Name;
        //        user.Email = assistant.Email;
        //        assist.Address = assistant.Address;
        //        assist.CitizenCard = assistant.CitizenCard;
        //        assist.Curriculum = assistant.Curriculum;
        //        assist.EndWorkTime = assistant.EndWorkTime;
        //        assist.FiscalNumber = assistant.FiscalNumber;
        //        assist.PhoneNumber = assistant.PhoneNumber;
        //        assist.Photo = assistant.Photo;
        //        assist.StartWorkTime = assistant.StartWorkTime;
        //        db.SaveChanges();
        //        return new { Result = "Success" };
        //    }
        //    catch (Exception)
        //    {
        //        return new { Result = "Failed" };
        //    }
        //}
    }
}
