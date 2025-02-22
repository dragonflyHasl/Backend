namespace EcoStore.Modelos.DTOs;

public class ProductoCrearDTO
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int CategoriaId { get; set; }
    public bool EsEcologico { get; set; } = true;
}