using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BUser
    {

        private static DBContextModel db = new DBContextModel();

        public static Object GetPagesCountByRole(int roleID)
        {
            try
            {
                return Math.Ceiling((float)db.TblUserRoles.Where(x => x.RoleFK == roleID).Count() / 50);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Object GetPageRole(int pageID, int roleID)
        {
            try
            {
                var users = db.TblUserRoles.Where(x => x.RoleFK == roleID).OrderBy(x => x.UserFK).Skip(50 * pageID).Take(50).Select(x => x.UserFK).ToList();
                if (users.Count() == 0) { return null; }
                return users;
            }
            catch (ArgumentException) { return null; }
        }

        public static Object GetUserDetails(int userID)
        {
            try { return db.TblUsers.Where(x => x.ID == userID).Select(x => new { x.ID, x.Photo, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.Name, x.Email, x.RegisterDate, x.Function, x.Curriculum, x.DateOfBirth, x.IsActive }).FirstOrDefault(); }
            catch (Exception) { return null; }
        }

        public static Object GetUserProfile(int userID)
        {
            try { return db.TblUsers.Where(x => x.ID == userID).Select(x => new { x.ID, x.Photo, x.Name, x.Email, x.IsActive }).FirstOrDefault(); }
            catch (Exception) { return null; }
        }

        public static Object CreateUser(User newUser)
        {
            try
            {
                if (_VerifyUser(newUser.CitizenCard)) { return new { result = false, info = "Utilizador já se encontra registado." }; }

                TblUsers user = new TblUsers
                {
                    Address = newUser.Address,
                    CitizenCard = newUser.CitizenCard,
                    Curriculum = newUser.Curriculum,
                    Email = newUser.Email,
                    FiscalNumber = newUser.FiscalNumber,
                    Name = newUser.Name,
                    Password = new PasswordHasher().HashPassword(newUser.Password),
                    PhoneNumber = newUser.PhoneNumber,
                    Photo = newUser.Photo,
                    IsActive = true,
                    Function = newUser.Function,
                    DateOfBirth = newUser.DateOfBirth,
                    RegisterDate = DateTime.Now

                };
                db.TblUsers.Add(user);
                db.SaveChanges();

                TblUserRoles userRoles = new TblUserRoles { UserFK = user.ID, RoleFK = newUser.RoleID };
                db.TblUserRoles.Add(userRoles);
                db.SaveChanges();

                return new { result = true, data = user.ID };
            }
            catch (Exception) { return new { result = false, info = "Não foi possível registar utilizador." }; }
        }

        public static Boolean EditUser(User editedUser)
        {
            try
            {
                var user = db.TblUsers.Find(editedUser.ID);

                user.Name = editedUser.Name;
                user.Email = editedUser.Email;
                user.Address = editedUser.Address;
                user.CitizenCard = editedUser.CitizenCard;
                user.Curriculum = editedUser.Curriculum;
                user.FiscalNumber = editedUser.FiscalNumber;
                user.PhoneNumber = editedUser.PhoneNumber;
                user.Photo = editedUser.Photo;
                user.Function = editedUser.Function;
                user.DateOfBirth = editedUser.DateOfBirth;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean ActivateUser(int userID)
        {
            try
            {
                var user = db.TblUsers.Find(userID);
                user.IsActive = (bool)user.IsActive ? false : true;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean AddRole(int userID, int roleID)
        {
            try
            {
                db.TblUserRoles.Add(new TblUserRoles { UserFK = userID, RoleFK = roleID });
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean RemoveRole(int userID, int roleID)
        {
            try
            {
                db.TblUserRoles.Remove(db.TblUserRoles.Find(userID,roleID));
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public static Boolean VerifyRole(int userID, int roleID)
        {
            try
            {
                return db.TblUserRoles.Any(x => x.RoleFK == roleID && x.UserFK == userID);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Boolean _VerifyUser(String CitizenCard )
        {
            try
            {
                return (db.TblUsers.Any(x => x.CitizenCard == CitizenCard)) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
