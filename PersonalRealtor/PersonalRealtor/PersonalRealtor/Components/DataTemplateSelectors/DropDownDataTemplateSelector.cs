using System;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class DropDownDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplateDropDown { get; set; }

        public DropDownDataTemplateSelector()
        {
            DataTemplateDropDown = new DataTemplate(typeof(DropDownViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
