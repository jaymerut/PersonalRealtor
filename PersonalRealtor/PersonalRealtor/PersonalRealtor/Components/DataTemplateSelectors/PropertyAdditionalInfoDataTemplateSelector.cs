using System;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PropertyAdditionalInfoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePropertyAdditionalInfo { get; set; }

        public PropertyAdditionalInfoDataTemplateSelector()
        {

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
