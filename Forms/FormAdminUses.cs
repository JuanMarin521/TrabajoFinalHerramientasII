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
    public partial class FormAdminUses : Form
    {
        private InstructorRepository repo = new InstructorRepository();
        private ClienteRepository ClienteRepository = new ClienteRepository();
        private ClaseRepository ClaseRepository = new ClaseRepository();

        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private ClienteRepository clienteRepository = new ClienteRepository();

        //Variables de instructores
        private InstructorRepository repoInstructor = new InstructorRepository();
        private Instructor instructorSeleccionado = null;

        public FormAdminUses()
        {
            InitializeComponent();
            CargarInstructores();

        }

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteUsuario.Text) ||
            string.IsNullOrWhiteSpace(txtClienteNombre.Text) ||
            string.IsNullOrWhiteSpace(txtClienteApellido.Text) ||
            string.IsNullOrWhiteSpace(txtClientePassword.Text) ||
            string.IsNullOrWhiteSpace(txtClienteTelefono.Text) ||
            cmbClienteMembresia.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            try
            {
                // Paso 1: Insertar en la tabla Usuarios
                bool usuarioRegistrado = usuarioRepository.RegistrarUsuario(
                    txtClienteUsuario.Text.Trim(),
                    txtClienteNombre.Text.Trim() + " " + txtClienteApellido.Text.Trim(),
                    txtClientePassword.Text.Trim(),
                    "Cliente" // Rol
                );

                if (!usuarioRegistrado)
                {
                    MessageBox.Show("No se pudo registrar el usuario.");
                    return;
                }

                // Paso 2: Insertar en la tabla Clientes (usando solo lo necesario)
                Cliente nuevoCliente = new Cliente
                {
                    UsuarioLogin = txtClienteUsuario.Text.Trim(),
                    UsuarioNombre = txtClienteNombre.Text.Trim() + " " + txtClienteApellido.Text.Trim(),
                    Contraseña = txtClientePassword.Text.Trim(),
                    Telefono = txtClienteTelefono.Text.Trim(),
                    TipoMembresia = cmbClienteMembresia.SelectedItem.ToString()
                };

                clienteRepository.Insertar(nuevoCliente);

                MessageBox.Show("Cliente agregado correctamente.");
                CargarClientesEnGrid();
                LimpiarCamposCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cliente: " + ex.Message);
            }
        }

        private void btnaddInst_Click(object sender, EventArgs e)
        {
            try
            {
                Instructor nuevo = new Instructor
                {
                    UsuarioNombre = txtNombre.Text,
                    Especialidad = txtEspecialidad.Text,
                    Disponible = chkDisponible.Checked
                };

                repoInstructor.Agregar(nuevo);
                MessageBox.Show("Instructor agregado correctamente.");
                CargarInstructores();
                LimpiarCamposInstructor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar instructor: " + ex.Message);
            }
        }

        private void dgvInstru_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                instructorSeleccionado = (Instructor)dgvInstru.Rows[e.RowIndex].DataBoundItem;
                txtNombre.Text = instructorSeleccionado.UsuarioNombre;
                txtEspecialidad.Text = instructorSeleccionado.Especialidad;
                chkDisponible.Checked = instructorSeleccionado.Disponible;
            }
        }

        private void LimpiarCamposInstructor()
        {
            txtNombre.Text = "";
            txtEspecialidad.Text = "";
            chkDisponible.Checked = false;
            instructorSeleccionado = null;
        }
        private void CargarClientesEnGrid()
        {
            dgvClientes.DataSource = ClienteRepository.ObtenerTodos();
        }

        private void LimpiarCamposCliente()
        {
            txtClienteUsuario.Clear();
            txtClienteNombre.Clear();
            txtClientePassword.Clear();
            txtClienteTelefono.Clear();
        }

        private void CargarInstructores()
        {
            dgvInstru.DataSource = null;
            dgvInstru.DataSource = repoInstructor.ObtenerTodos();
            dgvInstru.ClearSelection();

            //dgvInstru.Columns["InstructorID"].Visible = false;
            dgvInstru.Columns["UsuarioNombre"].HeaderText = "Nombre";
            dgvInstru.Columns["Especialidad"].HeaderText = "Especialidad";
            dgvInstru.Columns["Disponible"].HeaderText = "Disponible";

            // Establecer el orden visual de las columnas
            dgvInstru.Columns["InstructorID"].DisplayIndex = 0;
            dgvInstru.Columns["UsuarioNombre"].DisplayIndex = 1;
            dgvInstru.Columns["Especialidad"].DisplayIndex = 2;
            dgvInstru.Columns["Disponible"].DisplayIndex = 3;


            // Ocultar columnas heredadas que no uses
            dgvInstru.Columns["UsuarioLogin"].Visible = false;
            dgvInstru.Columns["Contraseña"].Visible = false;
            dgvInstru.Columns["Rol"].Visible = false;
            dgvInstru.Columns["Telefono"].Visible = false;
            dgvInstru.Columns["Apellido"].Visible = false;
        }

        private void btneditInst_Click(object sender, EventArgs e)
        {
            if (dgvInstru.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvInstru.CurrentRow.Cells["InstructorID"].Value);

                var instructor = new Instructor
                {
                    InstructorID = id,
                    UsuarioNombre = txtNombre.Text,
                    Especialidad = txtEspecialidad.Text,
                    Disponible = chkDisponible.Checked
                };

                repoInstructor.Editar(instructor);
                MessageBox.Show("Instructor editado correctamente.");

                CargarInstructores(); // vuelve a cargar los datos actualizados en el DataGridView
            }
            else
            {
                MessageBox.Show("Seleccione un instructor a editar.");
            }
        }

        private void btnDeleInst_Click(object sender, EventArgs e)
        {
            if (instructorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un instructor para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este instructor?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    repoInstructor.Eliminar(instructorSeleccionado.InstructorID);
                    MessageBox.Show("Instructor eliminado correctamente.");
                    CargarInstructores();
                    LimpiarCamposInstructor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar instructor: " + ex.Message);
                }
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);

            Cliente clienteActualizado = new Cliente
            {
                UsuarioID = id,
                UsuarioNombre = txtClienteNombre.Text.Trim(),
                Contraseña = txtClientePassword.Text.Trim(),
                Telefono = txtClienteTelefono.Text.Trim(),
                TipoMembresia = cmbClienteMembresia.SelectedItem.ToString()
            };

            try
            {
                clienteRepository.Actualizar(clienteActualizado);
                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientesEnGrid();
                LimpiarCamposCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
            }
        }

        private void btnDeleClient_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            string usuarioLogin = dgvClientes.CurrentRow.Cells["UsuarioLogin"].Value.ToString();

            DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    clienteRepository.Eliminar(id);
                    //usuarioRepository.Eliminar(usuarioLogin);
                    MessageBox.Show("Cliente eliminado correctamente.");
                    CargarClientesEnGrid();
                    LimpiarCamposCliente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }
        private void LimpiarCamposClase()
        {
            txtNombreClase.Clear();
            txtCupo.Clear();
            txtSala.Clear();
            dtpHorario.Value = DateTime.Now;
        }

        private void CargarClasesEnGrid()
        {
            var clases = ClaseRepository.ObtenerDisponibles(); // Debes implementar este método si no lo tienes
            dgvClases.DataSource = null;
            dgvClases.DataSource = clases;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreClase.Text) ||
       string.IsNullOrWhiteSpace(txtCupo.Text) ||
       string.IsNullOrWhiteSpace(txtSala.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            int cupoDisponible;
            if (!int.TryParse(txtCupo.Text, out cupoDisponible) || cupoDisponible < 1)
            {
                MessageBox.Show("El cupo debe ser un número válido mayor a cero.");
                return;
            }

            Clase nuevaClase = new Clase
            {
                Nombre = txtNombreClase.Text.Trim(),
                Horario = dtpHorario.Value,
                CupoDisponible = cupoDisponible,
                Sala = txtSala.Text.Trim()
            };

            try
            {
                ClaseRepository.AgregarClase(nuevaClase); 
                MessageBox.Show("Clase agregada exitosamente.");
                LimpiarCamposClase();
                CargarClasesEnGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la clase: " + ex.Message);
            }
        }

        private void FormAdminUses_Load(object sender, EventArgs e)
        {
            CargarInstructores();

        }
    }
}
