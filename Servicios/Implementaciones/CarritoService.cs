using EcoStore.Datos;
using EcoStore.Modelos.DTOs;
using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Servicios.Implementaciones;

public class CarritoService : ICarritoService
{
    private readonly EcoContexto _contexto;

    public CarritoService(EcoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task AgregarItem(ItemCarritoDTO item)
    {
        var producto = await _contexto.Productos.FindAsync(item.ProductoId);
        if (producto == null) throw new KeyNotFoundException("Producto no encontrado");

        var carritoItem = new Carrito
        {
            UsuarioId = item.UsuarioId,
            ProductoId = item.ProductoId,
            Cantidad = item.Cantidad
        };

        await _contexto.Carrito.AddAsync(carritoItem);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<ItemCarritoDTO>> ObtenerCarrito(Guid usuarioId)
    {
        return await _contexto.Carrito
            .Where(c => c.UsuarioId == usuarioId)
            .Include(c => c.Producto)
            .Select(c => new ItemCarritoDTO
            {
                UsuarioId = c.UsuarioId,
                ProductoId = c.ProductoId,
                Cantidad = c.Cantidad
            })
            .ToListAsync();
    }

    public async Task EliminarItem(int itemId)
    {
        var item = await _contexto.Carrito.FindAsync(itemId);
        if (item == null) throw new KeyNotFoundException("Ítem no encontrado");
        _contexto.Carrito.Remove(item);
        await _contexto.SaveChangesAsync();
    }
}