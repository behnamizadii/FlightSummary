using System.Collections.Generic;
using FlightSummaryReport.Entities;

namespace FlightSummaryReport.Client.Helpers
{
    public class InputRefactor
    {
        private readonly IInputValidator _inputValidator;
        public Input input { get; set; }
        public InputRefactor(IInputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        public bool InputValidator(List<string> inputString)
        {
            var result = _inputValidator.ValidateInputs(inputString);
            if (result) input = _inputValidator.Input;
            return result;
        }
    }
}
