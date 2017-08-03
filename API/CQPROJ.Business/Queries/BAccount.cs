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

        public Object Login(Login requestUser,Uri client)
        {
            try
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


                var roles = db.TblUserRoles.Where(x => x.UserFK == user.ID).Select(x => x.RoleFK);

                Dictionary<string, object> payload = new Dictionary<string, object>(){
                    {"iss",client.Authority },
                    {"aud",user.ID },
                    {"rol",roles },
                    {"iat",ToUnixTime(issued).ToString() },
                    {"exp",ToUnixTime(expire).ToString() }
                };
                var token= JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

                if (roles.Contains(1) || roles.Contains(2))
                {
                    int classID = db.TblClassUsers.Where(x => x.UserFK == user.ID).OrderByDescending(x => x.ClassFK).FirstOrDefault().ClassFK;
                    return new { token = token, userID = user.ID, roles = roles, classID = classID, name = user.Name, photo = user.Photo };
                }

                return new { token=token, userID=user.ID, roles=roles, classID=0, name = user.Name, photo = user.Photo };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Payload confirmToken(HttpRequestMessage request)
        {

            Payload payload;

            try
            {
                string token = request.Headers.GetValues("Authorization").First();
                byte[] secretKey = Encoding.ASCII.GetBytes("secret");
                string pl = JWT.Decode(token, secretKey, JwsAlgorithm.HS256);
                long date = ToUnixTime(DateTime.Now);

                JavaScriptSerializer pay = new JavaScriptSerializer();
                payload = pay.Deserialize<Payload>(pl);

                if (!payload.iss.Contains(request.RequestUri.Authority))
                {
                    return null;
                }

                if (date > Convert.ToInt64(payload.exp))
                {
                    return null;
                }

                return payload;
            }
            catch (Exception)
            {
                return null;
            }
        }

        static long ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
