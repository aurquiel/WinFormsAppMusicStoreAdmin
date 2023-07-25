namespace WinFormsAppMusicStoreAdmin
{
    partial class UserControlTool
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
            tableLayoutPanel = new TableLayoutPanel();
            panel6 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel7 = new Panel();
            buttonRefreshAudioListStore = new Button();
            comboBoxStore = new ComboBox();
            listBoxAudioListStore = new ListBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            panel9 = new Panel();
            buttonSelectAll = new Button();
            buttonUnselectAll = new Button();
            buttonCopyAudioListToStores = new Button();
            listBoxStores = new ListBox();
            label4 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel9.SuspendLayout();
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
            panel4.Size = new Size(982, 605);
            panel4.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(tableLayoutPanel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(4, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(974, 597);
            panel5.TabIndex = 3;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(panel6, 0, 1);
            tableLayoutPanel.Controls.Add(label4, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(974, 597);
            tableLayoutPanel.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Controls.Add(tableLayoutPanel4);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 27);
            panel6.Name = "panel6";
            panel6.Size = new Size(968, 567);
            panel6.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(968, 567);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(panel7, 0, 1);
            tableLayoutPanel5.Controls.Add(listBoxAudioListStore, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(4, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel5.Size = new Size(476, 559);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(buttonRefreshAudioListStore);
            panel7.Controls.Add(comboBoxStore);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 522);
            panel7.Name = "panel7";
            panel7.Size = new Size(470, 34);
            panel7.TabIndex = 22;
            // 
            // buttonRefreshAudioListStore
            // 
            buttonRefreshAudioListStore.BackColor = Color.White;
            buttonRefreshAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonRefreshAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRefreshAudioListStore.ForeColor = Color.Blue;
            buttonRefreshAudioListStore.Image = Properties.Resources.refreshListStore;
            buttonRefreshAudioListStore.Location = new Point(94, 4);
            buttonRefreshAudioListStore.Name = "buttonRefreshAudioListStore";
            buttonRefreshAudioListStore.Size = new Size(32, 27);
            buttonRefreshAudioListStore.TabIndex = 30;
            buttonRefreshAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonRefreshAudioListStore.UseVisualStyleBackColor = false;
            buttonRefreshAudioListStore.Click += buttonRefreshAudioListStore_Click;
            // 
            // comboBoxStore
            // 
            comboBoxStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStore.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStore.FormattingEnabled = true;
            comboBoxStore.Location = new Point(3, 6);
            comboBoxStore.Name = "comboBoxStore";
            comboBoxStore.Size = new Size(85, 25);
            comboBoxStore.TabIndex = 29;
            comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
            // 
            // listBoxAudioListStore
            // 
            listBoxAudioListStore.Dock = DockStyle.Fill;
            listBoxAudioListStore.FormattingEnabled = true;
            listBoxAudioListStore.ItemHeight = 20;
            listBoxAudioListStore.Location = new Point(3, 3);
            listBoxAudioListStore.Name = "listBoxAudioListStore";
            listBoxAudioListStore.SelectionMode = SelectionMode.None;
            listBoxAudioListStore.Size = new Size(470, 513);
            listBoxAudioListStore.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(panel9, 0, 1);
            tableLayoutPanel6.Controls.Add(listBoxStores, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(487, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel6.Size = new Size(477, 559);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.Controls.Add(buttonSelectAll);
            panel9.Controls.Add(buttonUnselectAll);
            panel9.Controls.Add(buttonCopyAudioListToStores);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 522);
            panel9.Name = "panel9";
            panel9.Size = new Size(471, 34);
            panel9.TabIndex = 23;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.BackColor = Color.White;
            buttonSelectAll.FlatStyle = FlatStyle.Flat;
            buttonSelectAll.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSelectAll.ForeColor = Color.Black;
            buttonSelectAll.Image = Properties.Resources.selectAll;
            buttonSelectAll.Location = new Point(41, 2);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(32, 27);
            buttonSelectAll.TabIndex = 26;
            buttonSelectAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonSelectAll.UseVisualStyleBackColor = false;
            buttonSelectAll.Click += buttonSelectAll_Click;
            // 
            // buttonUnselectAll
            // 
            buttonUnselectAll.BackColor = Color.White;
            buttonUnselectAll.FlatStyle = FlatStyle.Flat;
            buttonUnselectAll.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUnselectAll.ForeColor = Color.Black;
            buttonUnselectAll.Image = Properties.Resources.unselectAll;
            buttonUnselectAll.Location = new Point(3, 2);
            buttonUnselectAll.Name = "buttonUnselectAll";
            buttonUnselectAll.Size = new Size(32, 27);
            buttonUnselectAll.TabIndex = 25;
            buttonUnselectAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonUnselectAll.UseVisualStyleBackColor = false;
            buttonUnselectAll.Click += buttonUnselectAll_Click;
            // 
            // buttonCopyAudioListToStores
            // 
            buttonCopyAudioListToStores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopyAudioListToStores.BackColor = Color.White;
            buttonCopyAudioListToStores.FlatStyle = FlatStyle.Flat;
            buttonCopyAudioListToStores.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCopyAudioListToStores.ForeColor = Color.DarkOrange;
            buttonCopyAudioListToStores.Image = Properties.Resources.upload;
            buttonCopyAudioListToStores.Location = new Point(436, 2);
            buttonCopyAudioListToStores.Name = "buttonCopyAudioListToStores";
            buttonCopyAudioListToStores.Size = new Size(32, 27);
            buttonCopyAudioListToStores.TabIndex = 21;
            buttonCopyAudioListToStores.TextAlign = ContentAlignment.MiddleLeft;
            buttonCopyAudioListToStores.UseVisualStyleBackColor = false;
            buttonCopyAudioListToStores.Click += buttonCopyAudioListToStores_Click;
            // 
            // listBoxStores
            // 
            listBoxStores.Dock = DockStyle.Fill;
            listBoxStores.FormattingEnabled = true;
            listBoxStores.ItemHeight = 20;
            listBoxStores.Location = new Point(3, 3);
            listBoxStores.Name = "listBoxStores";
            listBoxStores.SelectionMode = SelectionMode.MultiSimple;
            listBoxStores.Size = new Size(471, 513);
            listBoxStores.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(968, 24);
            label4.TabIndex = 2;
            label4.Text = "COPIAR LISTA REPRODUCCION";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlTool
            // 
            Controls.Add(panel4);
            Name = "UserControlTool";
            Size = new Size(982, 605);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel4;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel7;
        private ListBox listBoxAudioListStore;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel9;
        private Button buttonCopyAudioListToStores;
        private ListBox listBoxStores;
        private Label label4;
        private Button buttonRefreshAudioListStore;
        private ComboBox comboBoxStore;
        private Button buttonSelectAll;
        private Button buttonUnselectAll;
    }
}
#endregion