using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PropertyAdditionalInfoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePropertyAdditionalInfo { get; set; }

        public PropertyAdditionalInfoDataTemplateSelector()
        {
            DataTemplatePropertyAdditionalInfo = new DataTemplate(typeof(PropertyAdditionalInfoViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is PropertyAdditionalInfoViewModel)
            {
                return DataTemplatePropertyAdditionalInfo;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
