using System;
using FlightSummaryReport.Entities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace FlightSummaryReport.Handlers.Tests
{
    [TestFixture]
    public class ProcessHandlerTests
    {
        [Test]
        public void ProcessOutput_InputObjectPassed_OutputShouldBeValidObject()
        {
            InputBuilder inputBuilder = new InputBuilder();
            var input = inputBuilder.GenerateInputFlightProceedFalse();

            ProcessHandler processHandler = new ProcessHandler();
            var output = processHandler.ProcessOutput(input);

            Assert.That(output, Is.TypeOf(typeof(Output)));
        }

        [Test]
        public void ProcessOutput_InputObjectWithMissingParameterPassed_OutputShouldBeNull()
        {
            InputBuilder inputBuilder = new InputBuilder();
            var input = inputBuilder.GenerateFaultyInput();

            ProcessHandler processHandler = new ProcessHandler();
            var output = processHandler.ProcessOutput(input);

            Assert.That(output, Is.Null);
        }

        [Test]
        public void ProcessOutput_InputObjectPassedScenario1_OutputShouldBeAccurate()
        {
            InputBuilder inputBuilder = new InputBuilder();
            var input = inputBuilder.GenerateInputFlightProceedFalse();

            ProcessHandler processHandler = new ProcessHandler();
            var output = processHandler.ProcessOutput(input);

            Assert.That(output.Passengers, Is.EqualTo(3));
            Assert.That(output.CostOfFlight, Is.EqualTo(240));
            Assert.That(output.RevenueBeforeDiscount, Is.EqualTo(300));
            Assert.That(output.RevenueAfterDiscount, Is.EqualTo(200));
            Assert.That(output.LoyaltyPointsUsed, Is.EqualTo(0));
            Assert.That(output.Bags, Is.EqualTo(3));
            Assert.That(output.AirlinePassengers, Is.EqualTo(1));
            Assert.That(output.LoyaltyPassengers, Is.EqualTo(1));
            Assert.That(output.GeneralPassengers, Is.EqualTo(1));
            Assert.That(output.CanFlightProceed, Is.EqualTo(false));
        }

        [Test]
        public void ProcessOutput_InputObjectPassedScenario2_OutputShouldBeAccurate()
        {
            InputBuilder inputBuilder = new InputBuilder();
            var input = inputBuilder.GenerateInputFlightProceedTrue();

            ProcessHandler processHandler = new ProcessHandler();
            var output = processHandler.ProcessOutput(input);

            Assert.That(output.Passengers, Is.EqualTo(6));
            Assert.That(output.CostOfFlight, Is.EqualTo(480));
            Assert.That(output.RevenueBeforeDiscount, Is.EqualTo(600));
            Assert.That(output.RevenueAfterDiscount, Is.EqualTo(490));
            Assert.That(output.LoyaltyPointsUsed, Is.EqualTo(10));
            Assert.That(output.Bags, Is.EqualTo(8));
            Assert.That(output.AirlinePassengers, Is.EqualTo(1));
            Assert.That(output.LoyaltyPassengers, Is.EqualTo(4));
            Assert.That(output.GeneralPassengers, Is.EqualTo(1));
            Assert.That(output.CanFlightProceed, Is.EqualTo(true));
        }
    }
}
