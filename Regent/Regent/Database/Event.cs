using System;
using System.Collections.Generic;
using System.Text;

namespace Regent.Database
{
    public class Event
    {
        public Guid id { get; set; }
        public DateTime dateTime { get; set; }
        public string cathegory { get; set; }
        public string location { get; set; }
        public string _event { get; set; }
        public Telemetry telemetry { get; set; }
    }
}
