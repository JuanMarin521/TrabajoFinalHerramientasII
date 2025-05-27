using System;

namespace Trabajo_final_herramientas_II.Models
{
    public class Clase
    {
        public int ClaseID { get; set; }
        public string Nombre { get; set; }
        public DateTime Horario { get; set; }
        public int CupoDisponible { get; set; }
        public string Sala { get; set; }
    }
}