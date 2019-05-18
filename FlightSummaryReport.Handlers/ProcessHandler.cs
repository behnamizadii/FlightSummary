
using System;
using System.Collections.Generic;
using System.Linq;
using FlightSummaryReport.Entities;
using FlightSummaryReport.Handlers.PassengerFactory;
using FlightSummaryReport.Handlers.Utilities;

namespace FlightSummaryReport.Handlers
{
    public interface IProcessHandler
    {
        Output ProcessOutput(Input input);
    }

    public class ProcessHandler : IProcessHandler
    {

        public Output ProcessOutput(Input input)
        {
            if (!CheckOutputForNullValues(input)) return null;
            var passengerData = ProcessPassengersData(input.Passenger, input.Route);
            if (passengerData == null) return null;

            var output = new Output();
            output.Passengers = input.Passenger.Count;
            output.GeneralPassengers = GetPassengersSum(input.Passenger, MembershipType.general);
            output.LoyaltyPassengers = GetPassengersSum(input.Passenger, MembershipType.loyalty);
            output.AirlinePassengers = GetPassengersSum(input.Passenger, MembershipType.airline);
            output.Bags = GetTotalBags(passengerData);
            output.LoyaltyPointsUsed = GetTotalUsedLoyaltyPoints(passengerData);
            output.CostOfFlight = GetTotalFlightCost(input.Passenger.Count, input.Route.CostToAirline);
            output.RevenueBeforeDiscount = GetRevenueBeforeDiscount(input.Passenger.Count, input.Route.TicketPrice);
            output.RevenueAfterDiscount = GetRevenueAfterDiscount(output.RevenueBeforeDiscount, 
                output.AirlinePassengers, 
                output.LoyaltyPointsUsed, 
                input.Route.TicketPrice);
            output.CanFlightProceed = output.RevenueAfterDiscount> output.CostOfFlight;

            OutputGenerator.GenerateJsonOutput(output);
            //The return output can be processed further for responses to the client
            //It is not implemented due to remain in the scope of the project
            return output;
        }



        #region Helper Methods

        private static double GetRevenueAfterDiscount(double revenueBeforeDiscount, 
            int airlinePassengers, 
            int loyaltyPointsUsed, 
            double ticketPrice)
        {
            return (revenueBeforeDiscount - (airlinePassengers * ticketPrice) - loyaltyPointsUsed);
        }

        private static double GetRevenueBeforeDiscount(int passengerCount, double ticketPrice)
        {
            return passengerCount * ticketPrice;
        }

        private static double GetTotalFlightCost(int passengerCount, double costToAirline)
        {
            return passengerCount * costToAirline;
        }

        private static int GetTotalUsedLoyaltyPoints(List<PassengerProcessedData> passengerData)
        {
            int totalPoints = 0;
            foreach (var item in passengerData)
            {
                totalPoints += item.LoyaltyPointUsed;
            }

            return totalPoints;
        }

        private static int GetTotalBags(List<PassengerProcessedData> passengerData)
        {
            int totalBags = 0;
            foreach (var item in passengerData)
            {
                totalBags += item.Bags;
            }

            return totalBags;
        }

        private static int GetPassengersSum(List<Passenger> inputPassenger, MembershipType membershipType)
        {
            int total = 0;
            foreach (var passenger in inputPassenger)
            {
                if (passenger.MembershipType == membershipType) total++;
            }

            return total;
        }

        public static List<PassengerProcessedData> ProcessPassengersData(List<Passenger> passengers, Route route)
        {
            var passengerProcessedData = new List<PassengerProcessedData>();

            foreach (var passenger in passengers)
            {
                ProcessDataFactory factory = null;
                switch (passenger.MembershipType)
                {
                    case MembershipType.general:
                        factory = new GeneralPassengerFactory(passenger, route);
                        break;
                    case MembershipType.airline:
                        factory = new AirlinePassengerFactory(passenger, route);
                        break;
                    case MembershipType.loyalty:
                        factory = new LoyaltyPassengerFactory(passenger, route);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                PassengerData passengerData = factory.GetPassengerData();
                if (passengerData != null)
                {
                    passengerProcessedData.Add(new PassengerProcessedData()
                    {
                        Bags = passengerData.TotalBags,
                        LoyaltyPointUsed = passengerData.LoyaltyPointUsed,
                        ProcessedRevnue = passengerData.TicketPrice
                    });
                }
            }

            return passengerProcessedData;
        }

        public static bool CheckOutputForNullValues<T>(T obj)
        {
            return typeof(T).GetProperties().All(propertyInfo => propertyInfo.GetValue(obj) != null);
        }

        #endregion
    }


}
