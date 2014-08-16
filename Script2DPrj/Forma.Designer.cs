namespace Script2D
{
    partial class Forma
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
            this.ivestis = new System.Windows.Forms.RichTextBox();
            this.isvestis = new System.Windows.Forms.RichTextBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vykdymasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.išeitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xy_ak = new System.Windows.Forms.Label();
            this.xy_ad = new System.Windows.Forms.Label();
            this.xy_vk = new System.Windows.Forms.Label();
            this.xy_vd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ivestis
            // 
            this.ivestis.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ivestis.Location = new System.Drawing.Point(12, 569);
            this.ivestis.Name = "ivestis";
            this.ivestis.Size = new System.Drawing.Size(475, 61);
            this.ivestis.TabIndex = 2;
            this.ivestis.Text = "";
            // 
            // isvestis
            // 
            this.isvestis.BackColor = System.Drawing.SystemColors.Info;
            this.isvestis.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.isvestis.Location = new System.Drawing.Point(12, 400);
            this.isvestis.Name = "isvestis";
            this.isvestis.Size = new System.Drawing.Size(475, 163);
            this.isvestis.TabIndex = 3;
            this.isvestis.Text = "";
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(29, 46);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(440, 330);
            this.pb.TabIndex = 4;
            this.pb.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vykdymasToolStripMenuItem,
            this.informacijaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(498, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vykdymasToolStripMenuItem
            // 
            this.vykdymasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.išeitiToolStripMenuItem});
            this.vykdymasToolStripMenuItem.Name = "vykdymasToolStripMenuItem";
            this.vykdymasToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.vykdymasToolStripMenuItem.Text = "Vykdymas";
            // 
            // išeitiToolStripMenuItem
            // 
            this.išeitiToolStripMenuItem.Name = "išeitiToolStripMenuItem";
            this.išeitiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.išeitiToolStripMenuItem.Text = "Išeiti";
            this.išeitiToolStripMenuItem.Click += new System.EventHandler(this.išeitiToolStripMenuItem_Click);
            // 
            // informacijaToolStripMenuItem
            // 
            this.informacijaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apieToolStripMenuItem});
            this.informacijaToolStripMenuItem.Name = "informacijaToolStripMenuItem";
            this.informacijaToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.informacijaToolStripMenuItem.Text = "Informacija";
            // 
            // apieToolStripMenuItem
            // 
            this.apieToolStripMenuItem.Name = "apieToolStripMenuItem";
            this.apieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.apieToolStripMenuItem.Text = "Apie";
            this.apieToolStripMenuItem.Click += new System.EventHandler(this.apieToolStripMenuItem_Click);
            // 
            // xy_ak
            // 
            this.xy_ak.AutoSize = true;
            this.xy_ak.Location = new System.Drawing.Point(26, 379);
            this.xy_ak.Name = "xy_ak";
            this.xy_ak.Size = new System.Drawing.Size(31, 13);
            this.xy_ak.TabIndex = 6;
            this.xy_ak.Text = "(0, 0)";
            // 
            // xy_ad
            // 
            this.xy_ad.AutoSize = true;
            this.xy_ad.Location = new System.Drawing.Point(426, 379);
            this.xy_ad.Name = "xy_ad";
            this.xy_ad.Size = new System.Drawing.Size(43, 13);
            this.xy_ad.TabIndex = 7;
            this.xy_ad.Text = "(440, 0)";
            // 
            // xy_vk
            // 
            this.xy_vk.AutoSize = true;
            this.xy_vk.Location = new System.Drawing.Point(26, 30);
            this.xy_vk.Name = "xy_vk";
            this.xy_vk.Size = new System.Drawing.Size(43, 13);
            this.xy_vk.TabIndex = 8;
            this.xy_vk.Text = "(0, 330)";
            // 
            // xy_vd
            // 
            this.xy_vd.AutoSize = true;
            this.xy_vd.Location = new System.Drawing.Point(414, 30);
            this.xy_vd.Name = "xy_vd";
            this.xy_vd.Size = new System.Drawing.Size(55, 13);
            this.xy_vd.TabIndex = 9;
            this.xy_vd.Text = "(440, 330)";
            // 
            // Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 642);
            this.Controls.Add(this.xy_vd);
            this.Controls.Add(this.xy_vk);
            this.Controls.Add(this.xy_ad);
            this.Controls.Add(this.xy_ak);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.isvestis);
            this.Controls.Add(this.ivestis);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Forma";
            this.Text = "Script2D IDE";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ivestis;
        private System.Windows.Forms.RichTextBox isvestis;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vykdymasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem išeitiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informacijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apieToolStripMenuItem;
        private System.Windows.Forms.Label xy_ak;
        private System.Windows.Forms.Label xy_ad;
        private System.Windows.Forms.Label xy_vk;
        private System.Windows.Forms.Label xy_vd;
    }
}

