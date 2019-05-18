using System.Collections.Generic;
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Handlers.Tests
{
    public class InputBuilder
    {
        public Passenger Passenger1 => new Passenger()
        {
            MembershipType = MembershipType.airline,
            LoyaltyPoints = 0,
            UsingLoyaltyPoints = false,
            PassengerName = "Mark",
            HasExtraBag = false
        };
        public Passenger Passenger2 => new Passenger()
        {
            MembershipType = MembershipType.general,
            LoyaltyPoints = 0,
            UsingLoyaltyPoints = false,
            PassengerName = "Ben",
            HasExtraBag = false
        };
        public Passenger Passenger3 => new Passenger()
        {
            MembershipType = MembershipType.loyalty,
            LoyaltyPoints = 10,
            UsingLoyaltyPoints = false,
            PassengerName = "Ahmad",
            HasExtraBag = false
        };

        public Passenger Passenger4 => new Passenger()
        {
            MembershipType = MembershipType.loyalty,
            LoyaltyPoints = 10,
            UsingLoyaltyPoints = true,
            PassengerName = "Milad",
            HasExtraBag = false
        };

        public Passenger Passenger5 => new Passenger()
        {
            MembershipType = MembershipType.loyalty,
            LoyaltyPoints = 10,
            UsingLoyaltyPoints = false,
            PassengerName = "Nima",
            HasExtraBag = true
        };
        public Passenger Passenger6 => new Passenger()
        {
            MembershipType = MembershipType.loyalty,
            LoyaltyPoints = 10,
            UsingLoyaltyPoints = false,
            PassengerName = "Alice",
            HasExtraBag = true
        };
        public Aircraft Aircraft => new Aircraft()
        {
            AircraftModel = "boeing-747",
            TotalSeats = 8,
        };

        public Route Route => new Route()
        {
            TicketPrice = 100,
            Destination = "Berlin",
            CostToAirline = 80,
            Origin = "London"
        };

        public List<Passenger> ThreePassengers => new List<Passenger>()
        {
            Passenger1,
            Passenger2,
            Passenger3
        };

        public List<Passenger> SixPassengers => new List<Passenger>()
        {
            Passenger1,
            Passenger2,
            Passenger3,
            Passenger4,
            Passenger5,
            Passenger6
        };

        public Input GenerateInputFlightProceedTrue()
        {
            return new Input()
            {
                Passenger = SixPassengers,
                Route = Route,
                Aircraft = Aircraft
            };
        }

        public Input GenerateInputFlightProceedFalse()
        {
            return new Input()
            {
                Passenger = ThreePassengers,
                Route = Route,
                Aircraft = Aircraft
            }; 
        }

        public Input GenerateFaultyInput()
        {
            return new Input()
            {
                Passenger = ThreePassengers,
                Route = null,
                Aircraft = Aircraft
            };
        }
    }
}