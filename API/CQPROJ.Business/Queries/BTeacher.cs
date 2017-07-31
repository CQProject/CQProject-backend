using CQPROJ.Business.Entities.IUser;
//using CQPROJ.Data.DB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Queries
{
    public class BTeacher
    {
        //private DBContextModel db = new DBContextModel();

        //public List<Object> GetTeachers()
        //{
        //    var teachers = db.TblTeachers.Select(x => new { x.ID, x.Photo, x.UserFK });
        //    var toSend = new List<Object>();
        //    foreach(var teach in teachers)
        //    {
        //        var user = db.TblUsers
        //            .Select(x => new { x.ID, x.Name, x.Email })
        //            .Where(x => x.ID == teach.UserFK)
        //            .FirstOrDefault();
        //        toSend.Add(new
        //        {
        //            ID = teach.ID,
        //            Photo = teach.Photo,
        //            Name = user.Name,
        //            Email = user.Email
        //        });
        //    }
        //    return toSend;
        //}

        //public Object GetTeacher(int id)
        //{
        //    try
        //    {
        //        var teach = db.TblTeachers
        //            .Select(x => new { x.ID, x.Photo, x.FiscalNumber, x.CitizenCard, x.PhoneNumber, x.Address, x.Curriculum,x.UserFK })
        //            .Where(x => x.ID == id)
        //            .FirstOrDefault();
        //        var user = db.TblUsers
        //            .Select(x => new { x.ID, x.Name, x.Email, x.CreatedDate, x.IsActive })
        //            .Where(x => x.ID == teach.UserFK)
        //            .FirstOrDefault();
        //        return new
        //        {
        //            Id = teach.ID,
        //            UserId = user.ID,
        //            Name = user.Name,
        //            Email = user.Email,
        //            Photo = teach.Photo,
        //            FiscalNumber = teach.FiscalNumber,
        //            CitizenCard = teach.CitizenCard,
        //            Phone = teach.PhoneNumber,
        //            Address = teach.Address,
        //            CreatedDate = user.CreatedDate,
        //            IsActive = user.IsActive,
        //            Curriculum = teach.Curriculum
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new { };
        //    }
        //}

        //public Object CreateTeacher(Teacher teacher)
        //{
        //    var pass = new PasswordHasher();
        //    var passHashed = pass.HashPassword(teacher.Password);
        //    var date = DateTime.Now;

        //    TblUsers user = new TblUsers { Name = teacher.Name, Email = teacher.Email, Password = passHashed, CreatedDate = date, IsActive = true, Function = "Teacher" };
        //    db.TblUsers.Add(user);
        //    db.SaveChanges();
        //    TblTeachers teach = new TblTeachers { UserFK = user.ID, Address = teacher.Address, CitizenCard = teacher.CitizenCard, Curriculum = teacher.Curriculum, FiscalNumber = teacher.FiscalNumber, Photo = teacher.Photo, PhoneNumber = teacher.PhoneNumber};
        //    db.TblTeachers.Add(teach);
        //    db.SaveChanges();

        //    return new { Result = "Success" };
        //}

        //public Object EditTeacher(int id, Teacher teacher)
        //{
        //    try
        //    {
        //        var teach = db.TblTeachers.Select(x => x).Where(x => x.ID == id).FirstOrDefault();
        //        var user = db.TblUsers.Select(x => x).Where(x => x.ID == teach.UserFK).FirstOrDefault();
        //        user.Name = teacher.Name;
        //        user.Email = teacher.Email;
        //        teach.FiscalNumber = teacher.FiscalNumber;
        //        teach.CitizenCard = teacher.CitizenCard;
        //        teach.PhoneNumber = teacher.PhoneNumber;
        //        teach.Address = teacher.Address;
        //        teach.Photo = teacher.Photo;
        //        teach.Curriculum = teacher.Curriculum;
        //        db.SaveChanges();
        //        return new { Result = "Success" };
        //    }
        //    catch (Exception)
        //    {
        //        return new { Result = "Failed" };
        //    }
        //}
    }
}
