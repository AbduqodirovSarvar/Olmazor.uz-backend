using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlmaTech.Application.UseCases.CommonToDoList.Queries;

namespace OlmaTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommonController(
        IMediator mediator
        ) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                return Ok(await _mediator.Send(new GetCommonDataQuery()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("enums")]
        public async Task<IActionResult> GetEnums()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllEnumsQuery()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("genders")]
        public async Task<IActionResult> GetGenderEnums()
        {
            try
            {
                return Ok(await _mediator.Send(new GetGenderEnumsQuery()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("communications")]
        public async Task<IActionResult> GetCommunicationEnums()
        {
            try
            {
                return Ok(await _mediator.Send(new GetCommunicationEnumsQuery()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("user-roles")]
        public async Task<IActionResult> GetUserRoleEnums()
        {
            try
            {
                return Ok(await _mediator.Send(new GetUserRoleEnumsQuery()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex);
            }
        }

    }
}
