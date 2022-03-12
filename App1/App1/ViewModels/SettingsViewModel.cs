using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using App1.Views;
using App.Models;

namespace App1.ViewModels
{
    internal class SettingsViewModel : BaseViewModel
    {
        public ICommand AboutAppCommand { get; }
        public ICommand EmailCommand { get; }
        public ICommand ExitCommand { get; }

        //private List<string> _emails = new() { "advasileva_2@edu.hse.ru", "eekolpakov@edu.hse.ru", "asbityugov@edu.hse.ru", "fafirsov@edu.hse.ru" };
        private List<string> _emails = new() { "Alenadvasileva@yandex.ru" };

        public SettingsViewModel()
        {
            AboutAppCommand = new Command(async () => await Browser.OpenAsync("https://github.com/Alena-Vasileva/FarmerCyberAssistant"));
            EmailCommand = new Command(async () => await Email.ComposeAsync(new EmailMessage() { To = _emails, Subject = "Отзыв" }));
            ExitCommand = new Command(async () => await Exit());
        }

        private async Task Exit()
        {
            bool result = await App.Current.MainPage.DisplayAlert("Подтвердить действие", "Вы точно хотите выйти?", "Да", "Нет");
            if (result)
            {
                App.Current.Properties["IsLoggedIn"] = false;
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}
