using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatExport
{
    public partial class HuaWeiToolForm : Form
    {
        private SoftReg softReg = null;

        public HuaWeiToolForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            softReg = new SoftReg();
        }

        private void HuaWeiToolForm_Load(object sender, EventArgs e)
        {
            savePathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            exportButton.Enabled = false;
        }

        private void BeforeLoadManifest()
        {
            label2.Text = "未选择";
            label2.ForeColor = Color.Black;
            exportButton.Enabled = false;
            loglistBox.Items.Clear();
        }
        private void bakSelectButton_Click(object sender, EventArgs e)
        {
            BeforeLoadManifest();

            OpenFileDialog fd = new OpenFileDialog
            {
                Filter = "华为备份|Info.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                bakPathTextBox.Text = Path.GetDirectoryName(fd.FileName);
                label2.Text = "正确";
                label2.ForeColor = Color.Green;
                exportButton.Enabled = true;
            }

           
        }

        private void browerButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                savePathTextBox.Text = fd.SelectedPath;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bakPathTextBox.Text))
            {
                MessageBox.Show("备份路径不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(savePathTextBox.Text))
            {
                MessageBox.Show("保存路径不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(pwdTextBox.Text))
            {
                MessageBox.Show("输入的备份密码不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            exportButton.Enabled = false;
            new Thread(new ThreadStart(DecryptBackUpData)).Start();

        }

        void AddLog(string str)
        {
            loglistBox.Items.Add(str);
            loglistBox.TopIndex = loglistBox.Items.Count - 1;
        }

        private bool HasWinRarInstalled(out string winRarParh)
        {
            winRarParh = null;
            string[] keys = { @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall" };
            foreach(string key in keys)
            {
                RegistryKey uninstallNode = Registry.LocalMachine.OpenSubKey(key);
                foreach (string subKeyName in uninstallNode.GetSubKeyNames())
                {
                    RegistryKey subKey = uninstallNode.OpenSubKey(subKeyName);
                    object displayName = subKey.GetValue("DisplayName");
                    if (displayName != null)
                    {
                        if (displayName.ToString().Contains("WinRAR"))
                        {
                            winRarParh = subKey.GetValue("DisplayIcon").ToString();
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// 利用 WinRAR 进行解压缩
        /// </summary>
        /// <param name="path">文件解压路径（绝对）</param>
        /// <param name="rarPath">将要解压缩的 .rar 文件的存放目录（绝对路径）</param>
        /// <param name="rarName">将要解压缩的 .rar 文件名（包括后缀）</param>
        /// <returns>true 或 false。解压缩成功返回 true，反之，false。</returns>
        private bool UnCompressWithWinRar(string winRarPath, string rarPath, string destPath)
        {
            bool succ = false;
            string cmd;
            try
            {
                Directory.CreateDirectory(destPath);
                //解压缩命令，相当于在要压缩文件(rarName)上点右键->WinRAR->解压到当前文件夹
                cmd = string.Format("x \"{0}\" \"{1}\" -y",
                                    rarPath,
                                    destPath);

                succ = Utils.ShellWait(winRarPath, cmd);
            }
            catch (Exception e)
            {
                AddLog("解压出错:" + e.Message);
            }
           
            return succ;
        }
        private void DecryptBackUpData()
        {
            string destDir = savePathTextBox.Text;
            if (Directory.Exists(destDir))
            {
                destDir = Path.Combine(destDir, Utils.RandomString(5));
            }

            string backupDir = bakPathTextBox.Text;
            string password = pwdTextBox.Text;

            string argvs = "\"" + password + "\" \"" + backupDir + "\" \"" + destDir + "\" -w";

            AddLog("开始解压");

            Utils.ShellWait("lib\\kobackupdec.exe", argvs);

            string wechatData = Path.Combine(destDir, "data", "data", "com.tencent.mm.tar");
             
            if (File.Exists(wechatData))
            {
                AddLog("解密完成");
                AddLog("解压微信数据");
                string dataDir = Directory.GetParent(wechatData).FullName;
                if (HasWinRarInstalled(out string winRarPath))
                {
                    if (UnCompressWithWinRar(winRarPath, wechatData, Directory.GetParent(wechatData).FullName))
                    {
                        AddLog("解压完成");
                        MessageBox.Show("解压完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else AddLog("解压出错");
                }
                else
                {
                    AddLog("未安装WinRar,请安装后再试");
                    MessageBox.Show("未安装WinRar,请安装后再试！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                AddLog("解密出错");
                MessageBox.Show("解密出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            exportButton.Enabled = true;
        }
    }
}
