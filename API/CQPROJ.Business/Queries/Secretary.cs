using CQPROJ.Business.Entities;
using CQPROJ.Data.BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CQPROJ.Business.Queries
{
    public class Secretary
    {
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetSecretaries()
        {
            var secretary = (from oneSecretary in db.TblSecretaries join user in db.TblUsers on oneSecretary.UserFK equals user.ID select new {
                user.Name, user.Email, oneSecretary.Id, oneSecretary.Photo});

            var sec = db.TblSecretaries.Select(x=> new {x.Id, x.Photo, x.TblUsers.Name, x.TblUsers.Email });
            return sec;
        }

        public Object GetSecretary(int id)
        {
            var sec = db.TblSecretaries.Select(x => new { x.Id, x.Photo, x.TblUsers.Name, x.TblUsers.Email });
            return sec;
        }

        //tornar void
        public Object CreateSecretary(CreateSecretary cs)
        {
            return "";
        }
    }
}
