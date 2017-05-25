using CQPROJ.Business.Entities;
using CQPROJ.Business.Entities.ESecretary;
using CQPROJ.Data.BD.Models;
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
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetSecretaries()
        {
            var sec = db.TblSecretaries.Select(x=> new {x.Id, x.Photo, x.TblUsers.Name, x.TblUsers.Email });
            return sec;
        }

        public Object GetSecretary(int id)
        {
            var sec = db.TblSecretaries.Select(x => new { x.Id, x.TblUsers.Name, x.TblUsers.Email, x.Photo, x.StartWorkTime, x.EndWorkTime, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.TblUsers.CreatedDate, x.TblUsers.IsActive }).Where(x=>x.Id==id);
            return sec;
        }

        public void CreateSecretary(Secretary secretary)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(secretary.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers { Name = secretary.Name, Email=secretary.Email, Password=passHashed, CreatedDate=date, IsActive=true };
            db.TblUsers.Add(user);
            TblSecretaries sec = new TblSecretaries { UserFK = user.ID, Address=secretary.Address, CitizenCard=secretary.CitizenCard, Curriculum=secretary.Curriculum, FiscalNumber=secretary.FiscalNumber, Photo = secretary.Photo, PhoneNumber=secretary.PhoneNumber, StartWorkTime=secretary.StartWorkTime, EndWorkTime=secretary.EndWorkTime };
            db.TblSecretaries.Add(sec);
            db.SaveChanges();
        }

        public Object EditSecretary(int id, Secretary secretary)
        {
            var sec = db.TblSecretaries.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            try
            {
                sec.TblUsers.Name = secretary.Name;
                sec.TblUsers.Email = secretary.Email;
                sec.FiscalNumber = secretary.FiscalNumber;
                sec.CitizenCard = secretary.CitizenCard;
                sec.PhoneNumber = secretary.PhoneNumber;
                sec.Address = secretary.Address;
                sec.Photo = secretary.Photo;
                sec.Curriculum = secretary.Curriculum;
                sec.StartWorkTime = secretary.StartWorkTime;
                db.SaveChanges();
                return new { Result = "Success" };
            }
            catch (Exception)
            {
                return new { Result = "Failed" };
            }
        }

        /*public Object RegistAction()
        {

        }*/
    }
}
