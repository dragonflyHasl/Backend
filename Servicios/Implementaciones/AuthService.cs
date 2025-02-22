using EcoStore.Datos;
using EcoStore.Modelos.DTOs.Auth;
using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using EcoStore.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Servicios.Implementaciones;

public class AuthService : IAuthService
{
    private readonly EcoContexto _contexto;
    private readonly JwtHelper _jwtHelper;

    public AuthService(EcoContexto contexto, JwtHelper jwtHelper)
    {
        _contexto = contexto;
        _jwtHelper = jwtHelper;
    }

    public async Task<string> Registrar(RegistroDTO registroDTO)
    {
        if (await _contexto.Usuarios.AnyAsync(u => u.Correo == registroDTO.Correo))
            throw new ArgumentException("El correo ya está registrado");

        var usuario = new Usuario
        {
            Correo = registroDTO.Correo,
            NombreCompleto = registroDTO.NombreCompleto,
            Rol = "Usuario"
        };

        JwtHelper.GenerarHashContraseña(registroDTO.Contraseña, out byte[] hash, out byte[] sal);
        usuario.HashContraseña = hash;
        usuario.SalContraseña = sal;

        await _contexto.Usuarios.AddAsync(usuario);
        await _contexto.SaveChangesAsync();

        return _jwtHelper.GenerarToken(usuario);
    }

    public async Task<string> Login(LoginDTO loginDTO)
    {
        var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Correo == loginDTO.Correo);
        if (usuario == null || !JwtHelper.VerificarContraseña(loginDTO.Contraseña, usuario.HashContraseña, usuario.SalContraseña))
            throw new UnauthorizedAccessException("Credenciales inválidas");

        return _jwtHelper.GenerarToken(usuario);
    }
}