using System.Diagnostics.CodeAnalysis;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseMediatorApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected virtual IActionResult HandleResult<TResult>([AllowNull]Result<TResult> result)
        {
            if(result == null) return NotFound();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}