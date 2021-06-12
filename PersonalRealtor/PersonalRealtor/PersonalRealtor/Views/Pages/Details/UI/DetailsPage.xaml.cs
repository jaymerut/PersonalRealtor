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
using MonkeyCache.FileStore;

namespace PersonalRealtor.Views.Pages.Details.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage, IDropDownDelegate
    {
        #region - Variables
        private RapidAPI RapidAPI = new RapidAPI();
        private PropertyDetailsProp Details;
        private DataTemplateSelector DataTemplateSelector;
        private ObservableCollection<Object> Objects = new ObservableCollection<Object>();
        private readonly string PropertyId;
        private string BarrelKey;
        #endregion

        #region - Constructors
        public DetailsPage(string propertyId, DataTemplateSelector dataTemplateSelector)
        {
            this.PropertyId = propertyId;
            this.DataTemplateSelector = dataTemplateSelector;
            this.BarrelKey = $"Details1-{propertyId}";
            Barrel.ApplicationId = "DetailsPage";
            InitializeComponent();

        }
        #endregion

        #region - ContentPage Lifecycle Methods
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Data
            await RetrievePropertyListingAsync(this.PropertyId);

            PopulateObjects();

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

        private void PopulateObjects()
        {
            var photoViewModel = ConvertPropertyDetailsToPhotoViewModel(this.Details);
            var propertyInfoViewModel = ConvertPropertyDetailsToPropertyInfoViewModel(this.Details);
            var propertyAdditionalInfoViewModelList = ConvertPropertyDetailsToPropertyAdditionalInfoViewModelList(this.Details);
            var dropDownViewModelList = ConvertPropertyDetailsToDropDownViewModelList();

            this.Objects.Add(photoViewModel);
            this.Objects.Add(propertyInfoViewModel);
            foreach (var propertyAdditionalInfoViewModel in propertyAdditionalInfoViewModelList)
            {
                this.Objects.Add(propertyAdditionalInfoViewModel);
            }
            foreach (var dropDownViewModel in dropDownViewModelList)
            {
                this.Objects.Add(dropDownViewModel);
            }
        }

        private void RefreshPage()
        {
            ObservableCollection<Object> UpdatedObjects = new ObservableCollection<Object>();

            foreach (var obj in this.Objects)
            {
                UpdatedObjects.Add(obj);
                if (obj is DropDownViewModel)
                {
                    if (((DropDownViewModel)obj).IsExpanded)
                    {
                        switch (((DropDownViewModel)obj).DropDownType) {
                            case DropDownType.PROPERTY_FEATURES:
                                foreach (var feature in this.Details.Features)
                                {
                                    UpdatedObjects.Add(new PropertyFeatureViewModel
                                    {
                                        Name = feature.Category,
                                        Text = feature.Text
                                    });
                                }
                                break;
                            case DropDownType.PROPERTY_HISTORY:
                                foreach (var history in this.Details.Histories)
                                {
                                    UpdatedObjects.Add(new PropertyHistoryViewModel
                                    {
                                        EventName = history.EventName,
                                        Date = history.Date,
                                        Price = history.Price,
                                        Sqft = history.Sqft,
                                        DataSourceName = history.DataSourceName
                                    });
                                }
                                break;
                            case DropDownType.PROPERTY_TAX:
                                foreach (var tax in this.Details.Taxes)
                                {
                                    UpdatedObjects.Add(new PropertyTaxViewModel
                                    {
                                        Year = tax.Year,
                                        Taxes = tax.Tax,
                                        Land = tax.Assessment?.Land,
                                        Additions = tax.Assessment?.Building,
                                        Total = tax.Assessment?.Total
                                    });
                                }
                                break;
                            case DropDownType.SCHOOLS:
                                // TODO
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            DetailsListView.ItemsSource = UpdatedObjects;
        }

        private PhotoViewModel ConvertPropertyDetailsToPhotoViewModel(PropertyDetailsProp details)
        {
            return new PhotoViewModel
            {
                Photos = details.Photos,
                PropStatus = details.PropStatus
            };
        }

        private PropertyInfoViewModel ConvertPropertyDetailsToPropertyInfoViewModel(PropertyDetailsProp details)
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

        private List<PropertyAdditionalInfoViewModel> ConvertPropertyDetailsToPropertyAdditionalInfoViewModelList(PropertyDetailsProp details)
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

        private List<DropDownViewModel> ConvertPropertyDetailsToDropDownViewModelList()
        {
            var result = new List<DropDownViewModel>();

            result.Add(new DropDownViewModel
            {
                Name = "Property Features",
                DropDownType = DropDownType.PROPERTY_FEATURES,
                Delegate = this
            });

            result.Add(new DropDownViewModel
            {
                Name = "Property History",
                DropDownType = DropDownType.PROPERTY_HISTORY,
                Delegate = this
            });

            result.Add(new DropDownViewModel
            {
                Name = "Property Tax",
                DropDownType = DropDownType.PROPERTY_TAX,
                Delegate = this
            });

            // TODO: Add Schools In Future Task
            /*
            result.Add(new DropDownViewModel
            {
                Name = "Schools",
                DropDownType = DropDownType.SCHOOLS,
                Delegate = this
            });
            */

            return result;
        }

        // Data Logic
        private async Task RetrievePropertyListingAsync(string propertyId)
        {
            // TODO: Uncomment this when updating Details Model
            /*
            var response = await RapidAPI.GetPropertyDetails(propertyId);
            this.Details = response.Properties.FirstOrDefault();
            */
            if (!Barrel.Current.IsExpired(key: BarrelKey))
            {
                this.Details = Barrel.Current.Get<PropertyDetailsProp>(key: BarrelKey);
            }
            else
            {
                var response = await RapidAPI.GetPropertyDetails(propertyId);
                this.Details = response.Properties.FirstOrDefault();
                Barrel.Current.Add(key: BarrelKey, data: this.Details, expireIn: TimeSpan.FromDays(1));
            }

        }

        #endregion

        #region - Public Methods

        // DropDownDelegate
        public void DropDownToggled(bool isExpanded, DropDownType dropDownType)
        {
            foreach (var obj in this.Objects)
            {
                if (obj is DropDownViewModel)
                {
                    if (((DropDownViewModel)obj).DropDownType == dropDownType)
                    {
                        ((DropDownViewModel)obj).IsExpanded = isExpanded;
                    }
                }
            }

            RefreshPage();
        }
        #endregion


    }
}
