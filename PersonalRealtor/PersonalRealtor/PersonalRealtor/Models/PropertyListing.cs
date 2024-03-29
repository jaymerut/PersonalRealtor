﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyListing
    {
        [JsonProperty("listing_id")]
        public string ListingId { get; set; }
        [JsonProperty("property_id")]
        public string PropertyId { get; set; }
        [JsonProperty("permalink")]
        public string PermaLink { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("list_price")]
        public long? ListPrice { get; set; }
        [JsonProperty("list_date")]
        public DateTime? ListDate { get; set; }
        [JsonProperty("primary_photo")]
        public Photo PrimaryPhoto { get; set; }
        [JsonProperty("description")]
        public PropertyDescription Desc { get; set; }
        [JsonProperty("location")]
        public PropertyLocation Location { get; set; }

        public string GetListPriceString()
        {
            return ListPrice > 0 ? $"${(ListPrice ?? 0).ToString("N0")}" : "";
        }

        public bool IsForSale()
        {
            return Status.ToLower().Equals("for_sale");
        }
        public bool IsForRent()
        {
            return Status.ToLower().Equals("for_rent");
        }
        public bool IsSold()
        {
            return Status.ToLower().Equals("sold");
        }
    }

}
