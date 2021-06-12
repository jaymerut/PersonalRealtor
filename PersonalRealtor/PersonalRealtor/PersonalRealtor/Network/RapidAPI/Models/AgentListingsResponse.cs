using System;
using Newtonsoft.Json;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RapidAPI.Models
{
    public class AgentListingsResponse
    {
        [JsonProperty("data")]
        public RealtorListingsData Data { get; set; }
    }
}


