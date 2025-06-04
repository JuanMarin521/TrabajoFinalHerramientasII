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
                string confirmContraseña = txtConfirmPassword.Text.Trim();

                string tipoMembresia = cmbMembresia.SelectedItem?.ToString() ?? "Básico";
                string rol = cmbRol.SelectedItem?.ToString() ?? "Cliente";

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(nombreUsuario) ||
                    string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Validación de nombre y apellido (solo letras y espacios)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nombreUsuario, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                {
                    MessageBox.Show("El nombre solo debe contener letras.", "Nombre inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                {
                    MessageBox.Show("El apellido solo debe contener letras.", "Apellido inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación de teléfono (10 dígitos numéricos)
                if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$"))
                {
                    MessageBox.Show("El teléfono debe contener exactamente 10 dígitos numéricos.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (contraseña != confirmContraseña)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error en contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Data Source=LAPTOP-5OE3AFLL\\SQLEXPRESS;Initial Catalog=Herramientas;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Verificar si el usuario ya existe
                    string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario";
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
                SELECT SCOPE_IDENTITY();";

                    int usuarioId;
                    using (SqlCommand insertUsuarioCmd = new SqlCommand(insertUsuarioQuery, con))
                    {
                        insertUsuarioCmd.Parameters.AddWithValue("@usuario", usuario);
                        insertUsuarioCmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        insertUsuarioCmd.Parameters.AddWithValue("@contraseña", contraseña);
                        insertUsuarioCmd.Parameters.AddWithValue("@rol", rol);

                        usuarioId = Convert.ToInt32(insertUsuarioCmd.ExecuteScalar());
                    }

                    // Insertar en Clientes
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

                // Limpiar campos
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //cerrar formulario registrar
            this.Close();
        }
    }
}
