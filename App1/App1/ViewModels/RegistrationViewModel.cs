using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FarmingAssistant.Views;
using System.IO;
using App.Services;
using System.Threading.Tasks;
using App.Models;

namespace FarmingAssistant.ViewModels
{
    internal class RegistrationViewModel : BaseViewModel
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
        public ICommand SignUpCommand2 { get; }

        public RegistrationViewModel()
        {
            SignUpCommand2 = new Command(async () => await SignUp(), () => !IsBusy);
        }

        async Task SignUp()
        {
            IsBusy = true;
            string[] errors = await CurrentAccount.SignUpAsync(Username, Password);
            if (errors.Length > 0) { System.Diagnostics.Debug.WriteLine(string.Join(' ', errors)); }
            else
            {
                App.Current.Properties["IsLoggedIn"] = true;
                await DataStore.SaveAsync();
                await Shell.Current.GoToAsync("//main");
            }
            IsBusy = false;
        }
    }
}





