namespace EcoStore.Utilidades.Excepciones;

public class ExcepcionPersonalizada : Exception
{
    public ExcepcionPersonalizada(string mensaje) : base(mensaje) { }
}