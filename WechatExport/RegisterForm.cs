using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatExport
{
    public partial class RegisterForm : Form
    {
        private SoftReg softReg = null;
        public RegisterForm()
        {
            InitializeComponent();
            softReg = new SoftReg();
            this.mNumTextBox.Text = softReg.GetMachineNum();
            //this.licenseTextBox.Text = softReg.GetRegisterNum();
            this.mNumTextBox.ReadOnly = true;

        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            string license = licenseTextBox.Text;
            if (softReg.Register(license))
            {
                MailHelper.SendMail("account register success", softReg.GetMachineNum() + ":" + license);

                MessageBox.Show("注册成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("注册码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                licenseTextBox.SelectAll();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.weixinxqm.com");
        }
    }
}
