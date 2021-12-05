using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson
{
    /// <summary>
    /// arkhamdb-json-data - Pack
    /// </summary>
    public class Pack
    {
        /// Identifier of the pack.The acronym of the pack name, with matching case, except for Core Set. Examples: "Core" for Core Set
        [JsonProperty("code")]
        public string Code { get; set; }

        /// Identifier of the cycle the pack belongs to. Must refer to one of the values from cycles' "code". Examples: "core"
        [JsonProperty("cycle_code")]
        public string CycleCode { get; set; }

        /// Properly formatted name of the pack. Examples: "Core Set"
        [JsonProperty("name")]
        public string Name { get; set; }

        /// Number of the pack within the cycle.Examples: 1 for Core Set
        [JsonProperty("position")]
        public int Position { get; set; }

        /// Date when the pack was officially released by FFG.When in doubt, look at the date of the pack release news on FFG's news page. Format of the date is YYYY-MM-DD. May be null - this value is used when the date is unknown. Examples: "2016-10-08" for Core Set
        [JsonProperty("released")]
        public DateTime? Released { get; set; }

        /// Number of different cards in the pack. May be null - this value is used when the pack is just an organizational entity, not a physical pack. Examples: 120 for Core Set
        [JsonProperty("size")]
        public int? Size { get; set; }

        public List<Card> Cards { get; set; }

        public Pack()
        {
            Cards = new List<Card>();
        }
    }
}
