using EcoStore.Datos;
using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Servicios.Implementaciones;

public class UsuarioService : IUsuarioService
{
    private readonly EcoContexto _contexto;

    public UsuarioService(EcoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Usuario>> ObtenerTodosUsuariosAsync()
    {
        return await _contexto.Usuarios.ToListAsync();
    }

    public async Task<Usuario> ObtenerUsuarioPorIdAsync(Guid id)
    {
        return await _contexto.Usuarios
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new KeyNotFoundException("Usuario no encontrado");
    }

    public async Task EliminarUsuarioAsync(Guid id)
    {
        var usuario = await ObtenerUsuarioPorIdAsync(id);
        _contexto.Usuarios.Remove(usuario);
        await _contexto.SaveChangesAsync();
    }
}