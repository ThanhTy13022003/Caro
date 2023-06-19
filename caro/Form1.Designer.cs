namespace caro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlBanCo = new Panel();
            panel2 = new Panel();
            pctbAvatar = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            btnLan = new Button();
            txtIP = new TextBox();
            pctbKiHieu = new PictureBox();
            prcbDemNguoc = new ProgressBar();
            txtTenNguoiChoi = new TextBox();
            tmDemNguoc = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbKiHieu).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBanCo
            // 
            pnlBanCo.BackColor = SystemColors.Control;
            pnlBanCo.Location = new Point(12, 42);
            pnlBanCo.Name = "pnlBanCo";
            pnlBanCo.Size = new Size(811, 605);
            pnlBanCo.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(pctbAvatar);
            panel2.Location = new Point(853, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(471, 205);
            panel2.TabIndex = 1;
            // 
            // pctbAvatar
            // 
            pctbAvatar.BackColor = SystemColors.ActiveCaption;
            pctbAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            pctbAvatar.BorderStyle = BorderStyle.Fixed3D;
            pctbAvatar.Image = Properties.Resources.choi_co_caro_468;
            pctbAvatar.Location = new Point(0, 0);
            pctbAvatar.Name = "pctbAvatar";
            pctbAvatar.Size = new Size(471, 202);
            pctbAvatar.TabIndex = 0;
            pctbAvatar.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnLan);
            panel3.Controls.Add(txtIP);
            panel3.Controls.Add(pctbKiHieu);
            panel3.Controls.Add(prcbDemNguoc);
            panel3.Controls.Add(txtTenNguoiChoi);
            panel3.Location = new Point(853, 223);
            panel3.Name = "panel3";
            panel3.Size = new Size(610, 424);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(15, 222);
            label1.Name = "label1";
            label1.Size = new Size(532, 53);
            label1.TabIndex = 5;
            label1.Text = "5 hình trên 1 đường là thắng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLan
            // 
            btnLan.Location = new Point(18, 165);
            btnLan.Name = "btnLan";
            btnLan.Size = new Size(219, 29);
            btnLan.TabIndex = 4;
            btnLan.Text = "LAN";
            btnLan.UseVisualStyleBackColor = true;
            btnLan.Click += btnLan_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(18, 111);
            txtIP.Multiline = true;
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(219, 34);
            txtIP.TabIndex = 3;
            txtIP.Text = "127.0.0.1";
            // 
            // pctbKiHieu
            // 
            pctbKiHieu.BackColor = SystemColors.Control;
            pctbKiHieu.Location = new Point(331, 12);
            pctbKiHieu.Name = "pctbKiHieu";
            pctbKiHieu.Size = new Size(262, 182);
            pctbKiHieu.SizeMode = PictureBoxSizeMode.StretchImage;
            pctbKiHieu.TabIndex = 2;
            pctbKiHieu.TabStop = false;
            // 
            // prcbDemNguoc
            // 
            prcbDemNguoc.Location = new Point(18, 52);
            prcbDemNguoc.Name = "prcbDemNguoc";
            prcbDemNguoc.Size = new Size(219, 45);
            prcbDemNguoc.TabIndex = 1;
            prcbDemNguoc.Click += tmDemNguoc_Tick;
            // 
            // txtTenNguoiChoi
            // 
            txtTenNguoiChoi.Location = new Point(15, 12);
            txtTenNguoiChoi.Multiline = true;
            txtTenNguoiChoi.Name = "txtTenNguoiChoi";
            txtTenNguoiChoi.ReadOnly = true;
            txtTenNguoiChoi.Size = new Size(222, 34);
            txtTenNguoiChoi.TabIndex = 0;
            // 
            // tmDemNguoc
            // 
            tmDemNguoc.Tick += tmDemNguoc_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1475, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, toolStripMenuItem1 });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(60, 24);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGameToolStripMenuItem.Size = new Size(214, 26);
            newGameToolStripMenuItem.Text = "NewGame";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(214, 26);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.Q;
            toolStripMenuItem1.Size = new Size(214, 26);
            toolStripMenuItem1.Text = "Quit";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 673);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlBanCo);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Game Caro";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbKiHieu).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBanCo;
        private Panel panel2;
        private PictureBox pctbAvatar;
        private Panel panel3;
        private Label label1;
        private Button btnLan;
        private TextBox txtIP;
        private PictureBox pctbKiHieu;
        private ProgressBar prcbDemNguoc;
        private TextBox txtTenNguoiChoi;
        private System.Windows.Forms.Timer tmDemNguoc;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}