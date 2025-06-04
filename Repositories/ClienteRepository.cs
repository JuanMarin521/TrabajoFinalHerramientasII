using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Data; 
using Trabajo_final_herramientas_II.Repositories;

namespace Trabajo_final_herramientas_II.Repositories
{
    public class ClienteRepository
    {
        private readonly SqlConnection connection;

        public ClienteRepository()
        {
            connection = DatabaseSingleton.Instance.Connection;
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "SELECT * FROM Clientes";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            UsuarioID = Convert.ToInt32(reader["ClienteID"]),
                            UsuarioNombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            TipoMembresia = reader["TipoMembresia"].ToString()
                        });
                    }
                }
            }

            return clientes;
        }

        public bool Insertar(Cliente cliente)
        {
            string query = "INSERT INTO Clientes (Nombre, Apellido, Telefono, TipoMembresia) VALUES (@Nombre, @Apellido, @Telefono, @TipoMembresia)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Nombre", cliente.UsuarioNombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);
               
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            string query = @"UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido,
                             Telefono = @Telefono, TipoMembresia = @TipoMembresia
                             WHERE ClienteID = @ClienteID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", cliente.UsuarioID);
                command.Parameters.AddWithValue("@Nombre", cliente.UsuarioNombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int clienteID)
        {
            string query = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", clienteID);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "SELECT * FROM Clientes WHERE Nombre LIKE @Nombre";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            UsuarioID = Convert.ToInt32(reader["ClienteID"]),
                            UsuarioNombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            TipoMembresia = reader["TipoMembresia"].ToString()
                        });
                    }
                }
            }

            return clientes;
        }

        public Cliente ObtenerPorID(int id)
        {
            string query = "SELECT * FROM Clientes WHERE ClienteID = @ClienteID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClienteID", id);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            UsuarioID = Convert.ToInt32(reader["ClienteID"]),
                            UsuarioNombre = reader["UsuarioNombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            TipoMembresia = reader["TipoMembresia"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public Cliente ObtenerPorClienteID(int clienteID)
        {
            using (var connection = new SqlConnection("Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True"))
            {
                string query = "SELECT * FROM Clientes WHERE ClienteID = @clienteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@clienteID", clienteID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Cliente
                    {
                        UsuarioID = clienteID,
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
