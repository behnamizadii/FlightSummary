using System.IO;
using FlightSummaryReport.Entities;
using Newtonsoft.Json;

namespace FlightSummaryReport.Handlers.Utilities
{
    public static class OutputGenerator
    {
        public static void GenerateJsonOutput(Output output)
        {
            File.WriteAllText(@"c:\users\public\FlightOutput.json", JsonConvert.SerializeObject(output));

            using (StreamWriter file = File.CreateText(@"c:\users\public\FlightOutput.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, output);
            }
        }
    }
}
