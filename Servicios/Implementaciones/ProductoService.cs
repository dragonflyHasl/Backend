using EcoStore.Datos;
using EcoStore.Modelos.DTOs;
using EcoStore.Modelos.Entidades;
using EcoStore.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoStore.Servicios.Implementaciones;

public class ProductoService : IProductoService
{
    private readonly EcoContexto _contexto;

    public ProductoService(EcoContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<Producto> CrearProducto(ProductoCrearDTO productoDTO)
    {
        var categoria = await _contexto.Categorias.FindAsync(productoDTO.CategoriaId);
        if (categoria == null) throw new KeyNotFoundException("Categoría no encontrada");

        var producto = new Producto
        {
            Nombre = productoDTO.Nombre,
            Descripcion = productoDTO.Descripcion,
            Precio = productoDTO.Precio,
            Stock = productoDTO.Stock,
            CategoriaId = productoDTO.CategoriaId,
            EsEcologico = productoDTO.EsEcologico
        };

        await _contexto.Productos.AddAsync(producto);
        await _contexto.SaveChangesAsync();
        return producto;
    }

    public async Task<List<Producto>> ObtenerTodos()
    {
        return await _contexto.Productos
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    public async Task<Producto> ObtenerPorId(int id)
    {
        return await _contexto.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new KeyNotFoundException("Producto no encontrado");
    }

    public async Task ActualizarProducto(int id, ProductoActualizarDTO productoDTO)
    {
        var producto = await ObtenerPorId(id);

        producto.Nombre = productoDTO.Nombre ?? producto.Nombre;
        producto.Descripcion = productoDTO.Descripcion ?? producto.Descripcion;
        producto.Precio = productoDTO.Precio ?? producto.Precio;
        producto.Stock = productoDTO.Stock ?? producto.Stock;
        producto.CategoriaId = productoDTO.CategoriaId ?? producto.CategoriaId;
        producto.EsEcologico = productoDTO.EsEcologico ?? producto.EsEcologico;

        await _contexto.SaveChangesAsync();
    }

    public async Task EliminarProducto(int id)
    {
        var producto = await ObtenerPorId(id);
        _contexto.Productos.Remove(producto);
        await _contexto.SaveChangesAsync();
    }
}