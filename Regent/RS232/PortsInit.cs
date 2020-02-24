using System.Collections.Generic;
using System.IO.Ports;

namespace Regent.RS232
{
    public class Init
    {
        public void AddPorts()
        {
            Ports.portName.AddRange(SerialPort.GetPortNames());
        }
    }
}