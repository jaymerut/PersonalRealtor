using System;
using Newtonsoft.Json;

namespace PersonalRealtor.Models
{
    public class PropertyDetailAssessment
    {
        [JsonProperty("building")]
        public int? Building { get; set; }
        [JsonProperty("land")]
        public int? Land { get; set; }
        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
