using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalRealtor.Network.RapidAPI.API;
using PersonalRealtor.Network.RapidAPI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.Details.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        #region - Variables
        private RapidAPI RapidAPI = new RapidAPI();
        private PropertyDetailsResponse Response;
        private readonly string PropertyId;
        #endregion

        #region - Constructors
        public DetailsPage(string propertyId)
        {
            this.PropertyId = propertyId;
            InitializeComponent();

            SetUpDetailsPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrievePropertyListingAsync(this.PropertyId);
        }
        #endregion

        #region - Private Methods
        private void SetUpDetailsPage()
        {

        }
        // Data Logic
        private async Task RetrievePropertyListingAsync(string propertyId)
        {
            var response = await RapidAPI.GetPropertyDetails(propertyId);
            this.Response = response;
        }
        #endregion

        #region - Public Methods
        #endregion


    }
}
