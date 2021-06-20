using System;
using System.Linq;
using MonkeyCache.FileStore;
using PersonalRealtor.Models;
using PersonalRealtor.ViewModels;

namespace PersonalRealtor.Components.Helpers {
    public class BookmarkHelper {

        private string BarrelKey;

        public BookmarkHelper() {
            this.BarrelKey = $"SavedHomes";
        }

        public bool IsBookmarked(SavedHome savedHome) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            return viewModel.SavedPropertyHomes.Select(x => x).Where(y => y.PropertyId == savedHome.PropertyId).ToList().Count > 0;
        }
        public void AddToSavedHomes(SavedHome savedHome) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            viewModel.SavedPropertyHomes.Add(savedHome);
            Barrel.Current.Add(key: BarrelKey, data: viewModel, expireIn: TimeSpan.FromDays(365));
        }
        public void RemoveFromSavedHomes(SavedHome savedHome) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            var homeToRemove = viewModel.SavedPropertyHomes.Select(x => x).Where(y => y.PropertyId == savedHome.PropertyId).ToList().FirstOrDefault();
            viewModel.SavedPropertyHomes.Remove(homeToRemove);
            Barrel.Current.Add(key: BarrelKey, data: viewModel, expireIn: TimeSpan.FromDays(365));
        }
        public SavedHomesViewModel RetrieveSavedHomes() {
            return Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
        }
        public SavedHome ConvertPropertyListingToSavedHome(PropertyListing propertyListing) {
            return new SavedHome() {
                PropertyId = propertyListing.PropertyId.Replace("M", ""),
                Address = $"{propertyListing.Location.PermaLink.Line}, {propertyListing.Location.PermaLink.GetCityState()}",
                Price = propertyListing.GetListPriceString(),
                Bath = $"{propertyListing.Desc.Baths}",
                Bed = $"{propertyListing.Desc.Beds}",
                Sqft = (propertyListing.Desc.Sqft ?? 0).ToString("N0")
            };
        }
        public SavedHome ConvertPropertyDetailsPropToSavedHome(PropertyDetailsProp propertyDetailsProp) {
            return new SavedHome() {
                PropertyId = propertyDetailsProp.PropertyId.Replace("M", ""),
                Address = $"{propertyDetailsProp.Address.Line}, {propertyDetailsProp.Address.GetCityState()}",
                Price = propertyDetailsProp.Price > 0 ? $"${(propertyDetailsProp.Price ?? 0).ToString("N0")}" : "",
                Bath = $"{propertyDetailsProp.BathsFull}",
                Bed = $"{propertyDetailsProp.Beds}",
                Sqft = $"{propertyDetailsProp.BuildingSize}"
            };
        }
    }
}
