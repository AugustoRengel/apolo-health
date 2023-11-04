using ApoloHealth.Application.UseCases.CreateEquipment;
using ApoloHealth.Application.UseCases.DeleteEquipment;
using ApoloHealth.Application.UseCases.GetAllEquipment;
using ApoloHealth.Application.UseCases.UpdateEquipment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApoloHealth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EquipmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllEquipmentResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllEquipmentRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEquipmentResponse>> Create(CreateEquipmentRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateEquipmentResponse>> Update(Guid id, UpdateEquipmentRequest request, CancellationToken cancellationToken)
    {
        if(id != request.Id)
        {
            return BadRequest();
        }

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if(id is null)
        {
            return BadRequest();
        }

        var deleteEquipmentRequest = new DeleteEquipmentRequest(id.Value);
        var response = await _mediator.Send(deleteEquipmentRequest, cancellationToken);
        return Ok(response);
    }
}
