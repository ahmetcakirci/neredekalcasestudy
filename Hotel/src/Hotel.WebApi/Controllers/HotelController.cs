using Application.Features.Hotel.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using NerdekalComResult;

namespace WebApi.Controllers;

public class HotelController:BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreateHotelCommandResponse>))]
    public async Task<IActionResult> Create([FromBody] CreateHotelCommand request)
    {
        CreateHotelCommandResponse response= await Mediator.Send(request);
        return Ok(Result<CreateHotelCommandResponse>.Succeed(response));
    }
}