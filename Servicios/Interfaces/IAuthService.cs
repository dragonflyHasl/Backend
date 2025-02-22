using EcoStore.Modelos.DTOs.Auth;

namespace EcoStore.Servicios.Interfaces;

public interface IAuthService
{
    Task<string> Registrar(RegistroDTO registroDTO);
    Task<string> Login(LoginDTO loginDTO);
}