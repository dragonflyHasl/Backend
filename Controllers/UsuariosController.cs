using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controladores;

[ApiController]
[Route("api/usuarios")]
[Authorize(Roles = "Administrador")] // Solo accesible por administradores
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // GET: api/usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerTodosUsuarios()
    {
        try
        {
            var usuarios = await _usuarioService.ObtenerTodosUsuariosAsync();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    // GET: api/usuarios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> ObtenerUsuarioPorId(Guid id)
    {
        try
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            return Ok(usuario);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    // DELETE: api/usuarios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarUsuario(Guid id)
    {
        try
        {
            await _usuarioService.EliminarUsuarioAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}