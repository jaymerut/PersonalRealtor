using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PropertyInfoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePropertyInfo { get; set; }

        public PropertyInfoDataTemplateSelector()
        {
            DataTemplatePropertyInfo = new DataTemplate(typeof(PropertyInfoViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is PropertyInfoViewModel)
            {
                return DataTemplatePropertyInfo;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
