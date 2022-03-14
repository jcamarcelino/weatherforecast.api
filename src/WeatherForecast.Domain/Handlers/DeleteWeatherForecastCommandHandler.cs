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
    public class DeleteWeatherForecastCommandHandler : IRequestHandler<DeleteWeatherForecastCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteWeatherForecastCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = await _unitOfWork.WeatherForecast.Find(request.Id);

            bool success = await _unitOfWork.WeatherForecast.Delete(forecast);

            await _unitOfWork.CompleteAsync();

            return await Task.FromResult(success);

        }
    }
}
