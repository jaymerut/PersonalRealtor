using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyLocation
    {
        [JsonProperty("address")]
        public PropertyAddress PermaLink { get; set; }
    }
}
