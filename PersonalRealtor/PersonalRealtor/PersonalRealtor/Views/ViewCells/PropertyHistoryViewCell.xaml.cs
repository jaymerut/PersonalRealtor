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
    public partial class PropertyHistoryViewCell : SelectableViewCell
    {
        private PropertyHistoryViewModel ViewModel;

        public PropertyHistoryViewCell()
        {
            InitializeComponent();

            BindingContext = this;
            SetupPropertyHistoryViewCell();
        }

        private void SetupPropertyHistoryViewCell()
        {

            // BindingContext
            this.BindingContextChanged += (s, e) =>
            {
                BindingContext_Changed(s, e);
            };

        }

        private void BindingContext_Changed(object sender, EventArgs eventArgs)
        {
            this.ViewModel = (PropertyHistoryViewModel)GetValue(BindingContextProperty);
            if (this.ViewModel != null)
                this.UpdatePropertyHistory();
        }

        private void UpdatePropertyHistory()
        {
            this.LabelDate.Text = this.ViewModel.Date?.ToString("MM/dd/yyyy");
            this.LabelEvent.Text = this.ViewModel.EventName;
            this.LabelPrice.Text = this.ViewModel.GetPriceString();
            this.LabelPricePerSqft.Text = this.ViewModel.GetPricePerSqftString();
        }
    }
}
