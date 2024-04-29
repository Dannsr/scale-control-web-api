using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScaleControl.Application.Commands.Detachment.CreateDetachment;
using ScaleControl.Application.Commands.Detachment.DeleteRestriction;
using ScaleControl.Application.Queries.Detachment.GetAllDetachment;
using ScaleControl.Application.Queries.Detachment.GetByIdDetachment;

namespace ScaleControl.API.Controllers;
[Route("api/detachments")]
public class DetachmentController : ControllerBase
{
    private readonly IMediator _mediator;
    public DetachmentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var command = new GetAllDetachmentQuery(query);
        var detachment = await _mediator.Send(command);
        return Ok(detachment);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int enrollment)
    {
        var command = new GetByIdDetachmentQuery(enrollment);
        var user = await _mediator.Send(command);
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDetachmentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDetachmentCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}