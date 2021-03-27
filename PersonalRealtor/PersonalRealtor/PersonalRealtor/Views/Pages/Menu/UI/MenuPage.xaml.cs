using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.Pages.Menu.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        public MenuOption<Image>[] Options { get; private set; }

        public MenuPage(MenuOption<Image>[] options)
        {
            InitializeComponent();

            Options = options;

            BindingContext = this;
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            if (e.Item is MenuOption<Image> option) { } else { return; }

            option.Action?.Invoke();

            if (sender is ListView listView) listView.SelectedItem = null;
        }
    }
}
