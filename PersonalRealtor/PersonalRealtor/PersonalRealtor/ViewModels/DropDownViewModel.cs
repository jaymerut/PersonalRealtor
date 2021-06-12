using System;
namespace PersonalRealtor.ViewModels
{
    public interface IDropDownDelegate
    {
        void DropDownToggled(bool isExpanded, DropDownType dropDownType);
    }
    public class DropDownViewModel
    {
        public string Name { get; set; }
        public DropDownType DropDownType { get; set; }
        public bool IsExpanded { get; set; }
        public IDropDownDelegate Delegate { get; set; }

        public DropDownViewModel()
        {
        }

        
    }

    public enum DropDownType
    {
        PROPERTY_FEATURES,
        PROPERTY_HISTORY,
        PROPERTY_TAX,
        SCHOOLS
    }
}
