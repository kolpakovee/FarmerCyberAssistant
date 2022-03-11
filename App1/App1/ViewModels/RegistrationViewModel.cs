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
        public ICommand SignUpCommand { get; }

        public RegistrationViewModel()
        {
            SignInCommand = new Command(async () => await SignIn(),() => !IsBusy);
            SignUpCommand = new Command(async () => await SignUp(), () => !IsBusy);
        }

        async Task SignUp()
        {
            IsBusy = true;
            string[] errors = await AccountInfo.SignInAsync(Username, Password);
            await Shell.Current.GoToAsync("//main");
            IsBusy = false;
        }

        async Task SignIn()
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}
