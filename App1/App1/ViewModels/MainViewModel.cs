using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Field> fields { get; set; }
        public MainViewModel()
        {
            fields = f;
        }

        private List<Field> f = new List<Field>()
        {
            new Field(){Name = "Кукурузное поле", CultureIcon = "corn.png", TodayIcon = "plant.png"
            , TomorrowIcon = "wateringCan.png", AfterTomorrowIcon = "shovel.png"},

            new Field(){Name = "Морковное поле", CultureIcon = "carrot.png",  TodayIcon = "ok.png"
            , AfterTomorrowIcon = "wateringCan.png", TomorrowIcon = "shovel.png"},

            new Field(){Name = "Томатное поле", CultureIcon = "tomato.png",  TodayIcon = "shovel.png"
            , TomorrowIcon = "plant.png", AfterTomorrowIcon = "wateringCan.png"},

            new Field(){Name = "Картофельное поле", CultureIcon = "potatoes.png",  TodayIcon = "ok.png"
            , TomorrowIcon = "ok.png", AfterTomorrowIcon = "plant.png"},
        };
    }

    public class Field
    {
        public string Name { get; set; } = "Name";
        public string CultureIcon { get; set; }   
        public string TodayIcon { get; set; }
        public string TomorrowIcon { get; set; }
        public string AfterTomorrowIcon { get; set; }
    }
}
