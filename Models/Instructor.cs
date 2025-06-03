using System;

namespace Trabajo_final_herramientas_II.Models
{
    public class Instructor : Usuario
    {
        public int InstructorID { get; set; } // ✅ Necesario para identificar en BD
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }

        public Instructor()
        {
            Rol = "Instructor";
        }

        public override void MostrarPermisos()
        {
            Console.WriteLine("Permisos: Ver y gestionar las clases a su cargo.");
        }
    }
}
