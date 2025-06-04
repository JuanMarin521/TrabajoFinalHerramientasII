using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Data;
using Trabajo_final_herramientas_II.Models;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class ClaseRepository
    {
        private readonly SqlConnection connection;

        public ClaseRepository()
        {
            connection = DatabaseSingleton.Instance.Connection;
        }

        public void AgregarClase(Clase clase)
        {
            
            string query = @"INSERT INTO Clases (NombreClase, TipoClase, Horario, CupoMaximo, InstructorID)
                     VALUES (@nombreClase, @tipoClase, @horario, @cupoMaximo, @instructorID)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                cmd.Parameters.AddWithValue("@nombreClase", clase.Nombre);
                cmd.Parameters.AddWithValue("@tipoClase", clase.Sala ?? "General"); 
                cmd.Parameters.AddWithValue("@horario", clase.Horario);
                cmd.Parameters.AddWithValue("@cupoMaximo", clase.CupoDisponible);
                cmd.Parameters.AddWithValue("@instructorID", DBNull.Value); 
                cmd.ExecuteNonQuery();
            }
        }

        public List<Clase> ObtenerDisponibles()
        {
            List<Clase> clases = new List<Clase>();
           
            string query = "SELECT * FROM Clases WHERE CupoMaximo > 0";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clases.Add(new Clase
                        {
                            ClaseID = (int)reader["ClaseID"],
                            Nombre = reader["NombreClase"].ToString(), 
                            Horario = (DateTime)reader["Horario"],
                            CupoDisponible = (int)reader["CupoMaximo"],
                            Sala = reader["TipoClase"].ToString() 
                        });
                    }
                }
            }
            return clases;
        }

        public List<Clase> ObtenerTodas()
        {
            List<Clase> clases = new List<Clase>();
            
            string query = "SELECT * FROM Clases";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clases.Add(new Clase
                        {
                            ClaseID = (int)reader["ClaseID"],
                            Nombre = reader["NombreClase"].ToString(), 
                            Horario = (DateTime)reader["Horario"],
                            CupoDisponible = (int)reader["CupoMaximo"], 
                            Sala = reader["TipoClase"].ToString() 
                        });
                    }
                }
            }
            return clases;
        }

        public List<Clase> ObtenerConCupoDisponible()
        {
            return ObtenerDisponibles(); // Reutiliza el método existente
        }

        public void ActualizarClase(Clase clase)
        {
            // CORREGIDO: Usar nombres de columnas correctos
            string query = @"UPDATE Clases 
                           SET NombreClase = @nombreClase, 
                               TipoClase = @tipoClase,
                               Horario = @horario, 
                               CupoMaximo = @cupoMaximo
                           WHERE ClaseID = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                cmd.Parameters.AddWithValue("@id", clase.ClaseID);
                cmd.Parameters.AddWithValue("@nombreClase", clase.Nombre);
                cmd.Parameters.AddWithValue("@tipoClase", clase.Sala ?? "General"); 
                cmd.Parameters.AddWithValue("@horario", clase.Horario);
                cmd.Parameters.AddWithValue("@cupoMaximo", clase.CupoDisponible);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarClase(int claseId)
        {
            string query = "DELETE FROM Clases WHERE ClaseID = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                cmd.Parameters.AddWithValue("@id", claseId);
                cmd.ExecuteNonQuery();
            }
        }

        public Clase ObtenerPorId(int claseId)
        {
            // CORREGIDO: Usar nombres de columnas correctos
            string query = "SELECT * FROM Clases WHERE ClaseID = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                cmd.Parameters.AddWithValue("@id", claseId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Clase
                        {
                            ClaseID = (int)reader["ClaseID"],
                            Nombre = reader["NombreClase"].ToString(), 
                            Horario = (DateTime)reader["Horario"],
                            CupoDisponible = (int)reader["CupoMaximo"], 
                            Sala = reader["TipoClase"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}