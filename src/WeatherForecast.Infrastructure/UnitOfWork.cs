using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Infrastructure.Repositories;

namespace WeatherForecast.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public IWeatherForecastRepository WeatherForecast { get; private set; }

        public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            WeatherForecast = new WeatherForecastRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
