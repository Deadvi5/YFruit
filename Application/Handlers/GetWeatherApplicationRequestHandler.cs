using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Mappings;
using Application.Abstractions.Models;
using Application.Abstractions.Requests;
using Data.Abstractions.Requests;
using MediatR;

namespace Application.Handlers
{
    public class GetWeatherApplicationRequestHandler : IRequestHandler<GetWeatherApplicationRequest, IEnumerable<WeatherModel>>
    {
        private readonly IWeatherMappings mappings;
        private readonly IMediator mediator;
        
        public GetWeatherApplicationRequestHandler(IWeatherMappings mappings, IMediator mediator)
        {
            this.mappings = mappings;
            this.mediator = mediator;
        }
        public async Task<IEnumerable<WeatherModel>> Handle(GetWeatherApplicationRequest request, CancellationToken cancellationToken)
        {
            var weathers = await mediator.Send(new GetWatherDtoRequest(), cancellationToken);
            return (from item in weathers select mappings.GetFromDto(item));
        }
    }
}