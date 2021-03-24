using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class Agent
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("agent_id")]
        public string AgentId { get; set; }
    }
}
