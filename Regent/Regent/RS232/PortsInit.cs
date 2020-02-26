using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Regent.RS232
{
    public class Init
    {
        public void AddPorts()
        {
            try
            {
                Ports.portName.AddRange(SerialPort.GetPortNames());
            }
            catch(Exception e)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} {e.ToString()}");
            }
            
        }
    }
}