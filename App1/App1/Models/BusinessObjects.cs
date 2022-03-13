using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace App.Models
{
    public enum Plants
    {
        None,
        Carrot,
        Corn,
        Potato,
        Tomato,
        Wheat
    }

    public enum RecommendationType
    {
        None,
        Fertilizing,
        Harvest,
        Watering
    }

    public class CustomerInfo : ICustomerInfo
    {
        private List<Field> _fields = new();

        public event Action OnFieldsChanged;

        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public List<Field> Fields
        {
            get => new(_fields);
            set
            {

                if (value is null) { throw new ArgumentNullException(nameof(value)); }
                if (value.Count > StaticSettings.ConfigVariables.FieldListLimitSize)
                {
                    throw new InvalidOperationException("List size limit exceeded.");
                }
                foreach (var field in value)
                {
                    if (field is null)
                    {
                        throw new ArgumentException("Some field is null.");
                    }
                }
                _fields = value;
                OnFieldsChanged?.Invoke();
            }
        }

        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public void AddField(Field field)
        {
            if (!FieldAddingIsPossible)
            {
                Console.WriteLine(Fields);
                Fields = null;
                throw new InvalidOperationException("List size limit exceeded.");
            }
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }
            _fields.Add(field);
            OnFieldsChanged?.Invoke();
        }

        public void DeleteField(Field field)
        {
            _fields.Remove(field);
            OnFieldsChanged?.Invoke();
        }

        private bool FieldAddingIsPossible => Fields.Count < StaticSettings.ConfigVariables.FieldListLimitSize;
    }

    public class Field : IField
    {
        private string _name;
        private double _latitude, _longitude;

        /// <exception cref="ArgumentException"/>
        public double Latitude
        {
            get => _latitude;
            set
            {
                if (value < -90 || 90 < value)
                {
                    throw new ArgumentException($"{nameof(value)} is out of valid interval.");
                }
                _latitude = value;
            }
        }


        /// <exception cref="ArgumentException"/>
        public double Longitude
        {
            get => _longitude;
            set
            {
                if (value < -180 || 180 < value)
                {
                    throw new ArgumentException($"{nameof(value)} is out of valid interval.");
                }
                _longitude = value;
            }
        }

        [JsonIgnore]
        public Plants Plant { get; set; }
        public string PlantName
        {
            get => Enum.GetName(typeof(Plants), Plant);
            set
            {
                foreach (Plants plant in Enum.GetValues(typeof(Plants)))
                {
                    if (Enum.GetName(typeof(Plants), plant) == value)
                    {
                        Plant = plant;
                        return;
                    }
                }
                Plant = Plants.None;
            }
        }

        public long PlantingDate { get; set; }

        /// <exception cref="ArgumentException"/>
        public string Name
        {
            get => _name;
            set
            {
                if (!NameIsCorrect(value))
                {
                    throw new ArgumentException("Invalid Name value.");
                }
                _name = value;
            }
        }

        private static bool NameIsCorrect(string name) => name == null
                || (name.Length <= 50 && !new Regex(@"['""\\/\f\n\r\t]").IsMatch(name));
    }

    public class Recommendation : IRecommendation
    {
        [JsonIgnore]
        public RecommendationType Type { get; init; }
        public string TypeName
        {
            get => Enum.GetName(typeof(RecommendationType), Type);
            init
            {
                foreach (RecommendationType type in Enum.GetValues(typeof(RecommendationType)))
                {
                    if (Enum.GetName(typeof(RecommendationType), type) == value)
                    {
                        Type = type;
                        return;
                    }
                }
                Type = RecommendationType.None;
            }
        }
        public string Value { get; init; }
        public long RelevanceLimitTimestamp { get; init; }

        public bool IsRelevant => ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds() <= RelevanceLimitTimestamp;
    }

    /*
    public class DetailedField : App1.ViewModels.BaseViewModel
    {
        public DetailedField(Field field)
        {
            FieldItem = field;
            CurrentAccount.LoadRecommendations(FieldItem);
            //OnLoadRecommendations?.Invoke(FieldItem);
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
            [Plants.None] = "unknown.png"
        };

        public Field FieldItem { get; init; }

        public static event Func<Field, string[]> OnLoadRecommendations;
        public static event Func<Field, Recommendation[]> OnGetRecommendations;

        private Recommendation[] recommendations
        {
            //get => OnGetRecommendations?.Invoke(FieldItem);
            get => CurrentAccount.GetRecommendations(FieldItem);
        }

        private Recommendation[] recommendations =
        {
            new Recommendation(){Type = RecommendationType.Watering, Value = "Полей поле, ну пожалуйста"}, 
            //new Recommendation(){Type = RecommendationType.Fertilizing},
            new Recommendation(){Type = RecommendationType.Harvest, Value = "Копай, пока не поздно..."},
        };

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
    */
}