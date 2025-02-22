using EcoStore.Datos;
using EcoStore.Modelos.DTOs;
using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Servicios.Implementaciones;

public class OrdenService : IOrdenService
{
    private readonly EcoContexto _contexto;

    public OrdenService(EcoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<Orden> CrearOrdenAsync(OrdenCrearDTO ordenDTO)
    {
        var usuario = await _contexto.Usuarios.FindAsync(ordenDTO.UsuarioId);
        if (usuario == null) throw new KeyNotFoundException("Usuario no encontrado");

        var orden = new Orden
        {
            UsuarioId = ordenDTO.UsuarioId,
            DireccionEnvio = ordenDTO.DireccionEnvio,
            Estado = "Pendiente"
        };

        decimal total = 0;
        foreach (var item in ordenDTO.Items)
        {
            var producto = await _contexto.Productos.FindAsync(item.ProductoId);
            if (producto == null) throw new KeyNotFoundException($"Producto {item.ProductoId} no encontrado");

            var detalle = new DetalleOrden
            {
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad,
                PrecioUnitario = producto.Precio
            };

            total += producto.Precio * item.Cantidad;
            orden.Detalles.Add(detalle);
        }

        orden.MontoTotal = total;
        await _contexto.Ordenes.AddAsync(orden);
        await _contexto.SaveChangesAsync();

        return orden;
    }

    public async Task<Orden> ObtenerOrdenPorIdAsync(Guid id)
    {
        return await _contexto.Ordenes
            .Include(o => o.Detalles)
            .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(o => o.Id == id)
            ?? throw new KeyNotFoundException("Orden no encontrada");
    }
}