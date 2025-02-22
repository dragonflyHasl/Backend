using EcoStore.Modelos.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EcoStore.Datos;

public class EcoContexto : DbContext
{
    public EcoContexto(DbContextOptions<EcoContexto> options) : base(options) { }

    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Carrito> Carrito => Set<Carrito>();
    public DbSet<Orden> Ordenes => Set<Orden>();
    public DbSet<DetalleOrden> DetallesOrden => Set<DetalleOrden>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de relaciones
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId);

        modelBuilder.Entity<Carrito>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.Carritos)
            .HasForeignKey(c => c.UsuarioId);

        modelBuilder.Entity<Orden>()
            .HasOne(o => o.Usuario)
            .WithMany(u => u.Ordenes)
            .HasForeignKey(o => o.UsuarioId);

        modelBuilder.Entity<DetalleOrden>()
            .HasOne(d => d.Orden)
            .WithMany(o => o.Detalles)
            .HasForeignKey(d => d.OrdenId);
    }
}