using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_final_herramientas_II.Repositories;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Data;
using System.Data.SqlClient;


namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormRegistroCliente : Form
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();
        private readonly string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";
        public FormRegistroCliente()
        {
            InitializeComponent();
            Repositories.ClienteRepository repo = new Repositories.ClienteRepository();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUser.Text.Trim();
                string nombreUsuario = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string contraseña = txtPassword.Text.Trim();
                string tipoMembresia = cmbMembresia.SelectedItem?.ToString() ?? "Básico";
                string rol = "Cliente"; 

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(nombreUsuario) ||
                    string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Verificar si el usuario ya existe
                    string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@usuario", usuario);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Ese nombre de usuario ya está en uso. Elige otro.", "Usuario existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insertar en Usuarios
                    string insertUsuarioQuery = @"
                INSERT INTO Usuarios (Usuario, NombreUsuario, Contraseña, Rol)
                VALUES (@usuario, @nombreUsuario, @contraseña, @rol);
                SELECT SCOPE_IDENTITY();"; // para obtener el ID generado

                    int usuarioId;
                    using (SqlCommand insertUsuarioCmd = new SqlCommand(insertUsuarioQuery, con))
                    {
                        insertUsuarioCmd.Parameters.AddWithValue("@usuario", usuario);
                        insertUsuarioCmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        insertUsuarioCmd.Parameters.AddWithValue("@contraseña", contraseña);
                        insertUsuarioCmd.Parameters.AddWithValue("@rol", rol);

                        usuarioId = Convert.ToInt32(insertUsuarioCmd.ExecuteScalar());
                    }

                    string insertClienteQuery = @"
                INSERT INTO Clientes (Nombre, Apellido, Telefono, TipoMembresia)
                VALUES (@nombreUsuario, @apellido, @telefono, @tipoMembresia);";

                    using (SqlCommand insertClienteCmd = new SqlCommand(insertClienteQuery, con))
                    {
                        insertClienteCmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        insertClienteCmd.Parameters.AddWithValue("@apellido", apellido);
                        insertClienteCmd.Parameters.AddWithValue("@telefono", telefono);
                        insertClienteCmd.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);

                        insertClienteCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario y cliente registrados exitosamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUser.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
                txtPassword.Clear();
                cmbMembresia.SelectedIndex = -1;

                 this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormRegistroCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
