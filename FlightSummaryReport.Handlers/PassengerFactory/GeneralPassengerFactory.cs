
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public class GeneralPassengerFactory : ProcessDataFactory
    {
        private Passenger _passenger;
        private Route _route;
        public GeneralPassengerFactory(Passenger passenger, Route route)
        {
            _passenger = passenger;
            _route = route;
        }
        public override PassengerData GetPassengerData()
        {
            return new GeneralPassenger(_passenger, _route);
        }
    }
}
