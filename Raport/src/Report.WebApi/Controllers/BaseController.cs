using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Report.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public class BaseController:ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();

}