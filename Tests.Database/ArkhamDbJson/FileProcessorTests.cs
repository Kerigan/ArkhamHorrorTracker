using ArkhamHorrorTracker.Database.ArkhamDbJson;
using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Tests.Database.ArkhamDbJson.FileProcessorTests
{
    public class ProcessCardJson
    {
        [Fact]
        public void ProcessCardJson_should_error_on_nonjson_input()
        {
            var input = "This is not JSON.";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessCardJson_should_error_on_invalid_json_input_non_array()
        {
            var input = "{ \"Improper\": \"JSON format\" }";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCardJson_should_error_on_invalid_json_input_array()
        {
            var input = "[{ \"Improper\": \"JSON format\" }]";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCardJson_should_return_list_carddto_from_core_json()
        {
            var path = "./arkhamdb-json-data/pack/core/core.json";
            JArray input;
            using (TextReader reader = File.OpenText(path))
            {
                input = JArray.ReadFrom(new JsonTextReader(reader)).ToObject<JArray>();
            }

            FileProcessor test = new FileProcessor();
            var output = test.ProcessCardJson(input.ToString());

            output
                .Should()
                .BeOfType<List<CardDto>>();

            output
                .Should()
                .HaveCount(104);
        }
    }

    public class ProcessCardJsonFromPath
    {
        [Fact]
        public void ProcessCardJsonFromPath_should_error_on_nonjson_input()
        {
            var path = "./ArkhamDbJson/TestFiles/NonJsonTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessCardJsonFromPath_should_error_on_invalid_json_input_non_array()
        {
            var path = "./ArkhamDbJson/TestFiles/NonArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCardJsonFromPath_should_error_on_invalid_json_input_array()
        {
            var path = "./ArkhamDbJson/TestFiles/InvalidArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCardJsonFromPath_should_error_on_invalid_path()
        {
            var input = "This is not a valid path";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessCardJsonFromPath_should_error_on_file_not_found()
        {
            var input = "./this/path/does/not/exist.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCardJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessCardJsonFromPath_should_return_list_carddto_from_core_json()
        {
            var path = "./ArkhamDbJson/TestFiles/core.json";

            FileProcessor test = new FileProcessor();
            var output = test.ProcessCardJsonFromPath(path);

            output
                .Should()
                .BeOfType<List<CardDto>>();

            output
                .Should()
                .HaveCount(104);
        }
    }

    public class ProcessCycleJson
    {
        [Fact]
        public void ProcessCycleJson_should_error_on_nonjson_input()
        {
            var input = "This is not JSON.";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessCycleJson_should_error_on_invalid_json_input_non_array()
        {
            var input = "{ \"Improper\": \"JSON format\" }";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCycleJson_should_error_on_invalid_json_input_array()
        {
            var input = "[{ \"Improper\": \"JSON format\" }]";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCycleJson_should_return_list_CycleDto_from_core_json()
        {
            var path = "./arkhamdb-json-data/cycles.json";
            JArray input;
            using (TextReader reader = File.OpenText(path))
            {
                input = JArray.ReadFrom(new JsonTextReader(reader)).ToObject<JArray>();
            }

            FileProcessor test = new FileProcessor();
            var output = test.ProcessCycleJson(input.ToString());

            output
                .Should()
                .BeOfType<List<CycleDto>>();

            output
                .Should()
                .HaveCount(13);
        }
    }

    public class ProcessCycleJsonFromPath
    {
        [Fact]
        public void ProcessCycleJsonFromPath_should_error_on_nonjson_input()
        {
            var path = "./ArkhamDbJson/TestFiles/NonJsonTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessCycleJsonFromPath_should_error_on_invalid_json_input_non_array()
        {
            var path = "./ArkhamDbJson/TestFiles/NonArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCycleJsonFromPath_should_error_on_invalid_json_input_array()
        {
            var path = "./ArkhamDbJson/TestFiles/InvalidArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessCycleJsonFromPath_should_error_on_invalid_path()
        {
            var input = "This is not a valid path";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessCycleJsonFromPath_should_error_on_file_not_found()
        {
            var input = "./this/path/does/not/exist.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessCycleJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessCycleJsonFromPath_should_return_list_Cycledto_from_core_json()
        {
            var path = "./ArkhamDbJson/TestFiles/cycles.json";

            FileProcessor test = new FileProcessor();
            var output = test.ProcessCycleJsonFromPath(path);

            output
                .Should()
                .BeOfType<List<CycleDto>>();

            output
                .Should()
                .HaveCount(13);
        }
    }

    public class ProcessPackJson
    {
        [Fact]
        public void ProcessPackJson_should_error_on_nonjson_input()
        {
            var input = "This is not JSON.";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessPackJson_should_error_on_invalid_json_input_non_array()
        {
            var input = "{ \"Improper\": \"JSON format\" }";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessPackJson_should_error_on_invalid_json_input_array()
        {
            var input = "[{ \"Improper\": \"JSON format\" }]";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJson(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessPackJson_should_return_list_Packdto_from_core_json()
        {
            var path = "./arkhamdb-json-data/packs.json";
            JArray input;
            using (TextReader reader = File.OpenText(path))
            {
                input = JArray.ReadFrom(new JsonTextReader(reader)).ToObject<JArray>();
            }

            FileProcessor test = new FileProcessor();
            var output = test.ProcessPackJson(input.ToString());

            output
                .Should()
                .BeOfType<List<PackDto>>();

            output
                .Should()
                .HaveCount(75);
        }
    }

    public class ProcessPackJsonFromPath
    {
        [Fact]
        public void ProcessPackJsonFromPath_should_error_on_nonjson_input()
        {
            var path = "./ArkhamDbJson/TestFiles/NonJsonTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input is not JSON");
        }

        [Fact]
        public void ProcessPackJsonFromPath_should_error_on_invalid_json_input_non_array()
        {
            var path = "./ArkhamDbJson/TestFiles/NonArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessPackJsonFromPath_should_error_on_invalid_json_input_array()
        {
            var path = "./ArkhamDbJson/TestFiles/InvalidArrayTest.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJsonFromPath(path);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Unable to process - Input does not match schema");
        }

        [Fact]
        public void ProcessPackJsonFromPath_should_error_on_invalid_path()
        {
            var input = "This is not a valid path";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessPackJsonFromPath_should_error_on_file_not_found()
        {
            var input = "./this/path/does/not/exist.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ProcessPackJsonFromPath(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ProcessPackJsonFromPath_should_return_list_Packdto_from_core_json()
        {
            var path = "./ArkhamDbJson/TestFiles/packs.json";

            FileProcessor test = new FileProcessor();
            var output = test.ProcessPackJsonFromPath(path);

            output
                .Should()
                .BeOfType<List<PackDto>>();

            output
                .Should()
                .HaveCount(75);
        }
    }

    public class ReadFile
    {
        [Fact]
        public void ReadFile_should_error_on_invalid_path()
        {
            var input = "This is not a valid path";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ReadFile(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ReadFile_should_error_on_file_not_found()
        {
            var input = "./this/path/does/not/exist.json";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ReadFile(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ReadFile_should_error_on_failname_without_json_file_extension()
        {
            var input = "./wrong.txt";

            FileProcessor test = new FileProcessor();
            Action action = () => test.ReadFile(input);

            action
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Invalid path");
        }

        [Fact]
        public void ReadFile_should_return_string_on_valid_path()
        {
            var input = "./ArkhamDbJson/TestFiles/ReadFileTestFile.json";
            var expected = "{ \"test\": \"element\" }";

            FileProcessor test = new FileProcessor();
            var output = test.ReadFile(input);

            output
                .Should()
                .BeOfType<string>();

            output
                .Should()
                .Equals(expected);
        }
    }
}
