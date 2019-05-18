using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightSummaryReport.Entities
{
    public class Input
    {
        [Required]
        public Route Route { get; set; }
        [Required]
        public Aircraft Aircraft { get; set; }
        [Required]
        public List<Passenger> Passenger { get; set; }
    }
}
