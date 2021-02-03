using System.Collections.Generic;
using Data.Abstractions.Models;
using MediatR;

namespace Data.Abstractions.Requests
{
    public class GetWeatherDtoRequest : IRequest<IEnumerable<WeatherDto>> { }
}