using EcoStore.Modelos.DTOs;
using EcoStore.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controladores;

[Authorize]
[ApiController]
[Route("api/ordenes")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _ordenService;

    public OrdenesController(IOrdenService ordenService)
    {
        _ordenService = ordenService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearOrden([FromBody] OrdenCrearDTO ordenDTO)
    {
        try
        {
            var orden = await _ordenService.CrearOrdenAsync(ordenDTO);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = orden.Id }, orden);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(Guid id)
    {
        var orden = await _ordenService.ObtenerOrdenPorIdAsync(id);
        return Ok(orden);
    }
}