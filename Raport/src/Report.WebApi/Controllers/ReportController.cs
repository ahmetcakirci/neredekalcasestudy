using Microsoft.AspNetCore.Mvc;
using NerdekalComResult;
using NeredekalComPagination;
using Report.Application.Features.Report.Commands.Create;
using Report.Application.Features.Report.Queries.GetAll;

namespace Report.WebApi.Controllers;

public class ReportController:BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CreateReportCommandResponse>))]
    public async Task<IActionResult> Create(string locationInfo)
    {
        return Ok(Result<CreateReportCommandResponse>.Succeed(await Mediator?.Send(new CreateReportCommand()
        {
            LocationInfo = locationInfo
        })!));
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<PaginationResult<GetAllQueryResponse>>))]
    public async Task<IActionResult> GetAll(int pageIndex=1,int pageSize=20)
    {
        var response = await Mediator.Send(
            new GetAllQuery 
            { 
                PageIndex = pageIndex,
                PageSize = pageSize
                
            });
        return Ok(Result<PaginationResult<GetAllQueryResponse>>.Succeed(response));
    }
}