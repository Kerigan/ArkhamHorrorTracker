using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson
{
    /// <summary>
    /// arkhamdb-json-data - Card
    /// </summary>
    public class Card
    {
        /// Agility value of investigator or number of Agility icons for use in skill checks
        [JsonProperty("agility")]
        public int? Agility { get; set; }

        /// 5 digit card identifier. Consists of two zero-padded numbers: first two digits are the cycle position, last three are position of the card within the cycle (printed on the card).
        [JsonProperty("code")]
        public string Code { get; set; }

        /// Play cost of the card. Relevant for all cards except agendas and titles. May be null - this value is used when the card has a special, possibly variable, cost.
        [JsonProperty("cost")]
        public int? Cost { get; set; }

        [JsonProperty("deck_limit")]
        public int? DeckLimit { get; set; }

        /// Investigator only - Special string describing the card options for an investigator. e.g. "faction:guardian:0:5"
        [JsonProperty("deck_options")]
        public string DeckOptions { get; set; }

        /// Investigator only - Special string describing the card requirements for an investigator. e.g. "size:30" "card:01007" "random:subtype:basicweakness"
        [JsonProperty("deck_requirements")]
        public string DeckRequirements { get; set; }

        [JsonProperty("faction_code")]
        public string FactionCode { get; set; }

        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        /// Health of Investigator or Ally Asset
        [JsonProperty("health")]
        public int? Health { get; set; }

        [JsonProperty("illustrator")]
        public string Illustrator { get; set; }

        ///is_unique
        [JsonProperty("is_unique")]
        public bool IsUnique { get; set; }

        /// Lore value of investigator or number of Lore icons for use in skill checks
        [JsonProperty("lore")]
        public int? Lore { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("octgn_id")]
        public int? OctgnId { get; set; }

        [JsonProperty("pack_code")]
        public string PackCode { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// Special string describing what decks this is restricted to e.g. investigaor:01001 will limit it to investigator with id 01001
        [JsonProperty("restrictions")]
        public string Restrictions { get; set; }

        /// Sanity of Investigator or Ally Asset
        [JsonProperty("sanity")]
        public int? Sanity { get; set; }

        /// Asset only - Which item slot it takes up, 1-Handed, 2-Handed, Amulet, Arcane, Ally
        [JsonProperty("slot")]
        public string Slot { get; set; }

        /// Strength value of investigator or number of Strength icons for use in skill checks
        [JsonProperty("strength")]
        public int? Strength { get; set; }

        /// Subtype of card, e.g. basicweakness or weakness.
        [JsonProperty("subtype_code")]
        public string SubtypeCode { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("traits")]
        public string Traits { get; set; }

        /// Type of the card. Possible values: "asset", "event", "skill", "treachery", "investigator"
        [JsonProperty("type_code")]
        public string TypeCode { get; set; }

        /// Number of wild icons for use in skill checks
        [JsonProperty("wild")]
        public int? Wild { get; set; }

        /// Will value of investigator or number of Will icons for use in skill checks
        [JsonProperty("will")]
        public int? Will { get; set; }
    }
}
