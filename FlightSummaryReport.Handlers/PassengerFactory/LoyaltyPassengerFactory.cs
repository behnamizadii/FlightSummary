
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public class LoyaltyPassengerFactory : ProcessDataFactory
    {
        private Passenger _passenger;
        private Route _route;
        public LoyaltyPassengerFactory(Passenger passenger, Route route)
        {
            _passenger = passenger;
            _route = route;
        }
        public override PassengerData GetPassengerData()
        {
            return new LoyaltyPassenger(_passenger, _route);
        }
    }
}
