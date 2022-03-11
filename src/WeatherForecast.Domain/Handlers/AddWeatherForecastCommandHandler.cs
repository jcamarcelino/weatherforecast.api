using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecast.Domain.Commands;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Domain.Handlers
{
    public class AddWeatherForecastCommandHandler : IRequestHandler<AddWeatherForecastCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddWeatherForecastCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = _mapper.Map<Entities.WeatherForecast>(request);

            bool sucess = await _unitOfWork.WeatherForecast.Add(forecast);

            if (!sucess)
                return await Task.FromResult(0);

            await _unitOfWork.CompleteAsync();

            return await Task.FromResult(forecast.Id);
        }
    }
}
