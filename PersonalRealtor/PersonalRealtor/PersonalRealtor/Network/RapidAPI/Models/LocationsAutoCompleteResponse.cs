using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RapidAPI.Models {
    public class LocationsAutoCompleteResponse {
        [JsonProperty("autocomplete")]
        public List<AutocompleteLocation> Autocomplete { get; set; }
    }
}
