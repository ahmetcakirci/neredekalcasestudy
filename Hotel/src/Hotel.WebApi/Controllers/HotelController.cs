using Application.Features.Hotel.Commands.Create;
using Application.Features.Hotel.Commands.Delete;
using Application.Features.Hotel.Commands.Update;
using Application.Features.Hotel.Queries.GetById;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NerdekalComResult;

namespace Hotel.WebApi.Controllers;

public class HotelController:BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreateHotelCommandResponse>))]
    public async Task<IActionResult> Create([FromBody] CreateHotelCommand request)
    {
        CreateHotelCommandResponse response= await Mediator.Send(request);
        return Ok(Result<CreateHotelCommandResponse>.Succeed(response));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(NoContent))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
    public async Task<IActionResult> Put([FromBody] UpdateHotelCommand request)
    {
        UpdateHotelCommandResponse response= await Mediator.Send(request);
        return response.Update ? NoContent() : NotFound();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(NoContent))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFound))]
    public async Task<IActionResult> Create(Guid id)
    {
        DeleteHotelCommandResponse response = await Mediator.Send(new DeleteHotelCommand(id));
        return response.Delete ? NoContent() : NotFound();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<GetByIdQueryResponse>))]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await Mediator.Send(new GetByIdQuery { Id = id });
        return Ok(Result<GetByIdQueryResponse>.Succeed(response));
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<GetByIdQueryResponse>))]
    public async Task<IActionResult> GetAll(Guid id)
    {
        var response = await Mediator.Send(new GetByIdQuery { Id = id });
        return Ok(Result<GetByIdQueryResponse>.Succeed(response));
    }
}