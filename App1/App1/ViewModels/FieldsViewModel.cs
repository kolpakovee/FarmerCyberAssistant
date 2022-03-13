using App.Models;
using FarmingAssistant.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmingAssistant.ViewModels
{
    internal class FieldsViewModel : BaseViewModel
    {
        public ICommand CreateFieldCommand { get; }
        public ICommand UpdateFieldCommand { get; }
        public ICommand DeleteFieldCommand { get; }

        public FieldsViewModel()
        {
            CreateFieldCommand = new Command(async () => await CreateField(), () => !IsBusy);
            UpdateFieldCommand = new Command(async () => await UpdateField(), () => !IsBusy);
            DeleteFieldCommand = new Command(async () => await DeleteField(), () => !IsBusy);
            System.Diagnostics.Debug.WriteLine("FIELDS VIEW MODEL");
            if (CurrentAccount.CustomerInfo.Fields.Count > 0)
            {
                SelectedField = CurrentAccount.CustomerInfo.Fields[0];
            }
        }

        private Field selectedField;
        public Field SelectedField
        {
            get => selectedField;
            set
            {
                if (selectedField != value)
                {
                    selectedField = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task CreateField()
        {
            IsBusy = true;
            CurrentAccount.CustomerInfo.AddField(new Field()
            {
                Plant = Plants.None,
                Name = "Новое поле",
                PlantingDate = 13032022
            });
            SelectedField = CurrentAccount.CustomerInfo.Fields[^1];
            await SaveChanges();
            IsBusy = false;
            System.Diagnostics.Debug.WriteLine($"Field created, count {CurrentAccount.CustomerInfo.Fields.Count}");
        }

        private async Task UpdateField()
        {
            IsBusy = true;
            await SaveChanges();
            IsBusy = false;
            System.Diagnostics.Debug.WriteLine($"Field updated");
        }

        private async Task DeleteField()
        {
            IsBusy = true;
            CurrentAccount.CustomerInfo.DeleteField(SelectedField);
            SelectedField = CurrentAccount.CustomerInfo.Fields.Count > 0 ? CurrentAccount.CustomerInfo.Fields[0] : null;
            await SaveChanges();
            IsBusy = false;
            System.Diagnostics.Debug.WriteLine($"Field deleted, count {CurrentAccount.CustomerInfo.Fields.Count}");
        }

        private async Task SaveChanges()
        {
            await DataStore.SaveAsync();
            await CurrentAccount.UpdateCustomerInfoAsync();
            OnPropertyChanged("CurrentAccount.CustomerInfo.Fields");
        }
    }
}
