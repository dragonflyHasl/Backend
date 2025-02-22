namespace EcoStore.Modelos.DTOs.Auth;

public class LoginDTO
{
    public required string Correo { get; set; }
    public required string Contraseña { get; set; }
}