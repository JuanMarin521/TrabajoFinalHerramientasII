using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_final_herramientas_II.Forms
{
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegistroCliente formRegistroCliente = new FormRegistroCliente();
            formRegistroCliente.ShowDialog();
        }

        private void llbUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario(); // Aquí deberías pasar un cliente válido
            formUsuario.ShowDialog();
        }

        private void llbInstructor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInstructor formInstructor = new FormInstructor();
            formInstructor.ShowDialog();
        }

        private void llbAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAdminUses formAdminUses = new FormAdminUses();
            formAdminUses.ShowDialog();
        }
    }
}
