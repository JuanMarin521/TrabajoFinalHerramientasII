using System;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Factories;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class UsuarioRepository
    {
       // private string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";
         private string connectionString = "Data Source=SEBASTIAN;Initial Catalog=Herramientas;Integrated Security=True";


        // Valida usuario y contraseña y devuelve un objeto Usuario con el rol correspondiente
        public Usuario ValidarCredenciales(string usuario, string contraseña)
        {
            Usuario resultado = null;

            string query = @"SELECT UsuarioID, Usuario, NombreUsuario, Contraseña, Rol 
                     FROM Usuarios 
                     WHERE Usuario = @usuario AND Contraseña = @contraseña";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string rol = reader["Rol"].ToString();

                        resultado = UsuarioFactory.CrearUsuario(rol);
                        resultado.UsuarioID = Convert.ToInt32(reader["UsuarioID"]);
                        resultado.UsuarioNombre = reader["Usuario"].ToString(); // aquí pones el usuario (ejemplo jpmarine)
                        resultado.Rol = rol;
                    }
                }
            }

            return resultado;
        }


        // Registra un nuevo usuario en la base de datos
        public bool RegistrarUsuario(string usuario, string nombreCompleto, string contraseña, string rol)
        {
            string query = @"INSERT INTO Usuarios (Usuario, NombreUsuario, Contraseña, Rol) 
                             VALUES (@usuario, @nombreUsuario, @contraseña, @rol)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Usuario: nombre corto de usuario
                cmd.Parameters.AddWithValue("@usuario", usuario);
                // NombreUsuario: nombre completo o display name
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreCompleto);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@rol", rol);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

     

        // Obtiene el cliente relacionado al nombre de usuario (NombreUsuario)
        public Cliente ObtenerPorUsuarioNombre(string usuarioNombre)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clientes WHERE Nombre = @nombreUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombreUsuario", usuarioNombre);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                UsuarioID = Convert.ToInt32(reader["ClienteID"]),
                                UsuarioNombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                TipoMembresia = reader["TipoMembresia"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
