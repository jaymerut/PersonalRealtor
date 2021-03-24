using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyDetailFeature
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("parent_category")]
        public string ParentCategory { get; set; }
        [JsonProperty("text")]
        public List<string> Text { get; set; }
    }
}
