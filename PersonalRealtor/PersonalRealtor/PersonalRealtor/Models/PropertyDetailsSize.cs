using System;
using Newtonsoft.Json;

namespace PersonalRealtor.Models
{
    public class PropertyDetailsSize
    {
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("units")]
        public string Units { get; set; }
    }
}
