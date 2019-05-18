
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public class AirlinePassengerFactory : ProcessDataFactory
    {
        private Passenger _passenger;
        private Route _route;

        public AirlinePassengerFactory(Passenger passenger, Route route)
        {
            _passenger = passenger;
            _route = route;
        }

        public override PassengerData GetPassengerData()
        {
            return new AirlinePassenger(_passenger, _route);
        }
    }
}
