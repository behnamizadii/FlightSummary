using System;
using FlightSummaryReport.Client.Helpers;
using FlightSummaryReport.Entities;
using NUnit.Framework;

namespace FlightSummaryReport.Client.Tests
{
    [TestFixture]
    public class InputAdapterTests
    {
        [Test]
        [TestCase("add passenger airline mark")]
        [TestCase("add passenger general ben")]
        [TestCase("add passenger loyalty amin 100 true true")]
        public void ConvertPassengerAdapter_PassedCorrectFormatInput_ShouldReturnPassengerObject(string passengerStr)
        {
            var result = InputAdapter.ConvertPassengerAdapter(passengerStr);

            Assert.That(result,Is.TypeOf(typeof(Passenger)));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.HasExtraBag, Is.Not.Null);
            Assert.That(result.LoyaltyPoints, Is.Not.Null);
            Assert.That(result.MembershipType, Is.Not.Null);
            Assert.That(result.PassengerName, Is.Not.Null);
            Assert.That(result.UsingLoyaltyPoints, Is.Not.Null);
        }

        [Test]
        [TestCase("add passenger airline amin 100 true true")]
        [TestCase("add passenger general ben 100 true true")]
        public void ConvertPassengerAdapter_PassedNonLoyaltyPassengerInfo_NoExtraBagAndLoyaltyShouldReturn(string passengerStr)
        {
            var result = InputAdapter.ConvertPassengerAdapter(passengerStr);

            Assert.That(result, Is.TypeOf(typeof(Passenger)));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.HasExtraBag, Is.False);
            Assert.That(result.LoyaltyPoints, Is.EqualTo(0));
            Assert.That(result.MembershipType, Is.Not.Null);
            Assert.That(result.PassengerName, Is.Not.Null);
            Assert.That(result.UsingLoyaltyPoints, Is.False);
        }

        [Test]
        [TestCase("add amin 100 true true")]
        [TestCase("add passenger t t t t")]
        [TestCase("t")]
        public void ConvertPassengerAdapter_PassedWrongFormatInput_ShouldReturnNull(string passengerStr)
        {
            var result = InputAdapter.ConvertPassengerAdapter(passengerStr);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("add aircraft Boeing-747 200")]
        [TestCase("add aircraft B 10")]
        [TestCase("add aircraft Boe 0")]
        public void ConvertAircraftAdapter_PassedCorrectFormatInput_ShouldReturnAircrafObject(string aircraftStr)
        {

            var result = InputAdapter.ConvertAircraftAdapter(aircraftStr);

            Assert.That(result, Is.TypeOf(typeof(Aircraft)));
            Assert.That(result.AircraftModel, Is.Not.Null);
            Assert.That(result.TotalSeats, Is.Not.Null);

        }

        [Test]
        [TestCase("add aircraft 200")]
        [TestCase("add aircraft B ")]
        [TestCase("add aircraft 200 QWERTY")]
        [TestCase("")]
        public void ConvertAircraftAdapter_PassedWrongFormatInput_ShouldReturnNull(string aircraftStr)
        {

            var result = InputAdapter.ConvertAircraftAdapter(aircraftStr);

            Assert.That(result, Is.Null);

        }

        [Test]
        [TestCase("add route london shiraz 200 300")]
        [TestCase("add route l s 2 3")]
        public void ConvertRouteAdapter_PassedCorrectFormatInput_ShouldReturnRouteObject(string routeStr)
        {

            var result = InputAdapter.ConvertRouteAdapter(routeStr);

            Assert.That(result, Is.TypeOf(typeof(Route)));
            Assert.That(result.CostToAirline, Is.Not.Null);
            Assert.That(result.Origin, Is.Not.Null);
            Assert.That(result.Destination, Is.Not.Null);
            Assert.That(result.TicketPrice, Is.Not.Null);
        }

        [Test]
        [TestCase("add route london shiraz 300")]
        [TestCase("add route l s 2 ")]
        [TestCase("add route h1 h1 h2 h2")]
        [TestCase("t")]
        public void ConvertRouteAdapter_PassedWrongFormatInput_ShouldReturnNull(string routeStr)
        {

            var result = InputAdapter.ConvertRouteAdapter(routeStr);

            Assert.That(result, Is.Null);

        }
    }
}
