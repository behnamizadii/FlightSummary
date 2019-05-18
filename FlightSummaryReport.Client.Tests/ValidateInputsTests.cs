using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSummaryReport.Client.Helpers;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FlightSummaryReport.Client.Tests
{
    public class InputStrnigBuilder : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new List<string>()
            {
                "add route London Dublin 100 150",
                "add aircraft Gulfstream-G550 8",
                "add passenger airline Trevor",
                "add passenger general Mark",
                "add passenger loyalty Joan 100 FALSE TRUE"
            };
            yield return new List<string>()
            {
                "add route London Dublin 100 150",
                "add aircraft Gulfstream-G550 8",
                "add passenger general Mark",
                "add passenger general Tom",
                "add passenger general James",
                "add passenger airline Trevor",
                "add passenger loyalty Alan 50 FALSE FALSE",
                "add passenger loyalty Susie 40 TRUE FALSE",
                "add passenger loyalty Joan 100 FALSE TRUE",
                "add passenger general Jack"
            };
        }
    }

    [TestFixture]
    public class ValidateInputsTests
    {

        [Test]
        [TestCaseSource(typeof(InputStrnigBuilder))]
        public void ValidateInput_PassCorrectFormatInput_ShouldReturnTrue(List<string> inpuList)
        {
            var inputValidator = new InputRefactor(new InputValidator());

            var result = inputValidator.InputValidator(inpuList);
            
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ValidateInput_PassWrongFormatInput_ShouldReturnFalse()
        {
            var input = new List<string>()
            {
                "add route London Dublin 100 150",
                "add Gulfstream-G550 8",
                "add passenger airline Trevor",
                "add passenger general Mark",
                "add loyalty Joan 100 FALSE TRUE"
            };
            var inputValidator = new InputRefactor(new InputValidator());

            var result = inputValidator.InputValidator(input);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ValidateInput_PassengersExceedPlaneCapacity_ShouldReturnFalse()
        {
            var input = new List<string>()
            {
                "add route London Dublin 100 150",
                "add aircraft Gulfstream-G550 5",
                "add passenger airline Trevor",
                "add passenger general Mark",
                "add passenger loyalty Joan 100 FALSE TRUE",
                "add passenger airline Trevor",
                "add passenger general Mark",
                "add passenger loyalty Joan 100 FALSE TRUE"
            };
            var inputValidator = new InputRefactor(new InputValidator());

            var result = inputValidator.InputValidator(input);

            Assert.That(result, Is.EqualTo(false));
        }


    }
}
