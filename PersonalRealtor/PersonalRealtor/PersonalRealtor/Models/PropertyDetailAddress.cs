using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyDetailAddress
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("line")]
        public string Line { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("county_needed_for_uniq")]
        public bool CountyNeededForUniq { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("state_code")]
        public string StateCode { get; set; }
        [JsonProperty("address_validation_code")]
        public string AddressValidationCode { get; set; }
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
        [JsonProperty("lat")]
        public float Latitude { get; set; }
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        public string GetCityState()
        {
            return $"{City}, {StateCode} {PostalCode}";
        }
    }
}
