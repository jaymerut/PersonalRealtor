using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RapidAPI.API;
using PersonalRealtor.Network.RapidAPI.Models;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Components.Extensions;
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
            var propertyAdditionalInfoViewModelList = ConvertPropertyDetailsToPropertyAdditionalInfoViewModelList(this.Details);
            //var dropDownViewModel = ConvertPropertyDetailsToDropDownViewModel(lead);

            this.Objects.Add(photoViewModel);
            this.Objects.Add(propertyInfoViewModel);
            foreach(var propertyAdditionalInfoViewModel in propertyAdditionalInfoViewModelList)
            {
                this.Objects.Add(propertyAdditionalInfoViewModel);
            }

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

        private static List<PropertyAdditionalInfoViewModel> ConvertPropertyDetailsToPropertyAdditionalInfoViewModelList(PropertyDetailsProp details)
        {
            var result = new List<PropertyAdditionalInfoViewModel>();

            if (!string.IsNullOrEmpty(details.PropType))
            {
                result.Add(new PropertyAdditionalInfoViewModel
                {
                    Name = "Property Type",
                    Value = details.PropType.Replace("_", " ").ToCapitalize()
                });
            }

            if (details.YearBuilt > 0)
            {
                result.Add(new PropertyAdditionalInfoViewModel
                {
                    Name = "Year Built",
                    Value = details.YearBuilt.ToString()
                });
            }

           if (details.Stories > 0)
            {
                result.Add(new PropertyAdditionalInfoViewModel
                {
                    Name = "Stories",
                    Value = details.Stories.ToString()
                });
            }

            if (!string.IsNullOrEmpty(details.Cooling))
            {
                result.Add(new PropertyAdditionalInfoViewModel
                {
                    Name = "Cooling",
                    Value = details.Cooling
                });
            }

            if (!string.IsNullOrEmpty(details.Heating))
            {
                result.Add(new PropertyAdditionalInfoViewModel
                {
                    Name = "Heating",
                    Value = details.Heating
                });

            }
            
            return result;
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
