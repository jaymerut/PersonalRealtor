using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class Photo
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
