using Application.Abstractions.Mappings;
using Application.Abstractions.Models;
using Data.Abstractions.Models;

namespace Application.Mappings
{
    public class WeatherMappings : IWeatherMappings
    {
        public WeatherModel GetFromDto(WeatherDto dto)
        {
            if (dto is null) return null;
            return new WeatherModel
            {
                Date = dto.Date,
                Summary = dto.Summary,
                TemperatureC = dto.TemperatureC
            };
        }
    }
}