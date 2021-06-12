using System;
using Newtonsoft.Json;

namespace PersonalRealtor.Network.RapidAPI.Models
{
    public class AgentListingsRequest
    {
        public long FulfillmentId { get; set; }
        public string Id { get; set; }
        public string AgentId { get; set; }
        public string Type { get; set; }
    }
}
