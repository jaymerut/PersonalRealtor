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
using PersonalRealtor.Network.RapidAPI.Models;
using PersonalRealtor.Network.RapidAPI.API;
using MoreLinq;
using MonkeyCache.FileStore;
using Xamarin.Essentials;

namespace PersonalRealtor.Views.Pages.RealtorListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorListingsPage : ContentPage
    {
        #region - Variables
        private List<AgentListingsRequest> RequestList;
        private RapidAPI RapidAPI = new RapidAPI();
        private AgentListingsResponse Response;
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private string BarrelKey = $"RealtorListings-{RealtorSingleton.Instance.FulfillmentIds[0]}";
        public int SelectedSegment;
        #endregion

        #region - Constructors
        public RealtorListingsPage(List<AgentListingsRequest> requestList, DataTemplateSelector dataTemplateSelector)
        {
            this.RequestList = requestList;
            this.DataTemplateSelector = dataTemplateSelector;
            this.BindingContext = this;

            InitializeComponent();

            SetUpRealtorListingsPage();
        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override void OnAppearing() {
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
            if (!Barrel.Current.IsExpired(key: BarrelKey))
            {
                this.Response = Barrel.Current.Get<AgentListingsResponse>(key: BarrelKey);
            }
            else
            {
                List<AgentListingsResponse> responseList = new List<AgentListingsResponse>();

                foreach (AgentListingsRequest request in this.RequestList)
                {
                    var result = await RapidAPI.GetAgentListings(request);
                    responseList.Add(result);
                }

                this.Response = FilterDistinctListingsResponse(responseList);
                Barrel.Current.Add(key: BarrelKey, data: this.Response, expireIn: TimeSpan.FromDays(1));
            }
            

            RetrieveListingsByListingType(ListingType.All);
        }

        private AgentListingsResponse FilterDistinctListingsResponse(List<AgentListingsResponse> responseList)
        {
            AgentListingsResponse response = new AgentListingsResponse()
            {
                Data = new RealtorListingsData()
                {
                    ForSale = new ListingTypeModel()
                    {
                        Results = new List<PropertyListing>()
                    },
                    ForRent = new ListingTypeModel()
                    {
                        Results = new List<PropertyListing>()
                    },
                    ForSold = new ListingTypeModel()
                    {
                        Results = new List<PropertyListing>()
                    }
                }
            };

            List<PropertyListing> ForSaleListings = new List<PropertyListing>();
            List<PropertyListing> ForRentListings = new List<PropertyListing>();
            List<PropertyListing> ForSoldListings = new List<PropertyListing>();

            foreach (AgentListingsResponse agentResponse in responseList)
            {
                ForSaleListings.AddRange(agentResponse.Data.ForSale.Results);
                ForRentListings.AddRange(agentResponse.Data.ForRent.Results);
                ForSoldListings.AddRange(agentResponse.Data.ForSold.Results);

                ForSaleListings = ForSaleListings.DistinctBy(x => x.ListingId).DistinctBy(x => x.PropertyId).ToList();
                ForRentListings = ForRentListings.DistinctBy(x => x.ListingId).DistinctBy(x => x.PropertyId).ToList();
                ForSoldListings = ForSoldListings.DistinctBy(x => x.ListingId).DistinctBy(x => x.PropertyId).ToList();
            }

            // ForSale
            response.Data.ForSale.Results.AddRange(ForSaleListings);
            response.Data.ForSale.Total = ForSaleListings.Count;
            response.Data.ForSale.Count = ForSaleListings.Count;

            // ForRent
            response.Data.ForRent.Results.AddRange(ForRentListings);
            response.Data.ForRent.Total = ForRentListings.Count;
            response.Data.ForRent.Count = ForRentListings.Count;

            // ForSold
            response.Data.ForSold.Results.AddRange(ForSoldListings);
            response.Data.ForSold.Total = ForSoldListings.Count;
            response.Data.ForSold.Count = ForSoldListings.Count;

            return response;
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
                    SelectedSegment = 0;
                    break;
                case "For Sale":
                    RetrieveListingsByListingType(ListingType.ForSale);
                    SelectedSegment = 1;
                    break;
                case "Sold":
                    RetrieveListingsByListingType(ListingType.ForSold);
                    SelectedSegment = 2;
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