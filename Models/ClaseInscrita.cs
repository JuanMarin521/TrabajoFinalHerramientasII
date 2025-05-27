using System;

namespace Trabajo_final_herramientas_II.Models
{
    public class ClaseInscrita
    {
        public int ClienteID { get; set; }
        public int ClaseID { get; set; }
        public string NombreClase { get; set; }  
        public DateTime FechaInscripcion { get; set; }
    }
}
