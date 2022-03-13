using App.Models;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    internal class FieldsViewModel : BaseViewModel
    {
        public FieldsViewModel()
        {
            System.Diagnostics.Debug.WriteLine("FIELDS VIEW MODEL");
            if (Fields.Count > 0)
            {
                SelectedField = Fields[0];
            }
        }

        DetailedField selectedField;
        public DetailedField SelectedField
        {
            get { return selectedField; }
            set
            {
                System.Diagnostics.Debug.WriteLine(App.Current.Properties["IsLoggedIn"]);
                if (selectedField != value)
                {
                    selectedField = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
