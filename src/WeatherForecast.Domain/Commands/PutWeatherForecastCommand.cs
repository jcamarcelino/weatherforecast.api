using MediatR;
using System;

namespace WeatherForecast.Domain.Commands
{
    public class PutWeatherForecastCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Local { get; set; }

        public int TemperatureC { get; set; }

        public int Rain { get; set; }

        public int Humidity { get; set; }

        public int Wind { get; set; }

        public string Summary { get; set; }
    }
}
