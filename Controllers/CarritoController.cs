using EcoStore.Modelos.DTOs;
using EcoStore.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controladores;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CarritoController : ControllerBase
{
    private readonly ICarritoService _carritoService;

    public CarritoController(ICarritoService carritoService)
    {
        _carritoService = carritoService;
    }

    [HttpPost]
    public async Task<IActionResult> AgregarItem([FromBody] ItemCarritoDTO item)
    {
        await _carritoService.AgregarItem(item);
        return Ok();
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> ObtenerCarrito(Guid usuarioId)
    {
        var items = await _carritoService.ObtenerCarrito(usuarioId);
        return Ok(items);
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> EliminarItem(int itemId)
    {
        await _carritoService.EliminarItem(itemId);
        return NoContent();
    }
}