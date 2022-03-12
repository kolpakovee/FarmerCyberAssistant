using App1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Services;
using App.Models;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Get<MockDataStore>().LoadAsync();
            MainPage = new AppShell();
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
