using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Domain.Commands;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Domain.Handlers
{
    public class PatchWeatherForecastCommandHandler : IRequestHandler<PatchWeatherForecastCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatchWeatherForecastCommandHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(PatchWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = await _unitOfWork.WeatherForecast.Find(request.Id);

            request.Patch.ApplyTo(forecast);

            bool success = await _unitOfWork.WeatherForecast.Update(forecast);

            await _unitOfWork.CompleteAsync();

            return await Task.FromResult(success);

        }
    }
}
