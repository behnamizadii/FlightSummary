
namespace FlightSummaryReport.Entities
{
    public class Output
    {
        public int Passengers { get; set; }
        public int GeneralPassengers { get; set; }
        public int AirlinePassengers { get; set; }
        public int LoyaltyPassengers { get; set; }
        public int Bags { get; set; }
        public int LoyaltyPointsUsed { get; set; }
        public double CostOfFlight { get; set; }
        public double RevenueBeforeDiscount { get; set; }
        public double RevenueAfterDiscount { get; set; }
        public bool CanFlightProceed { get; set; }
    }
}
