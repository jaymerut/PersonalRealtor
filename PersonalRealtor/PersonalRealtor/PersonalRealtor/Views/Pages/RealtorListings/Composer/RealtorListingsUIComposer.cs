using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Views.Pages.RealtorListings.UI;

namespace PersonalRealtor.Views.Pages.RealtorListings.Composer
{
    public static class RealtorListingsUIComposer
    {
        public static RealtorListingsPage MakeRealtorListingsUI()
        {
            return new RealtorListingsPage();
        }
    }
}
