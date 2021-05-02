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
using System.Collections.ObjectModel;

namespace PersonalRealtor.Views.Pages.RealtorListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorListingsPage : ContentPage
    {
        private RealtorListingsRequest Request;
        private RealtorAPI RealtorAPI = new RealtorAPI();
        private RealtorListingsResponse Response;
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();

        public RealtorListingsPage(RealtorListingsRequest request, DataTemplateSelector dataTemplateSelector)
        {
            this.Request = request;
            this.DataTemplateSelector = dataTemplateSelector;
            InitializeComponent();

            SetUpRealtorListingsPage();
        }

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrieveRealtorListingsAsync();

        }
        #endregion

        private void SetUpRealtorListingsPage()
        {
            RealtorListingsListView.VerticalOptions = LayoutOptions.FillAndExpand;
            RealtorListingsListView.HorizontalOptions = LayoutOptions.FillAndExpand;
            RealtorListingsListView.SeparatorVisibility = SeparatorVisibility.None;
            //RealtorListingsListView.ItemSelected += OnListViewItemSelected;
            RealtorListingsListView.ItemsSource = Objects;
            RealtorListingsListView.ItemTemplate = this.DataTemplateSelector;
            RealtorListingsListView.HasUnevenRows = true;
            //RealtorListingsListView.ItemAppearing += CarrierLeadListView_ItemAppearingAsync;
        }

        // Data Logic
        private async Task RetrieveRealtorListingsAsync()
        {
            var response = await RealtorAPI.RealtorListings(this.Request);
            this.Response = response;
            var listings = RetrieveListingsByListingType(ListingType.All);

            foreach(var listing in listings)
            {
                this.Objects.Add(listing);
            }

            this.ActivityIndicatorListView.IsVisible = false;
        }

        private List<PropertyListing> RetrieveListingsByListingType(ListingType listingType)
        {
            List<PropertyListing> propertyListings = new List<PropertyListing>();
            switch (listingType)
            {
                case ListingType.All:

                    propertyListings.AddRange(this.Response.Data.ForSale.Results);
                    propertyListings.AddRange(this.Response.Data.ForRent.Results);
                    propertyListings.AddRange(this.Response.Data.ForSold.Results);
                    break;
                case ListingType.ForSale:
                    propertyListings = this.Response.Data.ForSale.Results;
                    break;
                case ListingType.ForRent:
                    propertyListings = this.Response.Data.ForRent.Results;
                    break;
                case ListingType.ForSold:
                    propertyListings = this.Response.Data.ForSold.Results;
                    break;
                default:
                    break;
            }

            return propertyListings;
        }
    }
}