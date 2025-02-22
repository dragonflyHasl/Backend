using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoStore.Modelos.Entidades;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Correo { get; set; } = null!;

    [Required]
    [Column("HashContraseña")]
    public byte[] HashContraseña { get; set; } = null!;

    [Required]
    [Column("SalContraseña")]
    public byte[] SalContraseña { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string NombreCompleto { get; set; } = null!;

    [StringLength(20)]
    public string Rol { get; set; } = "Usuario"; // Valores: Usuario, Administrador

    [Column("FechaCreacion")]
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    // Relaciones
    public List<Carrito> Carritos { get; set; } = new();
    public List<Orden> Ordenes { get; set; } = new();
}