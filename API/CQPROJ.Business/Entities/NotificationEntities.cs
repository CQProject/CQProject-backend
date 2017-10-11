using System;

namespace CQPROJ.Business.Entities
{
    public class NotificationUser
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public Boolean Urgency { get; set; }
        public Boolean Approval { get; set; }
        public int SenderFK { get; set; }
        public int ReceiverFK { get; set; }
        public int StudentFK { get; set; }
    }

    public class NotificationClass
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public Boolean Urgency { get; set; }
        public Boolean Approval { get; set; }
        public int SenderFK { get; set; }
        public int ClassFK { get; set; }
    }
}
