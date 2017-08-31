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
        [HttpGet]
        [Route("school/")]
        public Object Get()
        {
            return BSchool.GetSchools();
        }

        // GET school/:schoolID
        [HttpGet]
        [Route("school/{schoolID}")]
        public Object Get(int schoolID)
        {
            return BSchool.GetSchool(schoolID);
        }

        // POST school/
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