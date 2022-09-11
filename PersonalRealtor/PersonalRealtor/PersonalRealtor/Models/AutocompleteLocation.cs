using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PersonalRealtor.Models {
    public class AutocompleteLocation {
        [JsonProperty("area_type")]
        public string AreaType { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state_code")]
        public string StateCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public enum AreaType {
        [Description("school")]
        School,
        [Description("neighborhood")]
        Neighborhood,
        [Description("school_district")]
        SchoolDistrict,
        [Description("city")]
        City,
        [Description("postal_code")]
        PostalCode,
        [Description("address")]
        Address
    }
}
