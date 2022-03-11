﻿using System;
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
        public ICommand SignUpCommand2 { get; }

        public RegistrationViewModel()
        {
            SignUpCommand2 = new Command(async () => await SignUp(), () => !IsBusy);
        }

        async Task SignUp()
        {
            IsBusy = true;
            var account = new Account();
            string[] errors = await account.SignUpAsync(Username, Password);
            System.Diagnostics.Debug.WriteLine($"user> {Username} passworg> {Password}");

            if (errors.Length > 0) { System.Diagnostics.Debug.WriteLine(string.Join(' ', errors)); }
            else
            {
                AccountInfo = account;
                string[] errorsAccount = await account.UpdateCustomerInfoAsync();
                System.Diagnostics.Debug.WriteLine(string.Join(' ', errorsAccount));
                await Shell.Current.GoToAsync("//main");
            }

            IsBusy = false;
        }
    }
}





