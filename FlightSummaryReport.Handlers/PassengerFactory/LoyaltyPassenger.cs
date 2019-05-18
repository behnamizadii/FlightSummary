
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public class LoyaltyPassenger : PassengerData
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

        public LoyaltyPassenger(Passenger passenger, Route route)
        {
            _ticketPrice = CalculateCost(route.TicketPrice, passenger.LoyaltyPoints, passenger.UsingLoyaltyPoints);
            _totalBags = GetTotalBag(passenger.HasExtraBag);
            _loyaltyPoints = passenger.UsingLoyaltyPoints ? passenger.LoyaltyPoints : 0;
        }

        public sealed override double CalculateCost(double ticketPrice, int loyaltyPoints, bool isUsingLoyaltyPoints)
        {
            if (isUsingLoyaltyPoints)
            {
                return ticketPrice - loyaltyPoints;
            }

            return ticketPrice;
        }

        public sealed override int GetTotalBag(bool isHavingExtraBag)
        {
            if(isHavingExtraBag)
                return 2;
            return 1;
        }
    }
}
