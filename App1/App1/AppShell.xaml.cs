
using FarmingAssistant.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FarmingAssistant
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("registration", typeof(RegistrationPage));
        }

    }
}
