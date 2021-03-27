using System;
namespace PersonalRealtor.Views.Pages.Menu
{
    public class MenuOption<ImageType>
    {
        public ImageType Image { get; set; }
        public string Title { get; set; }
        public Action Action { get; set; }
    }
}
