﻿using System.Data.SqlClient ;


namespace Trabajo_final_herramientas_II.Data
{
    public sealed class DatabaseSingleton
    {
        private static readonly DatabaseSingleton _instance = new DatabaseSingleton();
        private readonly SqlConnection _connection;

        private DatabaseSingleton()
        {
            // Cambia el connection string según tu servidor
            //  string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";
            string connectionString = "Data Source=SEBASTIAN;Initial Catalog=Herramientas;Integrated Security=True";

            _connection = new SqlConnection(connectionString);
        }

        public static DatabaseSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }
}
