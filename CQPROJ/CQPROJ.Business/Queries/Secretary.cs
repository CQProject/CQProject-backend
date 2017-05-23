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

        public Object GetSecretary()
        {
            var secretary = (from oneSecretary in db.TblSecretaries join user in db.TblUsers on oneSecretary.UserFK equals user.ID select new { oneSecretary.Address, oneSecretary.CitizenCard, oneSecretary.Curriculum, user.Name, user.Email});
            return secretary;
        }
    }
}
