using System;
using Newtonsoft.Json;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RapidAPI.Models {
    public class PropertiesListingsForRentResponse {
        [JsonProperty("data")]
        public RealtorListingsData Data { get; set; }
    }
}
