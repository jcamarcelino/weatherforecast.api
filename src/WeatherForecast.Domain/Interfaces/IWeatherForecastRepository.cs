using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Interfaces
{
    public interface IWeatherForecastRepository : IRepository<Entities.WeatherForecast>
    {
    }
}
