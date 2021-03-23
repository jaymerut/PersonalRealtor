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

        [Get("/properties/v2/detail?property_id={propertyId}")]
        Task<PropertyDetailsResponse> GetPropertyDetails(String propertyId);
    }
}
