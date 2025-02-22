namespace EcoStore.Modelos.DTOs;

public class ProductoActualizarDTO
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Precio { get; set; }
    public int? Stock { get; set; }
    public int? CategoriaId { get; set; }
    public bool? EsEcologico { get; set; }
}