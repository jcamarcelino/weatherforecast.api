using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Commands
{
    public class PatchWeatherForecastCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public JsonPatchDocument<WeatherForecast.Domain.Entities.WeatherForecast> Patch { get; set; }
    }
}
