using EcoStore.Modelos.Entidades;

namespace EcoStore.Servicios.Interfaces;

public interface IUsuarioService
{
    Task<List<Usuario>> ObtenerTodosUsuariosAsync();
    Task<Usuario> ObtenerUsuarioPorIdAsync(Guid id);
    Task EliminarUsuarioAsync(Guid id);
}