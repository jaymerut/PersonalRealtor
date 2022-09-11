using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Network.RapidAPI.Models;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.RapidAPI.API
{
    public interface IRapidAPI
    {
        [Get("/agents/list?postal_code={postalCode}&name={name}")]
        Task<AgentsListResponse> AgentsList(String postalCode, String name);

        [Get("/agents/get-listings?fulfillment_id={request.fulfillmentId}&id={request.id}&agent_id={request.agentId}&type={request.type}")]
        Task<AgentListingsResponse> GetAgentListings(AgentListingsRequest request);

        [Get("/properties/v2/detail?property_id={propertyId}")]
        Task<PropertyDetailsResponse> GetPropertyDetails(String propertyId);

        [Get("/properties/v2/list-sold")]
        Task<PropertiesListingsSoldResponse> SearchSoldListings(PropertiesListingsSoldRequest request);

        [Get("/properties/v2/list-for-rent")]
        Task<PropertiesListingsForRentResponse> SearchForRentListings(PropertiesListingsForRentRequest request);

        [Get("/properties/v2/list-for_sale")]
        Task<PropertiesListingsForSaleResponse> SearchForSaleListings(PropertiesListingsForSaleRequest request);

        [Get("/locations/auto-complete")]
        Task<LocationsAutoCompleteResponse> GetLocationsAutoComplete(LocationsAutoCompleteRequest request);
    }
}
