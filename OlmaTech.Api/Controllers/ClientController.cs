using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlmaTech.Application.UseCases.AboutToDoList.Commands;
using OlmaTech.Application.UseCases.AboutToDoList.Queries;
using OlmaTech.Application.UseCases.ClientToDoList.Commands;
using OlmaTech.Application.UseCases.ClientToDoList.Queries;

namespace OlmaTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetClientQuery query)
        {
            try
            {
                return Ok(await mediator.Send(query));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllClientQuery query)
        {
            try
            {
                return Ok(await mediator.Send(query));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateClientCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateClientCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteClientCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
