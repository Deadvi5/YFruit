using System;

namespace Application.Abstractions.Models
{
    public class WeatherModel
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}