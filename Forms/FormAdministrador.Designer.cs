﻿namespace Trabajo_final_herramientas_II.Forms
{
    partial class FormAdministrador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.llbRegistro = new System.Windows.Forms.LinkLabel();
            this.llbUsuario = new System.Windows.Forms.LinkLabel();
            this.llbInstructor = new System.Windows.Forms.LinkLabel();
            this.llbAdmin = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trabajo_final_herramientas_II.Properties.Resources._6_430_000__Structure_Pictures;
            this.pictureBox1.Location = new System.Drawing.Point(-9, -33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 451);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(227, 32);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(120, 26);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // llbRegistro
            // 
            this.llbRegistro.AutoSize = true;
            this.llbRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbRegistro.Location = new System.Drawing.Point(27, 76);
            this.llbRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbRegistro.Name = "llbRegistro";
            this.llbRegistro.Size = new System.Drawing.Size(101, 26);
            this.llbRegistro.TabIndex = 3;
            this.llbRegistro.TabStop = true;
            this.llbRegistro.Text = "Registro";
            this.llbRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // llbUsuario
            // 
            this.llbUsuario.AutoSize = true;
            this.llbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbUsuario.Location = new System.Drawing.Point(27, 121);
            this.llbUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbUsuario.Name = "llbUsuario";
            this.llbUsuario.Size = new System.Drawing.Size(94, 26);
            this.llbUsuario.TabIndex = 4;
            this.llbUsuario.TabStop = true;
            this.llbUsuario.Text = "Usuario";
            this.llbUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbUsuario_LinkClicked);
            // 
            // llbInstructor
            // 
            this.llbInstructor.AutoSize = true;
            this.llbInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbInstructor.Location = new System.Drawing.Point(27, 166);
            this.llbInstructor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbInstructor.Name = "llbInstructor";
            this.llbInstructor.Size = new System.Drawing.Size(112, 26);
            this.llbInstructor.TabIndex = 5;
            this.llbInstructor.TabStop = true;
            this.llbInstructor.Text = "Instructor";
            this.llbInstructor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbInstructor_LinkClicked);
            // 
            // llbAdmin
            // 
            this.llbAdmin.AutoSize = true;
            this.llbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbAdmin.Location = new System.Drawing.Point(27, 220);
            this.llbAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbAdmin.Name = "llbAdmin";
            this.llbAdmin.Size = new System.Drawing.Size(80, 26);
            this.llbAdmin.TabIndex = 6;
            this.llbAdmin.TabStop = true;
            this.llbAdmin.Text = "Admin";
            this.llbAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbAdmin_LinkClicked);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(727, 402);
            this.Controls.Add(this.llbAdmin);
            this.Controls.Add(this.llbInstructor);
            this.Controls.Add(this.llbUsuario);
            this.Controls.Add(this.llbRegistro);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.LinkLabel llbRegistro;
        private System.Windows.Forms.LinkLabel llbUsuario;
        private System.Windows.Forms.LinkLabel llbInstructor;
        private System.Windows.Forms.LinkLabel llbAdmin;
    }
}