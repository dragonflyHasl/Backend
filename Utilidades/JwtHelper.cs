using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using EcoStore.Modelos.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace EcoStore.Utilidades;

public class JwtHelper
{
    private readonly IConfiguration _config;

    public JwtHelper(IConfiguration config)
    {
        _config = config;
    }

    public string GenerarToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Email, usuario.Correo),
            new(ClaimTypes.Role, usuario.Rol)
        };

        var clave = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_config["Jwt:ClaveSecreta"]!));

        var creds = new SigningCredentials(clave, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static void GenerarHashContraseña(string contraseña, out byte[] hash, out byte[] sal)
    {
        using var hmac = new HMACSHA512();
        sal = hmac.Key;
        hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contraseña));
    }

    public static bool VerificarContraseña(string contraseña, byte[] hashAlmacenado, byte[] salAlmacenada)
    {
        using var hmac = new HMACSHA512(salAlmacenada);
        var hashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contraseña));
        return hashCalculado.SequenceEqual(hashAlmacenado);
    }
}