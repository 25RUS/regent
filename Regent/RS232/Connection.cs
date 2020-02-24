using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Regent.RS232
{
    public class RS232_Connection
    {
        SerialPort SP = new SerialPort(Ports.portName[Ports.p])
        {
            BaudRate = 9600,
            Parity = Parity.None,
            StopBits = StopBits.One,
            DataBits = 8,
            Handshake = Handshake.None            
        };

        public string Request(string pName, string command, int devNumber)
        {     
            Ports.p = devNumber;   
            SP.Open();
            SP.WriteLine(command);
            Thread.Sleep(500);
            string result = SP.ReadExisting();
            SP.Close();
            return result;
        }
    }
}
