using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views;
using System.IO;
using App.Services;
using System.Threading.Tasks;
using App.Models;

namespace App1.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        private string _username, _password;
        public string Username
        {
            get => _username;
            set
            {
                if (Account.UsernameIsCorrect(value))
                {
                    _username = value;
                }
                else
                {
                    // Вывести сообщение.
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (Account.PasswordIsCorrect(value))
                {
                    _password = value;
                }
                else
                {
                    // Вывести сообщение.
                }
            }
        }
        public ICommand SignInCommand { get; }
        public ICommand SignUpCommand { get; }

        public LoginViewModel()
        {
            SignInCommand = new Command(async () => await SignIn(),() => !IsBusy);
            SignUpCommand = new Command(async () => await SignUp(), () => !IsBusy);
            App.Current.Properties.TryAdd("IsLoggedIn", false);
        }

        async Task SignIn()
        {
            IsBusy = true;
            string[] errors = await CurrentAccount.SignInAsync(Username, Password);
            if (errors.Length > 0) { System.Diagnostics.Debug.WriteLine(string.Join(' ', errors));
                App.Current.MainPage.DisplayAlert("Error", String.Join(' ', errors), "Ok");
            }
            else
            {
                App.Current.Properties["IsLoggedIn"] = true;
                await DataStore.SaveAsync();
                await Shell.Current.GoToAsync("//main");
            }
            IsBusy = false;
        }

        async Task SignUp()
        {
            await Shell.Current.GoToAsync("//login/registration");
        }

        public async void PageAppearing(object sender, EventArgs e)
        {
            if (App.Current.Properties["IsLoggedIn"] is true)
            {
                await DataStore.LoadAsync();
                await Shell.Current.GoToAsync("//main");
            }
        }
    }
}
