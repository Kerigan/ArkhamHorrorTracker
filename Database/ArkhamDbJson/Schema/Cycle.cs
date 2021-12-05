using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson
{
    /// <summary>
    /// arkhamdb-json-data - Cycle
    /// </summary>
    public class Cycle
    {
        /// Identifier of the cycle.One single lowercase word.Examples: "core"
        [JsonProperty("code")]
        public string Code { get; set; }

        /// Properly formatted name of the cycle. Examples: "Core Set"
        [JsonProperty("name")]
        public string Name { get; set; }

        /// Number of the cycle, counting in chronological order. For packs released outside of normal constructed play cycles (such as draft packs), the special cycle with position 0 should be used.Examples: 1 for Core Set
        [JsonProperty("position")]
        public int Position { get; set; }

        /// Number of packs in the cycle.Examples: 1 for big boxes, 6 for regular pack cycles.
        [JsonProperty("size")]
        public int Size { get; set; }

        public List<Pack> Packs { get; set; }

        public Cycle()
        {
            Packs = new List<Pack>();
        }
    }
}
