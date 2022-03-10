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
            System.Diagnostics.Debug.WriteLine("user> " + _username);
            IsBusy = true;
            await Shell.Current.GoToAsync("//main");
            IsBusy = false;
        }

        async Task SignUp()
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}
