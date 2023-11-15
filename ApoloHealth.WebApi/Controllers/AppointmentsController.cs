using ApoloHealth.Application.UseCases.AppointmentOperations.Create;
using ApoloHealth.Application.UseCases.AppointmentOperations.Delete;
using ApoloHealth.Application.UseCases.AppointmentOperations.GetAll;
using ApoloHealth.Application.UseCases.AppointmentOperations.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApoloHealth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllAppointmentResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAppointmentRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAppointmentResponse>> Create(CreateAppointmentRequest request, CancellationToken cancellationToken)
    {
        
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateAppointmentResponse>> Update(Guid id, UpdateAppointmentRequest request, CancellationToken cancellationToken)
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

        var deleteAppointmentRequest = new DeleteAppointmentRequest(id.Value);
        var response = await _mediator.Send(deleteAppointmentRequest, cancellationToken);
        return Ok(response);
    }
}
