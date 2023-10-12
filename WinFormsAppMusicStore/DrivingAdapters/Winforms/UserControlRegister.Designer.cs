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
            panel1 = new Panel();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            cartesianChartMonth = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            cartesianChartWeek = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPage2 = new TabPage();
            panel14 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel21 = new Panel();
            buttonExportToExcel = new Button();
            buttonEraseRegisters = new Button();
            panel15 = new Panel();
            dataGridViewRegisters = new DataGridView();
            panel2 = new Panel();
            buttonSearchRegisters = new Button();
            dateTimePickerDate = new DateTimePicker();
            label18 = new Label();
            comboBoxStore = new ComboBox();
            label10 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tabPage2.SuspendLayout();
            panel14.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel21.SuspendLayout();
            panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegisters).BeginInit();
            panel2.SuspendLayout();
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
            panel4.Size = new Size(1049, 761);
            panel4.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 5);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1039, 751);
            panel5.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(tableLayoutPanel);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(1039, 751);
            panel6.TabIndex = 4;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(label4, 0, 0);
            tableLayoutPanel.Controls.Add(panel1, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel.Size = new Size(1039, 751);
            tableLayoutPanel.TabIndex = 5;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(1033, 32);
            label4.TabIndex = 2;
            label4.Text = "REGISTROS";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 36);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1033, 711);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 45);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1033, 666);
            panel3.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1033, 666);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel4);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1025, 636);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Graficos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(cartesianChartMonth, 0, 1);
            tableLayoutPanel4.Controls.Add(cartesianChartWeek, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 4);
            tableLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel4.Size = new Size(1019, 628);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // cartesianChartMonth
            // 
            cartesianChartMonth.Dock = DockStyle.Fill;
            cartesianChartMonth.Location = new Point(3, 317);
            cartesianChartMonth.Name = "cartesianChartMonth";
            cartesianChartMonth.Size = new Size(1013, 308);
            cartesianChartMonth.TabIndex = 28;
            // 
            // cartesianChartWeek
            // 
            cartesianChartWeek.Dock = DockStyle.Fill;
            cartesianChartWeek.Location = new Point(3, 3);
            cartesianChartWeek.Name = "cartesianChartWeek";
            cartesianChartWeek.Size = new Size(1013, 308);
            cartesianChartWeek.TabIndex = 26;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel14);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1025, 636);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Registros";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            panel14.Controls.Add(tableLayoutPanel3);
            panel14.Dock = DockStyle.Fill;
            panel14.Location = new Point(3, 4);
            panel14.Margin = new Padding(3, 4, 3, 4);
            panel14.Name = "panel14";
            panel14.Size = new Size(1019, 628);
            panel14.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(panel21, 0, 1);
            tableLayoutPanel3.Controls.Add(panel15, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel3.Size = new Size(1019, 628);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel21
            // 
            panel21.Controls.Add(buttonExportToExcel);
            panel21.Controls.Add(buttonEraseRegisters);
            panel21.Dock = DockStyle.Fill;
            panel21.Location = new Point(3, 587);
            panel21.Margin = new Padding(3, 4, 3, 4);
            panel21.Name = "panel21";
            panel21.Size = new Size(1013, 37);
            panel21.TabIndex = 1;
            // 
            // buttonExportToExcel
            // 
            buttonExportToExcel.FlatAppearance.BorderColor = Color.Green;
            buttonExportToExcel.FlatStyle = FlatStyle.Flat;
            buttonExportToExcel.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExportToExcel.ForeColor = Color.Green;
            buttonExportToExcel.Image = Properties.Resources.excel;
            buttonExportToExcel.ImageAlign = ContentAlignment.MiddleRight;
            buttonExportToExcel.Location = new Point(0, 4);
            buttonExportToExcel.Margin = new Padding(3, 4, 3, 4);
            buttonExportToExcel.Name = "buttonExportToExcel";
            buttonExportToExcel.Size = new Size(90, 30);
            buttonExportToExcel.TabIndex = 30;
            buttonExportToExcel.Text = "Exportar Excel";
            buttonExportToExcel.TextAlign = ContentAlignment.MiddleLeft;
            buttonExportToExcel.UseVisualStyleBackColor = true;
            buttonExportToExcel.Click += buttonExportToExcel_Click;
            // 
            // buttonEraseRegisters
            // 
            buttonEraseRegisters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEraseRegisters.FlatAppearance.BorderColor = Color.Green;
            buttonEraseRegisters.FlatStyle = FlatStyle.Flat;
            buttonEraseRegisters.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEraseRegisters.ForeColor = Color.FromArgb(192, 0, 0);
            buttonEraseRegisters.Image = Properties.Resources.delete;
            buttonEraseRegisters.ImageAlign = ContentAlignment.MiddleRight;
            buttonEraseRegisters.Location = new Point(850, 4);
            buttonEraseRegisters.Margin = new Padding(3, 4, 3, 4);
            buttonEraseRegisters.Name = "buttonEraseRegisters";
            buttonEraseRegisters.Size = new Size(160, 30);
            buttonEraseRegisters.TabIndex = 26;
            buttonEraseRegisters.Text = "Eliminar Registros";
            buttonEraseRegisters.TextAlign = ContentAlignment.MiddleLeft;
            buttonEraseRegisters.UseVisualStyleBackColor = true;
            buttonEraseRegisters.Click += buttonEraseRegisters_Click;
            // 
            // panel15
            // 
            panel15.Controls.Add(dataGridViewRegisters);
            panel15.Dock = DockStyle.Fill;
            panel15.Location = new Point(3, 4);
            panel15.Margin = new Padding(3, 4, 3, 4);
            panel15.Name = "panel15";
            panel15.Size = new Size(1013, 575);
            panel15.TabIndex = 2;
            // 
            // dataGridViewRegisters
            // 
            dataGridViewRegisters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRegisters.Dock = DockStyle.Fill;
            dataGridViewRegisters.Location = new Point(0, 0);
            dataGridViewRegisters.Margin = new Padding(3, 4, 3, 4);
            dataGridViewRegisters.Name = "dataGridViewRegisters";
            dataGridViewRegisters.RowHeadersWidth = 51;
            dataGridViewRegisters.RowTemplate.Height = 25;
            dataGridViewRegisters.Size = new Size(1013, 575);
            dataGridViewRegisters.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(buttonSearchRegisters);
            panel2.Controls.Add(dateTimePickerDate);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(comboBoxStore);
            panel2.Controls.Add(label10);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1033, 45);
            panel2.TabIndex = 0;
            // 
            // buttonSearchRegisters
            // 
            buttonSearchRegisters.FlatAppearance.BorderColor = Color.Green;
            buttonSearchRegisters.FlatStyle = FlatStyle.Flat;
            buttonSearchRegisters.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSearchRegisters.ForeColor = Color.Blue;
            buttonSearchRegisters.Image = Properties.Resources.search;
            buttonSearchRegisters.ImageAlign = ContentAlignment.MiddleRight;
            buttonSearchRegisters.Location = new Point(389, 6);
            buttonSearchRegisters.Margin = new Padding(3, 4, 3, 4);
            buttonSearchRegisters.Name = "buttonSearchRegisters";
            buttonSearchRegisters.Size = new Size(90, 30);
            buttonSearchRegisters.TabIndex = 20;
            buttonSearchRegisters.Text = "Buscar";
            buttonSearchRegisters.TextAlign = ContentAlignment.MiddleLeft;
            buttonSearchRegisters.UseVisualStyleBackColor = true;
            buttonSearchRegisters.Click += buttonSearchRegisters_Click;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePickerDate.Format = DateTimePickerFormat.Short;
            dateTimePickerDate.Location = new Point(268, 10);
            dateTimePickerDate.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(115, 25);
            dateTimePickerDate.TabIndex = 25;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(218, 12);
            label18.Name = "label18";
            label18.Size = new Size(44, 17);
            label18.TabIndex = 24;
            label18.Text = "Fecha:";
            // 
            // comboBoxStore
            // 
            comboBoxStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStore.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStore.FormattingEnabled = true;
            comboBoxStore.Location = new Point(65, 10);
            comboBoxStore.Margin = new Padding(3, 4, 3, 4);
            comboBoxStore.Name = "comboBoxStore";
            comboBoxStore.Size = new Size(147, 24);
            comboBoxStore.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(7, 13);
            label10.Name = "label10";
            label10.Size = new Size(50, 17);
            label10.TabIndex = 22;
            label10.Text = "Tienda:";
            // 
            // UserControlRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel4);
            Name = "UserControlRegister";
            Size = new Size(1049, 761);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel14.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegisters).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel;
        private Label label4;
        private Panel panel1;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel4;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartMonth;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChartWeek;
        private TabPage tabPage2;
        private Panel panel14;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel21;
        private Button buttonEraseRegisters;
        private Panel panel15;
        private DataGridView dataGridViewRegisters;
        private Panel panel2;
        private Button buttonSearchRegisters;
        private DateTimePicker dateTimePickerDate;
        private Label label18;
        private ComboBox comboBoxStore;
        private Label label10;
        private Button buttonExportToExcel;
    }
}
