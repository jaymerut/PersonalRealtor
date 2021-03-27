using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PersonalRealtor.Network.RealtorAPI;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RealtorAPI.Models;
using PersonalRealtor.Network.RealtorAPI.API;

namespace PersonalRealtor.Views.Pages.RealtorListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorListingsPage : ContentPage
    {
        private RealtorListingsRequest Request;
        private RealtorAPI RealtorAPI = new RealtorAPI();
        private RealtorListingsResponse Response;

        public RealtorListingsPage(RealtorListingsRequest request)
        {
            this.Request = request;
            InitializeComponent();
        }

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrieveLoadDetailsAsync();

            var test = this.Response.Data;
        }
        #endregion

        // Data Logic
        private async Task RetrieveLoadDetailsAsync()
        {

            var response = await RealtorAPI.RealtorListings(this.Request);
            this.Response = response;
        }
    }
}