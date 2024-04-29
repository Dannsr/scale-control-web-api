using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScaleControl.Application.Commands.Restriction.CreateRestriction;
using ScaleControl.Application.Commands.Restriction.DeleteRestriction;
using ScaleControl.Application.Queries.Restriction.GetAllRestrictions;
using ScaleControl.Application.Queries.Restriction.GetByIdRestriction;

namespace ScaleControl.API.Controllers;
[Route("api/restrictions")]
public class RestrictionController : ControllerBase
{
    private readonly IMediator _mediator;
    public RestrictionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var command = new GetAllRestrictionsQuery(query);
        var restrictions = await _mediator.Send(command);
        return Ok(restrictions);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int enrollment)
    {
        var command = new GetByIdRestrictionQuery(enrollment);
        var restriction  = await _mediator.Send(command);
        return Ok(restriction);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateRestrictionCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteRestrictionCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}