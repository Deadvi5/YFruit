using System;
using Application.Abstractions.Mappings;
using Application.Abstractions.Models;
using Application.Mappings;
using Data.Abstractions.Models;
using Xunit;

namespace Application.Test
{
    public class WeatherMappingsTest
    {
        private readonly IWeatherMappings sut;
        public WeatherMappingsTest()
        {
            sut = new WeatherMappings();
        }
        
        [Fact]
        public void GetFromDto_Should_Return_Null_If_Dto_Is_Null()
        {
            //Arrange & Act
            var result = sut.GetFromDto(null);

            //Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void GetFromDto_Should_Return_WeatherModel()
        {
            //Arrange
            WeatherDto dto = new WeatherDto {Date = DateTime.Now, Summary = "summary", TemperatureC = 10};

            //Act
            var result = sut.GetFromDto(dto);

            //Assert
            Assert.IsType<WeatherModel>(result);
            Assert.Equal(dto.Date, result.Date);
            Assert.Equal(dto.Summary, result.Summary);
            Assert.Equal(dto.TemperatureC, result.TemperatureC);
        }
    }
}