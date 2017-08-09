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
        public int aud { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }
        public int[] rol { get; set; }
        public int[] cla { get; set; }
    }
}
