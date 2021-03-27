using System;
using PersonalRealtor.Views.Pages.Menu.UI;
using Xamarin.Forms;

namespace PersonalRealtor.Views.Pages.Menu.Composer
{
    public class MenuUIComposer
    {
        public static MenuPage MenuUI(MenuOption<Image>[] options)
        {
            return new MenuPage(options);
        }
    }
}
