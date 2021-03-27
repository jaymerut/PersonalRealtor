using PersonalRealtor.Views;
using PersonalRealtor.Views.Pages.Base;
using PersonalRealtor.Views.Pages.BrowseListings.UI;
using PersonalRealtor.Views.Pages.GeneralInquiry.UI;
using PersonalRealtor.Views.Pages.Main.Composer;
using PersonalRealtor.Views.Pages.Main.UI;
using PersonalRealtor.Views.Pages.Menu;
using PersonalRealtor.Views.Pages.Menu.Composer;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Views.Pages.RealtorListings.Composer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = MakeMainUI();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private MainPage MakeMainUI()
        {
            var main = MainUIComposer.MainUI();
            main.Flyout = MenuUIComposer.MenuUI(MakeMenuOptions(main));
            main.Detail = new PRNavigationPage(new BrowseListingsPage());
            return main;
        }
        private MenuOption<Image>[] MakeMenuOptions(MainPage main)
        {
            return new MenuOption<Image>[] {
                new MenuOption<Image>() {
                    Title = "View Corey Marshall's Listings",
                    Image = new Image() { Source = "icon_about.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(RealtorListingsUIComposer.MakeRealtorListingsUI());
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Browse Homes",
                    Image = new Image() { Source = "icon_about.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(new BrowseListingsPage());
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "General Inquiry",
                    Image = new Image() { Source = "icon_about.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(new GeneralInquiryPage());
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Chat With Your Realtor!",
                    Image = new Image() { Source = "icon_about.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(new RealtorChatPage());
                        main.IsPresented = false;
                    }
                }
            };
        }
    }
}
