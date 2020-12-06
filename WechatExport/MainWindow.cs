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
    public partial class MainWindow : Form
    {
        private SoftReg softReg;
        private Form currentForm;
        public MainWindow()
        {
            InitializeComponent();
            softReg = new SoftReg();
            currentForm = null;
        }


        private void registerMenuItem_Click(object sender, EventArgs e)
        {
            if (softReg.GetIsReg())
            {
                MessageBox.Show("软件已注册！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RegisterForm frmRegister = new RegisterForm();
            frmRegister.ShowDialog();
            if (softReg.GetIsReg())
            {
                removeRegMenuItem.Visible = true;
                registerMenuItem.Visible = false;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            iphoneMenuItem_Click(sender, e);
            if (softReg.GetIsReg())
            {
                removeRegMenuItem.Visible = true;
                registerMenuItem.Visible = false;
            }
            else
            {
                removeRegMenuItem.Visible = false;
                registerMenuItem.Visible = true;
            }
        }

        private void huaweiDataDecryptMenuItem_Click(object sender, EventArgs e)
        {
            HuaWeiToolForm form = new HuaWeiToolForm();
            activateForm(form);
        }

        private void activateForm(Form form)
        {
            if (form == null)
                return;

            //窗体最大化
            form.WindowState = FormWindowState.Maximized;
            //去掉边框
            form.FormBorderStyle = FormBorderStyle.None;
            form.MdiParent = this;
            form.Parent = mainPanel;
            form.Show();
            if (currentForm != null) currentForm.Close();
            currentForm = form;
        }

        private void removeRegMenuItem_Click(object sender, EventArgs e)
        {
            softReg.removeReg();
            removeRegMenuItem.Visible = false;
            registerMenuItem.Visible = true;
        }

        private void iphoneMenuItem_Click(object sender, EventArgs e)
        {
            IphoneExportForm form = new IphoneExportForm();
            activateForm(form);
            iphoneMenuItem.CheckState = CheckState.Checked;
            iphoneMenuItem.Checked = true;
        }

        private void androidMenuItem_Click(object sender, EventArgs e)
        {
            AndroidExportForm form = new AndroidExportForm();
            activateForm(form);
            androidMenuItem.CheckState = CheckState.Checked;
            androidMenuItem.Checked = true;


        }

        private void infoMenuItem_Click(object sender, EventArgs e)
        {
            SoftInfoForm form = new SoftInfoForm();
            form.ShowDialog();
        }
    }
}
