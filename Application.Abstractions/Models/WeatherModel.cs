using System;

namespace Application.Abstractions.Models
{
    public class WeatherModel
    {
        public DateTime Date { get; init; }
        public int TemperatureC { get; init; }
        public string Summary { get; init; }
    }
}