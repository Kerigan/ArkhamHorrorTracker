using Newtonsoft.Json;

namespace ArkhamHorrorTracker.Database.ArkhamDbJson.Schema.Dto
{
    /// <summary>
    /// arkhamdb-json-data - Card
    /// </summary>
    public class CardDto
    {
        /// Agility value of investigator or number of Agility icons for use in skill checks
        [JsonProperty("agility", NullValueHandling = NullValueHandling.Ignore)]
        public int? Agility { get; set; }

        /// 5 digit card identifier. Consists of two zero-padded numbers: first two digits are the cycle position, last three are position of the card within the cycle (printed on the card).
        [JsonProperty("code")]
        public string Code { get; set; }

        /// Play cost of the card. Relevant for all cards except agendas and titles. May be null - this value is used when the card has a special, possibly variable, cost.
        [JsonProperty("cost", NullValueHandling = NullValueHandling.Ignore)]
        public int? Cost { get; set; }

        [JsonProperty("deck_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? DeckLimit { get; set; }

        /// Investigator only - Special string describing the card options for an investigator. e.g. "faction:guardian:0:5"
        [JsonProperty("deck_options", NullValueHandling = NullValueHandling.Ignore)]
        public DeckOptionDto[] DeckOptions { get; set; }

        /// Investigator only - Special string describing the card requirements for an investigator. e.g. "size:30" "card:01007" "random:subtype:basicweakness"
        [JsonProperty("deck_requirements", NullValueHandling = NullValueHandling.Ignore)]
        public string DeckRequirements { get; set; }

        [JsonProperty("faction_code", NullValueHandling = NullValueHandling.Ignore)]
        public string FactionCode { get; set; }

        [JsonProperty("flavor", NullValueHandling = NullValueHandling.Ignore)]
        public string Flavor { get; set; }

        /// Health of Investigator or Ally Asset
        [JsonProperty("health", NullValueHandling = NullValueHandling.Ignore)]
        public int? Health { get; set; }

        [JsonProperty("illustrator", NullValueHandling = NullValueHandling.Ignore)]
        public string Illustrator { get; set; }

        ///is_unique
        [JsonProperty("is_unique", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsUnique { get; set; }

        /// Lore value of investigator or number of Lore icons for use in skill checks
        [JsonProperty("lore", NullValueHandling = NullValueHandling.Ignore)]
        public int? Lore { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("octgn_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? OctgnId { get; set; }

        [JsonProperty("pack_code")]
        public string PackCode { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// Special string describing what decks this is restricted to e.g. investigaor:01001 will limit it to investigator with id 01001
        [JsonProperty("restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public string Restrictions { get; set; }

        /// Sanity of Investigator or Ally Asset
        [JsonProperty("sanity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Sanity { get; set; }

        /// Asset only - Which item slot it takes up, 1-Handed, 2-Handed, Amulet, Arcane, Ally
        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public string Slot { get; set; }

        /// Strength value of investigator or number of Strength icons for use in skill checks
        [JsonProperty("strength", NullValueHandling = NullValueHandling.Ignore)]
        public int? Strength { get; set; }

        /// Subtype of card, e.g. basicweakness or weakness.
        [JsonProperty("subtype_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SubtypeCode { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("traits", NullValueHandling = NullValueHandling.Ignore)]
        public string Traits { get; set; }

        /// Type of the card. Possible values: "asset", "event", "skill", "treachery", "investigator"
        [JsonProperty("type_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TypeCode { get; set; }

        /// Number of wild icons for use in skill checks
        [JsonProperty("wild", NullValueHandling = NullValueHandling.Ignore)]
        public int? Wild { get; set; }

        /// Will value of investigator or number of Will icons for use in skill checks
        [JsonProperty("will", NullValueHandling = NullValueHandling.Ignore)]
        public int? Will { get; set; }
    }
}
