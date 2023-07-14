namespace WinFormsAppMusicStore
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
            panel3 = new Panel();
            buttonCommitToServer = new Button();
            panel2 = new Panel();
            buttonPullFromServer = new Button();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            buttonAdd = new Button();
            buttonRemove = new Button();
            buttonRemoveAll = new Button();
            panel4 = new Panel();
            panel5 = new Panel();
            tableLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxAudio
            // 
            listBoxAudio.Dock = DockStyle.Fill;
            listBoxAudio.Font = new Font("Roboto Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxAudio.FormattingEnabled = true;
            listBoxAudio.ItemHeight = 19;
            listBoxAudio.Location = new Point(3, 27);
            listBoxAudio.Name = "listBoxAudio";
            listBoxAudio.ScrollAlwaysVisible = true;
            listBoxAudio.Size = new Size(973, 498);
            listBoxAudio.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 531);
            panel1.Name = "panel1";
            panel1.Size = new Size(973, 44);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonCommitToServer);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(929, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(42, 42);
            panel3.TabIndex = 22;
            // 
            // buttonCommitToServer
            // 
            buttonCommitToServer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCommitToServer.BackColor = Color.White;
            buttonCommitToServer.FlatStyle = FlatStyle.Flat;
            buttonCommitToServer.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCommitToServer.ForeColor = Color.Black;
            buttonCommitToServer.Image = Properties.Resources.save;
            buttonCommitToServer.Location = new Point(3, 3);
            buttonCommitToServer.Name = "buttonCommitToServer";
            buttonCommitToServer.Size = new Size(36, 36);
            buttonCommitToServer.TabIndex = 20;
            buttonCommitToServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonCommitToServer.UseVisualStyleBackColor = false;
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
            panel2.Name = "panel2";
            panel2.Size = new Size(365, 42);
            panel2.TabIndex = 21;
            // 
            // buttonPullFromServer
            // 
            buttonPullFromServer.BackColor = Color.White;
            buttonPullFromServer.FlatStyle = FlatStyle.Flat;
            buttonPullFromServer.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPullFromServer.ForeColor = Color.RoyalBlue;
            buttonPullFromServer.Image = Properties.Resources.replicaDown;
            buttonPullFromServer.Location = new Point(3, 3);
            buttonPullFromServer.Name = "buttonPullFromServer";
            buttonPullFromServer.Size = new Size(36, 36);
            buttonPullFromServer.TabIndex = 20;
            buttonPullFromServer.TextAlign = ContentAlignment.MiddleLeft;
            buttonPullFromServer.UseVisualStyleBackColor = false;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.BackColor = Color.White;
            buttonMoveDown.FlatStyle = FlatStyle.Flat;
            buttonMoveDown.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveDown.ForeColor = Color.Black;
            buttonMoveDown.Image = Properties.Resources.downArrow;
            buttonMoveDown.Location = new Point(156, 3);
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
            buttonMoveUp.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveUp.ForeColor = Color.Black;
            buttonMoveUp.Image = Properties.Resources.upArrow;
            buttonMoveUp.Location = new Point(198, 3);
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
            buttonAdd.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.ForeColor = Color.FromArgb(213, 88, 13);
            buttonAdd.Image = Properties.Resources.upload;
            buttonAdd.Location = new Point(324, 3);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(36, 36);
            buttonAdd.TabIndex = 19;
            buttonAdd.TextAlign = ContentAlignment.MiddleLeft;
            buttonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = Color.White;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemove.ForeColor = Color.Red;
            buttonRemove.Image = Properties.Resources.erase;
            buttonRemove.Location = new Point(240, 3);
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
            buttonRemoveAll.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRemoveAll.ForeColor = Color.FromArgb(41, 10, 10);
            buttonRemoveAll.Image = Properties.Resources.eraseAll;
            buttonRemoveAll.Location = new Point(282, 3);
            buttonRemoveAll.Name = "buttonRemoveAll";
            buttonRemoveAll.Size = new Size(36, 36);
            buttonRemoveAll.TabIndex = 18;
            buttonRemoveAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonRemoveAll.UseVisualStyleBackColor = false;
            buttonRemoveAll.Click += buttonRemoveAll_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Blue;
            panel4.Controls.Add(panel5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(999, 598);
            panel4.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(tableLayoutPanel);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(10, 10);
            panel5.Name = "panel5";
            panel5.Size = new Size(979, 578);
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
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(979, 578);
            tableLayoutPanel.TabIndex = 3;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(973, 24);
            label1.TabIndex = 2;
            label1.Text = "EDICION LISTA AUDIO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlMusic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Name = "UserControlMusic";
            Size = new Size(999, 598);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxAudio;
        private Panel panel1;
        private Button buttonMoveDown;
        private Button buttonMoveUp;
        private Button buttonRemove;
        private Button buttonAdd;
        private Button buttonRemoveAll;
        private Button buttonCommitToServer;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel;
        private Button buttonPullFromServer;
    }
}
