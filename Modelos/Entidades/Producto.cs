using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoStore.Modelos.Entidades;

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(500)]
    public string? Descripcion { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Precio { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;

    public bool EsEcologico { get; set; } = true;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}