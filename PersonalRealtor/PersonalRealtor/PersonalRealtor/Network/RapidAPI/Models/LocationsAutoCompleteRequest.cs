using System;
using Refit;

namespace PersonalRealtor.Network.RapidAPI.Models {
    public class LocationsAutoCompleteRequest {
        [AliasAs("input")]
        public string Input { get; set; }
    }
}
