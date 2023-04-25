using Newtonsoft.Json;

namespace FirehouseSubs.Models
{
    internal class UmbracoLocation
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
    }
}
