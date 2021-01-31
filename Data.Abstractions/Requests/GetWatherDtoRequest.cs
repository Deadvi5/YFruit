using System.Collections.Generic;
using Data.Abstractions.Models;
using MediatR;

namespace Data.Abstractions.Requests
{
    public class GetWatherDtoRequest : IRequest<IEnumerable<WeatherDto>> { }
}