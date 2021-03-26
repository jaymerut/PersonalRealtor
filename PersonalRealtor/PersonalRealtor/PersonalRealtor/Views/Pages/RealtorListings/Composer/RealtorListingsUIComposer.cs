using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Views.Pages.RealtorListings.UI;
using PersonalRealtor.Network.RealtorAPI.API;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RealtorAPI.Models;

namespace PersonalRealtor.Views.Pages.RealtorListings.Composer
{
    public static class RealtorListingsUIComposer
    {
        public static RealtorListingsPage MakeRealtorListingsUI()
        {
            RealtorListingsRequest request = new RealtorListingsRequest();
            RealtorAPIAdapter adapter = new RealtorAPIAdapter(request);
            var listings = adapter.RetrieveRealtorListingsData();
            return new RealtorListingsPage(listings);
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

        public List<RealtorListingsData> RetrieveRealtorListingsData()
        {
            var response = this.API.RealtorListings(this.Request).Result;
            return response.Data;
        }

    }
}
