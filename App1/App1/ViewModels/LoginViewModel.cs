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
        }

        async Task SignIn()
        {
            IsBusy = true;
            var account = new Account();
            string[] errors = await account.SignInAsync(Username, Password);

            if (errors.Length > 0) { System.Diagnostics.Debug.WriteLine(string.Join(' ', errors)); }
            else
            {
                AccountInfo = account;
                await Shell.Current.GoToAsync("//main");
            }

            IsBusy = false;

            System.Diagnostics.Debug.WriteLine($"username> {_username}");
            System.Diagnostics.Debug.WriteLine($"password> {_password}");
        }

        async Task SignUp()
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}
