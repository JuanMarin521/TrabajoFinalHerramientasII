namespace Trabajo_final_herramientas_II.Forms
{
    partial class FormInstructor
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAsigInst = new System.Windows.Forms.DataGridView();
            this.dgvParticipantes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsigInst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(52, 20);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(120, 26);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Clases Asignadas";
            // 
            // dgvAsigInst
            // 
            this.dgvAsigInst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsigInst.Location = new System.Drawing.Point(56, 119);
            this.dgvAsigInst.Name = "dgvAsigInst";
            this.dgvAsigInst.RowHeadersWidth = 51;
            this.dgvAsigInst.Size = new System.Drawing.Size(310, 240);
            this.dgvAsigInst.TabIndex = 6;
            // 
            // dgvParticipantes
            // 
            this.dgvParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipantes.Location = new System.Drawing.Point(417, 122);
            this.dgvParticipantes.Name = "dgvParticipantes";
            this.dgvParticipantes.RowHeadersWidth = 51;
            this.dgvParticipantes.Size = new System.Drawing.Size(307, 238);
            this.dgvParticipantes.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(505, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Participantes";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(428, 366);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Guardar Asistencia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(555, 366);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 54);
            this.button2.TabIndex = 10;
            this.button2.Text = "Ver Asistencia";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(768, 430);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvParticipantes);
            this.Controls.Add(this.dgvAsigInst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBienvenida);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormInstructor";
            this.Text = "FormInstructor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsigInst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAsigInst;
        private System.Windows.Forms.DataGridView dgvParticipantes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}