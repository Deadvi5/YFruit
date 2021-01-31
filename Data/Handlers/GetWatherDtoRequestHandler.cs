using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Data.Abstractions.Models;
using Data.Abstractions.Requests;
using MediatR;

namespace Data.Handlers
{
    public class PingRequestHandler : IRequestHandler<GetWatherDtoRequest, IEnumerable<WeatherDto>>
    {
        public async Task<IEnumerable<WeatherDto>> Handle(GetWatherDtoRequest request, CancellationToken cancellationToken)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            var httpClient = new HttpClient(clientHandler) {BaseAddress = new Uri("https://localhost:10001")};
            var apiRequest = new HttpRequestMessage(HttpMethod.Get, "WeatherForecast");
            using var weatherResponse = await httpClient.SendAsync(apiRequest, cancellationToken);

            if (!weatherResponse.IsSuccessStatusCode) throw new ApplicationException("Error in PingRequestHandler");
            return await weatherResponse.Content.ReadFromJsonAsync<IEnumerable<WeatherDto>>(cancellationToken: cancellationToken);
        }
    }
}
