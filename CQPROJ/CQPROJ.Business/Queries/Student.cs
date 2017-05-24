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
            var stud = db.TblStudents.Select(x=>x).Where( x=> x.ID.Equals(id));
            var student = stud.Select(x => new { x.Photo,x.DataOfBirth});
            return student;
        }
    }
}
