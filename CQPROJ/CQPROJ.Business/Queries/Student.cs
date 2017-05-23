using CQPROJ.Data.BD.Models;
using System;
using System.Linq;

namespace CQPROJ.Business.Queries
{
    public class Student
    {
        private ModelsDbContext db = new ModelsDbContext();

        public Object GetStudent(int id)
        {
            var student = db.TblStudents.Where(x => x.ID.Equals(id)).FirstOrDefault();
            var user = db.TblUsers.Select(x => new { x.ID, x.Name, x.Email, student.Photo, student.GuardianFK }).Where(x => x.ID == student.UserFK).FirstOrDefault();
            return user;
        }
    }
}
