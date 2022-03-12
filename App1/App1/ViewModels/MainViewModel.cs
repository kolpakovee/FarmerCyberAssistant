using System;
using System.Collections.Generic;
using System.Text;
using App1.Views;
using App.Models;

namespace App1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            CurrentAccount.CustomerInfo.OnFieldsChanged += () => OnPropertyChanged(nameof(Fields));
        }

        public List<DetailedField> Fields
        {
            get
            {
                System.Diagnostics.Debug.WriteLine(CurrentAccount.CustomerInfo.Fields.Count);
                return DetailedField.GetDetailedField(CurrentAccount.CustomerInfo.Fields);
            }
        }
    }

    public class DetailedField
    {
        private Dictionary<Plants, string> PlantImages = new()
        {
            [Plants.Carrot] = "carrot.png",
            [Plants.Potato] = "potatoes.png",
            [Plants.Wheat] = "grass.png",
            [Plants.None] = "default.png"
        };

        public Field FieldItem { get; init; }

        public string PlantIcon
        {
            get => PlantImages[FieldItem.Plant];
        }

        public static List<DetailedField> GetDetailedField(List<Field> fields)
        {
            List<DetailedField> list = new();
            
            foreach (Field field in fields)
                list.Add(new DetailedField() { FieldItem = field});

            return list;
        }
    }
}
