using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    class ETask
    {
        public int ID { get; set; }

        public string DayOfWeek { get; set; }

        public string Hour { get; set; }

        public bool? Weekly { get; set; }

        public string Description { get; set; }

       

                Secretary = db.TblSecretaries.Select(y => new { y.Id, y.TblUsers.Name, y.TblUsers.Email
    }).Where(y => y.Id == x.SecretaryFK),
                Assistant = db.TblSchAssistants.Select(z => new { z.Id, z.TblUsers.Name, z.TblUsers.Email
}).Where(z => z.Id == x.SchAssistantFK)

    }
}
