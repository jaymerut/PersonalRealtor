using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RapidAPI.Models
{
    public class PropertyDetailsResponse
    {
        [JsonProperty("properties")]
        public List<PropertyDetailsProp> Properties { get; set; }
    }
}
