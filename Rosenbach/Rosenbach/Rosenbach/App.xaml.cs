using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rosenbach.Views;
using Rosenbach.Services.DataBase;

namespace Rosenbach
{
    public partial class App : Application
    {

        public App()
        {
            
            InitializeComponent();
            DataBase.Init(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            MainPage = new MainPage();
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
    }
}
