using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropDownViewCell : ViewCell
    {
        private DropDownViewModel ViewModel;

        public DropDownViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupDropDownViewCell();
        }

        private void SetupDropDownViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (DropDownViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdateDropDown();
        }

        private void UpdateDropDown()
        {
            LabelName.Text = this.ViewModel.Name;
            SeparatorView.IsVisible = !this.ViewModel.IsExpanded;
        }

        private void DropDown_Tapped(System.Object sender, System.EventArgs e)
        {
            if (this.ViewModel != null && this.ViewModel.Delegate != null)
            {
                this.ViewModel.Delegate.DropDownToggled(!this.ViewModel.IsExpanded, this.ViewModel.DropDownType);
            }
        }
    }
}
