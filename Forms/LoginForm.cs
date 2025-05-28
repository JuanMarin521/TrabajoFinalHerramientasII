using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Repositories;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioRepository usuarioRepository = new UsuarioRepository();

        private Usuario _usuario;
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                string nombreUsuario = txtUsuario.Text.Trim();
                string contraseña = txtPassword.Text;

                if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuario = usuarioRepository.ValidarCredenciales(nombreUsuario, contraseña);

                if (usuario != null)
                {
                    MessageBox.Show($"Bienvenido {usuario.Nombre}. Rol: {usuario.Rol}", "Éxito");

                    this.Hide();

                    // Abrir el formulario correspondiente según el rol
                    switch (usuario.Rol)
                    {
                        case "Administrador":
                            // new FormAdministrador().Show();
                            break;
                        case "Instructor":
                            // new FormInstructor().Show();
                            break;
                        case "Cliente":
                            new FormClientes().Show();
                            break;
                        default:
                            MessageBox.Show("Rol no reconocido.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistroCliente formRegistro = new FormRegistroCliente();
            formRegistro.ShowDialog();
        }
    }
    // Add a constructor to FormClientes that accepts a Usuario parameter
    
}
