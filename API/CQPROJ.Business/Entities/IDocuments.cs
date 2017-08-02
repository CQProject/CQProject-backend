using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public class Document
    {
        public int ID { get; set; }

        public string File { get; set; }

        public Boolean IsVisible { get; set; }

        public DateTime SubmitedIn { get; set; }

        public int ClassFK { get; set; }

        public int UserFK { get; set; }
    }
}
