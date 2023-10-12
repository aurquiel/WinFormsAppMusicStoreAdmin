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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel4 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            panel6 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanelAudioList = new TableLayoutPanel();
            dataGridViewStore = new DataGridView();
            serverSelect = new DataGridViewCheckBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Order = new DataGridViewTextBoxColumn();
            serverAudioName = new DataGridViewTextBoxColumn();
            StoreId = new DataGridViewTextBoxColumn();
            serverPath = new DataGridViewTextBoxColumn();
            serverAudioDuration = new DataGridViewTextBoxColumn();
            serverAudioSize = new DataGridViewTextBoxColumn();
            checkForTime = new DataGridViewCheckBoxColumn();
            timeToPlay = new DataGridViewTextBoxColumn();
            labelStoreStadictics = new Label();
            panel7 = new Panel();
            buttonRefreshAudioListStore = new Button();
            comboBoxStore = new ComboBox();
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
            tableLayoutPanelAudioList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStore).BeginInit();
            panel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.Navy;
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
            tableLayoutPanel4.Controls.Add(tableLayoutPanelAudioList, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(968, 567);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // tableLayoutPanelAudioList
            // 
            tableLayoutPanelAudioList.ColumnCount = 1;
            tableLayoutPanelAudioList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelAudioList.Controls.Add(dataGridViewStore, 0, 0);
            tableLayoutPanelAudioList.Controls.Add(labelStoreStadictics, 0, 1);
            tableLayoutPanelAudioList.Controls.Add(panel7, 0, 2);
            tableLayoutPanelAudioList.Dock = DockStyle.Fill;
            tableLayoutPanelAudioList.Location = new Point(4, 4);
            tableLayoutPanelAudioList.Name = "tableLayoutPanelAudioList";
            tableLayoutPanelAudioList.RowCount = 3;
            tableLayoutPanelAudioList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelAudioList.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanelAudioList.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelAudioList.Size = new Size(476, 559);
            tableLayoutPanelAudioList.TabIndex = 0;
            // 
            // dataGridViewStore
            // 
            dataGridViewStore.AllowUserToAddRows = false;
            dataGridViewStore.AllowUserToDeleteRows = false;
            dataGridViewStore.AllowUserToResizeRows = false;
            dataGridViewStore.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewStore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStore.Columns.AddRange(new DataGridViewColumn[] { serverSelect, Id, Order, serverAudioName, StoreId, serverPath, serverAudioDuration, serverAudioSize, checkForTime, timeToPlay });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewStore.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewStore.Dock = DockStyle.Fill;
            dataGridViewStore.GridColor = Color.White;
            dataGridViewStore.Location = new Point(3, 3);
            dataGridViewStore.Name = "dataGridViewStore";
            dataGridViewStore.RowHeadersWidth = 51;
            dataGridViewStore.RowTemplate.Height = 25;
            dataGridViewStore.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStore.Size = new Size(470, 483);
            dataGridViewStore.TabIndex = 26;
            dataGridViewStore.SelectionChanged += dataGridViewStore_SelectionChanged;
            dataGridViewStore.Resize += dataGridViewStore_Resize;
            // 
            // serverSelect
            // 
            serverSelect.DataPropertyName = "select";
            serverSelect.HeaderText = "Seleccionar";
            serverSelect.MinimumWidth = 6;
            serverSelect.Name = "serverSelect";
            serverSelect.Visible = false;
            serverSelect.Width = 125;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Order
            // 
            Order.DataPropertyName = "Order";
            Order.HeaderText = "Orden";
            Order.MinimumWidth = 6;
            Order.Name = "Order";
            Order.ReadOnly = true;
            Order.Visible = false;
            Order.Width = 125;
            // 
            // serverAudioName
            // 
            serverAudioName.DataPropertyName = "name";
            serverAudioName.HeaderText = "Nombre";
            serverAudioName.MinimumWidth = 6;
            serverAudioName.Name = "serverAudioName";
            serverAudioName.ReadOnly = true;
            serverAudioName.Width = 200;
            // 
            // StoreId
            // 
            StoreId.DataPropertyName = "StoreId";
            StoreId.HeaderText = "Tienda Id";
            StoreId.MinimumWidth = 6;
            StoreId.Name = "StoreId";
            StoreId.ReadOnly = true;
            StoreId.Visible = false;
            StoreId.Width = 125;
            // 
            // serverPath
            // 
            serverPath.DataPropertyName = "path";
            serverPath.HeaderText = "Ruta";
            serverPath.MinimumWidth = 6;
            serverPath.Name = "serverPath";
            serverPath.ReadOnly = true;
            serverPath.Visible = false;
            serverPath.Width = 125;
            // 
            // serverAudioDuration
            // 
            serverAudioDuration.DataPropertyName = "duration";
            serverAudioDuration.HeaderText = "Duracion";
            serverAudioDuration.MinimumWidth = 6;
            serverAudioDuration.Name = "serverAudioDuration";
            serverAudioDuration.ReadOnly = true;
            serverAudioDuration.Width = 125;
            // 
            // serverAudioSize
            // 
            serverAudioSize.DataPropertyName = "size";
            serverAudioSize.HeaderText = "Peso Mb";
            serverAudioSize.MinimumWidth = 6;
            serverAudioSize.Name = "serverAudioSize";
            serverAudioSize.ReadOnly = true;
            serverAudioSize.Width = 125;
            // 
            // checkForTime
            // 
            checkForTime.DataPropertyName = "CheckForTime";
            checkForTime.HeaderText = "Tiempo";
            checkForTime.MinimumWidth = 6;
            checkForTime.Name = "checkForTime";
            checkForTime.ReadOnly = true;
            checkForTime.Width = 125;
            // 
            // timeToPlay
            // 
            timeToPlay.DataPropertyName = "TimeToPlay";
            timeToPlay.HeaderText = "Hora";
            timeToPlay.MinimumWidth = 6;
            timeToPlay.Name = "timeToPlay";
            timeToPlay.ReadOnly = true;
            timeToPlay.Width = 125;
            // 
            // labelStoreStadictics
            // 
            labelStoreStadictics.BackColor = Color.WhiteSmoke;
            labelStoreStadictics.Dock = DockStyle.Fill;
            labelStoreStadictics.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelStoreStadictics.Location = new Point(3, 489);
            labelStoreStadictics.Name = "labelStoreStadictics";
            labelStoreStadictics.Size = new Size(470, 25);
            labelStoreStadictics.TabIndex = 27;
            labelStoreStadictics.Text = "Lista Tienda: 0000; Audios: Peso Mb: Tiempo:";
            labelStoreStadictics.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.Controls.Add(buttonRefreshAudioListStore);
            panel7.Controls.Add(comboBoxStore);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 517);
            panel7.Name = "panel7";
            panel7.Size = new Size(470, 39);
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
            listBoxStores.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxStores.FormattingEnabled = true;
            listBoxStores.ItemHeight = 17;
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
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Navy;
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
            tableLayoutPanelAudioList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStore).EndInit();
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
        private TableLayoutPanel tableLayoutPanelAudioList;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel9;
        private Button buttonCopyAudioListToStores;
        private ListBox listBoxStores;
        private Label label4;
        private Button buttonRefreshAudioListStore;
        private ComboBox comboBoxStore;
        private Button buttonSelectAll;
        private Button buttonUnselectAll;
        private DataGridView dataGridViewStore;
        private Label labelStoreStadictics;
        private DataGridViewCheckBoxColumn serverSelect;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Order;
        private DataGridViewTextBoxColumn serverAudioName;
        private DataGridViewTextBoxColumn StoreId;
        private DataGridViewTextBoxColumn serverPath;
        private DataGridViewTextBoxColumn serverAudioDuration;
        private DataGridViewTextBoxColumn serverAudioSize;
        private DataGridViewCheckBoxColumn checkForTime;
        private DataGridViewTextBoxColumn timeToPlay;
    }
}
#endregion