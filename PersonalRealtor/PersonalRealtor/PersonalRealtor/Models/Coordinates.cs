using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public float? Latitude { get; set; }
        [JsonProperty("lon")]
        public float? Longitude { get; set; }
    }
}
