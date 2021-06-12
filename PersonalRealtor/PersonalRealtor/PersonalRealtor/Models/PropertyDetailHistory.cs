using System;
using Newtonsoft.Json;

namespace PersonalRealtor.Models
{
    public class PropertyDetailHistory
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("price")]
        public long? Price { get; set; }
        [JsonProperty("sqft")]
        public int? Sqft { get; set; }
        [JsonProperty("datasource_name")]
        public string DataSourceName { get; set; }
    }
    
}
