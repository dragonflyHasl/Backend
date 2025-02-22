using EcoStore.Modelos.Entidades;

namespace EcoStore.Datos;

public static class InicializadorBD
{
    public static async Task SembrarDatos(EcoContexto contexto)
    {
        if (!contexto.Categorias.Any())
        {
            var categorias = new List<Categoria>
            {
                new() { Nombre = "Higiene", Descripcion = "Productos ecológicos para el cuidado personal" },
                new() { Nombre = "Hogar", Descripcion = "Artículos sostenibles para el hogar" }
            };

            await contexto.Categorias.AddRangeAsync(categorias);
            await contexto.SaveChangesAsync();
        }

        if (!contexto.Usuarios.Any(u => u.Rol == "Administrador"))
        {
            var admin = new Usuario
            {
                Correo = "admin@ecostore.com",
                NombreCompleto = "Administrador del Sistema",
                Rol = "Administrador"
            };

            // Generar hash de contraseña (contraseña: Admin123)
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            admin.HashContraseña = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Admin123"));
            admin.SalContraseña = hmac.Key;

            await contexto.Usuarios.AddAsync(admin);
            await contexto.SaveChangesAsync();
        }
    }
}