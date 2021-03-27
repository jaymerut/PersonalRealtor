using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Network.RealtorAPI.Models;
using System.Net.Http;

namespace PersonalRealtor.Network.RealtorAPI.API
{
    public interface IRealtorAPI
    {
        [Post("/realestateagents/api/v3/listings")]
        Task<RealtorListingsResponse> RealtorListings([Body] RealtorListingsRequest request);
    }

}
