using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public interface IClass
    {
        string SchoolYear { get; set; }
        string Year { get; set; }
        string ClassDesc { get; set; }
        int SchoolFK { get; set; }
    }
}
