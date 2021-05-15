using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Models;
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
        private PropertyDetailsProp Details;
        private readonly string PropertyId;
        #endregion

        #region - Constructors
        public DetailsPage(string propertyId)
        {
            this.PropertyId = propertyId;
            InitializeComponent();

        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrievePropertyListingAsync(this.PropertyId);
            SetUpDetailsPage();
        }
        #endregion

        #region - Private Methods
        private void SetUpDetailsPage()
        {
            
            ImagePhoto.Source = Details.Photos.FirstOrDefault().Href.Replace(".jpg", "-w1020_h770_q90.jpg");
            if (Details.IsForSale())
            {
                LabelBadge.Text = "FOR SALE";
                FrameBadge.BackgroundColor = Color.FromHex("#3D850A");
                this.FrameBadge.IsVisible = true;
            }
            else if (Details.IsForRent())
            {
                LabelBadge.Text = "FOR RENT";
                FrameBadge.BackgroundColor = Color.FromHex("#1C5B99");
                this.FrameBadge.IsVisible = true;
            }
            else if (Details.IsSold())
            {
                LabelBadge.Text = "SOLD";
                FrameBadge.BackgroundColor = Color.Black;
                this.FrameBadge.IsVisible = true;
            }

            LabelStreetAddress.Text = Details.Address.Line;
            LabelPrice.Text = Details.GetListPriceString();
            LabelCityState.Text = Details.Address.GetCityState();

            LabelBed.Text = $"{Details.Beds} beds";
            LabelBath.Text = $"{Details.BathsFull} baths";
            if (Details.BuildingSize != null)
            {
                LabelSqft.Text = $"{(Details.BuildingSize.Size).ToString("N0")} {Details.BuildingSize.Units}";
                LabelSqft.IsVisible = Details.BuildingSize.Size > 0;
            }
            

            LabelBed.IsVisible = Details.Beds > 0;
            LabelBath.IsVisible = Details.BathsFull > 0;
            
        }
        // Data Logic
        private async Task RetrievePropertyListingAsync(string propertyId)
        {
            var response = await RapidAPI.GetPropertyDetails(propertyId);
            this.Details = response.Properties.FirstOrDefault();

            this.ActivityIndicatorDetails.IsRunning = false;
        }
        #endregion

        #region - Public Methods
        #endregion


    }
}
