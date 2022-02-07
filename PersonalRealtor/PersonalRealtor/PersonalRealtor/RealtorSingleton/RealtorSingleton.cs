using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using PersonalRealtor.Models;
using PersonalRealtor.Views.Pages.RealtorListings.UI;

namespace PersonalRealtor
{
    public sealed class RealtorSingleton
    {
        [JsonProperty("fulfillment_ids")]
        public List<long> FulfillmentIds { get; set; }
        [JsonProperty("agents")]
        public List<Agent> Agents { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("website_url")]
        public string WebsiteURL { get; set; }
        [JsonProperty("primary_color")]
        public string PrimaryColor { get; set; }
        [JsonProperty("secondary_color")]
        public string SecondaryColor { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        RealtorSingleton()
        {
        }
        private static readonly object padlock = new object();
        private static RealtorSingleton instance = null;
        public static RealtorSingleton Instance
        {
            get
            {
                lock (padlock)
                { 
                    if (instance == null)
                    {

                        var assembly = typeof(RealtorListingsPage).GetTypeInfo().Assembly;
                        Stream stream = assembly.GetManifestResourceStream("PersonalRealtor.Realtors.ScottBryant.json");
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            var jsonString = reader.ReadToEnd();

                            instance = JsonConvert.DeserializeObject<RealtorSingleton>(jsonString);
                        }
                    }
                    return instance;
                }
            }
        }
    }
}
