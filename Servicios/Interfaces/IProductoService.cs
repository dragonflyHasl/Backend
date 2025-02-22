using EcoStore.Modelos.DTOs;
using EcoStore.Modelos.Entidades;

namespace EcoStore.Servicios.Interfaces;

public interface IProductoService
{
    Task<Producto> CrearProducto(ProductoCrearDTO productoDTO);
    Task<List<Producto>> ObtenerTodos();
    Task<Producto> ObtenerPorId(int id);
    Task ActualizarProducto(int id, ProductoActualizarDTO productoDTO);
    Task EliminarProducto(int id);
}