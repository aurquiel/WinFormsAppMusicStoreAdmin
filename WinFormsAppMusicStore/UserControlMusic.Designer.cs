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
            listBoxAudio = new ListBox();
            panel1 = new Panel();
            panel2 = new Panel();
            buttonPullFromServer = new Button();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            buttonAdd = new Button();
            buttonRemove = new Button();
            buttonRemoveAll = new Button();
            buttonPushToServer = new Button();
            panel4 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxAudio
            // 
            listBoxAudio.Dock = DockStyle.Fill;
            listBoxAudio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxAudio.FormattingEnabled = true;
            listBoxAudio.ItemHeight = 25;
            listBoxAudio.Location = new Point(3, 36);
            listBoxAudio.Margin = new Padding(3, 4, 3, 4);
            listBoxAudio.Name = "listBoxAudio";
            listBoxAudio.ScrollAlwaysVisible = true;
            listBoxAudio.Size = new Size(1126, 689);
            listBoxAudio.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(buttonPushToServer);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 733);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1126, 50);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonPullFromServer);
            panel2.Controls.Add(buttonMoveDown);
            panel2.Controls.Add(buttonMoveUp);
            panel2.Controls.Add(buttonAdd);
            panel2.Controls.Add(buttonRemove);
            panel2.Controls.Add(buttonRemoveAll);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 48);
            panel2.TabIndex = 21;
            // 
            // buttonPullFromServer
            // 
            buttonPullFromServer.BackColor = Color.White;
            buttonPullFromServer.FlatStyle = FlatStyle.Flat;
            buttonPullFromServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPullFromServer.ForeColor = Color.RoyalBlue;
            buttonPullFromServer.Image = Properties.Resources.replicaDown;
            buttonPullFromServer.Location = new Point(3, 4);
            buttonPullFromServer.Margin = new Padding(3, 4, 3, 4);
            buttonPullFromServer.Name = "buttonPullFromServer";
            buttonPullFromServer.Size = new Size(36, 36);
            buttonPullFromServer.TabIndex = 21;
            buttonPullFromServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonPullFromServer.UseVisualStyleBackColor = false;
            buttonPullFromServer.Click += buttonPullFromServer_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.BackColor = Color.White;
            buttonMoveDown.FlatStyle = FlatStyle.Flat;
            buttonMoveDown.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveDown.ForeColor = Color.Black;
            buttonMoveDown.Image = Properties.Resources.downArrow;
            buttonMoveDown.Location = new Point(45, 4);
            buttonMoveDown.Margin = new Padding(3, 4, 3, 4);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(36, 36);
            buttonMoveDown.TabIndex = 15;
            buttonMoveDown.TextAlign = ContentAlignment.MiddleLeft;
            buttonMoveDown.UseVisualStyleBackColor = false;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.BackColor = Color.White;
            buttonMoveUp.FlatStyle = FlatStyle.Flat;
            buttonMoveUp.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveUp.ForeColor = Color.Black;
            buttonMoveUp.Image = Properties.Resources.upArrow;
            buttonMoveUp.Location = new Point(87, 4);
            buttonMoveUp.Margin = new Padding(3, 4, 3, 4);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(36, 36);
            buttonMoveUp.TabIndex = 16;
            buttonMoveUp.TextAlign = ContentAlignment.MiddleLeft;
            buttonMoveUp.UseVisualStyleBackColor = false;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.White;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.ForeColor = Color.ForestGreen;
            buttonAdd.Image = Properties.Resources.add;
            buttonAdd.Location = new Point(213, 4);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(36, 36);
            buttonAdd.TabIndex = 19;
            buttonAdd.TextAlign = ContentAlignment.MiddleLeft;
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = Color.White;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemove.ForeColor = Color.Red;
            buttonRemove.Image = Properties.Resources.erase;
            buttonRemove.Location = new Point(129, 4);
            buttonRemove.Margin = new Padding(3, 4, 3, 4);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(36, 36);
            buttonRemove.TabIndex = 17;
            buttonRemove.TextAlign = ContentAlignment.MiddleLeft;
            buttonRemove.UseVisualStyleBackColor = false;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonRemoveAll
            // 
            buttonRemoveAll.BackColor = Color.White;
            buttonRemoveAll.FlatStyle = FlatStyle.Flat;
            buttonRemoveAll.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveAll.ForeColor = Color.FromArgb(41, 10, 10);
            buttonRemoveAll.Image = Properties.Resources.eraseAll;
            buttonRemoveAll.Location = new Point(171, 4);
            buttonRemoveAll.Margin = new Padding(3, 4, 3, 4);
            buttonRemoveAll.Name = "buttonRemoveAll";
            buttonRemoveAll.Size = new Size(36, 36);
            buttonRemoveAll.TabIndex = 18;
            buttonRemoveAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonRemoveAll.UseVisualStyleBackColor = false;
            buttonRemoveAll.Click += buttonRemoveAll_Click;
            // 
            // buttonPushToServer
            // 
            buttonPushToServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPushToServer.BackColor = Color.White;
            buttonPushToServer.FlatStyle = FlatStyle.Flat;
            buttonPushToServer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPushToServer.ForeColor = Color.DarkOrange;
            buttonPushToServer.Image = Properties.Resources.upload;
            buttonPushToServer.Location = new Point(1085, 4);
            buttonPushToServer.Margin = new Padding(3, 4, 3, 4);
            buttonPushToServer.Name = "buttonPushToServer";
            buttonPushToServer.Size = new Size(36, 36);
            buttonPushToServer.TabIndex = 21;
            buttonPushToServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonPushToServer.UseVisualStyleBackColor = false;
            buttonPushToServer.Click += buttonPushToServer_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Blue;
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(1142, 797);
            panel4.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(tableLayoutPanel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(5, 5);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(1132, 787);
            panel5.TabIndex = 3;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(label1, 0, 0);
            tableLayoutPanel.Controls.Add(panel1, 0, 2);
            tableLayoutPanel.Controls.Add(listBoxAudio, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel.Size = new Size(1132, 787);
            tableLayoutPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1126, 32);
            label1.TabIndex = 2;
            label1.Text = "EDICION LISTA AUDIO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlMusic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserControlMusic";
            Size = new Size(1142, 797);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxAudio;
        private Panel panel1;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panel2;
        private Button buttonPullFromServer;
        private Button buttonMoveDown;
        private Button buttonMoveUp;
        private Button buttonAdd;
        private Button buttonRemove;
        private Button buttonRemoveAll;
        private Button buttonPushToServer;
    }
}
