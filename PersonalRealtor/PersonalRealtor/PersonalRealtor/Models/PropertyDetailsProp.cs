using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalRealtor.Models
{
    public class PropertyDetailsProp
    {
        [JsonProperty("property_id")]
        public string PropertyId { get; set; }
        [JsonProperty("prop_status")]
        public string PropStatus { get; set; }
        [JsonProperty("listing_id")]
        public string ListingId { get; set; }
        [JsonProperty("price")]
        public long? Price { get; set; }
        [JsonProperty("prop_type")]
        public string PropType { get; set; }
        [JsonProperty("list_date")]
        public DateTime ListDate { get; set; }
        [JsonProperty("hoa_fee")]
        public int? HOAFee { get; set; }
        [JsonProperty("list_update")]
        public DateTime ListUpdate { get; set; }
        [JsonProperty("year_built")]
        public int? YearBuilt { get; set; }
        [JsonProperty("listing_status")]
        public string ListingStatus { get; set; }
        [JsonProperty("beds")]
        public int? Beds { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("baths_full")]
        public int? BathsFull { get; set; }
        [JsonProperty("stories")]
        public int? Stories { get; set; }
        /*
        [JsonProperty("schools")]
        public List<School> Schools { get; set; 
        */
        [JsonProperty("heating")]
        public string Heating { get; set; }
        [JsonProperty("cooling")]
        public string Cooling { get; set; }
        [JsonProperty("feature_tags")]
        public List<string> FeatureTags { get; set; }
        [JsonProperty("address")]
        public PropertyDetailAddress Address { get; set; }
        [JsonProperty("features")]
        public List<PropertyDetailFeature> Features { get; set; }
        [JsonProperty("property_history")]
        public List<PropertyDetailHistory> Histories { get; set; }
        [JsonProperty("tax_history")]
        public List<PropertyDetailTax> Taxes { get; set; }
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
        [JsonProperty("building_size")]
        public PropertyDetailsSize BuildingSize { get; set; }
    }
}
