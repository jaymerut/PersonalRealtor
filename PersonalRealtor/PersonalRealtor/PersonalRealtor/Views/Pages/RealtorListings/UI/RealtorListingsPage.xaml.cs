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
using Plugin.Segmented;
using PersonalRealtor.Views.Pages.Details.Composer;

namespace PersonalRealtor.Views.Pages.RealtorListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorListingsPage : ContentPage
    {
        #region - Variables
        private RealtorListingsRequest Request;
        private RealtorAPI RealtorAPI = new RealtorAPI();
        private RealtorListingsResponse Response;
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        public int SelectedSegment;
        #endregion

        #region - Constructors
        public RealtorListingsPage(RealtorListingsRequest request, DataTemplateSelector dataTemplateSelector)
        {
            this.Request = request;
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;
            InitializeComponent();

            SetUpRealtorListingsPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }
        #endregion

        #region - Private Methods
        private void SetUpRealtorListingsPage()
        {
            // Data
            _ = RetrieveRealtorListingsAsync();

            RealtorListingsListView.ItemsSource = Objects;
            RealtorListingsListView.ItemTemplate = this.DataTemplateSelector;

            SelectedSegment = 0;
        }

        // Data Logic
        private async Task RetrieveRealtorListingsAsync()
        {
            var response = await RealtorAPI.RealtorListings(this.Request);
            this.Response = response;

            RetrieveListingsByListingType(ListingType.All);
        }

        private void RetrieveListingsByListingType(ListingType listingType)
        {
            this.Objects.Clear();
            List<PropertyListing> propertyListings = new List<PropertyListing>();
            if (this.Response != null)
            {
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

                foreach (var listing in propertyListings)
                {
                    this.Objects.Add(listing);
                }

                this.ActivityIndicatorListView.IsVisible = false;
            }
        }

        private void SegmentedControl_OnSegmentSelected(System.Object sender, Plugin.Segmented.Event.SegmentSelectEventArgs e)
        {
            this.ActivityIndicatorListView.IsVisible = true;
            var selectedOption = this.SegmentedControl.Children.ToList()[e.NewValue];
            switch(selectedOption.Text)
            {
                case "All":
                    RetrieveListingsByListingType(ListingType.All);
                    break;
                case "For Sale":
                    RetrieveListingsByListingType(ListingType.ForSale);
                    break;
                case "Sold":
                    RetrieveListingsByListingType(ListingType.ForSold);
                    break;
                default:
                    break;
            }
        }

        private void RealtorListingsListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                NavigateToDetails(e.SelectedItem as PropertyListing);
            }
        }

        private void NavigateToDetails(PropertyListing listing)
        {
            _ = Navigation.PushAsync(DetailsUIComposer.MakeDetailsUI(listing.PropertyId));

            RealtorListingsListView.SelectedItem = null;
        }
        #endregion

        #region - Public API
        #endregion
    }
}