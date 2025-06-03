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

        public FormAdminUses()
        {
            InitializeComponent();
            CargarInstructores();

        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteUsuario.Text) ||
       string.IsNullOrWhiteSpace(txtClienteNombre.Text) ||
       string.IsNullOrWhiteSpace(txtClientePassword.Text))
            {
                MessageBox.Show("Completa todos los campos obligatorios.");
                return;
            }

            Cliente nuevoCliente = new Cliente()
            {
                UsuarioLogin = txtClienteUsuario.Text.Trim(),
                UsuarioNombre = txtClienteNombre.Text.Trim(),
                Contraseña = txtClientePassword.Text.Trim(),
                Telefono = txtClienteTelefono.Text.Trim()
            };

            try
            {
                ClienteRepository.Insertar(nuevoCliente);
                MessageBox.Show("Cliente agregado correctamente.");
                CargarClientesEnGrid();  // Método para refrescar DataGridView
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
                    UsuarioLogin = txtUsuario.Text,
                    UsuarioNombre = txtNombre.Text,
                    Contraseña = txtPassword.Text,
                    Especialidad = txtEspecialidad.Text,
                    Disponible = chkDisponible.Checked
                };

                repo.Agregar(nuevo);
                MessageBox.Show("Instructor agregado correctamente.");
                CargarInstructores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar instructor: " + ex.Message);
            }
        }

        private void dgvInstru_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
            var repo = new InstructorRepository();
            var lista = repo.ObtenerTodos();

            dgvInstru.DataSource = null;
            dgvInstru.DataSource = lista;

            dgvInstru.Columns["UsuarioID"].Visible = false;
        }

        private void btneditInst_Click(object sender, EventArgs e)
        {
            if (dgvInstru.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un instructor para editar.");
                return;
            }

            try
            {
                Instructor instructorEdit = (Instructor)dgvInstru.CurrentRow.DataBoundItem;
                instructorEdit.UsuarioLogin = txtUsuario.Text;
                instructorEdit.UsuarioNombre = txtNombre.Text;
                instructorEdit.Contraseña = txtPassword.Text;
                instructorEdit.Especialidad = txtEspecialidad.Text;
                instructorEdit.Disponible = chkDisponible.Checked;

                Repo.Editar(instructorEdit);
                MessageBox.Show("Instructor editado correctamente.");
                CargarInstructores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar instructor: " + ex.Message);
            }
        }

        private void btnDeleInst_Click(object sender, EventArgs e)
        {
            if (dgvInstru.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un instructor para eliminar.");
                return;
            }

            try
            {
                Instructor instructorEliminar = (Instructor)dgvInstru.CurrentRow.DataBoundItem;

                // Confirmar eliminación
                var confirmResult = MessageBox.Show("¿Seguro que deseas eliminar este instructor?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    repo.Eliminar(instructorEliminar.InstructorID, instructorEliminar.UsuarioID);
                    MessageBox.Show("Instructor eliminado correctamente.");
                    CargarInstructores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar instructor: " + ex.Message);
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);

            if (string.IsNullOrWhiteSpace(txtClienteUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClienteNombre.Text) ||
                string.IsNullOrWhiteSpace(txtClientePassword.Text))
            {
                MessageBox.Show("Completa todos los campos obligatorios.");
                return;
            }

            Cliente clienteEditado = new Cliente()
            {
                UsuarioID = clienteId,
                UsuarioLogin = txtClienteUsuario.Text.Trim(),
                UsuarioNombre = txtClienteNombre.Text.Trim(),
                Contraseña = txtClientePassword.Text.Trim(),
                Telefono = txtClienteTelefono.Text.Trim()
            };

            try
            {
                ClienteRepository.Actualizar(clienteEditado);
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

            int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);

            DialogResult respuesta = MessageBox.Show("¿Seguro que quieres eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    ClienteRepository.Eliminar(clienteId);
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
    }
}
