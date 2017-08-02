using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Entities.Payload;
using CQPROJ.Data.DB.Models;
using Jose;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CQPROJ.Business.Queries
{
    public class BAccount
    {
        private DBContextModel db = new DBContextModel();

        public string Login(Login requestUser,Uri client)
        {

            var user = db.TblUsers.Select(x => x).Where(x => x.Email == requestUser.Email).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var password = new PasswordHasher();
            if (password.VerifyHashedPassword(user.Password, requestUser.Password).ToString() != "Success")
            {
                return null;
            }

            byte[] secretKey = Encoding.ASCII.GetBytes("secret");
            DateTime issued = DateTime.Now;
            DateTime expire = DateTime.Now.AddHours(10);

            var classID = db.TblClassStudents.Where(x => x.StudentFK == user.ID).Select(x => x.ClassFK).FirstOrDefault();
            var role = db.TblUserRoles.Select(x => x).Where(x => x.UserFK == user.ID).FirstOrDefault().RoleFK;

            Dictionary<string, object> payload;
            if (classID == 0)
            {
                payload = new Dictionary<string, object>(){
                    {"iss",client.Authority },
                    {"aud",user.ID },
                    {"rol",role },
                    {"iat",ToUnixTime(issued).ToString() },
                    {"exp",ToUnixTime(expire).ToString() }
                };
            }
            else
            {
                payload = new Dictionary<string, object>(){
                    {"iss",client.Authority },
                    {"aud",user.ID },
                    {"cla", classID },
                    {"rol",role },
                    {"iat",ToUnixTime(issued).ToString() },
                    {"exp",ToUnixTime(expire).ToString() }
                };
            }

            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);    
        }

        public Object confirmToken(HttpRequestMessage request)
        {
            string token =  request.Headers.GetValues("Token").First();
            byte[] secretKey = Encoding.ASCII.GetBytes("secret");
            string pl = JWT.Decode(token,secretKey,JwsAlgorithm.HS256);
            long date = ToUnixTime(DateTime.Now);

            JavaScriptSerializer pay = new JavaScriptSerializer();
            Payload payload = pay.Deserialize<Payload>(pl);

            if (!payload.iss.Contains(request.RequestUri.Authority))
            {
                return null;
            }

            if(date > Convert.ToInt64(payload.exp))
            {
                //logout
                return null;
            }

            return new { UserId=payload.aud, ClassId=payload.cla, RoleId=payload.rol };
        }

        static long ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
