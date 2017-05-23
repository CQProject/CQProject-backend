using CQPROJ.Business.Queries;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET student
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET student/:id
        [HttpGet]
        public Object GetStudent(int id)
        {
            var student = new Student().GetStudent(id);
            return student;
        }
    
        // POST student
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}