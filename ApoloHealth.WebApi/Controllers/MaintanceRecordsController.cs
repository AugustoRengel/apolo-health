using ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;
using ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;
using ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;
using ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApoloHealth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaintanceRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaintanceRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllMaintanceRecordResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllMaintanceRecordRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateMaintanceRecordResponse>> Create(CreateMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateMaintanceRecordResponse>> Update(Guid id, UpdateMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
        {
            return BadRequest();
        }

        var deleteMaintanceRecordRequest = new DeleteMaintanceRecordRequest(id.Value);
        var response = await _mediator.Send(deleteMaintanceRecordRequest, cancellationToken);
        return Ok(response);
    }
}
