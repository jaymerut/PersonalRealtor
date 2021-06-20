using System;
using MonkeyCache.FileStore;
using PersonalRealtor.ViewModels;

namespace PersonalRealtor.Components.Helpers {
    public class BookmarkHelper {

        private string BarrelKey;

        public BookmarkHelper() {
            this.BarrelKey = $"SavedHomes";
        }

        public bool IsBookmarked(string propertyId) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            return viewModel.SavedPropertyIds.Contains(propertyId.Replace("M", ""));
        }
        public void AddToSavedHomes(string propertyId) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            viewModel.SavedPropertyIds.Add(propertyId.Replace("M", ""));
            Barrel.Current.Add(key: BarrelKey, data: viewModel, expireIn: TimeSpan.FromDays(365));
        }
        public void RemoveFromSavedHomes(string propertyId) {
            var viewModel = Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) != null ? Barrel.Current.Get<SavedHomesViewModel>(key: BarrelKey) : new SavedHomesViewModel();
            viewModel.SavedPropertyIds.Remove(propertyId.Replace("M", ""));
            Barrel.Current.Add(key: BarrelKey, data: viewModel, expireIn: TimeSpan.FromDays(365));
        }
    }
}
