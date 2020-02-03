using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rosenbach.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreenPage : ContentPage
    {
        public MainScreenPage()
        {
            InitializeComponent();
            IconImageSource = "@drawable/rosenbachSmall.png";
        }
    }
}