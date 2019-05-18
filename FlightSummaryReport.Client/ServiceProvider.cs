using System;
using System.Net.Http;
using System.Threading.Tasks;
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Client
{
    public static class ServiceProvider
    {
        static readonly HttpClientHandler Handler = new HttpClientHandler();

        public static async Task GenerateFlightAsync(Input input)
        {
            try
            {
                using (var client = new HttpClient(Handler, false))
                {
                    client.BaseAddress = new Uri("http://localhost:55756/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/InputProcess", input);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Request has been processed Successfully!");
                        Console.WriteLine("Please refer to the generated file in Public folder under User forlder!\n");
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message+"\n");
                throw;
            }
        }
    }
}
