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
    public class CardFileProcessor
    {
        public string ReadFile(string path)
        {
            using (TextReader reader = File.OpenText(@"C:\Code\ArkhamHorrorTracker\Database\arkhamdb-json-data\schema\card_schema.json"))
            {
                throw new NotImplementedException();
            }
        }

        public List<CardDto> ProcessJson(string json)
        {
            // Throw out non-json
            if (String.IsNullOrEmpty(json)
                || !((json.Trim().StartsWith("{") && json.Trim().EndsWith("}")) ||
                    (json.Trim().StartsWith("[") && json.Trim().EndsWith("]"))))
                throw new ArgumentException("Unable to process - Input is not JSON");

            JArray inputJsonArray;

            try
            {
                inputJsonArray = JArray.Parse(json);
            }
            catch (Exception e)
            {
                if (e is JsonSerializationException
                    || e is JsonReaderException)
                    throw new ArgumentException("Unable to process - Input does not match Card schema");
                else
                    throw;
            }

            // Validate input against schema
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(List<CardDto>));

            if (!inputJsonArray.IsValid(schema))
                throw new ArgumentException("Unable to process - Input does not match Card schema");

            return inputJsonArray
                .ToObject<List<CardDto>>();
        }
    }
}
