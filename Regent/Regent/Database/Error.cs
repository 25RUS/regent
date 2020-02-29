using System;
using System.Collections.Generic;
using System.Text;

namespace Regent.Database
{
    public class Error
    {
        public Guid id { get; set; }
        public DateTime dateTime { get; set; }
        public string _error { get; set; }
    }
}
