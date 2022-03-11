using MediatR;
using System;

namespace WeatherForecast.Domain.Commands
{
    public class AddWeatherForecastCommand : IRequest<int>
    {
        public string Local { get; set; }

        public int TemperatureC { get; set; }

        public int Rain { get; set; }

        public int Humidity { get; set; }

        public int Wind { get; set; }

        public string Summary { get; set; }
    }
}
