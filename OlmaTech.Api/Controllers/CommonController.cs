using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlmaTech.Application.UseCases.CommonToDoList.Queries;

namespace OlmaTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            return Ok(await _mediator.Send(new GetCommonDataQuery()));
        }

        [HttpGet("enums")]
        public async Task<IActionResult> GetEnums()
        {
            return Ok(await _mediator.Send(new GetAllEnumsQuery()));
        }
    }
}
