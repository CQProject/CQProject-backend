using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities.Payload
{
    public class Payload
    {
        public string iss { get; set; }
        public string aud { get; set; }
        public string cla { get; set; }
        public string rol { get; set; }
        public string iat { get; set; }
        public string exp { get; set; }
    }
}
