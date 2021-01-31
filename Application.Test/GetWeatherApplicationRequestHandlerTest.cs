using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Mappings;
using Application.Abstractions.Models;
using Application.Abstractions.Requests;
using Application.Handlers;
using Data.Abstractions.Models;
using Data.Abstractions.Requests;
using MediatR;
using NSubstitute;
using Xunit;

namespace Application.Test
{
    public class GetWeatherApplicationRequestHandlerTest
    {
        private readonly GetWeatherApplicationRequestHandler sut;
        private readonly IWeatherMappings mapping;
        private readonly IMediator mediator;
        
        public GetWeatherApplicationRequestHandlerTest()
        {
            mediator = Substitute.For<IMediator>();
            mapping = Substitute.For<IWeatherMappings>();
            sut = new GetWeatherApplicationRequestHandler(mapping, mediator);
        }
        
        [Fact]
        public async Task Handle_Should_Return_WeatherModels()
        {
            //Arrange
            var dto = GetWeathers();
            mediator
                .Send(Arg.Any<GetWatherDtoRequest>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(dto.AsEnumerable()));

            mapping.GetFromDto(Arg.Any<WeatherDto>())
                .Returns(new WeatherModel{Date = DateTime.Now});

            //Act
            var result = await sut.Handle(new GetWeatherApplicationRequest(), new CancellationToken());

            //Assert
            await mediator.Received(1).Send(Arg.Any<GetWatherDtoRequest>(), Arg.Any<CancellationToken>());
        }

        private static WeatherDto[] GetWeathers()
        {
            var dto = new WeatherDto[]
            {
                new() {Date = DateTime.Now, TemperatureC = 12, Summary = "summary"},
                new() {Date = DateTime.Now, TemperatureC = 12, Summary = "summary"}
            };
            return dto;
        }
    }
}