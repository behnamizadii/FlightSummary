
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public class GeneralPassenger : PassengerData
    {
        private double _ticketPrice;
        private int _totalBags;
        private int _loyaltyPoints;

        #region Accessors

        public override double TicketPrice
        {
            get => _ticketPrice;
            set => _ticketPrice = value;
        }

        public override int TotalBags
        {
            get => _totalBags;
            set => _totalBags = value;
        }

        public override int LoyaltyPointUsed
        {
            get => _loyaltyPoints;
            set => _loyaltyPoints = value;
        }

        #endregion

        public GeneralPassenger(Passenger passenger, Route route)
        {
            _ticketPrice = CalculateCost(route.TicketPrice, passenger.LoyaltyPoints, passenger.UsingLoyaltyPoints);
            _totalBags = GetTotalBag(passenger.HasExtraBag);
            _loyaltyPoints = passenger.LoyaltyPoints;
        }

        public sealed override double CalculateCost(double ticketPrice, int loyaltyPoints, bool isUsingLoyaltyPoints)
        {
            return ticketPrice;
        }

        public sealed override int GetTotalBag(bool isHavingExtraBag)
        {
            return 1;
        }


    }
}
