using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CQPROJ.Business.Queries;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ClassController : ApiController
    {

        // todos os profs, secretarios e admins


        //// GET class/
        //[HttpGet]
        //[Route("class")]
        //public Object Get()
        //{
        //    var classes = new BClass().GetClasses();
        //    return classes;
        //}




        //// GET secretary/:id
        //[HttpGet]
        //[Route("class/{id}")]
        //public Object Get(int id)
        //{
        //    var classByID = new BClass().GetClass(id);
        //    return classByID;
        //}

        // GET class/:id
        /*[HttpGet]
        [Route("class/{id}")]
        public Object Get(int id)
        {
            int[] roles = BAccount.confirmToken(this.Request);

            if (!roles.Contains(3) && !roles.Contains(6) && !roles.Contains(2))
            {
                return new { Result = "Not Great Success - Unauthorized" };

            }

            var classes = new BClass().GetClassesByTeacher(id);
            return classes;
        }*/
    }
}