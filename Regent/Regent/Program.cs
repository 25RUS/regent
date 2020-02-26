using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Regent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RS232.Init pI = new RS232.Init();
            pI.AddPorts();

            //Console.WriteLine(RS232.Ports.portName[0]);
        }
    }
}
