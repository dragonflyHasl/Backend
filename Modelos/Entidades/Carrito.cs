using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoStore.Modelos.Entidades;

public class Carrito
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    [Required]
    public int Cantidad { get; set; }
    public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
}