using ArkhamHorrorTracker.Database.ArkhamDbJson;
using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Fact]
        public void ProcessJson_should_return_list_carddto_from_core_json()
        {
            var path = Directory.GetFiles("./arkhamdb-json-data/pack/core/", "core.json")?.FirstOrDefault();
            JArray input;
            using (TextReader reader = File.OpenText(path))
            {
                input = JArray.ReadFrom(new JsonTextReader(reader)).ToObject<JArray>();
            }

            CardFileProcessor test = new CardFileProcessor();
            var output = test.ProcessJson(input.ToString());

            output
                .Should()
                .BeOfType<List<CardDto>>();

            output
                .Should()
                .HaveCount(104);
        }
    }
}
