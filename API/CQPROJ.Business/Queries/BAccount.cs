using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Data.DB.Models;
using Jose;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace CQPROJ.Business.Queries
{
    public class BAccount
    {

        public static Object Login(Login requestUser,Uri client)
        {
            try
            {
                using (var db = new DBContextModel())
                {
                    var user = db.TblUsers.Select(x => x).Where(x => x.Email == requestUser.Email).FirstOrDefault();

                    if (user == null || (bool)!user.IsActive)
                    {
                        return null;
                    }

                    var password = new PasswordHasher();
                    if (password.VerifyHashedPassword(user.Password, requestUser.Password).ToString() != "Success")
                    {
                        return null;
                    }

                    byte[] secretKey = Encoding.ASCII.GetBytes("vMDUMFlFl6jUANQZezAu4bAmwBD9IyYl");

                    DateTime issued = DateTime.Now;
                    DateTime expire = DateTime.Now.AddHours(10);
                    var roles = db.TblUserRoles.Where(x => x.UserFK == user.ID).Select(x => x.RoleFK).ToList();

                    List<int> classes = new List<int>();
                    classes = db.TblClassUsers.Where(x => x.UserFK == user.ID).Select(x => x.ClassFK).ToList();
                    if (roles.Contains(5))
                    {
                        foreach (int child in BParenting.GetChildren(user.ID))
                        {
                            classes = classes.Concat(db.TblClassUsers.Where(x => x.UserFK == child).Select(x => x.ClassFK)).ToList();
                        }
                    }

                    Dictionary<string, object> payload = new Dictionary<string, object>(){
                    {"iss",client.Authority },
                    {"aud",user.ID },
                    {"iat",_ToUnixTime(issued).ToString() },
                    {"exp",_ToUnixTime(expire).ToString() },
                    {"rol",roles },
                    {"cla",classes }
                };

                    var token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

                    return new { token = token, userID = user.ID, roles = roles, name = user.Name, photo = user.Photo, classes= classes };
                }
            }
            catch (Exception) { return null; }
        }


        public static Payload ConfirmToken(HttpRequestMessage request)
        {

            Payload payload;
            try
            {
                string token = request.Headers.GetValues("Authorization").First();

                byte[] secretKey = Encoding.ASCII.GetBytes("vMDUMFlFl6jUANQZezAu4bAmwBD9IyYl");
                string decoded = JWT.Decode(token, secretKey, JwsAlgorithm.HS256);

                long date = _ToUnixTime(DateTime.Now);

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                payload = jsSerializer.Deserialize<Payload>(decoded);

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

        private static long _ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
