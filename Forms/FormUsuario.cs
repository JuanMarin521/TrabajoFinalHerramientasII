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
    public partial class FormUsuario : Form

    {
        private Cliente cliente;
        private ClaseRepository claseRepo;
        private ClasesInscritasRepository inscritaRepo;
        public FormUsuario(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            claseRepo = new ClaseRepository();
            inscritaRepo = new ClasesInscritasRepository();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarClasesDisponibles();
            CargarClasesInscritas();
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {

        }

        private void CargarClasesDisponibles()
        {
            var clases = claseRepo.ObtenerDisponibles(); // método que debes tener
            dgvClases.DataSource = clases;
            dgvClases.Columns["ClaseID"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClases.CurrentRow != null)
                {
                    int claseID = Convert.ToInt32(dgvClases.CurrentRow.Cells["ClaseID"].Value);

                    if (inscritaRepo.InscribirCliente(cliente.UsuarioID, claseID))
                    {
                        MessageBox.Show("Inscripción exitosa.");
                        CargarClasesDisponibles();
                        CargarClasesInscritas();
                    }
                    else
                    {
                        MessageBox.Show("Error al inscribirse.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una clase para inscribirte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la inscripción: " + ex.Message);
            }
        }

        private void CargarClasesInscritas()
        {
            try
            {
                var clasesInscritas = inscritaRepo.ObtenerClasesPorCliente(cliente.UsuarioID);
                dgvInscritas.DataSource = clasesInscritas;
                dgvInscritas.Columns["ClaseID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clases inscritas: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInscritas.CurrentRow != null)
                {
                    int claseID = Convert.ToInt32(dgvInscritas.CurrentRow.Cells["ClaseID"].Value);

                    if (inscritaRepo.EliminarInscripcion(cliente.UsuarioID, claseID))
                    {
                        MessageBox.Show("Inscripción cancelada.");
                        CargarClasesDisponibles();
                        CargarClasesInscritas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cancelar la inscripción.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una clase para cancelar inscripción.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cancelar inscripción: " + ex.Message);
            }

        }

        private void FormUsuario_Load_1(object sender, EventArgs e)
        {

        }
    }
}
