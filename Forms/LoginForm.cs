using System;
using System.Windows.Forms;
using Trabajo_final_herramientas_II.Models;
using Trabajo_final_herramientas_II.Repositories;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioRepository usuarioRepository = new UsuarioRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsuario.Text.Trim();
                string contraseña = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuario = usuarioRepository.ValidarCredenciales(username, contraseña);

                if (usuario != null)
                {
                    MessageBox.Show($"Bienvenido {usuario.UsuarioNombre}. Rol: {usuario.Rol}", "Éxito");

                    this.Hide();

                    switch (usuario.Rol)
                    {
                        case "Administrador":
                            FormAdministrador formAdmin = new FormAdministrador();
                            formAdmin.Show();   
                            break;
                        case "Instructor":
                            FormInstructor formInstructor = new FormInstructor();
                            formInstructor.Show();
                            break;
                        case "Cliente":
                            FormUsuario formUsuario1 = new FormUsuario(null);
                            formUsuario1.Show();
                            ClienteRepository clienteRepo = new ClienteRepository();
                            Cliente cliente = clienteRepo.ObtenerPorUsuarioID(usuario.UsuarioID);

                            if (cliente != null)
                            {
                                FormUsuario formUsuario = new FormUsuario(cliente);
                                formUsuario.Show();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró al cliente en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Show();
                            }
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
}


