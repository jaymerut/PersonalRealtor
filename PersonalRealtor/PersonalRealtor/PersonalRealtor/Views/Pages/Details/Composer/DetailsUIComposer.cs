using System;
using System.Collections.ObjectModel;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Models;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.Pages.Details.UI;

namespace PersonalRealtor.Views.Pages.Details.Composer
{
    public static class DetailsUIComposer
    {
        public static DetailsPage MakeDetailsUI(string propertyId)
        {
            var dataTemplateSelector = new DetailsDataTemplateSelector();

            return new DetailsPage(propertyId, dataTemplateSelector);
        }

    }
}
