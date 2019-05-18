

namespace FlightSummaryReport.Handlers.PassengerFactory
{
    public abstract class PassengerData
    {
        public abstract double TicketPrice{ get; set; }
        public abstract int TotalBags { get; set; }
        public abstract int LoyaltyPointUsed { get; set; }
        public abstract double CalculateCost(double ticketPrice,int loyaltyPoints, bool isUsingLoyaltyPoints);
        public abstract int GetTotalBag(bool isHavingExtraBag);
    }
}
