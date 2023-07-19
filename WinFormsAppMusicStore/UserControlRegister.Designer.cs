namespace WinFormsAppMusicStoreAdmin
{
    partial class UserControlRegister
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
            panel6 = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel7 = new Panel();
            panel8 = new Panel();
            dataGridViewRegister = new DataGridView();
            panel9 = new Panel();
            comboBoxRegisterStore = new ComboBox();
            label7 = new Label();
            dateTimePickerRegisterFinal = new DateTimePicker();
            label6 = new Label();
            buttonRegisterSearch = new Button();
            dateTimePickerRegisterInit = new DateTimePicker();
            label3 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            listBoxStoreNoRegister = new ListBox();
            panel2 = new Panel();
            buttonRegisterNoStoreSearch = new Button();
            dateTimePickerStoreNoRegister = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            panel10 = new Panel();
            buttonRegisterDelete = new Button();
            comboBoxRegisterDelete = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegister).BeginInit();
            panel9.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.Blue;
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(4);
            panel4.Size = new Size(918, 571);
            panel4.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(4, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(910, 563);
            panel5.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(tableLayoutPanel);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(910, 563);
            panel6.TabIndex = 4;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(label4, 0, 0);
            tableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(910, 563);
            tableLayoutPanel.TabIndex = 4;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(904, 24);
            label4.TabIndex = 2;
            label4.Text = "REGISTROS";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel10, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(904, 533);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.Controls.Add(panel7, 1, 0);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(898, 467);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel9);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(273, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(621, 459);
            panel7.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.Controls.Add(dataGridViewRegister);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(0, 120);
            panel8.Name = "panel8";
            panel8.Size = new Size(621, 339);
            panel8.TabIndex = 1;
            // 
            // dataGridViewRegister
            // 
            dataGridViewRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRegister.Dock = DockStyle.Fill;
            dataGridViewRegister.Location = new Point(0, 0);
            dataGridViewRegister.Name = "dataGridViewRegister";
            dataGridViewRegister.ReadOnly = true;
            dataGridViewRegister.RowTemplate.Height = 25;
            dataGridViewRegister.Size = new Size(621, 339);
            dataGridViewRegister.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(comboBoxRegisterStore);
            panel9.Controls.Add(label7);
            panel9.Controls.Add(dateTimePickerRegisterFinal);
            panel9.Controls.Add(label6);
            panel9.Controls.Add(buttonRegisterSearch);
            panel9.Controls.Add(dateTimePickerRegisterInit);
            panel9.Controls.Add(label3);
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(621, 120);
            panel9.TabIndex = 0;
            // 
            // comboBoxRegisterStore
            // 
            comboBoxRegisterStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRegisterStore.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxRegisterStore.FormattingEnabled = true;
            comboBoxRegisterStore.Location = new Point(54, 47);
            comboBoxRegisterStore.Name = "comboBoxRegisterStore";
            comboBoxRegisterStore.Size = new Size(129, 23);
            comboBoxRegisterStore.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 51);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 22;
            label7.Text = "Tienda:";
            // 
            // dateTimePickerRegisterFinal
            // 
            dateTimePickerRegisterFinal.Format = DateTimePickerFormat.Short;
            dateTimePickerRegisterFinal.Location = new Point(468, 43);
            dateTimePickerRegisterFinal.Name = "dateTimePickerRegisterFinal";
            dateTimePickerRegisterFinal.Size = new Size(101, 23);
            dateTimePickerRegisterFinal.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(393, 49);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 20;
            label6.Text = "Fecha Final:";
            // 
            // buttonRegisterSearch
            // 
            buttonRegisterSearch.FlatAppearance.BorderColor = Color.Green;
            buttonRegisterSearch.FlatStyle = FlatStyle.Flat;
            buttonRegisterSearch.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRegisterSearch.ForeColor = Color.Blue;
            buttonRegisterSearch.Image = Properties.Resources.search;
            buttonRegisterSearch.ImageAlign = ContentAlignment.MiddleRight;
            buttonRegisterSearch.Location = new Point(3, 87);
            buttonRegisterSearch.Name = "buttonRegisterSearch";
            buttonRegisterSearch.Size = new Size(105, 27);
            buttonRegisterSearch.TabIndex = 19;
            buttonRegisterSearch.Text = "Buscar";
            buttonRegisterSearch.TextAlign = ContentAlignment.MiddleLeft;
            buttonRegisterSearch.UseVisualStyleBackColor = true;
            buttonRegisterSearch.Click += buttonRegisterSearch_Click;
            // 
            // dateTimePickerRegisterInit
            // 
            dateTimePickerRegisterInit.Format = DateTimePickerFormat.Short;
            dateTimePickerRegisterInit.Location = new Point(277, 45);
            dateTimePickerRegisterInit.Name = "dateTimePickerRegisterInit";
            dateTimePickerRegisterInit.Size = new Size(101, 23);
            dateTimePickerRegisterInit.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(196, 49);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 1;
            label3.Text = "Fecha Inicial:";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Roboto Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(619, 23);
            label5.TabIndex = 0;
            label5.Text = "Registros";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 459);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(listBoxStoreNoRegister);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(262, 339);
            panel3.TabIndex = 1;
            // 
            // listBoxStoreNoRegister
            // 
            listBoxStoreNoRegister.Dock = DockStyle.Fill;
            listBoxStoreNoRegister.FormattingEnabled = true;
            listBoxStoreNoRegister.ItemHeight = 15;
            listBoxStoreNoRegister.Location = new Point(0, 0);
            listBoxStoreNoRegister.Name = "listBoxStoreNoRegister";
            listBoxStoreNoRegister.SelectionMode = SelectionMode.None;
            listBoxStoreNoRegister.Size = new Size(262, 339);
            listBoxStoreNoRegister.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonRegisterNoStoreSearch);
            panel2.Controls.Add(dateTimePickerStoreNoRegister);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 120);
            panel2.TabIndex = 0;
            // 
            // buttonRegisterNoStoreSearch
            // 
            buttonRegisterNoStoreSearch.FlatAppearance.BorderColor = Color.Green;
            buttonRegisterNoStoreSearch.FlatStyle = FlatStyle.Flat;
            buttonRegisterNoStoreSearch.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRegisterNoStoreSearch.ForeColor = Color.Blue;
            buttonRegisterNoStoreSearch.Image = Properties.Resources.search;
            buttonRegisterNoStoreSearch.ImageAlign = ContentAlignment.MiddleRight;
            buttonRegisterNoStoreSearch.Location = new Point(3, 87);
            buttonRegisterNoStoreSearch.Name = "buttonRegisterNoStoreSearch";
            buttonRegisterNoStoreSearch.Size = new Size(105, 27);
            buttonRegisterNoStoreSearch.TabIndex = 19;
            buttonRegisterNoStoreSearch.Text = "Buscar";
            buttonRegisterNoStoreSearch.TextAlign = ContentAlignment.MiddleLeft;
            buttonRegisterNoStoreSearch.UseVisualStyleBackColor = true;
            buttonRegisterNoStoreSearch.Click += buttonRegisterNoStoreSearch_Click;
            // 
            // dateTimePickerStoreNoRegister
            // 
            dateTimePickerStoreNoRegister.Format = DateTimePickerFormat.Short;
            dateTimePickerStoreNoRegister.Location = new Point(50, 45);
            dateTimePickerStoreNoRegister.Name = "dateTimePickerStoreNoRegister";
            dateTimePickerStoreNoRegister.Size = new Size(101, 23);
            dateTimePickerStoreNoRegister.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 51);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha:";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Roboto Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(260, 23);
            label1.TabIndex = 0;
            label1.Text = "Tienda no registros";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.Controls.Add(buttonRegisterDelete);
            panel10.Controls.Add(comboBoxRegisterDelete);
            panel10.Controls.Add(label9);
            panel10.Controls.Add(label8);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 476);
            panel10.Name = "panel10";
            panel10.Size = new Size(898, 54);
            panel10.TabIndex = 1;
            // 
            // buttonRegisterDelete
            // 
            buttonRegisterDelete.FlatAppearance.BorderColor = Color.Green;
            buttonRegisterDelete.FlatStyle = FlatStyle.Flat;
            buttonRegisterDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRegisterDelete.ForeColor = Color.FromArgb(192, 0, 0);
            buttonRegisterDelete.Image = Properties.Resources.delete;
            buttonRegisterDelete.ImageAlign = ContentAlignment.MiddleRight;
            buttonRegisterDelete.Location = new Point(366, 12);
            buttonRegisterDelete.Name = "buttonRegisterDelete";
            buttonRegisterDelete.Size = new Size(105, 27);
            buttonRegisterDelete.TabIndex = 26;
            buttonRegisterDelete.Text = "Eliminar";
            buttonRegisterDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonRegisterDelete.UseVisualStyleBackColor = true;
            buttonRegisterDelete.Click += buttonRegisterDelete_Click;
            // 
            // comboBoxRegisterDelete
            // 
            comboBoxRegisterDelete.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRegisterDelete.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxRegisterDelete.FormattingEnabled = true;
            comboBoxRegisterDelete.Location = new Point(217, 15);
            comboBoxRegisterDelete.Name = "comboBoxRegisterDelete";
            comboBoxRegisterDelete.Size = new Size(129, 23);
            comboBoxRegisterDelete.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(166, 19);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 24;
            label9.Text = "Tienda:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Roboto Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ImageAlign = ContentAlignment.MiddleLeft;
            label8.Location = new Point(8, 16);
            label8.Name = "label8";
            label8.Size = new Size(129, 21);
            label8.TabIndex = 2;
            label8.Text = "Eliminar Registros";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserControlRegister";
            Size = new Size(918, 571);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegister).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private ListBox listBoxStoreNoRegister;
        private DateTimePicker dateTimePickerStoreNoRegister;
        private Label label2;
        private Label label1;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel;
        private Label label4;
        private Button buttonRegisterNoStoreSearch;
        private Panel panel7;
        private Panel panel8;
        private DataGridView dataGridViewRegister;
        private Panel panel9;
        private Button buttonRegisterSearch;
        private DateTimePicker dateTimePickerRegisterInit;
        private Label label3;
        private Label label5;
        private Label label7;
        private DateTimePicker dateTimePickerRegisterFinal;
        private Label label6;
        private ComboBox comboBoxRegisterStore;
        private Panel panel10;
        private ComboBox comboBoxRegisterDelete;
        private Label label9;
        private Label label8;
        private Button buttonRegisterDelete;
    }
}
