using System;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class DropDownDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplateDropDown { get; set; }

        public DropDownDataTemplateSelector()
        {

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
