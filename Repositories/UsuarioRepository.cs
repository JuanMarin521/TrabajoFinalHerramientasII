using System;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Factory;
using Trabajo_final_herramientas_II.Factories;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class UsuarioRepository
    {
        private string connectionString = "Data Source=DESKTOP-0KBBNKK;Initial Catalog=Herramientas;Integrated Security=True";

        public Usuario ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;

            string query = "SELECT UsuarioID, NombreUsuario, Rol FROM Usuarios WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string rol = reader["Rol"].ToString();

                        usuario = UsuarioFactory.CrearUsuario(rol);
                        usuario.UsuarioID = (int)reader["UsuarioID"];
                        usuario.Contraseña = reader["Contraseña"].ToString();
                    }
                }
            }

            return usuario;
        }

        public bool RegistrarUsuario(string nombreUsuario, string contraseña, string rol)
        {
            string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol) VALUES (@nombreUsuario, @contraseña, @rol)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@rol", rol);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

