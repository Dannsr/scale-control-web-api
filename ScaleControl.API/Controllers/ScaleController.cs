using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaleControl.API;
using ScaleControl.Application.Commands.CreateScale;
using ScaleControl.Application.Commands.DeleteScale;
using ScaleControl.Application.Commands.Scale.FinishScale;
using ScaleControl.Application.Commands.StartScale;
using ScaleControl.Application.Commands.UpdateScale;
using ScaleControl.Application.Queries.Scale;
using ScaleControl.Application.Queries.Scale.GetByIdScales;

namespace ScaleControl.API.Controllers;
[Route("api/scales")]
public class ScaleController : ControllerBase
{
    private readonly IMediator _mediator;
    public ScaleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var command = new GetAllScalesQuery(query);
        var scales = await _mediator.Send(command);
        return Ok(scales);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var command = new GetByIdScaleQuery(id);
        var scale = await _mediator.Send(command);
        return Ok(scale);
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateScaleCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateScaleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteScaleCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartScaleCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet("{id}/finish")]
    public async Task<IActionResult> Finish(int id)
    {
        var command = new FinishScaleCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
    
}