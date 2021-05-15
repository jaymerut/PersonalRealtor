﻿using System;
using PersonalRealtor.Views.ViewCells;
using Xamarin.Forms;

namespace PersonalRealtor.Components.DataTemplateSelectors
{
    public class PhotoDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DataTemplatePhoto { get; set; }

        public PhotoDataTemplateSelector()
        {
            DataTemplatePhoto = new DataTemplate(typeof(PhotoViewCell));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return new DataTemplate(typeof(ViewCell));
        }
    }
}
