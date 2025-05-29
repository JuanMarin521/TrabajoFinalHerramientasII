﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final_herramientas_II.Models
{
    public abstract class Usuario
    {
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contraseña { get; set; } 
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public string Apellido { get; set; }

        public abstract void MostrarPermisos();
    }
}
