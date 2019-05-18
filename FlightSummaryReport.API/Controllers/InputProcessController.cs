using System.Web.Http;
using FlightSummaryReport.API.RequestHandlers;
using FlightSummaryReport.Entities;
using FlightSummaryReport.Handlers;

namespace FlightSummaryReport.API.Controllers
{
    public class InputProcessController : ApiController
    {
        // POST: api/InputProcess
        public void Post([FromBody]Input input)
        { 
            var requesHandler = new RequestHandler(new ProcessHandler());
            requesHandler.ProcessInput(input);
        }

    }
}
