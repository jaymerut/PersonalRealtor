using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalRealtor.Views.ViewCells {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutocompleteLocationGroupNameViewCell : SelectableViewCell {
        public AutocompleteLocationGroupNameViewCell() {
            InitializeComponent();
        }
    }
}
