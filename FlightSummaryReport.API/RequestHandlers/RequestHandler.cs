using FlightSummaryReport.Entities;
using FlightSummaryReport.Handlers;

namespace FlightSummaryReport.API.RequestHandlers
{
    public class RequestHandler
    {
        private readonly IProcessHandler _processHandler;

        public RequestHandler(IProcessHandler processHandler)
        {
            _processHandler = processHandler;
        }

        public void ProcessInput(Input input)
        {
            _processHandler.ProcessOutput(input);
        }
    }
}