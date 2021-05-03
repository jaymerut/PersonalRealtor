using System;
using PersonalRealtor.Views.Pages.Details.UI;

namespace PersonalRealtor.Views.Pages.Details.Composer
{
    public static class DetailsUIComposer
    {
        public static DetailsPage MakeDetailsUI(string propertyId)
        {
            return new DetailsPage(propertyId);
        }
    }
}
