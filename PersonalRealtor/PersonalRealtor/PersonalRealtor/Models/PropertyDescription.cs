using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyDescription
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("sold_date")]
        public DateTime? SoldDate { get; set; }
        [JsonProperty("sold_price")]
        public long? SoldPrice { get; set; }
        [JsonProperty("baths")]
        public int? Baths { get; set; }
        [JsonProperty("beds")]
        public int? Beds { get; set; }
        [JsonProperty("sqft")]
        public int? Sqft { get; set; }
        [JsonProperty("lot_sqft")]
        public long? LotSqft { get; set; }
    }
}
