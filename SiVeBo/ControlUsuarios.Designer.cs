﻿namespace SiVeBo
{
    partial class ControlUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlUsuarios));
            this.tbNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConfirmacion = new System.Windows.Forms.TextBox();
            this.cbPermisos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbContraseña = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btCancela = new System.Windows.Forms.Button();
            this.btRegistros = new System.Windows.Forms.Button();
            this.btElimina = new System.Windows.Forms.Button();
            this.btRegistraN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNombreUsuario
            // 
            this.tbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreUsuario.Location = new System.Drawing.Point(205, 41);
            this.tbNombreUsuario.Name = "tbNombreUsuario";
            this.tbNombreUsuario.Size = new System.Drawing.Size(173, 29);
            this.tbNombreUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de usuario: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirmar contraseña: ";
            // 
            // tbConfirmacion
            // 
            this.tbConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmacion.Location = new System.Drawing.Point(204, 111);
            this.tbConfirmacion.Name = "tbConfirmacion";
            this.tbConfirmacion.PasswordChar = '*';
            this.tbConfirmacion.Size = new System.Drawing.Size(173, 29);
            this.tbConfirmacion.TabIndex = 5;
            // 
            // cbPermisos
            // 
            this.cbPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPermisos.FormattingEnabled = true;
            this.cbPermisos.Location = new System.Drawing.Point(204, 149);
            this.cbPermisos.Name = "cbPermisos";
            this.cbPermisos.Size = new System.Drawing.Size(173, 32);
            this.cbPermisos.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nivel de permisos: ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(232, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbContraseña
            // 
            this.tbContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContraseña.Location = new System.Drawing.Point(205, 76);
            this.tbContraseña.Name = "tbContraseña";
            this.tbContraseña.PasswordChar = '*';
            this.tbContraseña.Size = new System.Drawing.Size(173, 29);
            this.tbContraseña.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(737, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 13;
            // 
            // btCancela
            // 
            this.btCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancela.Location = new System.Drawing.Point(113, 203);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(113, 37);
            this.btCancela.TabIndex = 14;
            this.btCancela.Text = "Cancelar";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // btRegistros
            // 
            this.btRegistros.BackColor = System.Drawing.Color.DimGray;
            this.btRegistros.BackgroundImage = global::SiVeBo.Properties.Resources.catalogoUser;
            this.btRegistros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistros.ForeColor = System.Drawing.Color.Blue;
            this.btRegistros.Location = new System.Drawing.Point(797, 456);
            this.btRegistros.Name = "btRegistros";
            this.btRegistros.Size = new System.Drawing.Size(100, 100);
            this.btRegistros.TabIndex = 12;
            this.btRegistros.Text = "Catálogo de Usuarios";
            this.btRegistros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRegistros.UseVisualStyleBackColor = false;
            this.btRegistros.Click += new System.EventHandler(this.btRegistros_Click);
            // 
            // btElimina
            // 
            this.btElimina.BackColor = System.Drawing.Color.Red;
            this.btElimina.BackgroundImage = global::SiVeBo.Properties.Resources.delUser;
            this.btElimina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btElimina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btElimina.ForeColor = System.Drawing.Color.Black;
            this.btElimina.Location = new System.Drawing.Point(532, 456);
            this.btElimina.Name = "btElimina";
            this.btElimina.Size = new System.Drawing.Size(100, 100);
            this.btElimina.TabIndex = 11;
            this.btElimina.Text = "Elimina Usuario";
            this.btElimina.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btElimina.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btElimina.UseVisualStyleBackColor = false;
            this.btElimina.Click += new System.EventHandler(this.btElimina_Click);
            // 
            // btRegistraN
            // 
            this.btRegistraN.BackColor = System.Drawing.Color.Lime;
            this.btRegistraN.BackgroundImage = global::SiVeBo.Properties.Resources.addUser;
            this.btRegistraN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRegistraN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistraN.ForeColor = System.Drawing.Color.Black;
            this.btRegistraN.Location = new System.Drawing.Point(258, 456);
            this.btRegistraN.Name = "btRegistraN";
            this.btRegistraN.Size = new System.Drawing.Size(100, 100);
            this.btRegistraN.TabIndex = 10;
            this.btRegistraN.Text = "Nuevo Usuario";
            this.btRegistraN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRegistraN.UseVisualStyleBackColor = false;
            this.btRegistraN.Click += new System.EventHandler(this.btRegistraN_Click);
            // 
            // ControlUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1088, 585);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btRegistros);
            this.Controls.Add(this.btElimina);
            this.Controls.Add(this.btRegistraN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPermisos);
            this.Controls.Add(this.tbConfirmacion);
            this.Controls.Add(this.tbContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNombreUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConfirmacion;
        private System.Windows.Forms.ComboBox cbPermisos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbContraseña;
        private System.Windows.Forms.Button btRegistraN;
        private System.Windows.Forms.Button btElimina;
        private System.Windows.Forms.Button btRegistros;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btCancela;
    }
}