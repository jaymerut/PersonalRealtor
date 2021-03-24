using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Models;

namespace PersonalRealtor.Network.RealtorAPI.Models
{
    public class RealtorListingsResponse
    {
        [JsonProperty("data")]
        public List<RealtorListingsData> Data { get; set; }
    }
}
