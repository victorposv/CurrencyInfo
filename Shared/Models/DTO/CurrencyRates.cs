namespace Shared.Models.DTO
{
    public class CurrencyRates
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "exchangerId")]
        public int BankId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "updateTime")]
        public int UpdateTime { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "usd")]
        public Currency USD { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "eur")]
        public Currency EUR { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "rur")]
        public Currency RUR { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "gbp")]
        public Currency GBP { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "chf")]
        public Currency CHF { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "pln")]
        public Currency PLN { get; set; }

        public CurrencyRates() { }
    }
}
 