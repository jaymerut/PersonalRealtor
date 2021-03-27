using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Views.Pages.RealtorListings.UI;
using PersonalRealtor.Network.RealtorAPI.API;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RealtorAPI.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace PersonalRealtor.Views.Pages.RealtorListings.Composer
{
    public static class RealtorListingsUIComposer
    {
        public static RealtorListingsPage MakeRealtorListingsUI()
        {
            RealtorListingsRequest request = new RealtorListingsRequest()
            {
                FulfillmentIds = RealtorSingleton.Instance.FulfillmentIds,
                Agents = RealtorSingleton.Instance.Agents,
                Page = 1,
                Type = "forSold"
            };
            //RealtorAPIAdapter adapter = new RealtorAPIAdapter(request);
            //var data = adapter.RetrieveRealtorListingsDataAsync().Result;
            return new RealtorListingsPage(request);
        }

    }

    public class RealtorAPIAdapter
    {
        private RealtorAPI API;
        private RealtorListingsRequest Request;

        public RealtorAPIAdapter(RealtorListingsRequest request)
        {
            this.API = new RealtorAPI();
            this.Request = request;
        }

        public async Task<RealtorListingsResponse> RetrieveRealtorListingsDataAsync()
        {
            return await this.API.RealtorListings(this.Request);
        }

    }
}
