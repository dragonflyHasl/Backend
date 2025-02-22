using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoStore.Modelos.Entidades;

public class Orden
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("Usuario")]
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public DateTime FechaOrden { get; set; } = DateTime.UtcNow;
    public decimal MontoTotal { get; set; }
    public string Estado { get; set; } = "Pendiente";
    public string DireccionEnvio { get; set; } = null!;

    public List<DetalleOrden> Detalles { get; set; } = new();
}