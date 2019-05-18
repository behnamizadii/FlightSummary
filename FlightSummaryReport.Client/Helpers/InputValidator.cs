using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Client.Helpers
{
    public interface IInputValidator
    {
        Input Input { get; set; }
        bool ValidateInputs(List<string> inputString);
    }
    public class InputValidator : IInputValidator
    {
        public Input Input { get; set; }

        public bool ValidateInputs(List<string> inputString)
        {
            var input = new Input();
            List<Passenger> passengers = new List<Passenger>();
            foreach (var item in inputString)
            {
                if (item.Contains("add route"))
                {
                    input.Route = InputAdapter.ConvertRouteAdapter(item);
                }
                else if (item.Contains("add aircraft"))
                {
                    input.Aircraft = InputAdapter.ConvertAircraftAdapter(item);
                }
                else if (item.Contains("add passenger"))
                {
                    var result = InputAdapter.ConvertPassengerAdapter(item);
                    if (result == null) return false;
                    passengers.Add(result);
                }
                else
                {
                    Console.WriteLine(item + " Is an Invalid Input");
                    return false;
                }
            }
            input.Passenger = passengers;
            this.Input = input;
            return CheckPlaneCapacity(Input) != false && ValidateEntites();
        }

        private bool ValidateEntites()
        {
            if (Input == null) return false;

            var context = new ValidationContext(Input, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(Input, context, results);

            if (isValid) return true;
            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }

            return false;
        }

        private bool CheckPlaneCapacity(Input input)
        {
            var result = input.Passenger.Count <= input.Aircraft.TotalSeats;
            if(!result) Console.WriteLine("Number of passengers exceed the Airplane capacity!\n");
            return result;
        }
    }
}
