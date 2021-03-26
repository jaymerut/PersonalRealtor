using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PersonalRealtor.Network.RealtorAPI;
using PersonalRealtor.Models;

namespace PersonalRealtor.Views.Pages.RealtorListings.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealtorListingsPage : ContentPage
    {
        private List<RealtorListingsData> Listings;
        public RealtorListingsPage(List<RealtorListingsData> listings)
        {
            this.Listings = listings;
            InitializeComponent();
        }
    }
}