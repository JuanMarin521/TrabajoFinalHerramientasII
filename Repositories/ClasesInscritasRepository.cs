using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Data;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class ClasesInscritasRepository
    {
        private readonly SqlConnection connection;

        private readonly string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";


        public ClasesInscritasRepository()
        {
            connection = DatabaseSingleton.Instance.Connection;
        }

        public bool InscribirCliente(int clienteID, int claseID)
        {
            string query = "INSERT INTO ClasesInscritas (ClienteID, ClaseID) VALUES (@clienteID, @claseID)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@clienteID", clienteID);
                cmd.Parameters.AddWithValue("@claseID", claseID);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool InscribirAClase(int clienteId, int claseId)
        {
            string query = @"
                INSERT INTO ClasesInscritas (ClienteID, ClaseID, FechaInscripcion)
                VALUES (@ClienteID, @ClaseID, GETDATE());
                
                UPDATE Clases SET CupoDisponible = CupoDisponible - 1
                WHERE ClaseID = @ClaseID AND CupoDisponible > 0;
            ";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                cmd.Parameters.AddWithValue("@ClaseID", claseId);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool YaInscrito(int clienteId, int claseId)
        {
            string query = @"SELECT COUNT(*) FROM ClasesInscritas WHERE ClienteID = @ClienteID AND ClaseID = @ClaseID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                    cmd.Parameters.AddWithValue("@ClaseID", claseId);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al verificar inscripción: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<ClaseInscrita> ObtenerPorCliente(int clienteId)
        {
            List<ClaseInscrita> lista = new List<ClaseInscrita>();
            string query = @"
                SELECT ci.ClaseID, ci.FechaInscripcion, c.Nombre AS NombreClase
                FROM ClasesInscritas ci
                JOIN Clases c ON ci.ClaseID = c.ClaseID
                WHERE ci.ClienteID = @ClienteID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteId);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClaseInscrita
                            {
                                ClaseID = (int)reader["ClaseID"],
                                NombreClase = reader["NombreClase"].ToString(),
                                FechaInscripcion = (DateTime)reader["FechaInscripcion"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al obtener clases inscritas: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return lista;
        }

        public List<Clase> ObtenerClasesPorCliente(int clienteID)
        {
            try {
                List<Clase> clases = new List<Clase>();

                string query = @"SELECT C.ClaseID, C.Nombre, C.Horario, C.CupoDisponible, C.Sala
                     FROM Clases C
                     INNER JOIN ClasesInscritas CI ON C.ClaseID = CI.ClaseID
                     WHERE CI.ClienteID = @clienteID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@clienteID", clienteID);
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clases por cliente: {ex.Message}");
                return new List<Clase>();
            }

            
        }

        public bool EliminarInscripcion(int clienteID, int claseID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ClasesInscritas WHERE ClienteID = @clienteID AND ClaseID = @claseID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@clienteID", clienteID);
                        cmd.Parameters.AddWithValue("@claseID", claseID);

                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar inscripción: {ex.Message}");
            }
            {
                // Puedes registrar o manejar el error si lo deseas
                return false;
            }
        }

    }
}
