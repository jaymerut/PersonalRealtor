using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyDetailsData
    {
        [JsonProperty("properties")]
        public List<PropertyDetailsProp> Properties { get; set; }
    }
}
