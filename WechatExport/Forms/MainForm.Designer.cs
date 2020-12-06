namespace WeChat
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBoxSkin1 = new WinForm.UI.Controls.CirclePictureBox();
            this.pictureBoxSkin2 = new WinForm.UI.Controls.CirclePictureBox();
            this.pictureBoxSkin3 = new WinForm.UI.Controls.CirclePictureBox();
            this.pictureBoxSkin4 = new WinForm.UI.Controls.CirclePictureBox();
            this.pbHead = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ContartList = new WinForm.UI.Controls.FListView();
            this.LastList = new WinForm.UI.Controls.FListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxSkin1 = new WinForm.UI.Controls.FTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.loadingView1 = new WinForm.UI.Controls.LoadingView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOpUser = new System.Windows.Forms.Label();
            this.MessageContext = new System.Windows.Forms.Panel();
            this.fListView1 = new WinForm.UI.Controls.FListView();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHead)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.MessageContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.pictureBoxSkin4);
            this.panel1.Controls.Add(this.pbHead);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 640);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBoxSkin1);
            this.panel5.Controls.Add(this.pictureBoxSkin2);
            this.panel5.Controls.Add(this.pictureBoxSkin3);
            this.panel5.Location = new System.Drawing.Point(0, 70);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(58, 171);
            this.panel5.TabIndex = 5;
            // 
            // pictureBoxSkin1
            // 
            this.pictureBoxSkin1.Image = global::WechatExport.Properties.Resources.img_last_tab_no;
            this.pictureBoxSkin1.IsSelected = false;
            this.pictureBoxSkin1.Location = new System.Drawing.Point(17, 15);
            this.pictureBoxSkin1.MouseMoveImage = null;
            this.pictureBoxSkin1.Name = "pictureBoxSkin1";
            this.pictureBoxSkin1.SelectedImage = global::WechatExport.Properties.Resources.img_last_tab;
            this.pictureBoxSkin1.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSkin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSkin1.TabIndex = 1;
            this.pictureBoxSkin1.TabStop = false;
            this.pictureBoxSkin1.Tag = "0";
            this.pictureBoxSkin1.SelectedChange += new WinForm.UI.Controls.CirclePictureBox.SelectedChangeHandler(this.pictureBoxSkin1_SelectedItem);
            this.pictureBoxSkin1.Click += new System.EventHandler(this.pictureBoxSkin1_Click);
            // 
            // pictureBoxSkin2
            // 
            this.pictureBoxSkin2.Image = global::WechatExport.Properties.Resources.img_Friends_tab_no;
            this.pictureBoxSkin2.IsSelected = false;
            this.pictureBoxSkin2.Location = new System.Drawing.Point(17, 69);
            this.pictureBoxSkin2.MouseMoveImage = null;
            this.pictureBoxSkin2.Name = "pictureBoxSkin2";
            this.pictureBoxSkin2.SelectedImage = global::WechatExport.Properties.Resources.img_Friends_tab;
            this.pictureBoxSkin2.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSkin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSkin2.TabIndex = 2;
            this.pictureBoxSkin2.TabStop = false;
            this.pictureBoxSkin2.Tag = "1";
            this.pictureBoxSkin2.SelectedChange += new WinForm.UI.Controls.CirclePictureBox.SelectedChangeHandler(this.pictureBoxSkin1_SelectedItem);
            this.pictureBoxSkin2.Click += new System.EventHandler(this.pictureBoxSkin1_Click);
            // 
            // pictureBoxSkin3
            // 
            this.pictureBoxSkin3.Image = global::WechatExport.Properties.Resources.img_public_tab_no;
            this.pictureBoxSkin3.IsSelected = false;
            this.pictureBoxSkin3.Location = new System.Drawing.Point(17, 118);
            this.pictureBoxSkin3.MouseMoveImage = null;
            this.pictureBoxSkin3.Name = "pictureBoxSkin3";
            this.pictureBoxSkin3.SelectedImage = null;
            this.pictureBoxSkin3.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSkin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSkin3.TabIndex = 3;
            this.pictureBoxSkin3.TabStop = false;
            this.pictureBoxSkin3.Tag = "2";
            this.pictureBoxSkin3.SelectedChange += new WinForm.UI.Controls.CirclePictureBox.SelectedChangeHandler(this.pictureBoxSkin1_SelectedItem);
            this.pictureBoxSkin3.Click += new System.EventHandler(this.pictureBoxSkin1_Click);
            // 
            // pictureBoxSkin4
            // 
            this.pictureBoxSkin4.Image = global::WechatExport.Properties.Resources.img_menu_no;
            this.pictureBoxSkin4.IsSelected = false;
            this.pictureBoxSkin4.Location = new System.Drawing.Point(17, 588);
            this.pictureBoxSkin4.MouseMoveImage = null;
            this.pictureBoxSkin4.Name = "pictureBoxSkin4";
            this.pictureBoxSkin4.SelectedImage = null;
            this.pictureBoxSkin4.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxSkin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSkin4.TabIndex = 4;
            this.pictureBoxSkin4.TabStop = false;
            // 
            // pbHead
            // 
            this.pbHead.Location = new System.Drawing.Point(12, 17);
            this.pbHead.Name = "pbHead";
            this.pbHead.Size = new System.Drawing.Size(35, 35);
            this.pbHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHead.TabIndex = 0;
            this.pbHead.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(60, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 639);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pictureBox3.Image = global::WechatExport.Properties.Resources.img_add;
            this.pictureBox3.Location = new System.Drawing.Point(206, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.ContartList);
            this.panel6.Controls.Add(this.LastList);
            this.panel6.Location = new System.Drawing.Point(1, 61);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(247, 577);
            this.panel6.TabIndex = 0;
            // 
            // ContartList
            // 
            this.ContartList.Adapter = null;
            this.ContartList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContartList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContartList.Location = new System.Drawing.Point(0, 148);
            this.ContartList.MouseHolder = null;
            this.ContartList.Name = "ContartList";
            this.ContartList.ScrollBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(201)))), ((int)(((byte)(198)))));
            this.ContartList.SelectHolder = null;
            this.ContartList.Size = new System.Drawing.Size(247, 77);
            this.ContartList.TabIndex = 6;
            this.ContartList.Text = "fListView1";
            this.ContartList.Visible = false;
            this.ContartList.ItemClick += new WinForm.UI.Controls.FListView.ItemClickHandler(this.LastList_ItemClick);
            // 
            // LastList
            // 
            this.LastList.Adapter = null;
            this.LastList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LastList.Location = new System.Drawing.Point(0, 23);
            this.LastList.MouseHolder = null;
            this.LastList.Name = "LastList";
            this.LastList.ScrollBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(201)))), ((int)(((byte)(198)))));
            this.LastList.SelectHolder = null;
            this.LastList.Size = new System.Drawing.Size(247, 77);
            this.LastList.TabIndex = 5;
            this.LastList.Text = "fListView1";
            this.LastList.ItemClick += new WinForm.UI.Controls.FListView.ItemClickHandler(this.LastList_ItemClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBoxSkin1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(8, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 25);
            this.panel3.TabIndex = 3;
            // 
            // textBoxSkin1
            // 
            this.textBoxSkin1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(215)))), ((int)(((byte)(214)))));
            this.textBoxSkin1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSkin1.Location = new System.Drawing.Point(3, 4);
            this.textBoxSkin1.Name = "textBoxSkin1";
            this.textBoxSkin1.Size = new System.Drawing.Size(148, 24);
            this.textBoxSkin1.TabIndex = 1;
            this.textBoxSkin1.WatermarkText = "搜索";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::WechatExport.Properties.Resources.img_search;
            this.pictureBox2.Location = new System.Drawing.Point(155, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "微 信";
            this.notifyIcon1.Visible = true;
            // 
            // loadingView1
            // 
            this.loadingView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(187)))), ((int)(((byte)(7)))));
            this.loadingView1.Enabled = false;
            this.loadingView1.Location = new System.Drawing.Point(329, 193);
            this.loadingView1.Name = "loadingView1";
            this.loadingView1.Size = new System.Drawing.Size(236, 239);
            this.loadingView1.TabIndex = 4;
            this.loadingView1.Text = "loadingView1";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackgroundImage = global::WechatExport.Properties.Resources.img_bg;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblOpUser);
            this.panel4.Controls.Add(this.MessageContext);
            this.panel4.Location = new System.Drawing.Point(310, 27);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(550, 613);
            this.panel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 1);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lblOpUser
            // 
            this.lblOpUser.AutoSize = true;
            this.lblOpUser.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOpUser.Location = new System.Drawing.Point(7, 7);
            this.lblOpUser.Name = "lblOpUser";
            this.lblOpUser.Size = new System.Drawing.Size(249, 38);
            this.lblOpUser.TabIndex = 1;
            this.lblOpUser.Text = "你点赞的样子好帅";
            this.lblOpUser.Visible = false;
            // 
            // MessageContext
            // 
            this.MessageContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageContext.Controls.Add(this.fListView1);
            this.MessageContext.Location = new System.Drawing.Point(1, 35);
            this.MessageContext.Margin = new System.Windows.Forms.Padding(0);
            this.MessageContext.Name = "MessageContext";
            this.MessageContext.Size = new System.Drawing.Size(549, 578);
            this.MessageContext.TabIndex = 0;
            this.MessageContext.Visible = false;
            // 
            // fListView1
            // 
            this.fListView1.Adapter = null;
            this.fListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fListView1.ItemDivider = 10;
            this.fListView1.Location = new System.Drawing.Point(2, 0);
            this.fListView1.Margin = new System.Windows.Forms.Padding(0);
            this.fListView1.MouseHolder = null;
            this.fListView1.Name = "fListView1";
            this.fListView1.ScrollBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(201)))), ((int)(((byte)(198)))));
            this.fListView1.SelectHolder = null;
            this.fListView1.Size = new System.Drawing.Size(544, 460);
            this.fListView1.TabIndex = 0;
            this.fListView1.Text = "fListView1";
            this.fListView1.ItemClick += new WinForm.UI.Controls.FListView.ItemClickHandler(this.fListView1_ItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(860, 640);
            this.CloseBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.CloseBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.Controls.Add(this.loadingView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogoVisible = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaxBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.MaxBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.MinBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.MinBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微 信";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSkin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHead)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.MessageContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbHead;
        private System.Windows.Forms.Panel panel2;
        private WinForm.UI.Controls.FTextBox textBoxSkin1;
        private WinForm.UI.Controls.CirclePictureBox pictureBoxSkin1;
        private WinForm.UI.Controls.CirclePictureBox pictureBoxSkin3;
        private WinForm.UI.Controls.CirclePictureBox pictureBoxSkin2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private WinForm.UI.Controls.FListView LastList;
        private WinForm.UI.Controls.CirclePictureBox pictureBoxSkin4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private WinForm.UI.Controls.FListView ContartList;
        private System.Windows.Forms.Panel MessageContext;
        private System.Windows.Forms.Label lblOpUser;
        private WinForm.UI.Controls.FListView fListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private WinForm.UI.Controls.LoadingView loadingView1;
    }
}