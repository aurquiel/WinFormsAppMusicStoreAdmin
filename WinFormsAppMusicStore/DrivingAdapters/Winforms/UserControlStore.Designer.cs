namespace WinFormsAppMusicStoreAdmin
{
    partial class UserControlStore
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            panel4 = new Panel();
            panel5 = new Panel();
            groupBox2 = new GroupBox();
            buttonStoreRefreshData = new Button();
            groupBox1 = new GroupBox();
            textBoxStoreAddCode = new TextBox();
            buttonStoreAdd = new Button();
            label1 = new Label();
            groupBoxEditUser = new GroupBox();
            buttonStoreEdit = new Button();
            buttonStoreDelete = new Button();
            comboBoxStoreEdit = new ComboBox();
            label4 = new Label();
            textBoxStoreEditCode = new TextBox();
            label2 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxEditUser.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.Navy;
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(1072, 633);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(groupBox2);
            panel5.Controls.Add(groupBox1);
            panel5.Controls.Add(groupBoxEditUser);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 5);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1062, 623);
            panel5.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(buttonStoreRefreshData);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 293);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1062, 88);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Refrescar Data";
            // 
            // buttonStoreRefreshData
            // 
            buttonStoreRefreshData.FlatAppearance.BorderColor = Color.Green;
            buttonStoreRefreshData.FlatStyle = FlatStyle.Flat;
            buttonStoreRefreshData.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStoreRefreshData.ForeColor = Color.Blue;
            buttonStoreRefreshData.Image = Properties.Resources.refresh;
            buttonStoreRefreshData.ImageAlign = ContentAlignment.MiddleRight;
            buttonStoreRefreshData.Location = new Point(22, 36);
            buttonStoreRefreshData.Margin = new Padding(3, 4, 3, 4);
            buttonStoreRefreshData.Name = "buttonStoreRefreshData";
            buttonStoreRefreshData.Size = new Size(120, 30);
            buttonStoreRefreshData.TabIndex = 18;
            buttonStoreRefreshData.Text = "Refrescar";
            buttonStoreRefreshData.TextAlign = ContentAlignment.MiddleLeft;
            buttonStoreRefreshData.UseVisualStyleBackColor = true;
            buttonStoreRefreshData.Click += buttonStoreRefreshData_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(textBoxStoreAddCode);
            groupBox1.Controls.Add(buttonStoreAdd);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 163);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1062, 130);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar Tienda";
            // 
            // textBoxStoreAddCode
            // 
            textBoxStoreAddCode.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxStoreAddCode.Location = new Point(141, 30);
            textBoxStoreAddCode.Margin = new Padding(3, 4, 3, 4);
            textBoxStoreAddCode.Name = "textBoxStoreAddCode";
            textBoxStoreAddCode.Size = new Size(147, 22);
            textBoxStoreAddCode.TabIndex = 22;
            textBoxStoreAddCode.KeyPress += textBoxOnlyNumbers_KeyPress;
            // 
            // buttonStoreAdd
            // 
            buttonStoreAdd.FlatAppearance.BorderColor = Color.Green;
            buttonStoreAdd.FlatStyle = FlatStyle.Flat;
            buttonStoreAdd.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStoreAdd.ForeColor = Color.Green;
            buttonStoreAdd.Image = Properties.Resources.add;
            buttonStoreAdd.ImageAlign = ContentAlignment.MiddleRight;
            buttonStoreAdd.Location = new Point(22, 80);
            buttonStoreAdd.Margin = new Padding(3, 4, 3, 4);
            buttonStoreAdd.Name = "buttonStoreAdd";
            buttonStoreAdd.Size = new Size(90, 30);
            buttonStoreAdd.TabIndex = 19;
            buttonStoreAdd.Text = "Agregar";
            buttonStoreAdd.TextAlign = ContentAlignment.MiddleLeft;
            buttonStoreAdd.UseVisualStyleBackColor = true;
            buttonStoreAdd.Click += buttonStoreAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(22, 33);
            label1.Name = "label1";
            label1.Size = new Size(96, 16);
            label1.TabIndex = 2;
            label1.Text = "Nuevo Tienda:";
            // 
            // groupBoxEditUser
            // 
            groupBoxEditUser.BackColor = Color.White;
            groupBoxEditUser.Controls.Add(buttonStoreEdit);
            groupBoxEditUser.Controls.Add(buttonStoreDelete);
            groupBoxEditUser.Controls.Add(comboBoxStoreEdit);
            groupBoxEditUser.Controls.Add(label4);
            groupBoxEditUser.Controls.Add(textBoxStoreEditCode);
            groupBoxEditUser.Controls.Add(label2);
            groupBoxEditUser.Dock = DockStyle.Top;
            groupBoxEditUser.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxEditUser.Location = new Point(0, 0);
            groupBoxEditUser.Margin = new Padding(3, 4, 3, 4);
            groupBoxEditUser.Name = "groupBoxEditUser";
            groupBoxEditUser.Padding = new Padding(3, 4, 3, 4);
            groupBoxEditUser.Size = new Size(1062, 163);
            groupBoxEditUser.TabIndex = 20;
            groupBoxEditUser.TabStop = false;
            groupBoxEditUser.Text = "Editar Tienda";
            // 
            // buttonStoreEdit
            // 
            buttonStoreEdit.FlatAppearance.BorderColor = Color.Green;
            buttonStoreEdit.FlatStyle = FlatStyle.Flat;
            buttonStoreEdit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStoreEdit.ForeColor = Color.FromArgb(255, 128, 0);
            buttonStoreEdit.Image = Properties.Resources.edit;
            buttonStoreEdit.ImageAlign = ContentAlignment.MiddleRight;
            buttonStoreEdit.Location = new Point(22, 115);
            buttonStoreEdit.Margin = new Padding(3, 4, 3, 4);
            buttonStoreEdit.Name = "buttonStoreEdit";
            buttonStoreEdit.Size = new Size(90, 30);
            buttonStoreEdit.TabIndex = 18;
            buttonStoreEdit.Text = "Editar";
            buttonStoreEdit.TextAlign = ContentAlignment.MiddleLeft;
            buttonStoreEdit.UseVisualStyleBackColor = true;
            buttonStoreEdit.Click += buttonStoreEdit_Click;
            // 
            // buttonStoreDelete
            // 
            buttonStoreDelete.FlatAppearance.BorderColor = Color.Green;
            buttonStoreDelete.FlatStyle = FlatStyle.Flat;
            buttonStoreDelete.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStoreDelete.ForeColor = Color.FromArgb(192, 0, 0);
            buttonStoreDelete.Image = Properties.Resources.delete;
            buttonStoreDelete.ImageAlign = ContentAlignment.MiddleRight;
            buttonStoreDelete.Location = new Point(141, 115);
            buttonStoreDelete.Margin = new Padding(3, 4, 3, 4);
            buttonStoreDelete.Name = "buttonStoreDelete";
            buttonStoreDelete.Size = new Size(90, 30);
            buttonStoreDelete.TabIndex = 19;
            buttonStoreDelete.Text = "Eliminar";
            buttonStoreDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonStoreDelete.UseVisualStyleBackColor = true;
            buttonStoreDelete.Click += buttonStoreDelete_Click;
            // 
            // comboBoxStoreEdit
            // 
            comboBoxStoreEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStoreEdit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStoreEdit.FormattingEnabled = true;
            comboBoxStoreEdit.Location = new Point(141, 31);
            comboBoxStoreEdit.Margin = new Padding(3, 4, 3, 4);
            comboBoxStoreEdit.Name = "comboBoxStoreEdit";
            comboBoxStoreEdit.Size = new Size(147, 24);
            comboBoxStoreEdit.TabIndex = 21;
            comboBoxStoreEdit.SelectedIndexChanged += comboBoxStoreEdit_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(22, 34);
            label4.Name = "label4";
            label4.Size = new Size(53, 16);
            label4.TabIndex = 20;
            label4.Text = "Tienda:";
            // 
            // textBoxStoreEditCode
            // 
            textBoxStoreEditCode.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxStoreEditCode.Location = new Point(141, 68);
            textBoxStoreEditCode.Margin = new Padding(3, 4, 3, 4);
            textBoxStoreEditCode.Name = "textBoxStoreEditCode";
            textBoxStoreEditCode.Size = new Size(147, 22);
            textBoxStoreEditCode.TabIndex = 3;
            textBoxStoreEditCode.KeyPress += textBoxOnlyNumbers_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 71);
            label2.Name = "label2";
            label2.Size = new Size(91, 16);
            label2.TabIndex = 2;
            label2.Text = "Editar Tienda:";
            // 
            // UserControlStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Name = "UserControlStore";
            Size = new Size(1072, 633);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxEditUser.ResumeLayout(false);
            groupBoxEditUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel5;
        private GroupBox groupBox2;
        private Button buttonStoreRefreshData;
        private GroupBox groupBox1;
        private TextBox textBoxStoreAddCode;
        private Button buttonStoreAdd;
        private Label label1;
        private GroupBox groupBoxEditUser;
        private Button buttonStoreEdit;
        private Button buttonStoreDelete;
        private ComboBox comboBoxStoreEdit;
        private Label label4;
        private TextBox textBoxStoreEditCode;
        private Label label2;
    }
}
