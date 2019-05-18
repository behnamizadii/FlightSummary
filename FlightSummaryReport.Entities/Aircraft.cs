using System.ComponentModel.DataAnnotations;

namespace FlightSummaryReport.Entities
{
    public class Aircraft
    {
        [Required]
        public string AircraftModel { get; set; }
        [Required]
        public int TotalSeats { get; set; }
    }
}
