using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class RealtorListingsData
    {
        [JsonProperty("forSale")]
        public ListingTypeModel ForSale { get; set; }
        [JsonProperty("forRent")]
        public ListingTypeModel ForRent { get; set; }
        [JsonProperty("openHouses")]
        public ListingTypeModel OpenHouses { get; set; }
        [JsonProperty("forSold")]
        public ListingTypeModel ForSold { get; set; }
    }
}
