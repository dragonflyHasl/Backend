using EcoStore.Modelos.DTOs;
using EcoStore.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controladores;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearProducto([FromBody] ProductoCrearDTO productoDTO)
    {
        try
        {
            var producto = await _productoService.CrearProducto(productoDTO);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var productos = await _productoService.ObtenerTodos();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        try
        {
            var producto = await _productoService.ObtenerPorId(id);
            return Ok(producto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(int id, [FromBody] ProductoActualizarDTO productoDTO)
    {
        try
        {
            await _productoService.ActualizarProducto(id, productoDTO);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        try
        {
            await _productoService.EliminarProducto(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}