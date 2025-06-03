using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_final_herramientas_II.Data;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Repositories
{

    public class InstructorRepository
    {
        private readonly SqlConnection connection;

        public InstructorRepository()
        {
            connection = DatabaseSingleton.Instance.Connection;
        }

        public void Agregar(Models.Instructor instructor)
        {
            string query = @"INSERT INTO Instructores 
                             (UsuarioLogin, Contraseña, UsuarioNombre, Especialidad, Disponible) 
                             VALUES (@UsuarioLogin, @Contraseña, @UsuarioNombre, @Especialidad, @Disponible)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsuarioLogin", instructor.UsuarioLogin);
                cmd.Parameters.AddWithValue("@Contraseña", instructor.Contraseña);
                cmd.Parameters.AddWithValue("@UsuarioNombre", instructor.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Especialidad", instructor.Especialidad);
                cmd.Parameters.AddWithValue("@Disponible", instructor.Disponible);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Models.Instructor> ObtenerTodos()
        {
            List<Models.Instructor> lista = new List<Models.Instructor>();
            string query = "SELECT * FROM Instructores";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Models.Instructor
                        {
                            InstructorID = Convert.ToInt32(reader["InstructorID"]),
                            UsuarioID = Convert.ToInt32(reader["InstructorID"]), // Usa mismo campo si no hay UsuarioID separado
                            UsuarioLogin = reader["UsuarioLogin"].ToString(),
                            Contraseña = reader["Contraseña"].ToString(),
                            UsuarioNombre = reader["UsuarioNombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Disponible = Convert.ToBoolean(reader["Disponible"])
                        });
                    }
                }
            }

            return lista;
        }

        public void Editar(Models.Instructor instructor)
        {
            string query = @"UPDATE Instructores 
                             SET UsuarioLogin = @UsuarioLogin, Contraseña = @Contraseña,
                                 UsuarioNombre = @UsuarioNombre, Especialidad = @Especialidad,
                                 Disponible = @Disponible 
                             WHERE InstructorID = @InstructorID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UsuarioLogin", instructor.UsuarioLogin);
                cmd.Parameters.AddWithValue("@Contraseña", instructor.Contraseña);
                cmd.Parameters.AddWithValue("@UsuarioNombre", instructor.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Especialidad", instructor.Especialidad);
                cmd.Parameters.AddWithValue("@Disponible", instructor.Disponible);
                cmd.Parameters.AddWithValue("@InstructorID", instructor.InstructorID);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int instructorId, int usuarioId)
        {
            string query = "DELETE FROM Instructores WHERE InstructorID = @InstructorID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InstructorID", instructorId);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}