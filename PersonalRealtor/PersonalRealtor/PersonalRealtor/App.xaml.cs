using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using MonkeyCache.FileStore;
using PersonalRealtor.Cache.AdminLogin;
using PersonalRealtor.Cache.OneSignal;
using PersonalRealtor.Cache.Username;
using PersonalRealtor.Network.Firestore.OneSignal.Repositories.RealtorOneSignal;
using PersonalRealtor.Views.Pages.Base;
using PersonalRealtor.Views.Pages.BrowseListings.Composer;
using PersonalRealtor.Views.Pages.BrowseListings.UI;
using PersonalRealtor.Views.Pages.GeneralInquiry.Composer;
using PersonalRealtor.Views.Pages.Login.Composer;
using PersonalRealtor.Views.Pages.Main.Composer;
using PersonalRealtor.Views.Pages.Main.UI;
using PersonalRealtor.Views.Pages.Menu;
using PersonalRealtor.Views.Pages.Menu.Composer;
using PersonalRealtor.Views.Pages.RealtorChat.Composer;
using PersonalRealtor.Views.Pages.RealtorChat.UI;
using PersonalRealtor.Views.Pages.RealtorChatList.Composer;
using PersonalRealtor.Views.Pages.RealtorListings.Composer;
using PersonalRealtor.Views.Pages.SavedHomes.Composer;
using Xamarin.Forms;

namespace PersonalRealtor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "RealtorListings";

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
            SaveRealtorPlayerId();
            var main = MainUIComposer.MainUI();
            main.Flyout = MenuUIComposer.MenuUI(MakeMenuOptions(main));
            main.Detail = new PRNavigationPage(BrowseListingsUIComposer.MakeBrowseListingsUI());
            ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
            ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
            return main;
        }
        
        private MenuOption<Image>[] MakeMenuOptions(MainPage main)
        {
            return new MenuOption<Image>[] {
                new MenuOption<Image>() {
                    Title = $"View {RealtorSingleton.Instance.FullName}'s Listings",
                    Image = new Image() { Source = "menu_realtor_listings.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(RealtorListingsUIComposer.MakeRealtorListingsUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Browse Homes",
                    Image = new Image() { Source = "menu_browse_listings.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(BrowseListingsUIComposer.MakeBrowseListingsUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "My Saved Homes",
                    Image = new Image() { Source = "menu_my_saved_homes.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(SavedHomesUIComposer.MakeSavedHomesUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "General Inquiry",
                    Image = new Image() { Source = "menu_general_inquiry.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(GeneralInquiryUIComposer.MakeGeneralInquiryUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Realtor Chat!",
                    Image = new Image() { Source = "menu_chat.png" },
                    Action = () => {
                        var isAdmin = AdminLoginCache.IsAdminLoggedIn();

                        if (isAdmin) {
                            main.Detail = new PRNavigationPage(RealtorChatListUIComposer.MakeRealtorChatListUI());
                        } else {
                            main.Detail = new PRNavigationPage(RealtorChatUIComposer.MakeRealtorChatUI(UsernameCache.GetCurrentUsername(), RealtorOneSignalCache.GetRealtorPlayerID()));
                        }

                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                },
                new MenuOption<Image>() {
                    Title = "Login",
                    Image = new Image() { Source = "menu_chat.png" },
                    Action = () => {
                        main.Detail = new PRNavigationPage(LoginUIComposer.MakeLoginUI());
                        ((PRNavigationPage)main.Detail).BarBackgroundColor = Color.FromHex(RealtorSingleton.Instance.PrimaryColor);
                        ((PRNavigationPage)main.Detail).BarTextColor = Color.FromHex(RealtorSingleton.Instance.SecondaryColor);
                        main.IsPresented = false;
                    }
                }
            };
        }

        private async void SaveRealtorPlayerId() {
            var repository = new RealtorOneSignalRepository();
            //if (string.IsNullOrEmpty(RealtorOneSignalCache.GetRealtorPlayerID())) {
                var signalInfo = await repository.GetRealtorOneSignalInfoAsync(RealtorSingleton.Instance.UserName);
                RealtorOneSignalCache.SaveRealtorPlayerID(signalInfo.PlayerId);
            //}
        }
    }
}
