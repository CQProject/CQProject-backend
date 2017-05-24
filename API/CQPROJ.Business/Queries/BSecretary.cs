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

        public void CreateSecretary(Secretary cs)
        {
            var pass = new PasswordHasher();
            var passHashed = pass.HashPassword(cs.Password);
            var date = DateTime.Now;

            TblUsers user = new TblUsers { Name = cs.Name, Email=cs.Email, Password=passHashed, CreatedDate=date, IsActive=true };
            db.TblUsers.Add(user);
            TblSecretaries sec = new TblSecretaries { UserFK = user.ID, Address=cs.Address, CitizenCard=cs.CitizenCard, Curriculum=cs.Curriculum, FiscalNumber=cs.FiscalNumber, Photo = cs.Photo, PhoneNumber=cs.PhoneNumber, StartWorkTime=cs.StartWorkTime, EndWorkTime=cs.EndWorkTime };
            db.TblSecretaries.Add(sec);
            db.SaveChanges();
        }

        public void EditSecretary(Secretary es)
        {

        }
    }
}
