using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public void Agregar(Instructor instructor)
        {
            string query = @"INSERT INTO Instructores 
                     (Nombre, Especialidad, Disponibilidad) 
                     VALUES (@Nombre, @Especialidad, @Disponibilidad);
                     SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", instructor.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Especialidad", instructor.Especialidad);
                cmd.Parameters.AddWithValue("@Disponibilidad", instructor.Disponible);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Recuperar el ID generado
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    instructor.InstructorID = Convert.ToInt32(result);
                }
            }
        }

        public List<Instructor> ObtenerTodos()
        {
            var lista = new List<Instructor>();
            string query = "SELECT * FROM Instructores";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Instructor
                        {
                            InstructorID = Convert.ToInt32(reader["InstructorID"]),
                            UsuarioNombre = reader["Nombre"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Disponible = Convert.ToBoolean(reader["Disponibilidad"])
                        });
                    }
                }
            }
            return lista;
        }

        public void Editar(Instructor instructor)
        {
            string query = @"UPDATE Instructores 
                     SET Nombre = @Nombre, 
                         Especialidad = @Especialidad,
                         Disponibilidad = @Disponibilidad 
                     WHERE InstructorID = @InstructorID";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", instructor.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Especialidad", instructor.Especialidad);
                cmd.Parameters.AddWithValue("@Disponibilidad", instructor.Disponible);
                cmd.Parameters.AddWithValue("@InstructorID", instructor.InstructorID);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int instructorId)
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
