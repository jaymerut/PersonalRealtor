using System;
using Refit;

namespace PersonalRealtor.Network.RapidAPI.Models {
    public class PropertiesListingsSoldRequest {
        [AliasAs("offset")]
        public int Offset { get; set; }
        [AliasAs("limit")]
        public int Limit { get; set; }
        [AliasAs("city")]
        public string City { get; set; }
        [AliasAs("state_code")]
        public string StateCode { get; set; }

        [AliasAs("postal_code")]
        public string PostalCode { get; set; }
        [AliasAs("sort")]
        public string Sort { get; set; }
        [AliasAs("prop_type")]
        public string PropType { get; set; }
        [AliasAs("radius")]
        public int? Radius { get; set; }
        [AliasAs("baths_min")]
        public int? BathsMin { get; set; }
        [AliasAs("beds_min")]
        public int? BedsMin { get; set; }
        [AliasAs("price_min")]
        public long? PriceMin { get; set; }
        [AliasAs("price_max")]
        public long? PriceMax { get; set; }
        [AliasAs("lot_sqft_min")]
        public int? LotSqftMin { get; set; }
        [AliasAs("lot_sqft_max")]
        public int? LotSqftMax { get; set; }
        [AliasAs("age_min")]
        public int? AgeMin { get; set; }
        [AliasAs("age_max")]
        public int? AgeMax { get; set; }
        [AliasAs("sqft_min")]
        public int? Sqft_Min { get; set; }
        [AliasAs("sqft_max")]
        public int? SqftMax { get; set; }
        [AliasAs("lat_min")]
        public float? LatMin { get; set; }
        [AliasAs("lat_max")]
        public float? LatMax { get; set; }
        [AliasAs("lng_min")]
        public float? LngMin { get; set; }
        [AliasAs("lng_max")]
        public float? LngMax { get; set; }
    }
}
