namespace Shared.Models.DTO
{
    public class Currency
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "buy")]
        [Newtonsoft.Json.JsonConverter(typeof(Services.Json.RateJsonConverter))]
        public float Purchase { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "sel")]
        [Newtonsoft.Json.JsonConverter(typeof(Services.Json.RateJsonConverter))]
        public float Sell { get; set; }
    }
}
