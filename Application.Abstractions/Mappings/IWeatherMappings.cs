using Application.Abstractions.Models;
using Data.Abstractions.Models;

namespace Application.Abstractions.Mappings
{
    public interface IWeatherMappings
    {
        WeatherModel GetFromDto(WeatherDto dto);
    }
}