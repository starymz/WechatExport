namespace WeChat
{
    partial class ImageForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNarrow = new WinForm.UI.Controls.CirclePictureBox();
            this.btnEnlarge = new WinForm.UI.Controls.CirclePictureBox();
            this.btnRotate = new WinForm.UI.Controls.CirclePictureBox();
            this.btnDownload = new WinForm.UI.Controls.CirclePictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNarrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnlarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "图片过期活已被清理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.btnNarrow);
            this.panel1.Controls.Add(this.btnEnlarge);
            this.panel1.Controls.Add(this.btnRotate);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 57);
            this.panel1.TabIndex = 2;
            // 
            // btnNarrow
            // 
            this.btnNarrow.Image = global::WechatExport.Properties.Resources.img_narrow;
            this.btnNarrow.IsSelected = false;
            this.btnNarrow.Location = new System.Drawing.Point(67, 17);
            this.btnNarrow.MouseMoveImage = global::WechatExport.Properties.Resources.img_narrow_move;
            this.btnNarrow.Name = "btnNarrow";
            this.btnNarrow.SelectedImage = null;
            this.btnNarrow.Size = new System.Drawing.Size(23, 23);
            this.btnNarrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnNarrow.TabIndex = 4;
            this.btnNarrow.TabStop = false;
            // 
            // btnEnlarge
            // 
            this.btnEnlarge.Image = global::WechatExport.Properties.Resources.img_enlarge;
            this.btnEnlarge.IsSelected = false;
            this.btnEnlarge.Location = new System.Drawing.Point(124, 17);
            this.btnEnlarge.MouseMoveImage = global::WechatExport.Properties.Resources.img_enlarge_move;
            this.btnEnlarge.Name = "btnEnlarge";
            this.btnEnlarge.SelectedImage = null;
            this.btnEnlarge.Size = new System.Drawing.Size(23, 23);
            this.btnEnlarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnEnlarge.TabIndex = 3;
            this.btnEnlarge.TabStop = false;
            this.btnEnlarge.Click += new System.EventHandler(this.btnEnlarge_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Image = global::WechatExport.Properties.Resources.img_rotate;
            this.btnRotate.IsSelected = false;
            this.btnRotate.Location = new System.Drawing.Point(181, 17);
            this.btnRotate.MouseMoveImage = global::WechatExport.Properties.Resources.img_rotate_move;
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.SelectedImage = null;
            this.btnRotate.Size = new System.Drawing.Size(27, 23);
            this.btnRotate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRotate.TabIndex = 2;
            this.btnRotate.TabStop = false;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Image = global::WechatExport.Properties.Resources.img_download;
            this.btnDownload.IsSelected = false;
            this.btnDownload.Location = new System.Drawing.Point(242, 17);
            this.btnDownload.MouseMoveImage = global::WechatExport.Properties.Resources.img_download_move;
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.SelectedImage = null;
            this.btnDownload.Size = new System.Drawing.Size(23, 23);
            this.btnDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnDownload.TabIndex = 1;
            this.btnDownload.TabStop = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BackColor = System.Drawing.Color.Black;
            this.pbImage.Location = new System.Drawing.Point(0, 30);
            this.pbImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(332, 339);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp";
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(332, 429);
            this.CloseBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbImage);
            this.LogoVisible = false;
            this.MaxBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.MaxBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.MinBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.MinBoxFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.Name = "ImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageForm";
            this.TitleHeight = 25;
            this.Load += new System.EventHandler(this.ImageForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNarrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnlarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private WinForm.UI.Controls.CirclePictureBox btnDownload;
        private WinForm.UI.Controls.CirclePictureBox btnRotate;
        private WinForm.UI.Controls.CirclePictureBox btnEnlarge;
        private WinForm.UI.Controls.CirclePictureBox btnNarrow;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}