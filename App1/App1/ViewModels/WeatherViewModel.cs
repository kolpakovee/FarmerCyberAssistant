﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    internal class WeatherViewModel
    {
        public List<Weather> Weathers { get => WeatherData(); }
        private List<Weather> WeatherData()
        {
            var tempList = new List<Weather>();
            tempList.Add(new Weather { Temp = "-6", Date = "Среда", Icon = "Snow.png"});
            tempList.Add(new Weather { Temp = "-4", Date = "Четверг", Icon = "Wind.png" });
            tempList.Add(new Weather { Temp = "-2", Date = "Пятница", Icon = "Sunny.png" });
            tempList.Add(new Weather { Temp = "1", Date = "Суббота", Icon = "PartlyCloudy.png" });
            tempList.Add(new Weather { Temp = "3", Date = "Понедельник", Icon = "Snow.png" });
            tempList.Add(new Weather { Temp = "-6", Date = "Среда", Icon = "Snow.png" });
            tempList.Add(new Weather { Temp = "-4", Date = "Четверг", Icon = "Wind.png" });
            tempList.Add(new Weather { Temp = "-2", Date = "Пятница", Icon = "Sunny.png" });
            tempList.Add(new Weather { Temp = "1", Date = "Суббота", Icon = "PartlyCloudy.png" });
            tempList.Add(new Weather { Temp = "3", Date = "Понедельник", Icon = "Snow.png" });
            tempList.Add(new Weather { Temp = "-6", Date = "Среда", Icon = "Snow.png" });
            tempList.Add(new Weather { Temp = "-4", Date = "Четверг", Icon = "Wind.png" });
            tempList.Add(new Weather { Temp = "-2", Date = "Пятница", Icon = "Sunny.png" });
            tempList.Add(new Weather { Temp = "1", Date = "Суббота", Icon = "PartlyCloudy.png" });
            tempList.Add(new Weather { Temp = "3", Date = "Понедельник", Icon = "Snow.png" });

            return tempList;
        }
    }

    public class Weather
    {
        public string Temp { get; set; }
        public string Date { get; set; }
        public string Icon { get; set; }
        public string Humidity { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Cloudiness { get; set; }

    }
}
