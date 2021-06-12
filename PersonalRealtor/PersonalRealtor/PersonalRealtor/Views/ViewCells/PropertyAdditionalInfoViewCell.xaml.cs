using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Controls;
using PersonalRealtor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyAdditionalInfoViewCell : SelectableViewCell
    {
        private PropertyAdditionalInfoViewModel ViewModel;

        public PropertyAdditionalInfoViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPropertyAdditionalInfoViewCell();
        }

        private void SetupPropertyAdditionalInfoViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PropertyAdditionalInfoViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePropertyAdditionalInfo();
        }

        private void UpdatePropertyAdditionalInfo()
        {
            LabelName.Text = this.ViewModel.Name;
            LabelValue.Text = this.ViewModel.Value;
        }
    }
}
