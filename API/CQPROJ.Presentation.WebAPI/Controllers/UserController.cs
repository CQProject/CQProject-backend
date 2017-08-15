using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Linq;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET role/pages/:id
        [HttpGet]
        [Route("role/pages/{roleid}")]
        public Object Count(int roleid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            return new { result = true, data = BUser.GetPagesCountByRole(roleid) };
        }

        // GET role/page/:roleid/:pageid
        [HttpGet]
        [Route("role/page/{roleid}/{pageid}")]
        public Object Page(int roleid, int pageid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null  || payload.rol.Contains(1) || payload.rol.Contains(4) || payload.rol.Contains(5))
            {
                return new { result = false, info="Não autorizado." };
            }

            var assistant = BUser.GetPageRole(pageid, roleid);

            if (assistant == null)
            {
                return new { result = false, info= "Impossível carregar página." };
            }
            return new { result = true, data = new { page = pageid, info = assistant} };
        }

        // GET user/detail/:userid
        [HttpGet]
        [Route("user/detail/{userid}")]
        public Object Detail(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (payload.aud != userid)
            {
                if(!payload.rol.Contains(3) && payload.rol.Contains(6))
                {
                    if(!payload.rol.Contains(5) || (payload.rol.Contains(5) && !BParenting.GetChildren(payload.aud).Contains(userid)))
                    {
                        return new { result = false, info = "Não autorizado." };
                    }
                }
            }
            var user = BUser.GetUserDetails(userid);

            if (user == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }
            return new { result = true, data = user };
        }

        // GET user/profile/:userid
        [HttpGet]
        [Route("user/profile/{userid}")]
        public Object Profile(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }

            var user = BUser.GetUserProfile(userid);

            if (user == null)
            {
                return new { result = false, info = "Utilizador não encontrado." };
            }
            return new { result = true, data = user };
        }

        //POST user/
        [HttpPost]
        [Route("user")]
        public Object Post([FromBody]User user)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BUser.CreateUser(user);
        }

        //POST role
        [HttpPost]
        [Route("role")]
        public Object AddRole([FromBody]RoleUser role)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if(!BUser.AddRole(role.UserID, role.RoleID))
            {
                return new { result = false, info = "Não foi possível atribuir as permissões ao utilizador." };
            }
            return new { result = true };
        }

        //DELETE role
        [HttpDelete]
        [Route("role")]
        public Object RemoveRole([FromBody]RoleUser role)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (!BUser.RemoveRole(role.UserID, role.RoleID))
            {
                return new { result = false, info = "Não foi possível remover as permissões do utilizador." };
            }
            return new { result = true };
        }

        // PUT user/profile/
        [HttpPut]
        [Route("user/profile")]
        public Object Put([FromBody]User editeduser)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (payload.aud != editeduser.ID)
            {
                if (!payload.rol.Contains(3) && payload.rol.Contains(6))
                {
                    if (!payload.rol.Contains(5) || (payload.rol.Contains(5) && !BParenting.GetChildren(payload.aud).Contains(editeduser.ID)))
                    {
                        return new { result = false, info = "Não autorizado." };
                    }
                }
            }
            if (BUser.EditUser(editeduser))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados do utilizador." };
        }

        // PUT user/activate/:userid
        [HttpPut]
        [Route("user/activate/{userid}")]
        public Object Activate(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            if (BUser.ActivateUser(userid))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados do utilizador." };
        }


    }
}