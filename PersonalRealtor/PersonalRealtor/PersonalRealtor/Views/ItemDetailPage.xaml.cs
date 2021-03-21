using PersonalRealtor.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PersonalRealtor.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}