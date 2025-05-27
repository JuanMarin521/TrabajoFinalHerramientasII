using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Factories
{
    public static class ClienteFactory
    {
        public static Cliente Crear(string nombre, string apellido, string telefono, string tipoMembresia)
        {
            return new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                TipoMembresia = tipoMembresia
            };
        }
    }
}