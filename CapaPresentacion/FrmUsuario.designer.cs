namespace CapaPresentacion
{
    partial class FrmUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pListado = new System.Windows.Forms.Panel();
            this.txtBuscarApellido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.btnIncio = new System.Windows.Forms.Button();
            this.btnFin = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pRegistro = new System.Windows.Forms.Panel();
            this.imgPassword = new System.Windows.Forms.PictureBox();
            this.imgUsuario = new System.Windows.Forms.PictureBox();
            this.imgAcceso = new System.Windows.Forms.PictureBox();
            this.imgApellido = new System.Windows.Forms.PictureBox();
            this.imgNombre = new System.Windows.Forms.PictureBox();
            this.cbAcceso = new System.Windows.Forms.ComboBox();
            this.lbModificar = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lbAgregar = new System.Windows.Forms.Label();
            this.pListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.pRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAcceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Eliminar";
            this.dataGridViewImageColumn2.Image = global::CapaPresentacion.Properties.Resources.Eliminar;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(346, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 31);
            this.label9.TabIndex = 4;
            this.label9.Text = "Gestion de Usuarios";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.buscar;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(392, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 32);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources._009_mas;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(5, 18);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(150, 43);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo Usuario";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // pListado
            // 
            this.pListado.BackColor = System.Drawing.Color.Transparent;
            this.pListado.Controls.Add(this.txtBuscarApellido);
            this.pListado.Controls.Add(this.label7);
            this.pListado.Controls.Add(this.lblTotal);
            this.pListado.Controls.Add(this.label5);
            this.pListado.Controls.Add(this.dataListado);
            this.pListado.Controls.Add(this.label10);
            this.pListado.Controls.Add(this.label9);
            this.pListado.Controls.Add(this.label11);
            this.pListado.Controls.Add(this.txtBuscarNombre);
            this.pListado.Controls.Add(this.btnIncio);
            this.pListado.Controls.Add(this.btnBuscar);
            this.pListado.Controls.Add(this.btnFin);
            this.pListado.Controls.Add(this.btnNuevo);
            this.pListado.Controls.Add(this.btnAtras);
            this.pListado.Controls.Add(this.btnSiguiente);
            this.pListado.Location = new System.Drawing.Point(26, 8);
            this.pListado.Name = "pListado";
            this.pListado.Size = new System.Drawing.Size(1021, 590);
            this.pListado.TabIndex = 5;
            // 
            // txtBuscarApellido
            // 
            this.txtBuscarApellido.Location = new System.Drawing.Point(73, 103);
            this.txtBuscarApellido.Name = "txtBuscarApellido";
            this.txtBuscarApellido.Size = new System.Drawing.Size(167, 20);
            this.txtBuscarApellido.TabIndex = 32;
            this.txtBuscarApellido.TextChanged += new System.EventHandler(this.TxtBuscarApellido_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(530, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 31;
            this.label7.Text = "Final";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(631, 103);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(47, 15);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Siguiente";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.BackgroundColor = System.Drawing.Color.White;
            this.dataListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataListado.ColumnHeadersHeight = 30;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar});
            this.dataListado.EnableHeadersVisualStyles = false;
            this.dataListado.GridColor = System.Drawing.Color.SteelBlue;
            this.dataListado.Location = new System.Drawing.Point(20, 137);
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.HotPink;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(780, 330);
            this.dataListado.TabIndex = 6;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataListado_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::CapaPresentacion.Properties.Resources.Editar;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::CapaPresentacion.Properties.Resources.Eliminar;
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(341, 486);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Anterior";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(254, 486);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Inicio";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(73, 77);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(167, 20);
            this.txtBuscarNombre.TabIndex = 3;
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // btnIncio
            // 
            this.btnIncio.Image = global::CapaPresentacion.Properties.Resources.pagina_inicio;
            this.btnIncio.Location = new System.Drawing.Point(242, 505);
            this.btnIncio.Name = "btnIncio";
            this.btnIncio.Size = new System.Drawing.Size(68, 31);
            this.btnIncio.TabIndex = 27;
            this.btnIncio.UseVisualStyleBackColor = true;
            this.btnIncio.Click += new System.EventHandler(this.BtnIncio_Click);
            // 
            // btnFin
            // 
            this.btnFin.Image = global::CapaPresentacion.Properties.Resources.pagina_final;
            this.btnFin.Location = new System.Drawing.Point(507, 505);
            this.btnFin.Name = "btnFin";
            this.btnFin.Size = new System.Drawing.Size(79, 31);
            this.btnFin.TabIndex = 26;
            this.btnFin.UseVisualStyleBackColor = true;
            this.btnFin.Click += new System.EventHandler(this.BtnFin_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Image = global::CapaPresentacion.Properties.Resources.pagina_anterior;
            this.btnAtras.Location = new System.Drawing.Point(333, 505);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 31);
            this.btnAtras.TabIndex = 25;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Image = global::CapaPresentacion.Properties.Resources.pagina_siguiente;
            this.btnSiguiente.Location = new System.Drawing.Point(414, 505);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 31);
            this.btnSiguiente.TabIndex = 24;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Image = global::CapaPresentacion.Properties.Resources.Editar;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // pRegistro
            // 
            this.pRegistro.BackColor = System.Drawing.Color.DarkGray;
            this.pRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRegistro.Controls.Add(this.imgPassword);
            this.pRegistro.Controls.Add(this.imgUsuario);
            this.pRegistro.Controls.Add(this.imgAcceso);
            this.pRegistro.Controls.Add(this.imgApellido);
            this.pRegistro.Controls.Add(this.imgNombre);
            this.pRegistro.Controls.Add(this.cbAcceso);
            this.pRegistro.Controls.Add(this.lbModificar);
            this.pRegistro.Controls.Add(this.btnLimpiar);
            this.pRegistro.Controls.Add(this.btnCerrar);
            this.pRegistro.Controls.Add(this.label8);
            this.pRegistro.Controls.Add(this.btnActualizar);
            this.pRegistro.Controls.Add(this.txtPassword);
            this.pRegistro.Controls.Add(this.txtUsuario);
            this.pRegistro.Controls.Add(this.txtApellido);
            this.pRegistro.Controls.Add(this.txtNombre);
            this.pRegistro.Controls.Add(this.txtId);
            this.pRegistro.Controls.Add(this.label6);
            this.pRegistro.Controls.Add(this.label4);
            this.pRegistro.Controls.Add(this.label3);
            this.pRegistro.Controls.Add(this.label2);
            this.pRegistro.Controls.Add(this.label1);
            this.pRegistro.Controls.Add(this.btnCancelar);
            this.pRegistro.Controls.Add(this.btnGuardar);
            this.pRegistro.Controls.Add(this.lbAgregar);
            this.pRegistro.Cursor = System.Windows.Forms.Cursors.Default;
            this.pRegistro.Dock = System.Windows.Forms.DockStyle.Left;
            this.pRegistro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pRegistro.Location = new System.Drawing.Point(0, 0);
            this.pRegistro.Name = "pRegistro";
            this.pRegistro.Size = new System.Drawing.Size(298, 596);
            this.pRegistro.TabIndex = 4;
            this.pRegistro.Visible = false;
            // 
            // imgPassword
            // 
            this.imgPassword.BackgroundImage = global::CapaPresentacion.Properties.Resources.ico_error;
            this.imgPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgPassword.Location = new System.Drawing.Point(245, 318);
            this.imgPassword.Name = "imgPassword";
            this.imgPassword.Size = new System.Drawing.Size(31, 25);
            this.imgPassword.TabIndex = 30;
            this.imgPassword.TabStop = false;
            this.imgPassword.Visible = false;
            // 
            // imgUsuario
            // 
            this.imgUsuario.BackgroundImage = global::CapaPresentacion.Properties.Resources.ico_error;
            this.imgUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgUsuario.Location = new System.Drawing.Point(245, 274);
            this.imgUsuario.Name = "imgUsuario";
            this.imgUsuario.Size = new System.Drawing.Size(31, 25);
            this.imgUsuario.TabIndex = 29;
            this.imgUsuario.TabStop = false;
            this.imgUsuario.Visible = false;
            // 
            // imgAcceso
            // 
            this.imgAcceso.BackgroundImage = global::CapaPresentacion.Properties.Resources.ico_error;
            this.imgAcceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgAcceso.Location = new System.Drawing.Point(245, 230);
            this.imgAcceso.Name = "imgAcceso";
            this.imgAcceso.Size = new System.Drawing.Size(31, 25);
            this.imgAcceso.TabIndex = 28;
            this.imgAcceso.TabStop = false;
            this.imgAcceso.Visible = false;
            // 
            // imgApellido
            // 
            this.imgApellido.BackgroundImage = global::CapaPresentacion.Properties.Resources.ico_error;
            this.imgApellido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgApellido.Location = new System.Drawing.Point(245, 188);
            this.imgApellido.Name = "imgApellido";
            this.imgApellido.Size = new System.Drawing.Size(31, 25);
            this.imgApellido.TabIndex = 27;
            this.imgApellido.TabStop = false;
            this.imgApellido.Visible = false;
            // 
            // imgNombre
            // 
            this.imgNombre.BackgroundImage = global::CapaPresentacion.Properties.Resources.ico_error;
            this.imgNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgNombre.Location = new System.Drawing.Point(245, 144);
            this.imgNombre.Name = "imgNombre";
            this.imgNombre.Size = new System.Drawing.Size(31, 25);
            this.imgNombre.TabIndex = 26;
            this.imgNombre.TabStop = false;
            this.imgNombre.Visible = false;
            // 
            // cbAcceso
            // 
            this.cbAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcceso.FormattingEnabled = true;
            this.cbAcceso.Items.AddRange(new object[] {
            "Administrador",
            "Encargado",
            "Secretaria",
            "Odontologo"});
            this.cbAcceso.Location = new System.Drawing.Point(118, 230);
            this.cbAcceso.Name = "cbAcceso";
            this.cbAcceso.Size = new System.Drawing.Size(121, 24);
            this.cbAcceso.TabIndex = 22;
            this.cbAcceso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbAcceso_KeyPress);
            // 
            // lbModificar
            // 
            this.lbModificar.AutoSize = true;
            this.lbModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModificar.Location = new System.Drawing.Point(69, 61);
            this.lbModificar.Name = "lbModificar";
            this.lbModificar.Size = new System.Drawing.Size(123, 16);
            this.lbModificar.TabIndex = 20;
            this.lbModificar.Text = "Modificar Usuario";
            this.lbModificar.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Image = global::CapaPresentacion.Properties.Resources.limpiar;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(73, 374);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 46);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::CapaPresentacion.Properties.Resources.cancelar;
            this.btnCerrar.Location = new System.Drawing.Point(221, 6);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(44, 39);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Usuario";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.actualizar;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(134, 438);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(119, 46);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(118, 318);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 23);
            this.txtPassword.TabIndex = 15;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(118, 265);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(121, 23);
            this.txtUsuario.TabIndex = 13;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsuario_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(118, 188);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 23);
            this.txtApellido.TabIndex = 11;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtApellido_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(118, 144);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 23);
            this.txtNombre.TabIndex = 10;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(118, 107);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(121, 23);
            this.txtId.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Acceso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(9, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 44);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(134, 440);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 44);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // lbAgregar
            // 
            this.lbAgregar.AutoSize = true;
            this.lbAgregar.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgregar.Location = new System.Drawing.Point(41, 55);
            this.lbAgregar.Name = "lbAgregar";
            this.lbAgregar.Size = new System.Drawing.Size(212, 19);
            this.lbAgregar.TabIndex = 21;
            this.lbAgregar.Text = "Agregar Nuevo Usuario";
            this.lbAgregar.Visible = false;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 596);
            this.Controls.Add(this.pRegistro);
            this.Controls.Add(this.pListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsuario";
            this.Text = "FrmUsuario";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.pListado.ResumeLayout(false);
            this.pListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.pRegistro.ResumeLayout(false);
            this.pRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAcceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNombre)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel pListado;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel pRegistro;
        private System.Windows.Forms.Label lbModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lbAgregar;
        private System.Windows.Forms.ComboBox cbAcceso;
        private System.Windows.Forms.PictureBox imgPassword;
        private System.Windows.Forms.PictureBox imgUsuario;
        private System.Windows.Forms.PictureBox imgAcceso;
        private System.Windows.Forms.PictureBox imgApellido;
        private System.Windows.Forms.PictureBox imgNombre;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnIncio;
        private System.Windows.Forms.Button btnFin;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox txtBuscarApellido;
    }
}