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
            buttonCommit = new Button();
            panel2 = new Panel();
            button6 = new Button();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            buttonUpload = new Button();
            buttonDelete = new Button();
            buttonDeleteAll = new Button();
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
            panel3.Controls.Add(buttonCommit);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(929, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(42, 42);
            panel3.TabIndex = 22;
            // 
            // buttonCommit
            // 
            buttonCommit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCommit.BackColor = Color.White;
            buttonCommit.FlatStyle = FlatStyle.Flat;
            buttonCommit.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCommit.ForeColor = Color.Black;
            buttonCommit.Image = Properties.Resources.save;
            buttonCommit.Location = new Point(3, 3);
            buttonCommit.Name = "buttonCommit";
            buttonCommit.Size = new Size(36, 36);
            buttonCommit.TabIndex = 20;
            buttonCommit.TextAlign = ContentAlignment.MiddleLeft;
            buttonCommit.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(button6);
            panel2.Controls.Add(buttonMoveDown);
            panel2.Controls.Add(buttonMoveUp);
            panel2.Controls.Add(buttonUpload);
            panel2.Controls.Add(buttonDelete);
            panel2.Controls.Add(buttonDeleteAll);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 42);
            panel2.TabIndex = 21;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.RoyalBlue;
            button6.Image = Properties.Resources.replicaDown;
            button6.Location = new Point(3, 3);
            button6.Name = "button6";
            button6.Size = new Size(36, 36);
            button6.TabIndex = 20;
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.BackColor = Color.White;
            buttonMoveDown.FlatStyle = FlatStyle.Flat;
            buttonMoveDown.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMoveDown.ForeColor = Color.Black;
            buttonMoveDown.Image = Properties.Resources.downArrow;
            buttonMoveDown.Location = new Point(87, 3);
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
            buttonMoveUp.Location = new Point(129, 3);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(36, 36);
            buttonMoveUp.TabIndex = 16;
            buttonMoveUp.TextAlign = ContentAlignment.MiddleLeft;
            buttonMoveUp.UseVisualStyleBackColor = false;
            // 
            // buttonUpload
            // 
            buttonUpload.BackColor = Color.White;
            buttonUpload.FlatStyle = FlatStyle.Flat;
            buttonUpload.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpload.ForeColor = Color.FromArgb(213, 88, 13);
            buttonUpload.Image = Properties.Resources.upload;
            buttonUpload.Location = new Point(255, 3);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Size = new Size(36, 36);
            buttonUpload.TabIndex = 19;
            buttonUpload.TextAlign = ContentAlignment.MiddleLeft;
            buttonUpload.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.Red;
            buttonDelete.Image = Properties.Resources.erase;
            buttonDelete.Location = new Point(171, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(36, 36);
            buttonDelete.TabIndex = 17;
            buttonDelete.TextAlign = ContentAlignment.MiddleLeft;
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteAll
            // 
            buttonDeleteAll.BackColor = Color.White;
            buttonDeleteAll.FlatStyle = FlatStyle.Flat;
            buttonDeleteAll.Font = new Font("Roboto Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteAll.ForeColor = Color.FromArgb(41, 10, 10);
            buttonDeleteAll.Image = Properties.Resources.eraseAll;
            buttonDeleteAll.Location = new Point(213, 3);
            buttonDeleteAll.Name = "buttonDeleteAll";
            buttonDeleteAll.Size = new Size(36, 36);
            buttonDeleteAll.TabIndex = 18;
            buttonDeleteAll.TextAlign = ContentAlignment.MiddleLeft;
            buttonDeleteAll.UseVisualStyleBackColor = false;
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
        private Button buttonDelete;
        private Button buttonUpload;
        private Button buttonDeleteAll;
        private Button buttonCommit;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel;
        private Button button6;
    }
}
