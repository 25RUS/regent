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
            //StorageFolder appFolder = ApplicationData.Current.LocalFolder;
            string outFile = "";

            switch (target)
            {
                case 0:
                    {
                        outFile = "smmrp.log";
                        break;
                    }
                case 1:
                    {
                        outFile = "error.log";
                        break;
                    }
            }

            try
            {
                DateTime D = DateTime.Now;
                string temp = D.ToString() + " scanner_module: " + logMessage + Environment.NewLine;
                temp.Replace("\n", " ");
                //StorageFile logFile = await appFolder.CreateFileAsync(outFile, CreationCollisionOption.OpenIfExists);
                //await FileIO.AppendTextAsync(logFile, temp);
            }
            catch
            {
                ;
            }
        }
    }
}
