using EcoStore.Modelos.DTOs;
using EcoStore.Modelos.Entidades;

namespace EcoStore.Servicios.Interfaces;

public interface IOrdenService
{
    Task<Orden> CrearOrdenAsync(OrdenCrearDTO ordenDTO);
    Task<Orden> ObtenerOrdenPorIdAsync(Guid id);
}