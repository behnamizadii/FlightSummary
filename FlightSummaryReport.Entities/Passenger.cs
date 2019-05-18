using System.ComponentModel.DataAnnotations;

namespace FlightSummaryReport.Entities
{
    public class Passenger
    {

        public string PassengerId { get; set; }
        [Required]
        public string PassengerName { get; set; }
        [Required]
        public MembershipType MembershipType { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool UsingLoyaltyPoints { get; set; }
        public bool HasExtraBag { get; set; }
    }

    public enum MembershipType
    {
        general,
        loyalty,
        airline
    }
}
