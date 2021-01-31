using System.Collections.Generic;
using Application.Abstractions.Models;
using MediatR;

namespace Application.Abstractions.Requests
{
    public class GetWeatherApplicationRequest : IRequest<IEnumerable<WeatherModel>> 
    {
        
    }
}