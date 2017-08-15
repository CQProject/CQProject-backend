using System;
using System.Web.Http;
using CQPROJ.Business.Queries;
using CQPROJ.Data.DB.Models;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET school/
        [HttpGet]
        public Object Get()
        {
            return BSchool.GetSchools();
        }

        // GET school/:schoolID
        [HttpGet]
        public Object Get(int? schoolID)
        {
            return BSchool.GetSchool((int)schoolID);
        }

        // POST school/
        [HttpPost]
        public Object Post([FromBody]TblSchools school)
        {
            if (!BSchool.CreateSchool(school))
            {
                return new { result = false, info="Não foi possível registar escola" };
            }
            return new { result = true };
        }

        // PUT school/
        [HttpPut]
        public Object Put([FromBody]TblSchools school)
        {
            if (!BSchool.EditSchool(school))
            {
                return new { result = false, info = "Não foi possível editar escola" };
            }
            return new { result = true };
        }
    }
}