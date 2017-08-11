using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public class IEvaluation
    {
        public int ID { get; set; }

        public string Purport { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int ScheduleFK { get; set; }

    }
}
