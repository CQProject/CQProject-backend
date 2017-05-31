using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQPROJ.Business.Entities.EAssistant;
using Microsoft.AspNet.Identity;
using CQPROJ.Data.DB.Models;

namespace CQPROJ.Business.Queries
{
    public class BAssistant
    {

        private DBContextModel db = new DBContextModel();

        public Object GetAssistants()
        {
            var assistant = db.TblSchAssistants.Select(x => new { x.ID, x.Photo, x.UserFK });
            var toSend = new List<Object>();
            foreach (var assist in assistant)
            {
                var user = db.TblUsers
                    .Select(x => new { x.ID, x.Name, x.Email })
                    .Where(x => x.ID == assist.UserFK)
                    .FirstOrDefault();
                toSend.Add(new
                {
                    ID = assist.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Photo = assist.Photo
                });
            }
            return toSend;
        }

        public Object GetAssistant(int id)
        {
            var assistant = db.TblSchAssistants
                            .Select(x => new { x.ID, x.UserFK, x.Photo, x.StartWorkTime, x.EndWorkTime, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address })
                            .Where(x => x.ID == id)
                            .FirstOrDefault();
            var user = db.TblUsers
                        .Select(x => new { x.ID, x.Name, x.Email, x.IsActive })
                        .Where(x => x.ID.Equals(assistant.UserFK))
                        .FirstOrDefault();

            return new
            {
                Id = assistant.ID,
                Photo = assistant.Photo,
                StartWorkTime = assistant.StartWorkTime,
                EndWorkTime = assistant.EndWorkTime,
                FiscalNumber = assistant.FiscalNumber,
                CitizenCard = assistant.CitizenCard,
                PhoneNumber = assistant.PhoneNumber,
                Address = assistant.Address,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive
            };
        }

        public void CreateAssistant(Assistant assistant)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(assistant.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers { Name = assistant.Name, Email = assistant.Email, Password = passHashed, CreatedDate = date, IsActive = true, Function = "Assistant" };
            db.TblUsers.Add(user);
            db.SaveChanges();
            TblSchAssistants assist = new TblSchAssistants { UserFK = user.ID, Address = assistant.Address, CitizenCard = assistant.CitizenCard, Curriculum = assistant.Curriculum, FiscalNumber = assistant.FiscalNumber, Photo = assistant.Photo, PhoneNumber = assistant.PhoneNumber, StartWorkTime = assistant.StartWorkTime, EndWorkTime = assistant.EndWorkTime };
            db.TblSchAssistants.Add(assist);
            db.SaveChanges();
        }

        public Object EditAssistant(int id, Assistant assistant)
        {
            try
            {
                var assist = db.TblSchAssistants.Select(x => x).Where(x => x.ID == id).FirstOrDefault();
                var user = db.TblUsers.Select(x => x).Where(x => x.ID == assist.UserFK).FirstOrDefault();
                user.Name = assistant.Name;
                user.Email = assistant.Email;
                assist.Address = assistant.Address;
                assist.CitizenCard = assistant.CitizenCard;
                assist.Curriculum = assistant.Curriculum;
                assist.EndWorkTime = assistant.EndWorkTime;
                assist.FiscalNumber = assistant.FiscalNumber;
                assist.PhoneNumber = assistant.PhoneNumber;
                assist.Photo = assistant.Photo;
                assist.StartWorkTime = assistant.StartWorkTime;
                db.SaveChanges();
                return new { Result = "Success" };
            }
            catch (Exception)
            {
                return new { Result = "Failed" };
            }
        }
    }
}
