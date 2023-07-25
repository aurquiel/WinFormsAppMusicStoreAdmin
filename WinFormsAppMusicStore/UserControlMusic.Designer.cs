namespace WinFormsAppMusicStoreAdmin
{
    partial class UserControlMusic
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
            buttonSelectAll = new Button();
            buttonUnselectAll = new Button();
            buttonSynchronizeAllStores = new Button();
            buttonPullAudioListFromServer = new Button();
            buttonAddAudiosToServer = new Button();
            buttonRemoveAudioFromServer = new Button();
            listBoxAudioListServer = new ListBox();
            panel8 = new Panel();
            buttonAddAudioToAudioListStore = new Button();
            tableLayoutPanel6 = new TableLayoutPanel();
            panel9 = new Panel();
            buttonRefreshListStore = new Button();
            comboBoxStore = new ComboBox();
            buttonUploadAudioListStore = new Button();
            buttonMoveDownAudioListStore = new Button();
            buttonMoveUpAudioListStore = new Button();
            buttonDeleteAudioAudioListStore = new Button();
            buttonDeleteAllAudioAudioListStore = new Button();
            listBoxAudioListStore = new ListBox();
            labelAudioListStoreCode = new Label();
            label4 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
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
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Controls.Add(panel8, 1, 0);
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
            tableLayoutPanel5.Controls.Add(listBoxAudioListServer, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(4, 4);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel5.Size = new Size(454, 559);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(buttonSelectAll);
            panel7.Controls.Add(buttonUnselectAll);
            panel7.Controls.Add(buttonSynchronizeAllStores);
            panel7.Controls.Add(buttonPullAudioListFromServer);
            panel7.Controls.Add(buttonAddAudiosToServer);
            panel7.Controls.Add(buttonRemoveAudioFromServer);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 522);
            panel7.Name = "panel7";
            panel7.Size = new Size(448, 34);
            panel7.TabIndex = 22;
            // 
            // buttonSelectAll
            // 
            buttonSelectAll.BackColor = Color.White;
            buttonSelectAll.FlatStyle = FlatStyle.Flat;
            buttonSelectAll.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSelectAll.ForeColor = Color.Black;
            buttonSelectAll.Image = Properties.Resources.selectAll;
            buttonSelectAll.Location = new Point(117, 3);
            buttonSelectAll.Name = "buttonSelectAll";
            buttonSelectAll.Size = new Size(32, 27);
            buttonSelectAll.TabIndex = 24;
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
            buttonUnselectAll.Location = new Point(79, 3);
            buttonUnselectAll.Name = "buttonUnselectAll";
            buttonUnselectAll.Size = new Size(32, 27);
            buttonUnselectAll.TabIndex = 23;
            buttonUnselectAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonUnselectAll.UseVisualStyleBackColor = false;
            buttonUnselectAll.Click += buttonUnselectAll_Click;
            // 
            // buttonSynchronizeAllStores
            // 
            buttonSynchronizeAllStores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSynchronizeAllStores.BackColor = Color.White;
            buttonSynchronizeAllStores.FlatStyle = FlatStyle.Flat;
            buttonSynchronizeAllStores.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSynchronizeAllStores.ForeColor = Color.Blue;
            buttonSynchronizeAllStores.Image = Properties.Resources.synchronizeAllStores;
            buttonSynchronizeAllStores.Location = new Point(413, 3);
            buttonSynchronizeAllStores.Name = "buttonSynchronizeAllStores";
            buttonSynchronizeAllStores.Size = new Size(32, 27);
            buttonSynchronizeAllStores.TabIndex = 22;
            buttonSynchronizeAllStores.TextAlign = ContentAlignment.MiddleLeft;
            buttonSynchronizeAllStores.UseVisualStyleBackColor = false;
            buttonSynchronizeAllStores.Click += buttonSynchronizeAllStores_Click;
            // 
            // buttonPullAudioListFromServer
            // 
            buttonPullAudioListFromServer.BackColor = Color.White;
            buttonPullAudioListFromServer.FlatStyle = FlatStyle.Flat;
            buttonPullAudioListFromServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPullAudioListFromServer.ForeColor = Color.RoyalBlue;
            buttonPullAudioListFromServer.Image = Properties.Resources.replicaDown;
            buttonPullAudioListFromServer.Location = new Point(3, 3);
            buttonPullAudioListFromServer.Name = "buttonPullAudioListFromServer";
            buttonPullAudioListFromServer.Size = new Size(32, 27);
            buttonPullAudioListFromServer.TabIndex = 21;
            buttonPullAudioListFromServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonPullAudioListFromServer.UseVisualStyleBackColor = false;
            buttonPullAudioListFromServer.Click += buttonPullAudioFromServer_Click;
            // 
            // buttonAddAudiosToServer
            // 
            buttonAddAudiosToServer.BackColor = Color.White;
            buttonAddAudiosToServer.FlatStyle = FlatStyle.Flat;
            buttonAddAudiosToServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddAudiosToServer.ForeColor = Color.ForestGreen;
            buttonAddAudiosToServer.Image = Properties.Resources.add;
            buttonAddAudiosToServer.Location = new Point(155, 3);
            buttonAddAudiosToServer.Name = "buttonAddAudiosToServer";
            buttonAddAudiosToServer.Size = new Size(32, 27);
            buttonAddAudiosToServer.TabIndex = 19;
            buttonAddAudiosToServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddAudiosToServer.UseVisualStyleBackColor = false;
            buttonAddAudiosToServer.Click += buttonAddAudiosToServer_Click;
            // 
            // buttonRemoveAudioFromServer
            // 
            buttonRemoveAudioFromServer.BackColor = Color.White;
            buttonRemoveAudioFromServer.FlatStyle = FlatStyle.Flat;
            buttonRemoveAudioFromServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveAudioFromServer.ForeColor = Color.Red;
            buttonRemoveAudioFromServer.Image = Properties.Resources.erase;
            buttonRemoveAudioFromServer.Location = new Point(41, 3);
            buttonRemoveAudioFromServer.Name = "buttonRemoveAudioFromServer";
            buttonRemoveAudioFromServer.Size = new Size(32, 27);
            buttonRemoveAudioFromServer.TabIndex = 17;
            buttonRemoveAudioFromServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonRemoveAudioFromServer.UseVisualStyleBackColor = false;
            buttonRemoveAudioFromServer.Click += buttonRemoveAudioFromServer_Click;
            // 
            // listBoxAudioListServer
            // 
            listBoxAudioListServer.Dock = DockStyle.Fill;
            listBoxAudioListServer.FormattingEnabled = true;
            listBoxAudioListServer.ItemHeight = 20;
            listBoxAudioListServer.Location = new Point(3, 3);
            listBoxAudioListServer.Name = "listBoxAudioListServer";
            listBoxAudioListServer.SelectionMode = SelectionMode.MultiSimple;
            listBoxAudioListServer.Size = new Size(448, 513);
            listBoxAudioListServer.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(buttonAddAudioToAudioListStore);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(465, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(38, 559);
            panel8.TabIndex = 1;
            // 
            // buttonAddAudioToAudioListStore
            // 
            buttonAddAudioToAudioListStore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddAudioToAudioListStore.BackColor = Color.White;
            buttonAddAudioToAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonAddAudioToAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddAudioToAudioListStore.ForeColor = Color.Black;
            buttonAddAudioToAudioListStore.Image = Properties.Resources.selectAudio;
            buttonAddAudioToAudioListStore.Location = new Point(3, 3);
            buttonAddAudioToAudioListStore.Name = "buttonAddAudioToAudioListStore";
            buttonAddAudioToAudioListStore.Size = new Size(32, 27);
            buttonAddAudioToAudioListStore.TabIndex = 17;
            buttonAddAudioToAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddAudioToAudioListStore.UseVisualStyleBackColor = false;
            buttonAddAudioToAudioListStore.Click += buttonAddAudioToAudioListStore_Click;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(panel9, 0, 2);
            tableLayoutPanel6.Controls.Add(listBoxAudioListStore, 0, 0);
            tableLayoutPanel6.Controls.Add(labelAudioListStoreCode, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(510, 4);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel6.Size = new Size(454, 559);
            tableLayoutPanel6.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.Controls.Add(buttonRefreshListStore);
            panel9.Controls.Add(comboBoxStore);
            panel9.Controls.Add(buttonUploadAudioListStore);
            panel9.Controls.Add(buttonMoveDownAudioListStore);
            panel9.Controls.Add(buttonMoveUpAudioListStore);
            panel9.Controls.Add(buttonDeleteAudioAudioListStore);
            panel9.Controls.Add(buttonDeleteAllAudioAudioListStore);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 517);
            panel9.Name = "panel9";
            panel9.Size = new Size(448, 39);
            panel9.TabIndex = 23;
            // 
            // buttonRefreshListStore
            // 
            buttonRefreshListStore.BackColor = Color.White;
            buttonRefreshListStore.FlatStyle = FlatStyle.Flat;
            buttonRefreshListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRefreshListStore.ForeColor = Color.Blue;
            buttonRefreshListStore.Image = Properties.Resources.refreshListStore;
            buttonRefreshListStore.Location = new Point(94, 4);
            buttonRefreshListStore.Name = "buttonRefreshListStore";
            buttonRefreshListStore.Size = new Size(32, 27);
            buttonRefreshListStore.TabIndex = 23;
            buttonRefreshListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonRefreshListStore.UseVisualStyleBackColor = false;
            buttonRefreshListStore.Click += buttonRefreshListStore_Click;
            // 
            // comboBoxStore
            // 
            comboBoxStore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStore.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxStore.FormattingEnabled = true;
            comboBoxStore.Location = new Point(3, 6);
            comboBoxStore.Name = "comboBoxStore";
            comboBoxStore.Size = new Size(85, 25);
            comboBoxStore.TabIndex = 22;
            comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
            // 
            // buttonUploadAudioListStore
            // 
            buttonUploadAudioListStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUploadAudioListStore.BackColor = Color.White;
            buttonUploadAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonUploadAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUploadAudioListStore.ForeColor = Color.DarkOrange;
            buttonUploadAudioListStore.Image = Properties.Resources.upload;
            buttonUploadAudioListStore.Location = new Point(413, 4);
            buttonUploadAudioListStore.Name = "buttonUploadAudioListStore";
            buttonUploadAudioListStore.Size = new Size(32, 27);
            buttonUploadAudioListStore.TabIndex = 21;
            buttonUploadAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonUploadAudioListStore.UseVisualStyleBackColor = false;
            buttonUploadAudioListStore.Click += buttonUploadAudioListStore_Click;
            // 
            // buttonMoveDownAudioListStore
            // 
            buttonMoveDownAudioListStore.BackColor = Color.White;
            buttonMoveDownAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonMoveDownAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveDownAudioListStore.ForeColor = Color.Black;
            buttonMoveDownAudioListStore.Image = Properties.Resources.downArrow;
            buttonMoveDownAudioListStore.Location = new Point(132, 4);
            buttonMoveDownAudioListStore.Name = "buttonMoveDownAudioListStore";
            buttonMoveDownAudioListStore.Size = new Size(32, 27);
            buttonMoveDownAudioListStore.TabIndex = 15;
            buttonMoveDownAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonMoveDownAudioListStore.UseVisualStyleBackColor = false;
            buttonMoveDownAudioListStore.Click += buttonMoveDownAudioListStore_Click;
            // 
            // buttonMoveUpAudioListStore
            // 
            buttonMoveUpAudioListStore.BackColor = Color.White;
            buttonMoveUpAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonMoveUpAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveUpAudioListStore.ForeColor = Color.Black;
            buttonMoveUpAudioListStore.Image = Properties.Resources.upArrow;
            buttonMoveUpAudioListStore.Location = new Point(169, 4);
            buttonMoveUpAudioListStore.Name = "buttonMoveUpAudioListStore";
            buttonMoveUpAudioListStore.Size = new Size(32, 27);
            buttonMoveUpAudioListStore.TabIndex = 16;
            buttonMoveUpAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonMoveUpAudioListStore.UseVisualStyleBackColor = false;
            buttonMoveUpAudioListStore.Click += buttonMoveUpAudioListStore_Click;
            // 
            // buttonDeleteAudioAudioListStore
            // 
            buttonDeleteAudioAudioListStore.BackColor = Color.White;
            buttonDeleteAudioAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonDeleteAudioAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteAudioAudioListStore.ForeColor = Color.Red;
            buttonDeleteAudioAudioListStore.Image = Properties.Resources.erase;
            buttonDeleteAudioAudioListStore.Location = new Point(206, 4);
            buttonDeleteAudioAudioListStore.Name = "buttonDeleteAudioAudioListStore";
            buttonDeleteAudioAudioListStore.Size = new Size(32, 27);
            buttonDeleteAudioAudioListStore.TabIndex = 17;
            buttonDeleteAudioAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonDeleteAudioAudioListStore.UseVisualStyleBackColor = false;
            buttonDeleteAudioAudioListStore.Click += buttonDeleteAudioListStore_Click;
            // 
            // buttonDeleteAllAudioAudioListStore
            // 
            buttonDeleteAllAudioAudioListStore.BackColor = Color.White;
            buttonDeleteAllAudioAudioListStore.FlatStyle = FlatStyle.Flat;
            buttonDeleteAllAudioAudioListStore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteAllAudioAudioListStore.ForeColor = Color.FromArgb(41, 10, 10);
            buttonDeleteAllAudioAudioListStore.Image = Properties.Resources.eraseAll;
            buttonDeleteAllAudioAudioListStore.Location = new Point(243, 4);
            buttonDeleteAllAudioAudioListStore.Name = "buttonDeleteAllAudioAudioListStore";
            buttonDeleteAllAudioAudioListStore.Size = new Size(32, 27);
            buttonDeleteAllAudioAudioListStore.TabIndex = 18;
            buttonDeleteAllAudioAudioListStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonDeleteAllAudioAudioListStore.UseVisualStyleBackColor = false;
            buttonDeleteAllAudioAudioListStore.Click += buttonDeleteAllAudioListStore_Click;
            // 
            // listBoxAudioListStore
            // 
            listBoxAudioListStore.Dock = DockStyle.Fill;
            listBoxAudioListStore.FormattingEnabled = true;
            listBoxAudioListStore.ItemHeight = 20;
            listBoxAudioListStore.Location = new Point(3, 3);
            listBoxAudioListStore.Name = "listBoxAudioListStore";
            listBoxAudioListStore.Size = new Size(448, 468);
            listBoxAudioListStore.TabIndex = 1;
            // 
            // labelAudioListStoreCode
            // 
            labelAudioListStoreCode.BackColor = Color.WhiteSmoke;
            labelAudioListStoreCode.Dock = DockStyle.Fill;
            labelAudioListStoreCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelAudioListStoreCode.Location = new Point(3, 474);
            labelAudioListStoreCode.Name = "labelAudioListStoreCode";
            labelAudioListStoreCode.Size = new Size(448, 40);
            labelAudioListStoreCode.TabIndex = 2;
            labelAudioListStoreCode.Text = "LISTA DE AUDIO TIENDA: 0000";
            labelAudioListStoreCode.TextAlign = ContentAlignment.MiddleCenter;
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
            label4.Text = "EDICION LISTA REPRODUCCION";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlMusic
            // 
            Controls.Add(panel4);
            Name = "UserControlMusic";
            Size = new Size(982, 605);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
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
        private Button buttonPullAudioListFromServer;
        private Button buttonAddAudiosToServer;
        private Button buttonRemoveAudioFromServer;
        private ListBox listBoxAudioListServer;
        private Panel panel8;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel9;
        private ComboBox comboBoxStore;
        private Button buttonUploadAudioListStore;
        private Button buttonMoveDownAudioListStore;
        private Button buttonMoveUpAudioListStore;
        private Button buttonDeleteAudioAudioListStore;
        private Button buttonDeleteAllAudioAudioListStore;
        private ListBox listBoxAudioListStore;
        private Label labelAudioListStoreCode;
        private Label label4;
        private Button buttonAddAudioToAudioListStore;
        private Button buttonSynchronizeAllStores;
        private Button buttonUnselectAll;
        private Button buttonSelectAll;
        private Button buttonRefreshListStore;
    }
}
#endregion