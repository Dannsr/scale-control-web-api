using Microsoft.AspNetCore.Mvc;
using ScaleControl.API.Models;
using ScaleControl.Application.inputModels;
using ScaleControl.Application.Services.Interfaces;

namespace ScaleControl.API.Controllers;
[Route("api/scales")]
public class ScaleController : ControllerBase
{
    private readonly IScaleService _scaleService;

    public ScaleController(IScaleService scaleService)
    {
        _scaleService = scaleService;
    }
    [HttpGet]
    public IActionResult Get(string query)
    {
        var scales = _scaleService.GetAll(query);
        return Ok(scales);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var scale = _scaleService.GetById(id);
        if (scale == null)
        {
            return NotFound();
        }
        return Ok(scale);
    }
    [HttpPost]
    public IActionResult Post([FromBody] ScaleInputModel scaleModel)
    {
        // Cadastrar escala
        if (scaleModel.StartAt > DateTime.Now)
        {
            return BadRequest();
        }

        var id = _scaleService.Create((scaleModel));
        return CreatedAtAction(nameof(GetById), new { id = scaleModel.Id}, scaleModel);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ScaleInputModel scaleModel)
    {
        _scaleService.Update(scaleModel);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {   
        _scaleService.Delete(id);
        // Remove escala
        return NoContent();
    }
    [HttpGet("{id}/start")]
    public IActionResult Start(int id)
    {
        _scaleService.Start(id);
        // inicia uma escala
        return NoContent();
    }
    [HttpGet("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _scaleService.Finish(id);
        // finaliza uma escala
        return NoContent();
    }
    
}