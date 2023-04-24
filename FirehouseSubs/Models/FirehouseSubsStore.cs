using Newtonsoft.Json;
using System.ComponentModel;

namespace FirehouseSubs.Models
{
    public class FirehouseSubsStore
    {
        [JsonProperty(PropertyName = "id")]
        public uint Id { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string AddressPart2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "orderSystemUrl")]
        public string OnlineOrderUrl { get; set; }

        [JsonProperty(PropertyName = "siteId")]
        public string SiteId { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string StoreTitle { get; set; }

        [JsonProperty(PropertyName = "moreInfoUrl")]
        public string MoreInfoUrl { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public uint ZipCode { get; set; }

        [JsonProperty(PropertyName = "hoursOpen")]
        public string HoursOpen { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }

        [JsonProperty(PropertyName = "directionsUrl")]
        public string DirectionsUrl { get; set; }

        [JsonProperty(PropertyName = "isComingSoon")]
        public bool IsComingSoon { get; set; }

        [JsonProperty(PropertyName = "isTempClosed")]
        public bool IsTemporarilyClosed { get; set; }

        [JsonProperty(PropertyName = "isOpen")]
        public bool IsOpen { get; set; }

        [JsonProperty(PropertyName = "hasDeliveryService")]
        public bool HasDeliveryService { get; set; }
    }
}
