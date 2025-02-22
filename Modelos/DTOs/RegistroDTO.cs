namespace EcoStore.Modelos.DTOs.Auth;

public class RegistroDTO
{
    public required string Correo { get; set; }
    public required string Contraseña { get; set; }
    public required string NombreCompleto { get; set; }
}