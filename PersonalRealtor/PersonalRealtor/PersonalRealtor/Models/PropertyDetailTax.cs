using System;
using Newtonsoft.Json;

namespace PersonalRealtor.Models
{
    public class PropertyDetailTax
    {
        [JsonProperty("assessment")]
        public PropertyDetailAssessment Assessment { get; set; }
        [JsonProperty("tax")]
        public int? Tax { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
    }
}
