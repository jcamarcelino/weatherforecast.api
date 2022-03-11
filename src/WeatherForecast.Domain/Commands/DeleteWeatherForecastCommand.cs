using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Commands
{
    public class DeleteWeatherForecastCommand : IRequest<bool>
    {
        public DeleteWeatherForecastCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
