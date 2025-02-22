using EcoStore.Modelos.DTOs.Auth;
using EcoStore.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controladores;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registrar([FromBody] RegistroDTO registroDTO)
    {
        try
        {
            var token = await _authService.Registrar(registroDTO);
            return Ok(new { Token = token });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        try
        {
            var token = await _authService.Login(loginDTO);
            return Ok(new { Token = token });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}