using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScaleControl.API;
using ScaleControl.Application.Commands.User;
using ScaleControl.Application.Queries.Scale.GetByIdScales;
using ScaleControl.Application.Queries.User.GetAllUsers;

namespace ScaleControl.API.Controllers;
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var command = new GetAllUsersQuery(query);
        var users = await _mediator.Send(command);
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var command = new GetByIdScaleQuery(id);
        var user = await _mediator.Send(command);
        return Ok(user);
    }    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}/login")]
    public async Task<IActionResult> Login(int id, [FromBody] CreateUserCommand command)
    {
        return NoContent();
    }
}