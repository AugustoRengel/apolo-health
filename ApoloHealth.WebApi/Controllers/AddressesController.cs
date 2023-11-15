using ApoloHealth.Application.UseCases.AddressOperations.Create;
using ApoloHealth.Application.UseCases.AddressOperations.Delete;
using ApoloHealth.Application.UseCases.AddressOperations.GetAll;
using ApoloHealth.Application.UseCases.AddressOperations.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApoloHealth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllAddressResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllAddressRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAddressResponse>> Create(CreateAddressRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateAddressResponse>> Update(Guid id, UpdateAddressRequest request, CancellationToken cancellationToken)
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

        var deleteAddressRequest = new DeleteAddressRequest(id.Value);
        var response = await _mediator.Send(deleteAddressRequest, cancellationToken);
        return Ok(response);
    }
}
