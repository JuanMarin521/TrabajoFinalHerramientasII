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
            string query = @"INSERT INTO Clases (Nombre, Horario, CupoDisponible, Sala)
                     VALUES (@nombre, @horario, @cupo, @sala)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                cmd.Parameters.AddWithValue("@nombre", clase.Nombre);
                cmd.Parameters.AddWithValue("@horario", clase.Horario);
                cmd.Parameters.AddWithValue("@cupo", clase.CupoDisponible);
                cmd.Parameters.AddWithValue("@sala", clase.Sala);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Clase> ObtenerDisponibles()
        {
            List<Clase> clases = new List<Clase>();
            string query = "SELECT * FROM Clases WHERE CupoDisponible > 0";

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
                            Nombre = reader["Nombre"].ToString(),
                            Horario = (DateTime)reader["Horario"],
                            CupoDisponible = (int)reader["CupoDisponible"],
                            Sala = reader["Sala"].ToString()
                        });
                    }
                }
            }

            return clases;
        }
    }
}
