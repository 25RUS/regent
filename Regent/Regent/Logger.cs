using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Regent
{
    class Logger
    {
        public async void RecordToLog(string logMessage, int target)
        {
            string logFolder = "Log";
            if(!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
            string outFile = "";

            switch (target)
            {
                case 0:
                    {
                        outFile = $"{logFolder}/smmrp.log";
                        break;
                    }
                case 1:
                    {
                        outFile = $"{logFolder}/error.log";
                        break;
                    }
            }

            try
            {
                DateTime D = DateTime.Now;
                string temp = $"{D.ToString()} scanner_module: {logMessage}";
                temp.Replace("\n", " ");
                await File.AppendAllTextAsync(outFile, temp);
            }
            catch
            {
                ;
            }
        }
    }
}
