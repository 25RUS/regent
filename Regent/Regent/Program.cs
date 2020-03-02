using System;
using System.IO;
using System.Collections.Generic;

namespace Regent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading REGENT - house remote control system.");

            //test db:
            //TestDb();
        }

        static void TestDb()
        {
            using (var db = new Database.RegistryContext())
            {
                db.Add(new Database.Device()
                {
                    comPort = "COM2",
                    deviceCategory = "arduino",
                    deviceName = "power management tool"
                });
                db.SaveChanges();

                db.Add(new Database.Event()
                {
                    dateTime = DateTime.Now,
                    cathegory = "GREEN",
                    location = "zone - 2",
                    _event = "door closed",
                    telemetry = new Database.Telemetry()
                    {
                        temperature = 30,
                        humidity = 100,
                        illumination = 200
                    }
                });
                db.SaveChanges();

                db.Add(new Database.Error()
                {
                    dateTime = DateTime.Now,
                    _error = "windows works fine!"
                });
                db.SaveChanges();
            }
        }


    }
}
