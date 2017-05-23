using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET /values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET /values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT /values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE /values/5
        public void Delete(int id)
        {
        }
    }
}
