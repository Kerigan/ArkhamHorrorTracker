using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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
            throw new NotImplementedException();
        }

        public List<Card> ProcessJson(string json)
        {
            // Throw out non-json
            if (String.IsNullOrEmpty(json)
                || !((json.Trim().StartsWith("{") && json.Trim().EndsWith("}")) ||
                    (json.Trim().StartsWith("[") && json.Trim().EndsWith("]"))))
                throw new ArgumentException("Unable to process - Input is not JSON");

            JObject inputJson;
            List<Card> results = new List<Card>();

            try
            {
                inputJson = JObject.Parse(json);
            }
            catch (JsonSerializationException e)
            {
                throw new ArgumentException("Input does not match Card schema");
            }
            catch
            {
                throw;
            }

            // Validate input against schema
            // TODO: This shouldn't be a hard-coded location
            using (TextReader reader = File.OpenText(@"C:\Code\ArkhamHorrorTracker\Database\arkhamdb-json-data\schema\card_schema.json"))
            {
                JsonSchema schema = JsonSchema.Read(new JsonTextReader(reader));

                if (!inputJson.IsValid(schema))
                    throw new ArgumentException("Input does not match Card schema");
            }

            return results;
        }
    }
}
