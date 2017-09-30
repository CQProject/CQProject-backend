using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class BParenting
    {
        public static List<int> GetGuardians(int studentID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var guardians = db.TblParenting.Where(x => x.StudentFK == studentID).Select(x => x.GuardianFK).ToList();
                    if (guardians.Count() == 0) { return null; }
                    return guardians;
                }
            }
            catch (Exception) { return null; }
        }

        public static List<int> GetChildren(int guardianID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var children = db.TblParenting.Where(x => x.GuardianFK == guardianID).Select(x => x.StudentFK).ToList();
                    if (children.Count() == 0) { return null; }
                    return children;
                }
            }
            catch (Exception) { return null; }
        }

        public static Object CreateGuardian(Guardian guardian, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    if (_VerifyUser(guardian.CitizenCard)) { return new { result = false, info = "Utilizador já se encontra registado." }; }

                    TblUsers user = new TblUsers
                    {
                        Address = guardian.Address,
                        CitizenCard = guardian.CitizenCard,
                        Email = guardian.Email,
                        FiscalNumber = guardian.FiscalNumber,
                        Name = guardian.Name,
                        Password = new PasswordHasher().HashPassword(guardian.Password),
                        PhoneNumber = guardian.PhoneNumber,
                        IsActive = true,
                        Function = guardian.Function,
                        DateOfBirth = guardian.DateOfBirth,
                        RegisterDate = DateTime.Now
                    };
                    db.TblUsers.Add(user);
                    db.SaveChanges();

                    TblUserRoles userRoles = new TblUserRoles { UserFK = user.ID, RoleFK = 5 };
                    db.TblUserRoles.Add(userRoles);
                    db.SaveChanges();

                    if (!AddParenting(user.ID, guardian.ChildrenID,userID)) { return new { result = false, info = "Não foi possível relacionar Enc.Educação com o Estudante." }; }
                    
                    return new { result = true };
                }
            }
            catch (Exception) { return new { result = false, info = "Não foi possível registar utilizador." }; }
        }

        public static Boolean AddParenting(int guardianID, int studentID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblParenting.Add(new TblParenting { GuardianFK = guardianID, StudentFK = studentID });
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("Associou o encarreagdo de educação '{0}' ao aluno '{1}'", db.TblUsers.Find(guardianID).Name, db.TblUsers.Find(studentID).Name), userID);
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public static Boolean RemoveParenting(int guardianID, int studentID, int userID)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    db.TblParenting.Remove(db.TblParenting.Find(studentID, guardianID));
                    db.SaveChanges();

                    BAction.SetActionToUser(String.Format("removeu a associação do encarreagdo de educação '{0}' ao aluno '{1}'", db.TblUsers.Find(guardianID).Name, db.TblUsers.Find(studentID).Name), userID);
                    return true;
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
                    return (db.TblUsers.Any(x => x.CitizenCard == CitizenCard)) ? true : false;

                }
            }
            catch (Exception) { return false; }
        }
    }
}
