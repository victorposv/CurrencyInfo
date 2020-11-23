namespace Shared.Models.DTO
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Bank
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "website")]
        public string Url { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "rates")]
        public CurrencyRates CurrencyRates { get; set; }

        public Bank()
        { }

        public Bank(CurrencyRates rates)
        {
            CurrencyRates = rates;
        }
    }
}
