using System;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;
using CQPROJ.Business.Entities.IAccount;
using System.Linq;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school/
        /// <summary>
        /// Mostra todas as escolas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("school/")]
        public Object Get()
        {
            return BSchool.GetSchools();
        }

        // GET school/:schoolID
        /// <summary>
        /// Mostra os detalhes de uma escola
        /// </summary>
        /// <param name="schoolID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("school/{schoolID}")]
        public Object Get(int schoolID)
        {
            return BSchool.GetSchool(schoolID);
        }

        // POST school/
        /// <summary>
        /// Cria uma nova escola
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("school")]
        public Object Post([FromBody]TblSchools school)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || (!payload.rol.Contains(6) && !payload.rol.Contains(3)))
            {
                return new { result = false, info = "Não autorizado." };
            }
            
            if (!BSchool.CreateSchool(school))
            {
                return new { result = false, info = "Não foi possível registar escola" };
            }
            return new { result = true };
        }

        // PUT school/
        /// <summary>
        /// Altera uma escola
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("school")]
        public Object Put([FromBody]TblSchools school)
        {
            Payload payload = BAccount.ConfirmToken(this.Request);

            if (payload == null || !payload.rol.Contains(6))
            {
                return new { result = false, info = "Não autorizado." };
            }

            if (!BSchool.EditSchool(school))
            {
                return new { result = false, info = "Não foi possível editar escola" };
            }
            return new { result = true };
        }
    }
}