namespace WechatExport
{
    partial class HuaWeiToolForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bakPathTextBox = new System.Windows.Forms.TextBox();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.bakSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.browerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.loglistBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pwdTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bakPathTextBox);
            this.groupBox1.Controls.Add(this.savePathTextBox);
            this.groupBox1.Controls.Add(this.bakSelectButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.browerButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(33, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(720, 162);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径配置";
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.pwdTextBox.Location = new System.Drawing.Point(177, 117);
            this.pwdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.Size = new System.Drawing.Size(338, 28);
            this.pwdTextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "备份密码：";
            // 
            // bakPathTextBox
            // 
            this.bakPathTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.bakPathTextBox.Location = new System.Drawing.Point(177, 27);
            this.bakPathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bakPathTextBox.Name = "bakPathTextBox";
            this.bakPathTextBox.ReadOnly = true;
            this.bakPathTextBox.Size = new System.Drawing.Size(338, 28);
            this.bakPathTextBox.TabIndex = 13;
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(177, 74);
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
            this.label3.Location = new System.Drawing.Point(39, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "导出保存路径：";
            // 
            // browerButton
            // 
            this.browerButton.Location = new System.Drawing.Point(520, 71);
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
            this.label1.Text = "手机备份路径：";
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
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(33, 202);
            this.exportButton.Margin = new System.Windows.Forms.Padding(4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(122, 43);
            this.exportButton.TabIndex = 18;
            this.exportButton.Text = "解密";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loglistBox
            // 
            this.loglistBox.FormattingEnabled = true;
            this.loglistBox.ItemHeight = 18;
            this.loglistBox.Location = new System.Drawing.Point(33, 253);
            this.loglistBox.Margin = new System.Windows.Forms.Padding(4);
            this.loglistBox.Name = "loglistBox";
            this.loglistBox.Size = new System.Drawing.Size(720, 418);
            this.loglistBox.TabIndex = 20;
            // 
            // HuaWeiToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 704);
            this.Controls.Add(this.loglistBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exportButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HuaWeiToolForm";
            this.Text = "huawei";
            this.Load += new System.EventHandler(this.HuaWeiToolForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox bakPathTextBox;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Button bakSelectButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ListBox loglistBox;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.Label label4;
    }
}