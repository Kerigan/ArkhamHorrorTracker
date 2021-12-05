using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema;
using ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson
{
    public class FileProcessor
    {
        public bool CheckForFile(string path)
        {
            return !((String.IsNullOrWhiteSpace(path))
                || (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                || (!File.Exists(path))
                || (Path.GetExtension(path) != ".json"));
        }

        public List<CardDto> ProcessCardJson(string json)
        {
            if (ValidateJson(json, SchemaTypes.Card, out var inputJsonArray))
                return inputJsonArray
                    .ToObject<List<CardDto>>();
            else
                return null;
        }

        public List<CardDto> ProcessCardJsonFromPath(string path)
        {
            return ProcessCardJson(ReadFile(path));
        }

        public List<CycleDto> ProcessCycleJson(string json)
        {
            if (ValidateJson(json, SchemaTypes.Cycle, out var inputJsonArray))
                return inputJsonArray
                    .ToObject<List<CycleDto>>();
            else
                return null;
        }

        public List<CycleDto> ProcessCycleJsonFromPath(string path)
        {
            return ProcessCycleJson(ReadFile(path));
        }

        public List<PackDto> ProcessPackJson(string json)
        {
            if (ValidateJson(json, SchemaTypes.Pack, out var inputJsonArray))
                return inputJsonArray
                    .ToObject<List<PackDto>>();
            else
                return null;
        }

        public List<PackDto> ProcessPackJsonFromPath(string path)
        {
            return ProcessPackJson(ReadFile(path));
        }

        public string ReadFile(string path)
        {
            if (!CheckForFile(path))
                throw new ArgumentException("Invalid path");

            using (TextReader reader = File.OpenText(path))
            {
                return reader.ReadToEnd();
            }
        }

        private bool ValidateJson(string json, SchemaTypes schemaType, out JArray inputJsonArray)
        {
            // Throw out non-json
            if (String.IsNullOrEmpty(json)
                || !((json.Trim().StartsWith("{") && json.Trim().EndsWith("}")) ||
                    (json.Trim().StartsWith("[") && json.Trim().EndsWith("]"))))
                throw new ArgumentException("Unable to process - Input is not JSON");

            try
            {
                inputJsonArray = JArray.Parse(json);
            }
            catch (Exception e)
            {
                if (e is JsonSerializationException
                    || e is JsonReaderException)
                    throw new ArgumentException("Unable to process - Input does not match schema");
                else
                    throw;
            }

            // Validate input against schema
            //JSchemaGenerator generator = new();
            //JSchema schema = generator.Generate(schemaType);

            JSchema schema = JSchema.Parse(ReadFile(schemaType switch
            {
                SchemaTypes.Card => "./ArkhamDbJson/Schema/Definitions/CardSchema.json",
                SchemaTypes.Cycle => "./ArkhamDbJson/Schema/Definitions/CycleSchema.json",
                SchemaTypes.Pack => "./ArkhamDbJson/Schema/Definitions/PackSchema.json",
                _ => throw new ArgumentException("Invalid schema type")
            }));

            // TODO: Figure out how to add an attribute to handle the dates properly
            if (schema?.Items?.FirstOrDefault()?.Properties != null
                && schema.Items.FirstOrDefault().Properties.Any())
            {
                foreach (var property in schema.Items.First().Properties)
                {
                    if (property.Value.Format == "date-time")
                        property.Value.Format = "date-fullyear";
                }
            }

            if (!inputJsonArray.IsValid(schema))
                throw new ArgumentException("Unable to process - Input does not match schema");

            return true;
        }
    }
}
