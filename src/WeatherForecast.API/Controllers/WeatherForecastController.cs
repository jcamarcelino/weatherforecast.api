using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherForecast.Domain.Commands;
using WeatherForecast.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/weatherForecasts")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post(AddWeatherForecastCommand command)
        {
            try
            {
                int result =  _mediator.Send(command).Result;

                return Ok(result);
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }

        [HttpPut]
        public IActionResult Put(PutWeatherForecastCommand command)
        {
            try
            {
                _mediator.Send(command);

                return Ok();
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(PatchWeatherForecastCommand command, [FromRoute] int id)
        {
            try
            {
                command.Id = id;

                _mediator.Send(command);

                return Ok();
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _mediator.Send(new DeleteWeatherForecastCommand(id));

                return Ok();
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                return Ok(await _unitOfWork.WeatherForecast.All());
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {

                return Ok(await _unitOfWork.WeatherForecast.Find(id));
            }
            catch (Exception e)
            {
                string mensagem = e.Message;
                if (e.InnerException != null)
                    mensagem += $" - {e.InnerException.Message}";

                _logger.LogError(e, mensagem);

                return BadRequest(mensagem);
            }
        }
    }
}
