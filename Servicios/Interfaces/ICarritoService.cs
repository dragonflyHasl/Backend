using EcoStore.Modelos.DTOs;

namespace EcoStore.Servicios.Interfaces;

public interface ICarritoService
{
    Task AgregarItem(ItemCarritoDTO item);
    Task<List<ItemCarritoDTO>> ObtenerCarrito(Guid usuarioId);
    Task EliminarItem(int itemId);
}