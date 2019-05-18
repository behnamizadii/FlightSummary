using System.ComponentModel.DataAnnotations;

namespace FlightSummaryReport.Entities
{
    public class Route
    {
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public double CostToAirline { get; set; }
        [Required]
        public double TicketPrice { get; set; }
    }
}
