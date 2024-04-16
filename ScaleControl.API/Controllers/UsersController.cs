using Microsoft.AspNetCore.Mvc;
using ScaleControl.API.Models;

namespace ScaleControl.API.Controllers;
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }    
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel createUserModel)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1}, createUserModel);
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel loginModel)
    {
        return NoContent();
    }
}