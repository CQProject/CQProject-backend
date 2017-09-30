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
        /// <summary>
        /// Número de páginas por role (50 por página) ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("role/pages/{roleid}")]
        public Object Count(int roleid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info = "Não autorizado." };
            }

            var user =  BUser.GetPagesCountByRole(roleid);

            if (user == null)
            {
                return new { result = false, info = "Impossível carregar página." };
            }


            return new { result = true, data = user };
        }

        // GET role/page/:roleid/:pageid
        /// <summary>
        /// Lista os utilizadores com um role específico na página selecionado ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary
        /// ]
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="pageid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("role/page/{roleid}/{pageid}")]
        public Object Page(int roleid, int pageid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null  || (!payload.rol.Contains(3) && !payload.rol.Contains(6)))
            {
                return new { result = false, info="Não autorizado." };
            }

            var users = BUser.GetPageRole(pageid, roleid);

            if (users == null)
            {
                return new { result = false, info= "Impossível carregar página." };
            }
            return new { result = true, data = new { page = pageid, info = users } };
        }

        // GET user/detail/:userid
        /// <summary>
        /// Mostra os detalhes de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary,
        ///     teacher (se for o proprio),
        ///     student (se for o proprio),
        ///     assistant (se for o proprio),
        ///     guardian (se for o proprio ou um educando seu)
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Mostra o perfil básico de um utilizador ||
        /// Autenticação: Sim
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Cria um novo utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary (excepto se tentar criar um secretario ou administrador)
        /// ]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user")]
        public Object Post([FromBody]User user)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || 
                (!payload.rol.Contains(3) && !payload.rol.Contains(6)) || 
                (payload.rol.Contains(3) && (user.RoleID==3 || user.RoleID ==6)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            return BUser.CreateUser(user);
        }

        //POST role
        /// <summary>
        /// Define o role de um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary (excepto se tentar editar um secretario ou administrador)
        /// ]
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("role")]
        public Object AddRole([FromBody]RoleUser role)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||
                (!payload.rol.Contains(3) && !payload.rol.Contains(6)) ||
                (payload.rol.Contains(3) && (role.RoleID == 3 || role.RoleID == 6)))
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
        /// <summary>
        /// Apaga o relaciomento entre um utilizador e um role ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary (excepto se tentar eliminar um secretario ou administrador)
        /// ]
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("role")]
        public Object RemoveRole([FromBody]RoleUser role)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null ||
                (!payload.rol.Contains(3) && !payload.rol.Contains(6)) ||
                (payload.rol.Contains(3) && (role.RoleID == 3 || role.RoleID == 6)))
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
        /// <summary>
        /// Altera o perfil do utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary,
        ///     teacher (se for o proprio),
        ///     assistant (se for o proprio),
        ///     guardian (se for o proprio ou um educando seu)
        /// ]
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("user/profile")]
        public Object Put([FromBody]User user)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null)
            {
                return new { result = false, info = "Não autorizado." };
            }
            if (payload.aud != user.ID || (payload.aud == user.ID && payload.rol.Contains(1)))
            {
                if ((!payload.rol.Contains(3) && !payload.rol.Contains(6)) || (payload.rol.Contains(3) && (user.RoleID == 3 || user.RoleID == 6)))
                {
                    if (!payload.rol.Contains(5) || (payload.rol.Contains(5) && !BParenting.GetChildren(payload.aud).Contains(user.ID)))
                    {
                        return new { result = false, info = "Não autorizado." };
                    }
                }
            }
            if (BUser.EditUser(user))
            {
                return new { result = true };
            }
            return new { result = false, info = "Não foi possível alterar dados do utilizador."};
        }

        // PUT user/activate/:userid
        /// <summary>
        /// Ativa um utilizador ||
        /// Autenticação: Sim
        /// [   
        ///     admin,
        ///     secretary (excepto se tentar ativar um secretario ou administrador)
        /// ]
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("user/activate/{userid}")]
        public Object Activate(int userid)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || 
                (!payload.rol.Contains(3) && !payload.rol.Contains(6)) ||
                (payload.rol.Contains(3) && (BUser.VerifyRole(userid, 3) || BUser.VerifyRole(userid, 6))))
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