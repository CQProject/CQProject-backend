using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Data.AD;
using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BUser
    {
        public static Object GetPagesCountByRole(int roleID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return Math.Ceiling((float)db.TblUserRoles.Where(x => x.RoleFK == roleID).Count() / 50);
                }
            }
            catch (Exception) { return null; }
        }

        public static Object GetPageRole(int pageID, int roleID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var users = db.TblUserRoles.Where(x => x.RoleFK == roleID).OrderBy(x => x.UserFK).Skip(50 * pageID).Take(50).Select(x => x.UserFK).ToList();
                    if (users.Count() == 0) { return null; }
                    return users;
                }
            }
            catch (ArgumentException) { return null; }
        }

        public static Object GetUserDetails(int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                { return db.TblUsers.Where(x => x.ID == userID).Select(x => new { x.ID, x.Photo, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.Name, x.Email, x.RegisterDate, x.Function, x.Curriculum, x.DateOfBirth, x.IsActive }).FirstOrDefault(); }
            }
            catch (Exception) { return null; }
        }

        public static Object GetUserProfile(int userID)
        {

            try
            {
                using (var db = new DBContextModel())
                { return db.TblUsers.Where(x => x.ID == userID).Select(x => new { x.ID, x.Photo, x.Name, x.Email, x.IsActive, x.Function }).FirstOrDefault(); }
            }
            catch (Exception) { return null; }

        }

        public static object GetStudentsWithoutClass()
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    string year;
                    if (DateTime.Now.Month < 13 && DateTime.Now.Month > 7) year = (DateTime.Now.Year + 1).ToString();
                    else year = DateTime.Now.Year.ToString();

                    var students = db.TblUserRoles.Where(x => x.RoleFK == 1).ToList();
                    var studentsWithoutClass = students.Where(x => !db.TblClassUsers.Any(y => x.UserFK == y.UserFK)).ToList();

                    if (studentsWithoutClass.Count() == 0) { return null; }
                    return studentsWithoutClass;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object CreateUser(User newUser, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
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

                    /*ActiveDirectory.CreateUser(user.Email, user.Password);
                    ActiveDirectory.AddRole(user.Email, userRoles.RoleFK);*/

                    //BAction.SetActionToUser(String.Format("Registou o utilizador '{0}'", newUser.Name), userID);
                    return new { result = true, data = user.ID };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível registar utilizador." }; }
        }

        public static Boolean EditUser(User editedUser, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
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


                    BAction.SetActionToUser(String.Format("Editou os dados do utilizador '{0}'", editedUser.Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean SwitchActivity(int userID, int currentUser)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var user = db.TblUsers.Find(userID);
                    user.IsActive = (bool)user.IsActive ? false : true;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    //ActiveDirectory.DisableOrEnableUser(user.Email);

                    BAction.SetActionToUser(String.Format("Alterou o estado de atividade do utilizador '{0}'", user.Name), currentUser);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean AddRole(int userID, int roleID, int currentUser)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblUserRoles.Add(new TblUserRoles { UserFK = userID, RoleFK = roleID });
                    db.SaveChanges();

                    var user = db.TblUsers.Find(userID);

                    //ActiveDirectory.AddRole(user.Email, roleID);

                    BAction.SetActionToUser(String.Format("Atribuiu ao utilizador '{0}' a função de '{1}'", db.TblUsers.Find(userID).Name, db.TblRoles.Find(roleID).Name), currentUser);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean RemoveRole(int userID, int roleID, int currentUser)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblUserRoles.Remove(db.TblUserRoles.Find(userID, roleID));
                    db.SaveChanges();

                    var user = db.TblUsers.Find(userID);

                    //ActiveDirectory.RemoveRole(user.Email, roleID);

                    BAction.SetActionToUser(String.Format("Removeu ao utilizador '{0}' a função de '{1}'", db.TblUsers.Find(userID).Name, db.TblRoles.Find(roleID).Name), currentUser);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean VerifyRole(int userID, int roleID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblUserRoles.Any(x => x.RoleFK == roleID && x.UserFK == userID);
                }
            }
            catch (Exception) { return false; }
        }

        private static Boolean _VerifyUser(String CitizenCard)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    return db.TblUsers.Any(x => x.CitizenCard == CitizenCard);
                }
            }
            catch (Exception) { return false; }
        }
    }
}
