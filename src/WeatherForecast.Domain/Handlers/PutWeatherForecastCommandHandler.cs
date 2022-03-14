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
    public class PutWeatherForecastCommandHandler : IRequestHandler<PutWeatherForecastCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PutWeatherForecastCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(PutWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = _mapper.Map<Entities.WeatherForecast>(request);

            bool success = await _unitOfWork.WeatherForecast.Update(forecast);

            await _unitOfWork.CompleteAsync();

            return await Task.FromResult(success);

        }   
    }
}
