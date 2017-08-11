using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using CQPROJ.Data.DB.Models;
using CQPROJ.Business.Entities.IUser;
using System.Data.Entity;

namespace CQPROJ.Business.Queries
{
    public class BAssistant
    {

        private static DBContextModel db = new DBContextModel();

        public static Object GetAssistantsPages()
        {
            return Math.Ceiling((float)db.TblUserRoles.Where(x => x.RoleFK == 4).Count() / 50);
        }

        public static Object GetAssistantsPage(int pageID)
        {
            try
            {
                var assistants = db.TblUserRoles.Where(x => x.RoleFK == 4).OrderBy(x => x.UserFK).Skip(50 * pageID).Take(50).Select(x=>x.UserFK).ToList();

                if (assistants.Count() == 0)
                {
                    return null;
                }
                
                return assistants;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        
        public static Object GetAssistant(int id)
        {
            var assistant = db.TblUserRoles.Find(id, 4);

            if (assistant == null)
            {
                return null;
            }

            var user = db.TblUsers.Find(id);

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

        public static Boolean CreateAssistant(User assistant)
        {
            try
            {
                var hasher = new PasswordHasher();
                var password = hasher.HashPassword(assistant.Password);
                var date = DateTime.Now;

                TblUsers user = new TblUsers
                {
                    Address = assistant.Address,
                    CitizenCard = assistant.CitizenCard,
                    Curriculum = assistant.Curriculum,
                    Email = assistant.Email,
                    FiscalNumber = assistant.FiscalNumber,
                    Name = assistant.Name,
                    Password = password,
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

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static Boolean EditAssistant(int id, User assistant)
        {
            try
            {
                var role = db.TblUserRoles.Find(id, 4);

                if (role == null || assistant == null)
                {
                    return false;
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

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
