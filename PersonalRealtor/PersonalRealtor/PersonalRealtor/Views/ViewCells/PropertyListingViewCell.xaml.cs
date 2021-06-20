using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Components.Helpers;
using PersonalRealtor.Controls;
using PersonalRealtor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyListingViewCell : SelectableViewCell
    {
        private PropertyListing PropertyListing;
        private BookmarkHelper BookmarkHelper = new BookmarkHelper();

        public PropertyListingViewCell()
        {
            InitializeComponent();

            // BindingContext
            this.BindingContextChanged += (s, e) => {
                BindingContext_Changed(s, e);
            };
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            Console.WriteLine($"{this.PropertyListing.PropertyId}: Appeared!");
        }

        // Display Logic
        private void UpdateListing(PropertyListing listing)
        {
            this.PropertyListing = listing;

            ImageButtonBookmark.Source = BookmarkHelper.IsBookmarked(BookmarkHelper.ConvertPropertyListingToSavedHome(this.PropertyListing)) ? "bookmark_selected.png" : "bookmark_unselected.png";
            ImageButtonBookmark.IsVisible = !listing.IsSold();
            ImagePhoto.Source = listing.PrimaryPhoto.Href.Replace(".jpg", "-w1020_h770_q90.jpg");
            if (listing.IsForSale())
            {
                LabelBadge.Text = "FOR SALE";
                LabelBadge.TextColor = Color.White;
                FrameBadge.BackgroundColor = Color.FromHex("#3D850A");
            }
            else if (listing.IsForRent())
            {
                LabelBadge.Text = "FOR RENT";
                LabelBadge.TextColor = Color.White;
                FrameBadge.BackgroundColor = Color.FromHex("#1C5B99");
            }
            else if (listing.IsSold())
            {
                LabelBadge.Text = "SOLD";
                LabelBadge.TextColor = Color.Black;
                FrameBadge.BackgroundColor = Color.FromHex("#EAEAEA");
            }

            LabelStreetAddress.Text = listing.Location.PermaLink.Line;
            LabelPrice.Text = listing.IsSold() ? listing.Desc.GetSoldPriceString() : listing.GetListPriceString();
            LabelCityState.Text = listing.Location.PermaLink.GetCityState();

            LabelBed.Text = $"{listing.Desc.Beds} beds";
            LabelBath.Text = $"{listing.Desc.Baths} baths";
            LabelSqft.Text = $"{(listing.Desc.Sqft ?? 0).ToString("N0")} sqft";

            LabelBed.IsVisible = listing.Desc.Beds > 0;
            LabelBath.IsVisible = listing.Desc.Baths > 0;
            LabelSqft.IsVisible = listing.Desc.Sqft > 0;

        }

        // UIResponders
        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            var listing = (PropertyListing)GetValue(BindingContextProperty);
            if (listing != null)
                UpdateListing(listing);
        }

        private void ImageButtonBookmark_Clicked(System.Object sender, System.EventArgs e) {

            if (!BookmarkHelper.IsBookmarked(BookmarkHelper.ConvertPropertyListingToSavedHome(this.PropertyListing))) {
                BookmarkHelper.AddToSavedHomes(BookmarkHelper.ConvertPropertyListingToSavedHome(this.PropertyListing));
                this.ImageButtonBookmark.Source = "bookmark_selected.png";
            } else {
                BookmarkHelper.RemoveFromSavedHomes(BookmarkHelper.ConvertPropertyListingToSavedHome(this.PropertyListing));
                this.ImageButtonBookmark.Source = "bookmark_unselected.png";
            }

        }
    }
}
