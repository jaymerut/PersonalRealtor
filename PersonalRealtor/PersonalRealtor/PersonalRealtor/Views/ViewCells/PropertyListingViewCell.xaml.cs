using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyListingViewCell : ViewCell
    {
        public PropertyListingViewCell()
        {
            InitializeComponent();

            // BindingContext
            this.BindingContextChanged += (s, e) => {
                BindingContext_Changed(s, e);
            };
        }

        // Display Logic
        private void UpdateListing(PropertyListing listing)
        {
            LabelPrice.Text = listing.Status.ToLower().Equals("sold") ? listing.Desc.SoldPrice.ToString() : listing.ListPrice.ToString();
            ImagePhoto.Source = listing.PrimaryPhoto.Href.Replace(".jpg", "-w1020_h770_q90.jpg");
        }

        // UIRespondersß
        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            var listing = (PropertyListing)GetValue(BindingContextProperty);
            if (listing != null)
                UpdateListing(listing);
        }
    }
}
