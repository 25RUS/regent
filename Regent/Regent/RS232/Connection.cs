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
            Handshake = Handshake.RequestToSend            
        };

        private void AddPorts()
        {
            try
            {
                Ports.portName.AddRange(SerialPort.GetPortNames());
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} {e.ToString()}");
            }

        }

        public List<string> Request(string [] command, int devNumber)
        {
            AddPorts();

            List<string> result = new List<string>();
            Ports.p = devNumber;   

            try
            {
                SP.Open();
                for (int i = 0; i < command.Count(); i++)
                {
                    SP.WriteLine(command[i]);
                    Thread.Sleep(500);
                    result.Add(SP.ReadExisting());
                }
                SP.Close();
            }
            catch(Exception e)
            {
                result.Add(e.ToString());
            }
            
            return result;
        }
    }
}
