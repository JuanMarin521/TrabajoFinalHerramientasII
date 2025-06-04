using System;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
//using Trabajo_final_herramientas_II.Factory;
using Trabajo_final_herramientas_II.Factories;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class UsuarioRepository
    {
        private string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";

        public Usuario ValidarCredenciales(string usuario, string contraseña)
        {
            Usuario resultado = null;

            string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";

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
                        resultado.UsuarioID = (int)reader["UsuarioID"];
                        resultado.UsuarioNombre = reader["Usuario"].ToString();
                        resultado.Rol = rol;
                    }
                }
            }

            return resultado;
        }

        public bool RegistrarUsuario(string nombreUsuario, string contraseña, string rol)
        {
            string query = "INSERT INTO Usuarios (Usuario, NombreUsuario, Contraseña, Rol) VALUES (@usuario, @nombreUsuario, @contraseña, @rol)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario); 
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario); 
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@rol", rol); 

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public Cliente ObtenerPorUsuarioNombre(string usuarioNombre)
        {
            using (var connection = new SqlConnection("Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True"))
            {
                string query = "SELECT * FROM Clientes WHERE Nombre = @nombreUsuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombreUsuario", usuarioNombre);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Cliente
                    {
                        UsuarioID = (int)reader["ClienteID"],
                        UsuarioNombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        TipoMembresia = reader["TipoMembresia"].ToString()
                    };
                }
            }

            return null;
        }
    }
}

