using System;
using System.Collections.Generic;
using System.Text;

namespace Regent.Database
{
    public class Telemetry
    {
        public Guid id { get; set; }
        public int temperature { get; set; }
        public int illumination { get; set; }
        public int humidity { get; set; }
    }
}
