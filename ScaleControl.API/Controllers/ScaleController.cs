using Microsoft.AspNetCore.Mvc;

namespace ScaleControl.API.Controllers;
[Route("api/scales")]
public class ScaleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}