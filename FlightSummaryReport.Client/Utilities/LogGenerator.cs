using System;
using System.IO;

namespace FlightSummaryReport.Client.Utilities
{
    public static class LogGenerator
    {
        public static void GenerateLog(Exception e)
        {
            //There are better practices in real life project for generating a ticket
            //Here for simplicity it is done using random generator

            Random rnd = new Random();
            var ticket = rnd.Next(100000, 999999);

            Console.WriteLine("Something went wrong while processing request!" +
                              "if the issue persist, contact support team provide them the issue Number:{0}.\n", ticket);

            StreamWriter sw = new StreamWriter($@"c:\users\public\log-{ticket}.txt");
            sw.WriteLine(DateTime.Now);
            sw.WriteLine(e.Message);
            sw.WriteLine(e.InnerException);
            sw.WriteLine(e.Source);
            sw.WriteLine(e.StackTrace);
            sw.Close();

            //A log file should be created in the users\public folder
        }
    }
}
