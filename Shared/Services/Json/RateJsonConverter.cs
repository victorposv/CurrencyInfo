using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shared.Services.Json
{
    public class RateJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var rawValue = serializer.Deserialize(reader);
            float converted = float.NaN;
            float.TryParse(rawValue.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out converted);
            return converted;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
