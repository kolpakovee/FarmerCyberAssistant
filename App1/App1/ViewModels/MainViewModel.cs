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
            CurrentAccount.OnCustomerInfoChanged += () => OnPropertyChanged(nameof(Fields));
        }

        public List<DetailedField> Fields
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Кол-во полей:" + CurrentAccount.CustomerInfo.Fields.Count);
                return DetailedField.GetDetailedField(CurrentAccount.CustomerInfo.Fields);
            }
        }
    }

    public class DetailedField: BaseViewModel
    {
        public DetailedField()
        {

            var errors = CurrentAccount.LoadRecommendationsAsync(FieldItem).Result;
            System.Diagnostics.Debug.WriteLine("Ошибки:" +  string.Join(' ', errors));
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
                list.Add(new DetailedField() { FieldItem = field});

            return list;
        }
    }
}
