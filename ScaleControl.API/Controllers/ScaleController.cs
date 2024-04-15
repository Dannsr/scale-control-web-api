using Microsoft.AspNetCore.Mvc;
using ScaleControl.API.Models;

namespace ScaleControl.API.Controllers;
[Route("api/scales")]
public class ScaleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string query)
    {
        // Buscar todas as escalas
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // Buscar detalhes de uma escala
        return Ok();
    }
    [HttpPost]
    public IActionResult Post([FromBody] ScaleModel scaleModel)
    {
        // Cadastrar escala
        if (scaleModel.StartAt > DateTime.Now)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new { id = scaleModel.Id}, scaleModel);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateScaleModel updateScaleModel)
    {
        // Atualizar escala
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {   
        // Remove escala
        return NoContent();
    }
    [HttpGet("{id}/start")]
    public IActionResult Start(int id)
    {
        // inicia uma escala
        return NoContent();
    }
    [HttpGet("{id}/finish")]
    public IActionResult Finish(int id)
    {
        // finaliza uma escala
        return NoContent();
    }
    
}