using ArkhamHorrorTracker.Database.ArkhamDbJson;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Database.ArkhamDbJson
{
    public class CardFileProcessorTests
    {
        [Fact]
        public void ProcessJson_should_error_on_nonjson_input()
        {
            var input = "This is not JSON.";

            CardFileProcessor test = new CardFileProcessor();
            Action action = () => test.ProcessJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessJson_should_error_on_invalid_json_input_non_array()
        {
            var input = "{ \"Improper\": \"JSON format\" }";

            CardFileProcessor test = new CardFileProcessor();
            Action action = () => test.ProcessJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match Card schema");
        }

        [Fact]
        public void ProcessJson_should_error_on_invalid_json_input_array()
        {
            var input = "[{ \"Improper\": \"JSON format\" }]";

            CardFileProcessor test = new CardFileProcessor();
            Action action = () => test.ProcessJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match Card schema");
        }
    }
}
