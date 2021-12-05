using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto
{
    //[
    //  {
    //    "faction": [
    //      "guardian",
    //      "neutral"
    //    ],
    //    "level": {
    //      "min": 0,
    //      "max": 5
    //    }
    //  },
    //  {
    //    "level": {
    //      "min": 0,
    //      "max": 0
    //    },
    //    "limit": 5,
    //    "error": "You cannot have more than 5 cards that are not Guardian or Neutral"
    //  }
    //]

    public class DeckOptionDto
    {
        [JsonProperty("faction", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Faction { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public DeckOptionLevelDto Level { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }

    public class DeckOptionLevelDto
    {
        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
