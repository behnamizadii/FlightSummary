using System;
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Client.Helpers
{
    public static class InputAdapter
    {
        public static Passenger ConvertPassengerAdapter(string passengerStr)
        {
            var input = passengerStr.Split();
            try
            {
                var passenger = new Passenger();

                passenger.MembershipType = Enum.IsDefined(typeof(MembershipType),
                    input[2]) ? 
                    (MembershipType) Enum.Parse(typeof(MembershipType), input[2]): 
                    throw new Exception();
                passenger.PassengerName = input[3];
                passenger.LoyaltyPoints = input[2] == MembershipType.loyalty.ToString() ? int.Parse(input[4]) : 0;
                passenger.UsingLoyaltyPoints = input[2] == MembershipType.loyalty.ToString() && bool.Parse(input[5]);
                passenger.HasExtraBag = input[2] == MembershipType.loyalty.ToString() && bool.Parse(input[6]);
                
                return passenger;
            }
            catch (Exception)
            {
                Console.WriteLine(passengerStr + " input is not in correct format!");
                return null;
            }
            
        }

        public static Route ConvertRouteAdapter(string routeStr)
        {
            var input = routeStr.Split();
            try
            {
                return new Route()
                {
                    Origin = input[2],
                    Destination = input[3],
                    CostToAirline = Convert.ToInt32(input[4]),
                    TicketPrice = Convert.ToInt32(input[5])
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Route input is not in correct format!");
                return null;
            }
        }

        public static Aircraft ConvertAircraftAdapter(string aircraftStr)
        {
            var input = aircraftStr.Split();

            try
            {
                return new Aircraft()
                {
                    AircraftModel = input[2],
                    TotalSeats = Convert.ToInt32(input[3])
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Passenger input is not in correct format!");
                return null;
            }
        }
    }
}
