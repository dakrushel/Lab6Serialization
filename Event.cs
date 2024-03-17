using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Serialization
{
    [Serializable]
    public class Event
    {
        public int EventNumber { get; set; }
        public string Location { get; set; }
        public string EventType { get; set; }

        public Event() { }

        public Event(int eventNumber, string location, string eventType)
        {
            this.EventNumber = eventNumber;
            this.Location = location;
            this.EventType = eventType;
        }

        public override string ToString()
        {
            return $"{EventNumber}" +
                $"\n\n{Location}" +
                $"\n\n{EventType}";
        }
    }

}
