using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinForm.UI;

namespace WechatExport
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Style style = FormsManager.Style;
            string path = Path.Combine(Application.StartupPath, "logo.ico");
            if (File.Exists(path))
                style.Icon = new Icon(path);
            style.TitleBackColor = Color.Transparent;
            style.MinBoxBackColor = Color.FromArgb(70, Color.White);
            style.MaxBoxBackColor = Color.FromArgb(70, Color.White);

            Application.Run(new MainWindow());
        }
    }
}
