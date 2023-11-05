using ApoloHealth.Application.UseCases.ExamOperations.Create;
using ApoloHealth.Application.UseCases.ExamOperations.Delete;
using ApoloHealth.Application.UseCases.ExamOperations.GetAll;
using ApoloHealth.Application.UseCases.ExamOperations.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApoloHealth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllExamResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllExamRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamResponse>> Create(CreateExamRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<UpdateExamResponse>> Update(Guid id, UpdateExamRequest request, CancellationToken cancellationToken)
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

        var deleteExamRequest = new DeleteExamRequest(id.Value);
        var response = await _mediator.Send(deleteExamRequest, cancellationToken);
        return Ok(response);
    }
}
