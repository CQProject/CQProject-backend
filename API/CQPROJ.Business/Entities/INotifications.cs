using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQPROJ.Business.Entities
{
    public class INotification
    {
        public int ID { get; set; }

        public string Subject { get; set; }

        public DateTime Hour { get; set; }

        public string Description { get; set; }

        public Boolean Urgency { get; set; }

        public int SenderFK { get; set; }

        public int[] ReceiverFK { get; set; }
    }
}
