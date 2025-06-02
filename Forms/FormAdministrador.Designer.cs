namespace Trabajo_final_herramientas_II.Forms
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
            this.pictureBox1.Location = new System.Drawing.Point(-12, -41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 555);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(303, 39);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(157, 32);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // llbRegistro
            // 
            this.llbRegistro.AutoSize = true;
            this.llbRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbRegistro.Location = new System.Drawing.Point(36, 94);
            this.llbRegistro.Name = "llbRegistro";
            this.llbRegistro.Size = new System.Drawing.Size(128, 32);
            this.llbRegistro.TabIndex = 3;
            this.llbRegistro.TabStop = true;
            this.llbRegistro.Text = "Registro";
            this.llbRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // llbUsuario
            // 
            this.llbUsuario.AutoSize = true;
            this.llbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbUsuario.Location = new System.Drawing.Point(36, 149);
            this.llbUsuario.Name = "llbUsuario";
            this.llbUsuario.Size = new System.Drawing.Size(119, 32);
            this.llbUsuario.TabIndex = 4;
            this.llbUsuario.TabStop = true;
            this.llbUsuario.Text = "Usuario";
            this.llbUsuario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbUsuario_LinkClicked);
            // 
            // llbInstructor
            // 
            this.llbInstructor.AutoSize = true;
            this.llbInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbInstructor.Location = new System.Drawing.Point(36, 204);
            this.llbInstructor.Name = "llbInstructor";
            this.llbInstructor.Size = new System.Drawing.Size(141, 32);
            this.llbInstructor.TabIndex = 5;
            this.llbInstructor.TabStop = true;
            this.llbInstructor.Text = "Instructor";
            this.llbInstructor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbInstructor_LinkClicked);
            // 
            // llbAdmin
            // 
            this.llbAdmin.AutoSize = true;
            this.llbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbAdmin.Location = new System.Drawing.Point(36, 271);
            this.llbAdmin.Name = "llbAdmin";
            this.llbAdmin.Size = new System.Drawing.Size(100, 32);
            this.llbAdmin.TabIndex = 6;
            this.llbAdmin.TabStop = true;
            this.llbAdmin.Text = "Admin";
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(969, 495);
            this.Controls.Add(this.llbAdmin);
            this.Controls.Add(this.llbInstructor);
            this.Controls.Add(this.llbUsuario);
            this.Controls.Add(this.llbRegistro);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pictureBox1);
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