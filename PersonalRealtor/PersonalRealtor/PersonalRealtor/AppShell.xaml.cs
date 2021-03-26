using PersonalRealtor.ViewModels;
using PersonalRealtor.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PersonalRealtor.Views.Pages.RealtorListings.Composer;

namespace PersonalRealtor
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            if (sender == this.BrowseListings)
            {
                await Navigation.PushModalAsync(RealtorListingsUIComposer.MakeRealtorListingsUI());
            }
            else if (sender == this.BrowseHomes)
            {
                // Add Navigation
            }
            else if (sender == this.RealtorChat)
            {
                // Add Navigation
            }
            else if (sender == this.GeneralInquiry)
            {
                // Add Navigation
            }
            else if (sender == this.SavedHomes)
            {
                // Add Navigation
            }
        }
    }
}
