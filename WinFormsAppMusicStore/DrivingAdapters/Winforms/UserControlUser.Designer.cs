namespace WinFormsAppMusicStoreAdmin
{
    partial class UserControlUser
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
            buttonUserRefreshData = new Button();
            groupBox1 = new GroupBox();
            comboBoxUserAddStore = new ComboBox();
            radioButtonUserAddStore = new RadioButton();
            radioButtonUserAddAdmin = new RadioButton();
            label1 = new Label();
            textBoxUserAddPassword = new TextBox();
            label6 = new Label();
            textBoxUserAddAlias = new TextBox();
            label7 = new Label();
            buttonUserAdd = new Button();
            groupBoxEditUser = new GroupBox();
            comboBoxUserEditStore = new ComboBox();
            radioButtonUserEditStore = new RadioButton();
            radioButtonUserEditAdmin = new RadioButton();
            label5 = new Label();
            textBoxUserEditPassword = new TextBox();
            label3 = new Label();
            buttonUserEdit = new Button();
            buttonUserDelete = new Button();
            comboBoxUserEdit = new ComboBox();
            label4 = new Label();
            textBoxUserEditAlias = new TextBox();
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
            panel4.Size = new Size(1026, 548);
            panel4.TabIndex = 7;
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
            panel5.Size = new Size(1016, 538);
            panel5.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(buttonUserRefreshData);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(0, 372);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1016, 88);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Refrescar Data";
            // 
            // buttonUserRefreshData
            // 
            buttonUserRefreshData.FlatAppearance.BorderColor = Color.Green;
            buttonUserRefreshData.FlatStyle = FlatStyle.Flat;
            buttonUserRefreshData.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUserRefreshData.ForeColor = Color.Blue;
            buttonUserRefreshData.Image = Properties.Resources.refresh;
            buttonUserRefreshData.ImageAlign = ContentAlignment.MiddleRight;
            buttonUserRefreshData.Location = new Point(22, 36);
            buttonUserRefreshData.Margin = new Padding(3, 4, 3, 4);
            buttonUserRefreshData.Name = "buttonUserRefreshData";
            buttonUserRefreshData.Size = new Size(120, 30);
            buttonUserRefreshData.TabIndex = 18;
            buttonUserRefreshData.Text = "Refrescar";
            buttonUserRefreshData.TextAlign = ContentAlignment.MiddleLeft;
            buttonUserRefreshData.UseVisualStyleBackColor = true;
            buttonUserRefreshData.Click += buttonUserRefreshData_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(comboBoxUserAddStore);
            groupBox1.Controls.Add(radioButtonUserAddStore);
            groupBox1.Controls.Add(radioButtonUserAddAdmin);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxUserAddPassword);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBoxUserAddAlias);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(buttonUserAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 215);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1016, 157);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar Usuario";
            // 
            // comboBoxUserAddStore
            // 
            comboBoxUserAddStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUserAddStore.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxUserAddStore.FormattingEnabled = true;
            comboBoxUserAddStore.Location = new Point(454, 76);
            comboBoxUserAddStore.Margin = new Padding(3, 4, 3, 4);
            comboBoxUserAddStore.Name = "comboBoxUserAddStore";
            comboBoxUserAddStore.Size = new Size(147, 24);
            comboBoxUserAddStore.TabIndex = 35;
            // 
            // radioButtonUserAddStore
            // 
            radioButtonUserAddStore.AutoSize = true;
            radioButtonUserAddStore.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonUserAddStore.Location = new Point(335, 80);
            radioButtonUserAddStore.Name = "radioButtonUserAddStore";
            radioButtonUserAddStore.Size = new Size(71, 20);
            radioButtonUserAddStore.TabIndex = 34;
            radioButtonUserAddStore.TabStop = true;
            radioButtonUserAddStore.Text = "Tienda";
            radioButtonUserAddStore.UseVisualStyleBackColor = true;
            radioButtonUserAddStore.CheckedChanged += radioButtonUserAddStore_CheckedChanged;
            // 
            // radioButtonUserAddAdmin
            // 
            radioButtonUserAddAdmin.AutoSize = true;
            radioButtonUserAddAdmin.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonUserAddAdmin.Location = new Point(141, 80);
            radioButtonUserAddAdmin.Name = "radioButtonUserAddAdmin";
            radioButtonUserAddAdmin.Size = new Size(111, 20);
            radioButtonUserAddAdmin.TabIndex = 33;
            radioButtonUserAddAdmin.TabStop = true;
            radioButtonUserAddAdmin.Text = "Administrador";
            radioButtonUserAddAdmin.UseVisualStyleBackColor = true;
            radioButtonUserAddAdmin.CheckedChanged += radioButtonUserAddAdmin_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(22, 83);
            label1.Name = "label1";
            label1.Size = new Size(31, 16);
            label1.TabIndex = 32;
            label1.Text = "Rol:";
            // 
            // textBoxUserAddPassword
            // 
            textBoxUserAddPassword.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserAddPassword.Location = new Point(454, 31);
            textBoxUserAddPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxUserAddPassword.Name = "textBoxUserAddPassword";
            textBoxUserAddPassword.Size = new Size(147, 22);
            textBoxUserAddPassword.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(335, 35);
            label6.Name = "label6";
            label6.Size = new Size(70, 16);
            label6.TabIndex = 30;
            label6.Text = "Password:";
            // 
            // textBoxUserAddAlias
            // 
            textBoxUserAddAlias.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserAddAlias.Location = new Point(141, 31);
            textBoxUserAddAlias.Margin = new Padding(3, 4, 3, 4);
            textBoxUserAddAlias.Name = "textBoxUserAddAlias";
            textBoxUserAddAlias.Size = new Size(147, 22);
            textBoxUserAddAlias.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(22, 35);
            label7.Name = "label7";
            label7.Size = new Size(40, 16);
            label7.TabIndex = 28;
            label7.Text = "Alias:";
            // 
            // buttonUserAdd
            // 
            buttonUserAdd.FlatAppearance.BorderColor = Color.Green;
            buttonUserAdd.FlatStyle = FlatStyle.Flat;
            buttonUserAdd.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUserAdd.ForeColor = Color.Green;
            buttonUserAdd.Image = Properties.Resources.add;
            buttonUserAdd.ImageAlign = ContentAlignment.MiddleRight;
            buttonUserAdd.Location = new Point(22, 115);
            buttonUserAdd.Margin = new Padding(3, 4, 3, 4);
            buttonUserAdd.Name = "buttonUserAdd";
            buttonUserAdd.Size = new Size(90, 30);
            buttonUserAdd.TabIndex = 19;
            buttonUserAdd.Text = "Agregar";
            buttonUserAdd.TextAlign = ContentAlignment.MiddleLeft;
            buttonUserAdd.UseVisualStyleBackColor = true;
            buttonUserAdd.Click += buttonUserAdd_Click;
            // 
            // groupBoxEditUser
            // 
            groupBoxEditUser.BackColor = Color.White;
            groupBoxEditUser.Controls.Add(comboBoxUserEditStore);
            groupBoxEditUser.Controls.Add(radioButtonUserEditStore);
            groupBoxEditUser.Controls.Add(radioButtonUserEditAdmin);
            groupBoxEditUser.Controls.Add(label5);
            groupBoxEditUser.Controls.Add(textBoxUserEditPassword);
            groupBoxEditUser.Controls.Add(label3);
            groupBoxEditUser.Controls.Add(buttonUserEdit);
            groupBoxEditUser.Controls.Add(buttonUserDelete);
            groupBoxEditUser.Controls.Add(comboBoxUserEdit);
            groupBoxEditUser.Controls.Add(label4);
            groupBoxEditUser.Controls.Add(textBoxUserEditAlias);
            groupBoxEditUser.Controls.Add(label2);
            groupBoxEditUser.Dock = DockStyle.Top;
            groupBoxEditUser.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxEditUser.Location = new Point(0, 0);
            groupBoxEditUser.Margin = new Padding(3, 4, 3, 4);
            groupBoxEditUser.Name = "groupBoxEditUser";
            groupBoxEditUser.Padding = new Padding(3, 4, 3, 4);
            groupBoxEditUser.Size = new Size(1016, 215);
            groupBoxEditUser.TabIndex = 20;
            groupBoxEditUser.TabStop = false;
            groupBoxEditUser.Text = "Editar Usuario";
            // 
            // comboBoxUserEditStore
            // 
            comboBoxUserEditStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUserEditStore.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxUserEditStore.FormattingEnabled = true;
            comboBoxUserEditStore.Location = new Point(454, 113);
            comboBoxUserEditStore.Margin = new Padding(3, 4, 3, 4);
            comboBoxUserEditStore.Name = "comboBoxUserEditStore";
            comboBoxUserEditStore.Size = new Size(147, 24);
            comboBoxUserEditStore.TabIndex = 27;
            // 
            // radioButtonUserEditStore
            // 
            radioButtonUserEditStore.AutoSize = true;
            radioButtonUserEditStore.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonUserEditStore.Location = new Point(335, 117);
            radioButtonUserEditStore.Name = "radioButtonUserEditStore";
            radioButtonUserEditStore.Size = new Size(71, 20);
            radioButtonUserEditStore.TabIndex = 26;
            radioButtonUserEditStore.TabStop = true;
            radioButtonUserEditStore.Text = "Tienda";
            radioButtonUserEditStore.UseVisualStyleBackColor = true;
            radioButtonUserEditStore.CheckedChanged += radioButtonUserEditStore_CheckedChanged;
            // 
            // radioButtonUserEditAdmin
            // 
            radioButtonUserEditAdmin.AutoSize = true;
            radioButtonUserEditAdmin.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonUserEditAdmin.Location = new Point(141, 117);
            radioButtonUserEditAdmin.Name = "radioButtonUserEditAdmin";
            radioButtonUserEditAdmin.Size = new Size(111, 20);
            radioButtonUserEditAdmin.TabIndex = 25;
            radioButtonUserEditAdmin.TabStop = true;
            radioButtonUserEditAdmin.Text = "Administrador";
            radioButtonUserEditAdmin.UseVisualStyleBackColor = true;
            radioButtonUserEditAdmin.CheckedChanged += radioButtonUserEditAdmin_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(22, 119);
            label5.Name = "label5";
            label5.Size = new Size(31, 16);
            label5.TabIndex = 24;
            label5.Text = "Rol:";
            // 
            // textBoxUserEditPassword
            // 
            textBoxUserEditPassword.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserEditPassword.Location = new Point(454, 68);
            textBoxUserEditPassword.Margin = new Padding(3, 4, 3, 4);
            textBoxUserEditPassword.Name = "textBoxUserEditPassword";
            textBoxUserEditPassword.Size = new Size(147, 22);
            textBoxUserEditPassword.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(335, 72);
            label3.Name = "label3";
            label3.Size = new Size(70, 16);
            label3.TabIndex = 22;
            label3.Text = "Password:";
            // 
            // buttonUserEdit
            // 
            buttonUserEdit.FlatAppearance.BorderColor = Color.Green;
            buttonUserEdit.FlatStyle = FlatStyle.Flat;
            buttonUserEdit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUserEdit.ForeColor = Color.FromArgb(255, 128, 0);
            buttonUserEdit.Image = Properties.Resources.edit;
            buttonUserEdit.ImageAlign = ContentAlignment.MiddleRight;
            buttonUserEdit.Location = new Point(22, 157);
            buttonUserEdit.Margin = new Padding(3, 4, 3, 4);
            buttonUserEdit.Name = "buttonUserEdit";
            buttonUserEdit.Size = new Size(90, 30);
            buttonUserEdit.TabIndex = 18;
            buttonUserEdit.Text = "Editar";
            buttonUserEdit.TextAlign = ContentAlignment.MiddleLeft;
            buttonUserEdit.UseVisualStyleBackColor = true;
            buttonUserEdit.Click += buttonStoreUserEdit_Click;
            // 
            // buttonUserDelete
            // 
            buttonUserDelete.FlatAppearance.BorderColor = Color.Green;
            buttonUserDelete.FlatStyle = FlatStyle.Flat;
            buttonUserDelete.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUserDelete.ForeColor = Color.FromArgb(192, 0, 0);
            buttonUserDelete.Image = Properties.Resources.delete;
            buttonUserDelete.ImageAlign = ContentAlignment.MiddleRight;
            buttonUserDelete.Location = new Point(141, 157);
            buttonUserDelete.Margin = new Padding(3, 4, 3, 4);
            buttonUserDelete.Name = "buttonUserDelete";
            buttonUserDelete.Size = new Size(90, 30);
            buttonUserDelete.TabIndex = 19;
            buttonUserDelete.Text = "Eliminar";
            buttonUserDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonUserDelete.UseVisualStyleBackColor = true;
            buttonUserDelete.Click += buttonUserDelete_Click;
            // 
            // comboBoxUserEdit
            // 
            comboBoxUserEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUserEdit.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxUserEdit.FormattingEnabled = true;
            comboBoxUserEdit.Location = new Point(141, 31);
            comboBoxUserEdit.Margin = new Padding(3, 4, 3, 4);
            comboBoxUserEdit.Name = "comboBoxUserEdit";
            comboBoxUserEdit.Size = new Size(147, 24);
            comboBoxUserEdit.TabIndex = 21;
            comboBoxUserEdit.SelectedIndexChanged += comboBoxUserEdit_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(22, 35);
            label4.Name = "label4";
            label4.Size = new Size(57, 16);
            label4.TabIndex = 20;
            label4.Text = "Usuario:";
            // 
            // textBoxUserEditAlias
            // 
            textBoxUserEditAlias.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxUserEditAlias.Location = new Point(141, 68);
            textBoxUserEditAlias.Margin = new Padding(3, 4, 3, 4);
            textBoxUserEditAlias.Name = "textBoxUserEditAlias";
            textBoxUserEditAlias.Size = new Size(147, 22);
            textBoxUserEditAlias.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 72);
            label2.Name = "label2";
            label2.Size = new Size(40, 16);
            label2.TabIndex = 2;
            label2.Text = "Alias:";
            // 
            // UserControlUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Name = "UserControlUser";
            Size = new Size(1026, 548);
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
        private Button buttonUserRefreshData;
        private GroupBox groupBox1;
        private Button buttonUserAdd;
        private GroupBox groupBoxEditUser;
        private Button buttonUserEdit;
        private Button buttonUserDelete;
        private ComboBox comboBoxUserEdit;
        private Label label4;
        private TextBox textBoxUserEditAlias;
        private Label label2;
        private ComboBox comboBoxUserEditStore;
        private RadioButton radioButtonUserEditStore;
        private RadioButton radioButtonUserEditAdmin;
        private Label label5;
        private TextBox textBoxUserEditPassword;
        private Label label3;
        private ComboBox comboBoxUserAddStore;
        private RadioButton radioButtonUserAddStore;
        private RadioButton radioButtonUserAddAdmin;
        private Label label1;
        private TextBox textBoxUserAddPassword;
        private Label label6;
        private TextBox textBoxUserAddAlias;
        private Label label7;
    }
}
