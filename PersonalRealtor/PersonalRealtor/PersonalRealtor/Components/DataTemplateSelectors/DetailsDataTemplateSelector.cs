using System;
using PersonalRealtor.ViewModels;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class DetailsDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePhoto { get; set; }
        public DataTemplate DataTemplatePropertyInfo { get; set; }
        public DataTemplate DataTemplatePropertyAdditionalInfo { get; set; }
        public DataTemplate DataTemplateDropDown { get; set; }

        public DetailsDataTemplateSelector()
        {
            DataTemplatePhoto = new DataTemplate(typeof(PhotoViewCell));
            DataTemplatePropertyInfo = new DataTemplate(typeof(PropertyInfoViewCell));
            DataTemplatePropertyAdditionalInfo = new DataTemplate(typeof(PropertyAdditionalInfoViewCell));
            DataTemplateDropDown = new DataTemplate(typeof(DropDownViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is PhotoViewModel)
            {
                return DataTemplatePhoto;
            }
            else if (item is PropertyInfoViewModel)
            {
                return DataTemplatePropertyInfo;
            }
            else if (item is PropertyAdditionalInfoViewModel)
            {
                return DataTemplatePropertyAdditionalInfo;
            }
            else if (item is DropDownViewModel)
            {
                return DataTemplateDropDown;
            }
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
