using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto
{
    public class DeckOptionDto
    {
        [JsonProperty("faction")]
        public string[] Faction { get; set; }

        [JsonProperty("level")]
        public DeckOptionLevelDto Level { get; set; }
    }

    public class DeckOptionLevelDto
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
