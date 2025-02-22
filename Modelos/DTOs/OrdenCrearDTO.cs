namespace EcoStore.Modelos.DTOs;

public class OrdenCrearDTO
{
    public Guid UsuarioId { get; set; }
    public string DireccionEnvio { get; set; } = null!;
    public List<ItemOrdenDTO> Items { get; set; } = new();
}

public class ItemOrdenDTO
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}