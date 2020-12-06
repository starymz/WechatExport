namespace WechatExport
{
    partial class AndroidExportForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.htmlRadioButton = new System.Windows.Forms.RadioButton();
            this.textRadioButton = new System.Windows.Forms.RadioButton();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.bakSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.browerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wechatPathTextBox = new System.Windows.Forms.TextBox();
            this.resSelectButton = new System.Windows.Forms.Button();
            this.resPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.loglistBox = new System.Windows.Forms.ListBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.htmlRadioButton);
            this.groupBox4.Controls.Add(this.textRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(36, 188);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(720, 123);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "保存格式";
            // 
            // htmlRadioButton
            // 
            this.htmlRadioButton.AutoSize = true;
            this.htmlRadioButton.Location = new System.Drawing.Point(21, 72);
            this.htmlRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.htmlRadioButton.Name = "htmlRadioButton";
            this.htmlRadioButton.Size = new System.Drawing.Size(528, 22);
            this.htmlRadioButton.TabIndex = 0;
            this.htmlRadioButton.Text = "网页 （显示图片、视频、语音等，每个对话为一个html文件）";
            this.htmlRadioButton.UseVisualStyleBackColor = true;
            // 
            // textRadioButton
            // 
            this.textRadioButton.AutoSize = true;
            this.textRadioButton.Checked = true;
            this.textRadioButton.Location = new System.Drawing.Point(22, 34);
            this.textRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.textRadioButton.Name = "textRadioButton";
            this.textRadioButton.Size = new System.Drawing.Size(465, 22);
            this.textRadioButton.TabIndex = 0;
            this.textRadioButton.TabStop = true;
            this.textRadioButton.Text = "文本 （保留文字内容，每个对话保存为一个txt文件）";
            this.textRadioButton.UseVisualStyleBackColor = true;
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(177, 106);
            this.savePathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.ReadOnly = true;
            this.savePathTextBox.Size = new System.Drawing.Size(338, 28);
            this.savePathTextBox.TabIndex = 6;
            // 
            // bakSelectButton
            // 
            this.bakSelectButton.Location = new System.Drawing.Point(520, 25);
            this.bakSelectButton.Name = "bakSelectButton";
            this.bakSelectButton.Size = new System.Drawing.Size(86, 33);
            this.bakSelectButton.TabIndex = 2;
            this.bakSelectButton.Text = "浏览";
            this.bakSelectButton.UseVisualStyleBackColor = true;
            this.bakSelectButton.Click += new System.EventHandler(this.bakSelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "导出保存路径：";
            // 
            // browerButton
            // 
            this.browerButton.Location = new System.Drawing.Point(520, 104);
            this.browerButton.Margin = new System.Windows.Forms.Padding(4);
            this.browerButton.Name = "browerButton";
            this.browerButton.Size = new System.Drawing.Size(86, 33);
            this.browerButton.TabIndex = 7;
            this.browerButton.Text = "浏览";
            this.browerButton.UseVisualStyleBackColor = true;
            this.browerButton.Click += new System.EventHandler(this.browerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "微信备份路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "未选择";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wechatPathTextBox);
            this.groupBox1.Controls.Add(this.resSelectButton);
            this.groupBox1.Controls.Add(this.resPathTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.savePathTextBox);
            this.groupBox1.Controls.Add(this.bakSelectButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.browerButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(36, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(720, 154);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径配置";
            // 
            // wechatPathTextBox
            // 
            this.wechatPathTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.wechatPathTextBox.Location = new System.Drawing.Point(177, 27);
            this.wechatPathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.wechatPathTextBox.Name = "wechatPathTextBox";
            this.wechatPathTextBox.ReadOnly = true;
            this.wechatPathTextBox.Size = new System.Drawing.Size(338, 28);
            this.wechatPathTextBox.TabIndex = 13;
            // 
            // resSelectButton
            // 
            this.resSelectButton.Location = new System.Drawing.Point(520, 64);
            this.resSelectButton.Margin = new System.Windows.Forms.Padding(4);
            this.resSelectButton.Name = "resSelectButton";
            this.resSelectButton.Size = new System.Drawing.Size(86, 34);
            this.resSelectButton.TabIndex = 12;
            this.resSelectButton.Text = "浏览";
            this.resSelectButton.UseVisualStyleBackColor = true;
            this.resSelectButton.Click += new System.EventHandler(this.resSelectButton_Click);
            // 
            // resPathTextBox
            // 
            this.resPathTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.resPathTextBox.Location = new System.Drawing.Point(177, 68);
            this.resPathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.resPathTextBox.Name = "resPathTextBox";
            this.resPathTextBox.ReadOnly = true;
            this.resPathTextBox.Size = new System.Drawing.Size(338, 28);
            this.resPathTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "微信资源路径：";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(36, 319);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(122, 42);
            this.exportButton.TabIndex = 15;
            this.exportButton.Text = "导出";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loglistBox
            // 
            this.loglistBox.FormattingEnabled = true;
            this.loglistBox.ItemHeight = 18;
            this.loglistBox.Location = new System.Drawing.Point(36, 368);
            this.loglistBox.Margin = new System.Windows.Forms.Padding(4);
            this.loglistBox.Name = "loglistBox";
            this.loglistBox.Size = new System.Drawing.Size(720, 328);
            this.loglistBox.TabIndex = 14;
            // 
            // AndroidExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 704);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loglistBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AndroidExportForm";
            this.Text = "android";
            this.Load += new System.EventHandler(this.AndroidExportForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton htmlRadioButton;
        private System.Windows.Forms.RadioButton textRadioButton;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Button bakSelectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button resSelectButton;
        private System.Windows.Forms.TextBox resPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ListBox loglistBox;
        private System.Windows.Forms.TextBox wechatPathTextBox;
    }
}