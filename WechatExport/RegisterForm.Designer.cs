namespace WechatExport
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.regBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mNumTextBox = new System.Windows.Forms.TextBox();
            this.licenseTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(45, 140);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(75, 23);
            this.regBtn.TabIndex = 0;
            this.regBtn.Text = "注册";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(247, 142);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "机器码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "注册码：";
            // 
            // mNumTextBox
            // 
            this.mNumTextBox.Location = new System.Drawing.Point(98, 55);
            this.mNumTextBox.Name = "mNumTextBox";
            this.mNumTextBox.Size = new System.Drawing.Size(182, 21);
            this.mNumTextBox.TabIndex = 4;
            // 
            // licenseTextBox
            // 
            this.licenseTextBox.Location = new System.Drawing.Point(99, 97);
            this.licenseTextBox.Name = "licenseTextBox";
            this.licenseTextBox.Size = new System.Drawing.Size(181, 21);
            this.licenseTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(43, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "请https://www.weixinxqm.com购买注册码";
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(276, 14);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(46, 23);
            this.buyBtn.TabIndex = 7;
            this.buyBtn.Text = "购买";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 177);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.licenseTextBox);
            this.Controls.Add(this.mNumTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.regBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mNumTextBox;
        private System.Windows.Forms.TextBox licenseTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buyBtn;
    }
}