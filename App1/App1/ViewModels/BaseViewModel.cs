using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            CurrentAccount = new List<Account>(DataStore.GetItemsAsync().Result)[0];
            //DetailedField.OnLoadRecommendations += CurrentAccount.LoadRecommendations;
            //DetailedField.OnGetRecommendations += CurrentAccount.GetRecommendations;
            CurrentAccount.CustomerInfo.OnFieldsChanged += () => OnPropertyChanged(nameof(Fields));
            CurrentAccount.OnCustomerInfoChanged += () => OnPropertyChanged(nameof(Fields));

        }
        public IDataStore<Account> DataStore { get; set; } = DependencyService.Get<IDataStore<Account>>();

        public Account CurrentAccount { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private List<DetailedField> fields;
        public List<DetailedField> Fields
        {
            get
            {
                if (fields == null)
                    fields = DetailedField.GetDetailedField(CurrentAccount.CustomerInfo.Fields);
                return fields;
            }
        }
    }

    public class DetailedField : BaseViewModel
    {
        public DetailedField(Field field)
        {
            FieldItem = field;
            var task = CurrentAccount.LoadRecommendations(FieldItem);
            System.Diagnostics.Debug.WriteLine("CREATED DETAILED FIELD");
        }

        public Dictionary<RecommendationType, string> Recommendations = new()
        {
            [RecommendationType.Watering] = "wateringCan.png",
            [RecommendationType.Fertilizing] = "plant.png",
            [RecommendationType.Harvest] = "shovel.png",
            [RecommendationType.None] = "ok.png"
        };

        private Dictionary<Plants, string> PlantImages = new()
        {
            [Plants.Carrot] = "carrot.png",
            [Plants.Potato] = "potatoes.png",
            [Plants.Wheat] = "grass.png",
            [Plants.Tomato] = "tomato.png",
            [Plants.Corn] = "corn.png",
            [Plants.None] = "default.png"
        };

        public Field FieldItem { get; init; }

        private Recommendation[] recommendations
        {
            get => CurrentAccount.GetRecommendations(FieldItem);
        }

        /*private Recommendation[] recommendations =
        {
            new Recommendation(){Type = RecommendationType.Watering, Value = "Полей поле, ну пожалуйста"}, 
            //new Recommendation(){Type = RecommendationType.Fertilizing},
            new Recommendation(){Type = RecommendationType.Harvest, Value = "Копай, пока не поздно..."},
        };*/

        public string FirstRecommendation
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Кол-во рекомендаций: " + recommendations.Length);
                if (recommendations.Length == 0)
                    return "Можно отдохнуть сегодня!";

                return recommendations[0].Value;
            }
        }

        public string FirstRecommendationIcon
        {
            get
            {
                if (recommendations.Length == 0)
                    return Recommendations[RecommendationType.None];

                return Recommendations[recommendations[0].Type];
            }
        }

        public string SecondRecommendation
        {
            get
            {
                if (recommendations.Length <= 1)
                    return "Можно отдохнуть сегодня!";

                return recommendations[1].Value;
            }
        }

        public string SecondRecommendationIcon
        {
            get
            {
                if (recommendations.Length <= 1)
                    return Recommendations[RecommendationType.None];

                return Recommendations[recommendations[1].Type];
            }
        }

        public string ThirdRecommendation
        {
            get
            {
                if (recommendations.Length <= 2)
                    return "Можно отдохнуть сегодня!";

                return recommendations[2].Value;
            }
        }


        public string ThirdRecommendationIcon
        {
            get
            {
                if (recommendations.Length <= 2)
                    return Recommendations[RecommendationType.None];

                return Recommendations[recommendations[2].Type];
            }
        }

        public string PlantIcon
        {
            get => PlantImages[FieldItem.Plant];
        }

        public static List<DetailedField> GetDetailedField(List<Field> fields)
        {
            List<DetailedField> list = new();

            foreach (Field field in fields)
                list.Add(new DetailedField(field));

            return list;
        }
    }
}