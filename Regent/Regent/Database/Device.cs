using System;
using System.Collections.Generic;
using System.Text;

namespace Regent.Database
{
    public class Device
    {
        public Guid id { get; set; }
        public string comPort { get; set; }
        public string deviceCategory { get; set; }
        public string deviceName { get; set; }
    }
}
