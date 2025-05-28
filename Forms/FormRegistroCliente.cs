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


namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormRegistroCliente : Form
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();
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
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    TipoMembresia = cmbMembresia.SelectedItem?.ToString() ?? "Básico"
                };

                ClienteRepository repo = new ClienteRepository();
                bool registrado = repo.Insertar(nuevoCliente);

                if (registrado)
                {
                    MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.");
                    this.Close(); // Cierra el formulario de registro
                    // Aquí podrías abrir el formulario de inicio de sesión si es necesario
                    new LoginForm().Show();
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
    }
    
}
