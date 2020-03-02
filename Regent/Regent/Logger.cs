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
        public async void RecordToLog(string cathegory, string zone, string logMessage)
        {
            try
            {
                await using (var db = new Database.RegistryContext())
                {            
                    db.Add(new Database.Event()
                    {
                        dateTime = DateTime.Now,
                        cathegory = cathegory,
                        location = zone,
                        _event = logMessage,
                        telemetry = new Database.Telemetry()
                        {
                            temperature = 30,
                            humidity = 100,
                            illumination = 200
                        }
                    });
                    db.SaveChanges();
                }
            }
            catch
            {
                ;
            }
        }

        public async void RecordToLog(string errorMsg)
        {
            await using (var db = new Database.RegistryContext())
            {
                try
                {
                    db.Add(new Database.Error()
                    {
                        dateTime = DateTime.Now,
                        _error = errorMsg
                    });
                    db.SaveChanges();
                }
                catch
                {
                    ;
                }
            }
        }
    }
}
