using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyAddress
    {
        [JsonProperty("line")]
        public string Line { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state_code")]
        public string StateCode { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("coordinate")]
        public Coordinates Coordinate { get; set; }
    }
}
