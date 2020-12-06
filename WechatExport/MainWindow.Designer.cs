namespace WechatExport
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iphoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.androidMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huaweiDataDecryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.androidwechatBackupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeRegMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iphoneMenuItem,
            this.androidMenuItem,
            this.toolsMenuItem,
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iphoneMenuItem
            // 
            this.iphoneMenuItem.Name = "iphoneMenuItem";
            this.iphoneMenuItem.Size = new System.Drawing.Size(158, 28);
            this.iphoneMenuItem.Text = "iphone数据恢复";
            this.iphoneMenuItem.Click += new System.EventHandler(this.iphoneMenuItem_Click);
            // 
            // androidMenuItem
            // 
            this.androidMenuItem.Name = "androidMenuItem";
            this.androidMenuItem.Size = new System.Drawing.Size(169, 28);
            this.androidMenuItem.Text = "Android数据恢复";
            this.androidMenuItem.Click += new System.EventHandler(this.androidMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huaweiDataDecryptMenuItem,
            this.androidwechatBackupMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(134, 28);
            this.toolsMenuItem.Text = "数据备份工具";
            // 
            // huaweiDataDecryptMenuItem
            // 
            this.huaweiDataDecryptMenuItem.Name = "huaweiDataDecryptMenuItem";
            this.huaweiDataDecryptMenuItem.Size = new System.Drawing.Size(254, 34);
            this.huaweiDataDecryptMenuItem.Text = "华为备份数据解密";
            this.huaweiDataDecryptMenuItem.Click += new System.EventHandler(this.huaweiDataDecryptMenuItem_Click);
            // 
            // androidwechatBackupMenuItem
            // 
            this.androidwechatBackupMenuItem.Name = "androidwechatBackupMenuItem";
            this.androidwechatBackupMenuItem.Size = new System.Drawing.Size(254, 34);
            this.androidwechatBackupMenuItem.Text = "android微信备份";
            this.androidwechatBackupMenuItem.Visible = false;
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerMenuItem,
            this.removeRegMenuItem,
            this.infoMenuItem});
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(62, 28);
            this.aboutMenuItem.Text = "帮助";
            // 
            // registerMenuItem
            // 
            this.registerMenuItem.Name = "registerMenuItem";
            this.registerMenuItem.Size = new System.Drawing.Size(270, 34);
            this.registerMenuItem.Text = "注册";
            this.registerMenuItem.Click += new System.EventHandler(this.registerMenuItem_Click);
            // 
            // removeRegMenuItem
            // 
            this.removeRegMenuItem.Name = "removeRegMenuItem";
            this.removeRegMenuItem.Size = new System.Drawing.Size(270, 34);
            this.removeRegMenuItem.Text = "取消注册";
            this.removeRegMenuItem.Click += new System.EventHandler(this.removeRegMenuItem_Click);
            // 
            // infoMenuItem
            // 
            this.infoMenuItem.Name = "infoMenuItem";
            this.infoMenuItem.Size = new System.Drawing.Size(270, 34);
            this.infoMenuItem.Text = "软件介绍";
            this.infoMenuItem.Click += new System.EventHandler(this.infoMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Location = new System.Drawing.Point(0, 34);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 742);
            this.mainPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 774);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "微信恢复大师";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huaweiDataDecryptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem androidwechatBackupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem removeRegMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iphoneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem androidMenuItem;
    }
}