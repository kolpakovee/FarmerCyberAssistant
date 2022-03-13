using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace FarmingAssistant.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            System.Diagnostics.Debug.WriteLine("CREATED BASE MODEL");
            CurrentAccount = new List<Account>(DataStore.GetItemsAsync().Result)[0];
            DetailedField.OnLoadRecommendations += CurrentAccount.LoadRecommendations;
            DetailedField.OnGetRecommendations += CurrentAccount.GetRecommendations;
            CurrentAccount.CustomerInfo.OnFieldsChanged += () => OnPropertyChanged(nameof(Fields));
            CurrentAccount.OnCustomerInfoChanged += () => OnPropertyChanged(nameof(Fields));
        }
        public IDataStore<Account> DataStore { get; set; } = DependencyService.Get<IDataStore<Account>>();

        public Account CurrentAccount { get; set; }

        protected List<DetailedField> fields;
        public List<DetailedField> Fields
        {
            get
            {
                if (fields == null)
                    fields = DetailedField.GetDetailedField(CurrentAccount.CustomerInfo.Fields);
                return fields;
            }
            set
            {
                OnPropertyChanged(nameof(Fields));
            }
        }

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
    }

    public class DetailedField
    {
        public DetailedField(Field field)
        {
            FieldItem = field;
            //CurrentAccount.LoadRecommendations(FieldItem);
            OnLoadRecommendations.Invoke(FieldItem);
            System.Diagnostics.Debug.WriteLine("CREATED DETAILED FIELD");
        }

        public Dictionary<RecommendationTypes, string> Recommendations = new()
        {
            [RecommendationTypes.Watering] = "wateringCan.png",
            [RecommendationTypes.Fertilizing] = "plant.png",
            [RecommendationTypes.Harvest] = "shovel.png",
            [RecommendationTypes.None] = "ok.png"
        };

        private readonly Dictionary<Plants, string> PlantImages = new()
        {
            [Plants.Carrot] = "carrot.png",
            [Plants.Potato] = "potatoes.png",
            [Plants.Wheat] = "grass.png",
            [Plants.Tomato] = "tomato.png",
            [Plants.Corn] = "corn.png",
            [Plants.None] = "default.png"
        };

        public static event Func<Field, string[]> OnLoadRecommendations;
        public static event Func<Field, Recommendation[]> OnGetRecommendations;

        public Field FieldItem { get; init; }

        private Recommendation[] ActualRecommendations
        {
            get => OnGetRecommendations.Invoke(FieldItem);
        }

        public string FirstRecommendation
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Кол-во рекомендаций: " + ActualRecommendations.Length);
                if (ActualRecommendations.Length == 0)
                    return "Можно отдохнуть сегодня!";

                return ActualRecommendations[0].Value;
            }
        }

        public string FirstRecommendationIcon
        {
            get
            {
                if (ActualRecommendations.Length == 0)
                    return Recommendations[RecommendationTypes.None];

                return Recommendations[ActualRecommendations[0].Type];
            }
        }

        public string SecondRecommendation
        {
            get
            {
                if (ActualRecommendations.Length <= 1)
                    return "Можно отдохнуть сегодня!";

                return ActualRecommendations[1].Value;
            }
        }

        public string SecondRecommendationIcon
        {
            get
            {
                if (ActualRecommendations.Length <= 1)
                    return Recommendations[RecommendationTypes.None];

                return Recommendations[ActualRecommendations[1].Type];
            }
        }

        public string ThirdRecommendation
        {
            get
            {
                if (ActualRecommendations.Length <= 2)
                    return "Можно отдохнуть сегодня!";

                return ActualRecommendations[2].Value;
            }
        }


        public string ThirdRecommendationIcon
        {
            get
            {
                if (ActualRecommendations.Length <= 2)
                    return Recommendations[RecommendationTypes.None];

                return Recommendations[ActualRecommendations[2].Type];
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