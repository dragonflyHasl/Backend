namespace EcoStore.Modelos.DTOs;

public class ItemCarritoDTO
{
    public Guid UsuarioId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}