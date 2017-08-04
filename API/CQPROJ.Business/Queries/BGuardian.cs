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
    public class BGuardian
    {
        private static DBContextModel db = new DBContextModel();

        public static List<int> GetGuardians(int studentID)
        {
            var guardians = db.TblParenting.Where(x => x.StudentFK == studentID).Select(x => x.GuardianFK).ToList();

            return guardians;
        }

        public static void CreateGuardian(User guardian, int id)
        {
                var pass = new PasswordHasher();
                var passHashed = pass.HashPassword(guardian.Password);
                var date = DateTime.Now;

                TblUsers user = new TblUsers
                {
                    CitizenCard = guardian.CitizenCard,
                    Email = guardian.Email,
                    FiscalNumber = guardian.FiscalNumber,
                    Name = guardian.Name,
                    Password = passHashed,
                    Photo = guardian.Photo,
                    IsActive = true,
                    Function = guardian.Function,
                    DateOfBirth = guardian.DateOfBirth,
                    RegisterDate = date

                };

                db.TblUsers.Add(user);
                db.SaveChanges();

                TblUserRoles userRoles = new TblUserRoles
                {
                    UserFK = user.ID,
                    RoleFK = 5
                };
                db.TblUserRoles.Add(userRoles);
                db.SaveChanges();

                TblParenting guardian_student = new TblParenting
                {
                    GuardianFK = user.ID,
                    StudentFK = id
                };
                db.TblParenting.Add(guardian_student);
                db.SaveChanges();
        }
    }
}
