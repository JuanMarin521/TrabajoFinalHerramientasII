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
        private Cliente clienteSeleccionado = null;


        //Variables de instructores
        private InstructorRepository repoInstructor = new InstructorRepository();
        private Instructor instructorSeleccionado = null;

        private Clase claseSeleccionada = null;

        public FormAdminUses()
        {
            InitializeComponent();
            this.dgvInstru.SelectionChanged += dgvInstru_SelectionChanged;
            this.dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            this.dgvClases.SelectionChanged += dgvClases_SelectionChanged;
            this.nmupCupo.ValueChanged += nmupCupo_ValueChanged;

           
            ConfigurarNumericUpDown();

            CargarInstructores();
            CargarClientesEnGrid();
            CargarClasesEnGrid();
        }
        private void ConfigurarNumericUpDown()
        {
            // Configurar el rango del NumericUpDown
            nmupCupo.Minimum = 0;  // Permitir 0 para clases llenas
            nmupCupo.Maximum = 100; // Ajustar según tus necesidades
            nmupCupo.Value = 1;     // Valor por defecto
            nmupCupo.Increment = 1; // Incremento de 1 en 1
        }
        private void dgvClases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow != null && dgvClases.CurrentRow.Index >= 0)
            {
                try
                {
                    claseSeleccionada = (Clase)dgvClases.CurrentRow.DataBoundItem;
                    if (claseSeleccionada != null)
                    {
                        txtNombreClase.Text = claseSeleccionada.Nombre ?? "";
                        txtSala.Text = claseSeleccionada.Sala ?? "";

                        // CAMBIAR: Usar nmupCupo en lugar de txtCupo
                        nmupCupo.Value = claseSeleccionada.CupoDisponible;

                        dtpHorario.Value = claseSeleccionada.Horario;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores silenciosamente
                    claseSeleccionada = null;
                }
            }
        }
        private void dgvInstru_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInstru.CurrentRow != null && dgvInstru.CurrentRow.Index >= 0)
            {
                try
                {
                    instructorSeleccionado = (Instructor)dgvInstru.CurrentRow.DataBoundItem;
                    if (instructorSeleccionado != null)
                    {
                        txtNombre.Text = instructorSeleccionado.UsuarioNombre ?? "";
                        txtEspecialidad.Text = instructorSeleccionado.Especialidad ?? "";
                        chkDisponible.Checked = instructorSeleccionado.Disponible;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores silenciosamente para evitar interrupciones
                    instructorSeleccionado = null;
                }
            }
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

              
                Cliente nuevoCliente = new Cliente
                {
                    UsuarioLogin = txtClienteUsuario.Text.Trim(),
                    UsuarioNombre = txtClienteNombre.Text.Trim(),
                    Apellido = txtClienteApellido.Text.Trim(),
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
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = ClienteRepository.ObtenerTodos();
                dgvClientes.ClearSelection();

                // Configurar las columnas si existen
                if (dgvClientes.Columns.Count > 0)
                {
                    // MOSTRAR TODAS LAS COLUMNAS IMPORTANTES (incluyendo Usuario y Contraseña)

                    // Configurar headers más amigables y hacer visibles las columnas necesarias
                    if (dgvClientes.Columns.Contains("UsuarioID"))
                    {
                        dgvClientes.Columns["UsuarioID"].HeaderText = "ID";
                        dgvClientes.Columns["UsuarioID"].DisplayIndex = 0;
                    }

                    if (dgvClientes.Columns.Contains("UsuarioLogin"))
                    {
                        dgvClientes.Columns["UsuarioLogin"].HeaderText = "Usuario";
                        dgvClientes.Columns["UsuarioLogin"].Visible = true; // ASEGURAR QUE SEA VISIBLE
                        dgvClientes.Columns["UsuarioLogin"].DisplayIndex = 1;
                    }

                    if (dgvClientes.Columns.Contains("UsuarioNombre"))
                    {
                        dgvClientes.Columns["UsuarioNombre"].HeaderText = "Nombre";
                        dgvClientes.Columns["UsuarioNombre"].DisplayIndex = 2;
                    }

                    if (dgvClientes.Columns.Contains("Apellido"))
                    {
                        dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
                        dgvClientes.Columns["Apellido"].DisplayIndex = 3;
                    }

                    // MOSTRAR LA CONTRASEÑA (en lugar de ocultarla)
                    if (dgvClientes.Columns.Contains("Contraseña"))
                    {
                        dgvClientes.Columns["Contraseña"].HeaderText = "Contraseña";
                        dgvClientes.Columns["Contraseña"].Visible = true; // HACER VISIBLE
                        dgvClientes.Columns["Contraseña"].DisplayIndex = 4;
                    }

                    if (dgvClientes.Columns.Contains("Telefono"))
                    {
                        dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                        dgvClientes.Columns["Telefono"].DisplayIndex = 5;
                    }

                    if (dgvClientes.Columns.Contains("TipoMembresia"))
                    {
                        dgvClientes.Columns["TipoMembresia"].HeaderText = "Membresía";
                        dgvClientes.Columns["TipoMembresia"].DisplayIndex = 6;
                    }

                    // Ocultar solo la columna Rol que no es necesaria para clientes
                    if (dgvClientes.Columns.Contains("Rol"))
                        dgvClientes.Columns["Rol"].Visible = false;

                    // Ajustar el ancho de las columnas para mejor visualización
                    if (dgvClientes.Columns.Contains("UsuarioID"))
                        dgvClientes.Columns["UsuarioID"].Width = 50;

                    if (dgvClientes.Columns.Contains("UsuarioLogin"))
                        dgvClientes.Columns["UsuarioLogin"].Width = 100;

                    if (dgvClientes.Columns.Contains("UsuarioNombre"))
                        dgvClientes.Columns["UsuarioNombre"].Width = 120;

                    if (dgvClientes.Columns.Contains("Apellido"))
                        dgvClientes.Columns["Apellido"].Width = 120;

                    if (dgvClientes.Columns.Contains("Contraseña"))
                        dgvClientes.Columns["Contraseña"].Width = 100;

                    if (dgvClientes.Columns.Contains("Telefono"))
                        dgvClientes.Columns["Telefono"].Width = 100;

                    if (dgvClientes.Columns.Contains("TipoMembresia"))
                        dgvClientes.Columns["TipoMembresia"].Width = 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void LimpiarCamposCliente()
        {
            txtClienteUsuario.Clear();
            txtClienteNombre.Clear();
            txtClienteApellido.Clear(); // Agregar esta línea
            txtClientePassword.Clear();
            txtClienteTelefono.Clear();
            cmbClienteMembresia.SelectedIndex = -1; // Limpiar la selección del combobox
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

            // CORREGIDO: Verificar que los campos obligatorios estén llenos
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

            // CORREGIDO: Usar el objeto seleccionado en lugar de buscar la columna
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Selecciona un cliente de la lista primero.");
                return;
            }

            Cliente clienteActualizado = new Cliente
            {
                UsuarioID = clienteSeleccionado.UsuarioID,
                UsuarioLogin = txtClienteUsuario.Text.Trim(),
                UsuarioNombre = txtClienteNombre.Text.Trim(),
                Apellido = txtClienteApellido.Text.Trim(),
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
                clienteSeleccionado = null; // Limpiar la selección
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
            }
        }

        private void btnDeleClient_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    clienteRepository.Eliminar(clienteSeleccionado.UsuarioID);
                    MessageBox.Show("Cliente eliminado correctamente.");
                    CargarClientesEnGrid();
                    LimpiarCamposCliente();
                    clienteSeleccionado = null; // Limpiar la selección
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
            txtSala.Clear();
            dtpHorario.Value = DateTime.Now;

            // CAMBIAR: Limpiar nmupCupo en lugar de txtCupo
            nmupCupo.Value = nmupCupo.Minimum; // O el valor que prefieras como default
        }

        private void CargarClasesEnGrid()
        {
            try
            {
                dgvClases.DataSource = null;
                dgvClases.DataSource = ClaseRepository.ObtenerTodas(); // Cambiar para obtener todas las clases
                dgvClases.ClearSelection();

                // Configurar las columnas si existen
                if (dgvClases.Columns.Count > 0)
                {
                    // Configurar headers más amigables
                    if (dgvClases.Columns.Contains("ClaseID"))
                    {
                        dgvClases.Columns["ClaseID"].HeaderText = "ID";
                        dgvClases.Columns["ClaseID"].Width = 50;
                        dgvClases.Columns["ClaseID"].DisplayIndex = 0;
                    }

                    if (dgvClases.Columns.Contains("Nombre"))
                    {
                        dgvClases.Columns["Nombre"].HeaderText = "Nombre de Clase";
                        dgvClases.Columns["Nombre"].Width = 150;
                        dgvClases.Columns["Nombre"].DisplayIndex = 1;
                    }

                    if (dgvClases.Columns.Contains("Horario"))
                    {
                        dgvClases.Columns["Horario"].HeaderText = "Horario";
                        dgvClases.Columns["Horario"].Width = 120;
                        dgvClases.Columns["Horario"].DisplayIndex = 2;
                        // Formatear la fecha/hora
                        dgvClases.Columns["Horario"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }

                    if (dgvClases.Columns.Contains("CupoDisponible"))
                    {
                        dgvClases.Columns["CupoDisponible"].HeaderText = "Cupo";
                        dgvClases.Columns["CupoDisponible"].Width = 80;
                        dgvClases.Columns["CupoDisponible"].DisplayIndex = 3;
                    }

                    if (dgvClases.Columns.Contains("Sala"))
                    {
                        dgvClases.Columns["Sala"].HeaderText = "Sala";
                        dgvClases.Columns["Sala"].Width = 100;
                        dgvClases.Columns["Sala"].DisplayIndex = 4;
                    }

                    // Ocultar otras columnas que no sean necesarias
                    foreach (DataGridViewColumn column in dgvClases.Columns)
                    {
                        if (!new[] { "ClaseID", "Nombre", "Horario", "CupoDisponible", "Sala" }.Contains(column.Name))
                        {
                            column.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clases: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreClase.Text) ||
         string.IsNullOrWhiteSpace(txtSala.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            // CAMBIAR: Usar nmupCupo.Value directamente
            int cupoDisponible = (int)nmupCupo.Value;

            if (cupoDisponible < 1)
            {
                MessageBox.Show("El cupo debe ser mayor a cero.");
                return;
            }

            try
            {
                Clase nuevaClase = new Clase
                {
                    Nombre = txtNombreClase.Text.Trim(),
                    Horario = dtpHorario.Value,
                    CupoDisponible = cupoDisponible,
                    Sala = txtSala.Text.Trim()
                };

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
            CargarClientesEnGrid();
            CargarClasesEnGrid();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clienteSeleccionado = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                txtClienteUsuario.Text = clienteSeleccionado.UsuarioLogin ?? "";

                // CORREGIDO: Manejar mejor la separación del nombre
                txtClienteNombre.Text = clienteSeleccionado.UsuarioNombre ?? "";

                // CORREGIDO: Usar la propiedad Apellido directamente
                txtClienteApellido.Text = clienteSeleccionado.Apellido ?? "";
                txtClientePassword.Text = clienteSeleccionado.Contraseña ?? "";
                txtClienteTelefono.Text = clienteSeleccionado.Telefono ?? "";

                // CORREGIDO: Manejar la selección del combobox de manera segura
                if (!string.IsNullOrEmpty(clienteSeleccionado.TipoMembresia))
                {
                    int index = cmbClienteMembresia.FindStringExact(clienteSeleccionado.TipoMembresia);
                    if (index >= 0)
                        cmbClienteMembresia.SelectedIndex = index;
                    else
                        cmbClienteMembresia.SelectedIndex = -1;
                }
                else
                {
                    cmbClienteMembresia.SelectedIndex = -1;
                }
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null && dgvClientes.CurrentRow.Index >= 0)
            {
                try
                {
                    clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                    if (clienteSeleccionado != null)
                    {
                        txtClienteUsuario.Text = clienteSeleccionado.UsuarioLogin ?? "";
                        txtClienteNombre.Text = clienteSeleccionado.UsuarioNombre ?? "";
                        txtClienteApellido.Text = clienteSeleccionado.Apellido ?? "";
                        txtClientePassword.Text = clienteSeleccionado.Contraseña ?? "";
                        txtClienteTelefono.Text = clienteSeleccionado.Telefono ?? "";

                        if (!string.IsNullOrEmpty(clienteSeleccionado.TipoMembresia))
                        {
                            int index = cmbClienteMembresia.FindStringExact(clienteSeleccionado.TipoMembresia);
                            if (index >= 0)
                                cmbClienteMembresia.SelectedIndex = index;
                            else
                                cmbClienteMembresia.SelectedIndex = -1;
                        }
                        else
                        {
                            cmbClienteMembresia.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores silenciosamente para evitar interrupciones
                    clienteSeleccionado = null;
                }
            }
        }

        private void dgvClases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    claseSeleccionada = (Clase)dgvClases.Rows[e.RowIndex].DataBoundItem;
                    txtNombreClase.Text = claseSeleccionada.Nombre ?? "";
                    txtSala.Text = claseSeleccionada.Sala ?? "";

                    // CAMBIAR: Usar nmupCupo en lugar de txtCupo
                    nmupCupo.Value = claseSeleccionada.CupoDisponible;

                    dtpHorario.Value = claseSeleccionada.Horario;
                }
            }
        }

        private void dgvestadis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtClienteUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (claseSeleccionada == null)
            {
                MessageBox.Show("Selecciona una clase para editar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreClase.Text) ||
                string.IsNullOrWhiteSpace(txtSala.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            // CAMBIAR: Usar nmupCupo.Value directamente
            int cupoDisponible = (int)nmupCupo.Value;

            if (cupoDisponible < 1)
            {
                MessageBox.Show("El cupo debe ser mayor a cero.");
                return;
            }

            try
            {
                Clase claseActualizada = new Clase
                {
                    ClaseID = claseSeleccionada.ClaseID,
                    Nombre = txtNombreClase.Text.Trim(),
                    Horario = dtpHorario.Value,
                    CupoDisponible = cupoDisponible,
                    Sala = txtSala.Text.Trim()
                };

                ClaseRepository.ActualizarClase(claseActualizada);
                MessageBox.Show("Clase actualizada correctamente.");
                CargarClasesEnGrid();
                LimpiarCamposClase();
                claseSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar clase: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (claseSeleccionada == null)
            {
                MessageBox.Show("Selecciona una clase para eliminar.");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar esta clase?", "Confirmación", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ClaseRepository.EliminarClase(claseSeleccionada.ClaseID);
                    MessageBox.Show("Clase eliminada correctamente.");
                    CargarClasesEnGrid();
                    LimpiarCamposClase();
                    claseSeleccionada = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar clase: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dgvClases.DataSource = null;
                dgvClases.DataSource = ClaseRepository.ObtenerConCupoDisponible();
                dgvClases.ClearSelection();
                MessageBox.Show("Mostrando solo clases con cupo disponible.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar clases: " + ex.Message);
            }
        }

        private void nmupCupo_ValueChanged(object sender, EventArgs e)
        {
            if (nmupCupo.Value <= 5 && nmupCupo.Value > 0)
            {
                nmupCupo.BackColor = Color.LightYellow; // Advertencia cuando queden pocos cupos
            }
            else if (nmupCupo.Value == 0)
            {
                nmupCupo.BackColor = Color.LightCoral; // Rojo cuando no hay cupo
            }
            else
            {
                nmupCupo.BackColor = SystemColors.Window; // Color normal
            }
        }
    }
}