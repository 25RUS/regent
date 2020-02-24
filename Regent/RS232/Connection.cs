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
        string  portName {get; set;}
        SerialPort SP = new SerialPort(portName)
        {
            SP.BaudRate = 9600,
            SP.Parity = Parity.None,
            SP.StopBits = StopBits.One,
            SP.DataBits = 8,
            SP.Handshake = Handshake.None            
        };

        Request(string pName, string command)
        {        
            portName = pName;    
            SP.Open();
            SP.WriteLine(command);
            Thread.Sleep(500);
            string result = SP.ReadExisting();
            SP.Close();
            return result;
        }
    }
}
