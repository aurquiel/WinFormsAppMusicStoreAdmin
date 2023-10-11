namespace WinFormsAppMusicStoreAdmin
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panel6 = new Panel();
            panelChildForm = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            richTextBoxStatusMessages = new RichTextBox();
            panel3 = new Panel();
            label1 = new Label();
            splitContainer = new SplitContainer();
            panel1 = new Panel();
            panel7 = new Panel();
            panel4 = new Panel();
            menuStrip = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            musicaToolStripMenuItem = new ToolStripMenuItem();
            herramientasToolStripMenuItem = new ToolStripMenuItem();
            reproductorToolStripMenuItem = new ToolStripMenuItem();
            registrosToolStripMenuItem = new ToolStripMenuItem();
            tiendasToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Controls.Add(panelChildForm);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1440, 634);
            panel6.TabIndex = 2;
            // 
            // panelChildForm
            // 
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(0, 0);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Size = new Size(1440, 634);
            panelChildForm.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1440, 76);
            panel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(richTextBoxStatusMessages);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(118, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1322, 76);
            panel5.TabIndex = 4;
            // 
            // richTextBoxStatusMessages
            // 
            richTextBoxStatusMessages.BackColor = SystemColors.GradientActiveCaption;
            richTextBoxStatusMessages.Dock = DockStyle.Fill;
            richTextBoxStatusMessages.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBoxStatusMessages.Location = new Point(0, 0);
            richTextBoxStatusMessages.Name = "richTextBoxStatusMessages";
            richTextBoxStatusMessages.ReadOnly = true;
            richTextBoxStatusMessages.Size = new Size(1322, 76);
            richTextBoxStatusMessages.TabIndex = 0;
            richTextBoxStatusMessages.Text = "";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(118, 76);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 21);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 0;
            label1.Text = "ESTATUS:";
            // 
            // splitContainer
            // 
            splitContainer.BorderStyle = BorderStyle.FixedSingle;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel2;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panel6);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panel2);
            splitContainer.Panel2MinSize = 45;
            splitContainer.Size = new Size(1442, 720);
            splitContainer.SplitterDistance = 636;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1442, 753);
            panel1.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Controls.Add(splitContainer);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 33);
            panel7.Name = "panel7";
            panel7.Size = new Size(1442, 720);
            panel7.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(menuStrip);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1442, 33);
            panel4.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1442, 29);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { musicaToolStripMenuItem, herramientasToolStripMenuItem, reproductorToolStripMenuItem, registrosToolStripMenuItem, tiendasToolStripMenuItem, usuariosToolStripMenuItem, toolStripSeparator1, salirToolStripMenuItem });
            menuToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(62, 25);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // musicaToolStripMenuItem
            // 
            musicaToolStripMenuItem.Image = Properties.Resources.arrange;
            musicaToolStripMenuItem.Name = "musicaToolStripMenuItem";
            musicaToolStripMenuItem.Size = new Size(180, 26);
            musicaToolStripMenuItem.Text = "Musica";
            musicaToolStripMenuItem.Click += musicaToolStripMenuItem_Click;
            // 
            // herramientasToolStripMenuItem
            // 
            herramientasToolStripMenuItem.Image = Properties.Resources.tools;
            herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            herramientasToolStripMenuItem.Size = new Size(180, 26);
            herramientasToolStripMenuItem.Text = "Herramientas";
            herramientasToolStripMenuItem.Click += herramientasToolStripMenuItem_Click;
            // 
            // reproductorToolStripMenuItem
            // 
            reproductorToolStripMenuItem.Image = Properties.Resources.play;
            reproductorToolStripMenuItem.Name = "reproductorToolStripMenuItem";
            reproductorToolStripMenuItem.Size = new Size(180, 26);
            reproductorToolStripMenuItem.Text = "Reproductor";
            // 
            // registrosToolStripMenuItem
            // 
            registrosToolStripMenuItem.Image = Properties.Resources.registers;
            registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            registrosToolStripMenuItem.Size = new Size(180, 26);
            registrosToolStripMenuItem.Text = "Registros";
            registrosToolStripMenuItem.Click += registrosToolStripMenuItem_Click;
            // 
            // tiendasToolStripMenuItem
            // 
            tiendasToolStripMenuItem.Image = Properties.Resources.store;
            tiendasToolStripMenuItem.Name = "tiendasToolStripMenuItem";
            tiendasToolStripMenuItem.Size = new Size(180, 26);
            tiendasToolStripMenuItem.Text = "Tiendas";
            tiendasToolStripMenuItem.Click += tiendasToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Image = Properties.Resources.users;
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(180, 26);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Image = Properties.Resources.close;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1442, 753);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Store";
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel6;
        private Panel panelChildForm;
        private Panel panel2;
        private Panel panel5;
        private RichTextBox richTextBoxStatusMessages;
        private Panel panel3;
        private Label label1;
        private SplitContainer splitContainer;
        private Panel panel1;
        private Panel panel7;
        private Panel panel4;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem musicaToolStripMenuItem;
        private ToolStripMenuItem herramientasToolStripMenuItem;
        private ToolStripMenuItem reproductorToolStripMenuItem;
        private ToolStripMenuItem registrosToolStripMenuItem;
        private ToolStripMenuItem tiendasToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}