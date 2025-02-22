using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoStore.Modelos.Entidades;

[Table("DetallesOrden")]
public class DetalleOrden
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Orden")]
    public Guid OrdenId { get; set; }
    public Orden Orden { get; set; } = null!;

    [Required]
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal PrecioUnitario { get; set; }
}