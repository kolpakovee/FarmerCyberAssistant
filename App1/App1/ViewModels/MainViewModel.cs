using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class MainViewModel
    {
        Field[] f =
        {
            new Field(){Name = "Кукурузное поле", CultureIcon = "corn.png"},
            new Field(){Name = "Морковное поле", CultureIcon = "carrot.png"},
            new Field(){Name = "Томатное поле", CultureIcon = "tomato.png"},
            new Field(){Name = "Картофельное поле", CultureIcon = "potatoes.png"},
        };
        Recommendation[] rec =
        {
            new Recommendation{Icon = "plant.png"},
            new Recommendation{Icon = "wateringCan.png"},
            new Recommendation{Icon = "shovel.png"}
        };
        public Dictionary<Field, Recommendation[]> fields { get => Generate(); }


        private Dictionary<Field, Recommendation[]> Generate()
        {
            Dictionary<Field, Recommendation[]> result = new();
            Random random = new Random();

            foreach (var field in f)
            {
                int n = random.Next(5,10); // кол-во рекомендаций
                Recommendation[] recToResult = new Recommendation[n];

                for (int i = 0; i < n; i++)
                    recToResult[i] = rec[random.Next(0,3)];

                result.Add(field, recToResult);
            }
            return result;
        }
    }

    public class Recommendation
    {
        public string Icon { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string CultureIcon { get; set; }    
    }
}
