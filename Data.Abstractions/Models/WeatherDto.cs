using System;

namespace Data.Abstractions.Models
{
    public class WeatherDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}