namespace WinFormsAppMusicStore
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
            panel1 = new Panel();
            buttonUser = new Button();
            buttonStore = new Button();
            buttonRegister = new Button();
            buttonPlayer = new Button();
            buttonClose = new Button();
            buttonMusic = new Button();
            pictureBox1 = new PictureBox();
            panel6 = new Panel();
            panelChildForm = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            richTextBoxStatusMessages = new RichTextBox();
            panel3 = new Panel();
            label1 = new Label();
            splitContainer = new SplitContainer();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(buttonUser);
            panel1.Controls.Add(buttonStore);
            panel1.Controls.Add(buttonRegister);
            panel1.Controls.Add(buttonPlayer);
            panel1.Controls.Add(buttonClose);
            panel1.Controls.Add(buttonMusic);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 753);
            panel1.TabIndex = 1;
            // 
            // buttonUser
            // 
            buttonUser.BackColor = Color.RoyalBlue;
            buttonUser.Dock = DockStyle.Top;
            buttonUser.FlatAppearance.BorderSize = 0;
            buttonUser.FlatStyle = FlatStyle.Flat;
            buttonUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUser.ForeColor = Color.White;
            buttonUser.ImageAlign = ContentAlignment.MiddleRight;
            buttonUser.Location = new Point(0, 330);
            buttonUser.Name = "buttonUser";
            buttonUser.Size = new Size(200, 46);
            buttonUser.TabIndex = 8;
            buttonUser.Text = "USUARIO";
            buttonUser.TextAlign = ContentAlignment.MiddleLeft;
            buttonUser.UseVisualStyleBackColor = false;
            buttonUser.Click += buttonUser_Click;
            // 
            // buttonStore
            // 
            buttonStore.BackColor = Color.RoyalBlue;
            buttonStore.Dock = DockStyle.Top;
            buttonStore.FlatAppearance.BorderSize = 0;
            buttonStore.FlatStyle = FlatStyle.Flat;
            buttonStore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStore.ForeColor = Color.White;
            buttonStore.ImageAlign = ContentAlignment.MiddleRight;
            buttonStore.Location = new Point(0, 284);
            buttonStore.Name = "buttonStore";
            buttonStore.Size = new Size(200, 46);
            buttonStore.TabIndex = 10;
            buttonStore.Text = "TIENDAS";
            buttonStore.TextAlign = ContentAlignment.MiddleLeft;
            buttonStore.UseVisualStyleBackColor = false;
            buttonStore.Click += buttonStore_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.RoyalBlue;
            buttonRegister.Dock = DockStyle.Top;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.ImageAlign = ContentAlignment.MiddleRight;
            buttonRegister.Location = new Point(0, 238);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(200, 46);
            buttonRegister.TabIndex = 5;
            buttonRegister.Text = "REGISTROS";
            buttonRegister.TextAlign = ContentAlignment.MiddleLeft;
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonPlayer
            // 
            buttonPlayer.BackColor = Color.RoyalBlue;
            buttonPlayer.Dock = DockStyle.Top;
            buttonPlayer.FlatAppearance.BorderSize = 0;
            buttonPlayer.FlatStyle = FlatStyle.Flat;
            buttonPlayer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPlayer.ForeColor = Color.White;
            buttonPlayer.ImageAlign = ContentAlignment.MiddleRight;
            buttonPlayer.Location = new Point(0, 192);
            buttonPlayer.Name = "buttonPlayer";
            buttonPlayer.Size = new Size(200, 46);
            buttonPlayer.TabIndex = 9;
            buttonPlayer.Text = "REPRODUCTOR";
            buttonPlayer.TextAlign = ContentAlignment.MiddleLeft;
            buttonPlayer.UseVisualStyleBackColor = false;
            buttonPlayer.Click += buttonPlayer_Click;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.Crimson;
            buttonClose.Dock = DockStyle.Bottom;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.ForeColor = Color.White;
            buttonClose.Image = Properties.Resources.close;
            buttonClose.ImageAlign = ContentAlignment.MiddleRight;
            buttonClose.Location = new Point(0, 693);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(200, 60);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "SALIR";
            buttonClose.TextAlign = ContentAlignment.MiddleLeft;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonMusic
            // 
            buttonMusic.BackColor = Color.RoyalBlue;
            buttonMusic.Dock = DockStyle.Top;
            buttonMusic.FlatAppearance.BorderSize = 0;
            buttonMusic.FlatStyle = FlatStyle.Flat;
            buttonMusic.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMusic.ForeColor = Color.White;
            buttonMusic.ImageAlign = ContentAlignment.MiddleRight;
            buttonMusic.Location = new Point(0, 146);
            buttonMusic.Name = "buttonMusic";
            buttonMusic.Size = new Size(200, 46);
            buttonMusic.TabIndex = 1;
            buttonMusic.Text = "MUSICA";
            buttonMusic.TextAlign = ContentAlignment.MiddleLeft;
            buttonMusic.UseVisualStyleBackColor = false;
            buttonMusic.Click += buttonMusic_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.logoMundoTotal;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(panelChildForm);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(980, 684);
            panel6.TabIndex = 2;
            // 
            // panelChildForm
            // 
            panelChildForm.Dock = DockStyle.Fill;
            panelChildForm.Location = new Point(0, 0);
            panelChildForm.Name = "panelChildForm";
            panelChildForm.Size = new Size(980, 684);
            panelChildForm.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(980, 59);
            panel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(richTextBoxStatusMessages);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(118, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(862, 59);
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
            richTextBoxStatusMessages.Size = new Size(862, 59);
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
            panel3.Size = new Size(118, 59);
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
            splitContainer.Location = new Point(200, 0);
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
            splitContainer.Size = new Size(982, 753);
            splitContainer.SplitterDistance = 686;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 3;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 753);
            Controls.Add(splitContainer);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Store";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonUser;
        private Button buttonRegister;
        private Button buttonPlayer;
        private Button buttonClose;
        private Button buttonMusic;
        private PictureBox pictureBox1;
        private Panel panel6;
        private Panel panelChildForm;
        private Panel panel2;
        private Panel panel5;
        private RichTextBox richTextBoxStatusMessages;
        private Panel panel3;
        private Label label1;
        private SplitContainer splitContainer;
        private Button buttonStore;
    }
}