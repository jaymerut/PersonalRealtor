using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RealtorAPI.Models
{
    public class RealtorListingsRequest
    {
        [JsonProperty("fulfillment_ids")]
        public List<int> FulfillmentIds { get; set; }
        [JsonProperty("agents")]
        public List<Agent> Agents { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
