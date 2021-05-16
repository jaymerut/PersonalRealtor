using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RapidAPI.API;
using PersonalRealtor.Network.RapidAPI.Models;
using PersonalRealtor.ViewModels;
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
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private readonly string PropertyId;
        #endregion

        #region - Constructors
        public DetailsPage(string propertyId, DataTemplateSelector dataTemplateSelector)
        {
            this.PropertyId = propertyId;
            this.DataTemplateSelector = dataTemplateSelector;

            InitializeComponent();

        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrievePropertyListingAsync(this.PropertyId);
            var photoViewModel = ConvertPropertyDetailsToPhotoViewModel(this.Details);
            var propertyInfoViewModel = ConvertPropertyDetailsToPropertyInfoViewModel(this.Details);
            //var propertyAdditionalInfoViewModel = ConvertPropertyDetailsToPropertyAdditionalInfoViewModel(lead);
            //var dropDownViewModel = ConvertPropertyDetailsToDropDownViewModel(lead);

            this.Objects.Add(photoViewModel);
            this.Objects.Add(propertyInfoViewModel);

            SetUpDetailsPage();
        }
        #endregion

        #region - Private Methods
        private void SetUpDetailsPage()
        {

            DetailsListView.ItemTemplate = this.DataTemplateSelector;
            DetailsListView.ItemsSource = this.Objects;

            this.ActivityIndicatorDetails.IsRunning = false;
        }

        private static PhotoViewModel ConvertPropertyDetailsToPhotoViewModel(PropertyDetailsProp details)
        {
            return new PhotoViewModel
            {
                Photos = details.Photos,
                PropStatus = details.PropStatus
            };
        }

        private static PropertyInfoViewModel ConvertPropertyDetailsToPropertyInfoViewModel(PropertyDetailsProp details)
        {
            return new PropertyInfoViewModel
            {
                Address = details.Address,
                Beds = details.Beds,
                BathsFull = details.BathsFull,
                BuildingSize = details.BuildingSize,
                Price = details.Price
            };
        }

        // Data Logic
        private async Task RetrievePropertyListingAsync(string propertyId)
        {
            var response = await RapidAPI.GetPropertyDetails(propertyId);
            this.Details = response.Properties.FirstOrDefault();

            
        }
        #endregion

        #region - Public Methods
        #endregion


    }
}
