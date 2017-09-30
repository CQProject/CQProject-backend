using System;

namespace CQPROJ.Business.Entities.IAccount
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Payload
    {
        public string iss { get; set; }
        public int aud { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }
        public int[] rol { get; set; }
        public int[] cla { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Curriculum { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Function { get; set; }
        public int RoleID { get; set; }
    }

    public class Guardian
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FiscalNumber { get; set; }
        public string CitizenCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Function { get; set; }
        public int ChildrenID { get; set; }
    }

    public class RoleUser
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
    }

    public class ClassUser
    {
        public int ClassID { get; set; }
        public int UserID { get; set; }
    }

    public class Parenting
    {
        public int StudentID { get; set; }
        public int GuardianID { get; set; }
    }
}
