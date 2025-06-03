namespace Trabajo_final_herramientas_II.Forms
{
    partial class FormAdminUses
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInstru = new System.Windows.Forms.DataGridView();
            this.btnaddInst = new System.Windows.Forms.Button();
            this.btneditInst = new System.Windows.Forms.Button();
            this.btnDeleInst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnDeleClient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvestadis = new System.Windows.Forms.DataGridView();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtClienteTelefono = new System.Windows.Forms.TextBox();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.txtClientePassword = new System.Windows.Forms.TextBox();
            this.txtClienteUsuario = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Cupo = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.txtSala = new System.Windows.Forms.TextBox();
            this.txtNombreClase = new System.Windows.Forms.TextBox();
            this.dtpHorario = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvestadis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Instructores";
            // 
            // dgvInstru
            // 
            this.dgvInstru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstru.Location = new System.Drawing.Point(14, 37);
            this.dgvInstru.Name = "dgvInstru";
            this.dgvInstru.RowHeadersWidth = 51;
            this.dgvInstru.Size = new System.Drawing.Size(348, 117);
            this.dgvInstru.TabIndex = 6;
            this.dgvInstru.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstru_CellContentClick);
            // 
            // btnaddInst
            // 
            this.btnaddInst.Location = new System.Drawing.Point(14, 160);
            this.btnaddInst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnaddInst.Name = "btnaddInst";
            this.btnaddInst.Size = new System.Drawing.Size(92, 39);
            this.btnaddInst.TabIndex = 7;
            this.btnaddInst.Text = "Añadir";
            this.btnaddInst.UseVisualStyleBackColor = true;
            this.btnaddInst.Click += new System.EventHandler(this.btnaddInst_Click);
            // 
            // btneditInst
            // 
            this.btneditInst.Location = new System.Drawing.Point(137, 159);
            this.btneditInst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btneditInst.Name = "btneditInst";
            this.btneditInst.Size = new System.Drawing.Size(94, 39);
            this.btneditInst.TabIndex = 8;
            this.btneditInst.Text = "Editar";
            this.btneditInst.UseVisualStyleBackColor = true;
            this.btneditInst.Click += new System.EventHandler(this.btneditInst_Click);
            // 
            // btnDeleInst
            // 
            this.btnDeleInst.Location = new System.Drawing.Point(270, 159);
            this.btnDeleInst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleInst.Name = "btnDeleInst";
            this.btnDeleInst.Size = new System.Drawing.Size(92, 39);
            this.btnDeleInst.TabIndex = 9;
            this.btnDeleInst.Text = "Eliminar";
            this.btnDeleInst.UseVisualStyleBackColor = true;
            this.btnDeleInst.Click += new System.EventHandler(this.btnDeleInst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(371, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Clientes";
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(376, 37);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.Size = new System.Drawing.Size(348, 117);
            this.dgvClientes.TabIndex = 11;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(376, 159);
            this.btnAddClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(92, 39);
            this.btnAddClient.TabIndex = 12;
            this.btnAddClient.Text = "Añadir";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(499, 159);
            this.btnEditClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(94, 39);
            this.btnEditClient.TabIndex = 13;
            this.btnEditClient.Text = "Editar";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnDeleClient
            // 
            this.btnDeleClient.Location = new System.Drawing.Point(632, 159);
            this.btnDeleClient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleClient.Name = "btnDeleClient";
            this.btnDeleClient.Size = new System.Drawing.Size(92, 39);
            this.btnDeleClient.TabIndex = 14;
            this.btnDeleClient.Text = "Eliminar";
            this.btnDeleClient.UseVisualStyleBackColor = true;
            this.btnDeleClient.Click += new System.EventHandler(this.btnDeleClient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "Estadisticas";
            // 
            // dgvestadis
            // 
            this.dgvestadis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvestadis.Location = new System.Drawing.Point(14, 245);
            this.dgvestadis.Name = "dgvestadis";
            this.dgvestadis.RowHeadersWidth = 51;
            this.dgvestadis.Size = new System.Drawing.Size(348, 117);
            this.dgvestadis.TabIndex = 16;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Fecha",
            "Tipo de clase"});
            this.cmbFiltro.Location = new System.Drawing.Point(140, 367);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(144, 21);
            this.cmbFiltro.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "Filtrar por:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(371, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Clases";
            // 
            // dgvClases
            // 
            this.dgvClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClases.Location = new System.Drawing.Point(376, 245);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.RowHeadersWidth = 51;
            this.dgvClases.Size = new System.Drawing.Size(348, 117);
            this.dgvClases.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 367);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 39);
            this.button1.TabIndex = 27;
            this.button1.Text = "Crear ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 367);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 39);
            this.button2.TabIndex = 28;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(550, 367);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 39);
            this.button3.TabIndex = 29;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(632, 367);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 39);
            this.button4.TabIndex = 30;
            this.button4.Text = "Cupo Disponible";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(104, 451);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 31;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(240, 451);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 32;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(376, 451);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 33;
            // 
            // chkDisponible
            // 
            this.chkDisponible.AutoSize = true;
            this.chkDisponible.Location = new System.Drawing.Point(658, 453);
            this.chkDisponible.Name = "chkDisponible";
            this.chkDisponible.Size = new System.Drawing.Size(80, 17);
            this.chkDisponible.TabIndex = 34;
            this.chkDisponible.Text = "checkBox1";
            this.chkDisponible.UseVisualStyleBackColor = true;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(503, 451);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(100, 20);
            this.txtEspecialidad.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(101, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(500, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Especialidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(373, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(237, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Contraseña";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(655, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Disponible";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(11, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 18);
            this.label11.TabIndex = 41;
            this.label11.Text = "Instructor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(11, 518);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 18);
            this.label12.TabIndex = 42;
            this.label12.Text = "Usuario";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(237, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 18);
            this.label13.TabIndex = 50;
            this.label13.Text = "Contraseña";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(373, 490);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 49;
            this.label14.Text = "Nombre";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(500, 490);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 18);
            this.label15.TabIndex = 48;
            this.label15.Text = "Telefono";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(101, 490);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 18);
            this.label16.TabIndex = 47;
            this.label16.Text = "Usuario";
            // 
            // txtClienteTelefono
            // 
            this.txtClienteTelefono.Location = new System.Drawing.Point(503, 520);
            this.txtClienteTelefono.Name = "txtClienteTelefono";
            this.txtClienteTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtClienteTelefono.TabIndex = 46;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(376, 520);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(100, 20);
            this.txtClienteNombre.TabIndex = 45;
            // 
            // txtClientePassword
            // 
            this.txtClientePassword.Location = new System.Drawing.Point(240, 520);
            this.txtClientePassword.Name = "txtClientePassword";
            this.txtClientePassword.Size = new System.Drawing.Size(100, 20);
            this.txtClientePassword.TabIndex = 44;
            // 
            // txtClienteUsuario
            // 
            this.txtClienteUsuario.Location = new System.Drawing.Point(104, 520);
            this.txtClienteUsuario.Name = "txtClienteUsuario";
            this.txtClienteUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtClienteUsuario.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(11, 590);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 18);
            this.label17.TabIndex = 51;
            this.label17.Text = "Clase";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(237, 562);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 18);
            this.label18.TabIndex = 59;
            this.label18.Text = "Sala";
            // 
            // Cupo
            // 
            this.Cupo.AutoSize = true;
            this.Cupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cupo.ForeColor = System.Drawing.Color.White;
            this.Cupo.Location = new System.Drawing.Point(373, 562);
            this.Cupo.Name = "Cupo";
            this.Cupo.Size = new System.Drawing.Size(62, 18);
            this.Cupo.TabIndex = 58;
            this.Cupo.Text = "Nombre";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(500, 562);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 18);
            this.label20.TabIndex = 57;
            this.label20.Text = "Fecha";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(101, 562);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 18);
            this.label21.TabIndex = 56;
            this.label21.Text = "Nombre clase";
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(376, 592);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(100, 20);
            this.txtCupo.TabIndex = 54;
            // 
            // txtSala
            // 
            this.txtSala.Location = new System.Drawing.Point(240, 592);
            this.txtSala.Name = "txtSala";
            this.txtSala.Size = new System.Drawing.Size(100, 20);
            this.txtSala.TabIndex = 53;
            // 
            // txtNombreClase
            // 
            this.txtNombreClase.Location = new System.Drawing.Point(104, 592);
            this.txtNombreClase.Name = "txtNombreClase";
            this.txtNombreClase.Size = new System.Drawing.Size(100, 20);
            this.txtNombreClase.TabIndex = 52;
            // 
            // dtpHorario
            // 
            this.dtpHorario.Location = new System.Drawing.Point(503, 592);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.Size = new System.Drawing.Size(217, 20);
            this.dtpHorario.TabIndex = 60;
            // 
            // FormAdminUses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(940, 649);
            this.Controls.Add(this.dtpHorario);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Cupo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCupo);
            this.Controls.Add(this.txtSala);
            this.Controls.Add(this.txtNombreClase);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtClienteTelefono);
            this.Controls.Add(this.txtClienteNombre);
            this.Controls.Add(this.txtClientePassword);
            this.Controls.Add(this.txtClienteUsuario);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.chkDisponible);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvClases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.dgvestadis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeleClient);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleInst);
            this.Controls.Add(this.btneditInst);
            this.Controls.Add(this.btnaddInst);
            this.Controls.Add(this.dgvInstru);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAdminUses";
            this.Text = "FormAdminUses";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvestadis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInstru;
        private System.Windows.Forms.Button btnaddInst;
        private System.Windows.Forms.Button btneditInst;
        private System.Windows.Forms.Button btnDeleInst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnDeleClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvestadis;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtClienteTelefono;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.TextBox txtClientePassword;
        private System.Windows.Forms.TextBox txtClienteUsuario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label Cupo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.TextBox txtSala;
        private System.Windows.Forms.TextBox txtNombreClase;
        private System.Windows.Forms.DateTimePicker dtpHorario;
    }
}