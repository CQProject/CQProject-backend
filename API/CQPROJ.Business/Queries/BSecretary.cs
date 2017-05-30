using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.ESecretary;
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
            var secs = db.TblSecretaries
                .Select(x => new { x.ID, x.Photo, x.UserFK });
            var toSend = new List<Object>();
            foreach (var sec in secs)
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

        public Object GetSecretary(int id)
        {
            var sec = db.TblSecretaries
                .Select(x => new { x.ID, x.Photo, x.StartWorkTime, x.EndWorkTime, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.Curriculum, x.UserFK })
                .Where(x => x.ID == id)
                .FirstOrDefault();
            var user = db.TblUsers
                .Select(x => new { x.ID, x.Name, x.Email, x.CreatedDate, x.IsActive })
                .Where(x => x.ID == sec.UserFK)
                .FirstOrDefault();
            return new
            {
                Id = sec.ID,
                Name = user.Name,
                Email = user.Email,
                Photo = sec.Photo,
                StartWorkTime = sec.StartWorkTime,
                EndWorkTime = sec.EndWorkTime,
                FiscalNumber = sec.FiscalNumber,
                CitizenCard = sec.CitizenCard,
                Phone = sec.Photo,
                Address = sec.Address,
                CreatedDate = user.CreatedDate,
                IsActive = user.IsActive,
                Curriculum = sec.Curriculum
            };
        }

        //public void CreateSecretary(Secretary secretary)
        //{
        //    var pass = new PasswordHasher();
        //    var passHashed = pass.HashPassword(secretary.Password);
        //    var date = DateTime.Now;

        //    TblUsers user = new TblUsers { Name = secretary.Name, Email = secretary.Email, Password = passHashed, CreatedDate = date, IsActive = true };
        //    db.TblUsers.Add(user);
        //    TblSecretaries sec = new TblSecretaries { UserFK = user.ID, Address = secretary.Address, CitizenCard = secretary.CitizenCard, Curriculum = secretary.Curriculum, FiscalNumber = secretary.FiscalNumber, Photo = secretary.Photo, PhoneNumber = secretary.PhoneNumber, StartWorkTime = secretary.StartWorkTime, EndWorkTime = secretary.EndWorkTime };
        //    db.TblSecretaries.Add(sec);
        //    db.SaveChanges();
        //}

        //public Object EditSecretary(int id, Secretary secretary)
        //{
        //    var sec = db.TblSecretaries.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
        //    try
        //    {
        //        sec.TblUsers.Name = secretary.Name;
        //        sec.TblUsers.Email = secretary.Email;
        //        sec.FiscalNumber = secretary.FiscalNumber;
        //        sec.CitizenCard = secretary.CitizenCard;
        //        sec.PhoneNumber = secretary.PhoneNumber;
        //        sec.Address = secretary.Address;
        //        sec.Photo = secretary.Photo;
        //        sec.Curriculum = secretary.Curriculum;
        //        sec.StartWorkTime = secretary.StartWorkTime;
        //        db.SaveChanges();
        //        return new { Result = "Success" };
        //    }
        //    catch (Exception)
        //    {
        //        return new { Result = "Failed" };
        //    }
        //}

        /*public Object RegistAction()
        {

        }*/
    }
}
