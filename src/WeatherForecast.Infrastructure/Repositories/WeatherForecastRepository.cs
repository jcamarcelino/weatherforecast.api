using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Infrastructure.Repositories
{
    public class WeatherForecastRepository : Repository<Domain.Entities.WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
