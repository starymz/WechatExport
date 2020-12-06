namespace WechatExport
{
    partial class IphoneExportForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.freshButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.browerButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loglistBox = new System.Windows.Forms.ListBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.htmlRadioButton);
            this.groupBox4.Controls.Add(this.textRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(32, 150);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(720, 123);
            this.groupBox4.TabIndex = 4;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "未选择";
            // 
            // freshButton
            // 
            this.freshButton.Location = new System.Drawing.Point(520, 23);
            this.freshButton.Name = "freshButton";
            this.freshButton.Size = new System.Drawing.Size(86, 33);
            this.freshButton.TabIndex = 2;
            this.freshButton.Text = "刷新";
            this.freshButton.UseVisualStyleBackColor = true;
            this.freshButton.Click += new System.EventHandler(this.freshButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(176, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(340, 26);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // browerButton
            // 
            this.browerButton.Location = new System.Drawing.Point(520, 68);
            this.browerButton.Margin = new System.Windows.Forms.Padding(4);
            this.browerButton.Name = "browerButton";
            this.browerButton.Size = new System.Drawing.Size(86, 33);
            this.browerButton.TabIndex = 7;
            this.browerButton.Text = "浏览";
            this.browerButton.UseVisualStyleBackColor = true;
            this.browerButton.Click += new System.EventHandler(this.browerButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(338, 28);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "iphone备份路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "导出保存路径：";
            // 
            // loglistBox
            // 
            this.loglistBox.FormattingEnabled = true;
            this.loglistBox.ItemHeight = 18;
            this.loglistBox.Location = new System.Drawing.Point(32, 322);
            this.loglistBox.Margin = new System.Windows.Forms.Padding(4);
            this.loglistBox.Name = "loglistBox";
            this.loglistBox.Size = new System.Drawing.Size(720, 364);
            this.loglistBox.TabIndex = 10;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(32, 281);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(122, 40);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "导出";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.freshButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.browerButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(32, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(720, 116);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径配置";
            // 
            // IphoneExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 704);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loglistBox);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IphoneExportForm";
            this.Text = "iphone";
            this.Load += new System.EventHandler(this.IphoneExportForm_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button freshButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button browerButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox loglistBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}