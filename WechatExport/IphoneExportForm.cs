using iphonebackupbrowser;
using mbdbdump;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatExport
{
    public partial class IphoneExportForm : Form
    {

        private List<MBFileRecord> files92;
        private SoftReg softReg = null;

        public IphoneExportForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            softReg = new SoftReg();
        }

        private IPhoneBackup LoadManifest(string path)
        {
            IPhoneBackup backup = null;
            string filename = Path.Combine(path, "Info.plist");
            try
            {
                xdict dd = xdict.open(filename);
                if (dd != null)
                {
                    backup = new IPhoneBackup
                    {
                        path = path
                    };
                    foreach (xdictpair p in dd)
                    {
                        if (p.item.GetType() == typeof(string))
                        {
                            switch (p.key)
                            {
                                case "Device Name": backup.DeviceName = (string)p.item; break;
                                case "Display Name": backup.DisplayName = (string)p.item; break;
                                case "Last Backup Date":
                                    DateTime.TryParse((string)p.item, out backup.LastBackupDate);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return backup;
        }

        private void LoadManifests()
        {
            comboBox1.Items.Clear();

            List<string> dirs = new List<string>();
            string s = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            s = MyPath.Combine(s, "Apple Computer", "MobileSync", "Backup");
            dirs.Add(s);

            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }
            path = MyPath.Combine(path, "Apple", "MobileSync", "Backup");
            dirs.Add(path);

            try
            {
                foreach (string dir in dirs)
                {
                    if (Directory.Exists(dir))
                    {

                        DirectoryInfo d = new DirectoryInfo(dir);

                        foreach (DirectoryInfo sd in d.GetDirectories())
                        {
                            comboBox1.Items.Add(LoadManifest(sd.FullName));
                        }
                    }
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("没有找到iTunes备份文件夹，可能需要手动选择。");
            }

            comboBox1.Items.Add("<选择其他备份文件夹...>");
        }


        private void LoadCurrentBackup()
        {
            if (comboBox1.SelectedItem.GetType() == typeof(IPhoneBackup))
            {
                //判断选择的itune备份路径是否正确
                var backup = (IPhoneBackup)comboBox1.SelectedItem;

                files92 = null;
                try
                {
                    if (File.Exists(Path.Combine(backup.path, "Manifest.mbdb")))
                    {
                        files92 = mbdbdump.mbdb.ReadMBDB(backup.path, "com.tencent.xin");
                    }
                    else if (File.Exists(Path.Combine(backup.path, "Manifest.db")))
                    {
                        files92 = V10db.ReadMBDB(Path.Combine(backup.path, "Manifest.db"), "com.tencent.xin");
                    }
                    if (files92 != null && files92.Count > 0)
                    {
                        label2.Text = "正确";
                        label2.ForeColor = Color.Green;
                        exportButton.Enabled = true;
                    }
                    else
                    {
                        label2.Text = "未找到";
                        label2.ForeColor = Color.Red;
                        exportButton.Enabled = false;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void BeforeLoadManifest()
        {
            comboBox1.SelectedIndex = -1;
            label2.Text = "未选择";
            label2.ForeColor = Color.Black;
            exportButton.Enabled = false;
            loglistBox.Items.Clear();
        }


        private void freshButton_Click(object sender, EventArgs e)
        {
            BeforeLoadManifest();
            LoadManifests();
        }

        private void browerButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fd.SelectedPath;
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            loglistBox.Items.Clear();
            groupBox1.Enabled = groupBox4.Enabled = false;
            exportButton.Enabled = false;
            new Thread(new ThreadStart(IphoneRun)).Start();           
        }

        private void IphoneExportForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            freshButton_Click(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            if (comboBox1.SelectedItem.GetType() == typeof(IPhoneBackup) || comboBox1.SelectedItem.GetType() == typeof(AndroidBackup))
            {
                LoadCurrentBackup();
                return;
            }
            OpenFileDialog fd = new OpenFileDialog
            {
                Filter = "iPhone Backup|Info.plist|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                BeforeLoadManifest();
                IPhoneBackup b = LoadManifest(Path.GetDirectoryName(fd.FileName));
                if (b != null)
                {
                    b.custom = true;
                    comboBox1.Items.Insert(comboBox1.Items.Count - 1, b);
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 2;
                }
            }
        }

        private void AddLog(string str)
        {
            loglistBox.Items.Add(str);
            loglistBox.TopIndex = loglistBox.Items.Count - 1;
        }

        private void IphoneRun()
        {

            int maxCount = int.MaxValue;
            if (!softReg.GetIsReg())
            {
                maxCount = 10;
                MessageBox.Show("非注册用户暂时支持部分导出 \n如果导出全量信息请到https://www.weixinxqm.com/购买注册！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var saveBase = textBox1.Text;
            Directory.CreateDirectory(saveBase);
            AddLog("分析文件夹结构");
            IphoneWeChatInterface wechat = new IphoneWeChatInterface(((IPhoneBackup)comboBox1.SelectedItem).path, files92);
            wechat.BuildFilesDictionary();
            AddLog("查找UID");
            var UIDs = wechat.FindUIDs();
            AddLog("找到" + UIDs.Count + "个账号的消息记录");
            var uidList = new List<DisplayItem>();
            int delta = 90 / ((UIDs.Count > 0 ? UIDs.Count : 1) * 5);
            foreach (var uid in UIDs)
            {
                var userBase = Path.Combine("Documents", uid);
                AddLog("开始处理UID: " + uid);
                AddLog("读取账号信息");
                if (wechat.GetUserBasics(uid, userBase, out Friend myself)) AddLog("微信号：" + myself.ID() + " 昵称：" + myself.DisplayName());
                else AddLog("没有找到本人信息，用默认值替代");
                var userSaveBase = Path.Combine(saveBase, myself.ID());
                Directory.CreateDirectory(userSaveBase);
                AddLog("正在打开数据库");
                if (!wechat.OpenMMSqlite(userBase, out System.Data.SQLite.SQLiteConnection conn))
                {
                    AddLog("打开MM.sqlite失败，跳过");
                    continue;
                }
                if (wechat.OpenWCDBContact(userBase, out SQLiteConnection wcdb))
                    AddLog("存在WCDB，与旧版好友列表合并使用");
                AddLog("读取好友列表");
                if (!wechat.GetFriendsDict(conn, wcdb, myself, out Dictionary<string, Friend> friends, out int friendcount))
                {
                    AddLog("读取好友列表失败，跳过");
                    continue;
                }
                AddLog("找到" + friendcount + "个好友/聊天室");

                AddLog("导出好友列表:");
                BaseWeChat.saveFriends(Path.Combine(userSaveBase, "好友列表.txt"), friends, maxCount, out int exportCount);
                AddLog("导出" + exportCount + "个好友");

                conn.Close();
                wcdb.Close();

                var emojidown = new HashSet<DownloadTask>();
                var chatList = new List<DisplayItem>();

                var messageDBs = wechat.FindMessageDB(uid);

                foreach (var messageDB in messageDBs)
                {
                    if (!wechat.OpenMessageSqlite(messageDB, out SQLiteConnection msgConn))
                    {
                        AddLog("读取" + messageDB + "出错，跳过");
                        continue;
                    }

                    AddLog("查找对话:" + messageDB);
                    wechat.GetChatSessions(msgConn, out List<string> chats);
                    AddLog("找到" + chats.Count + "个对话");

                    foreach (var chat in chats)
                    {
                        var hash = chat;
                        string displayname = chat, id = displayname;
                        Friend friend = null;
                        if (friends.ContainsKey(hash))
                        {
                            friend = friends[hash];
                            displayname = friend.DisplayName();
                            AddLog("处理与" + displayname + "的对话");
                            id = friend.ID();
                        }
                        else AddLog("未找到好友信息，用默认名字代替");
                        if (textRadioButton.Checked)
                        {
                            if (wechat.SaveTextRecord(msgConn, Path.Combine(userSaveBase, id + ".txt"), displayname, id, myself, chat, friend, friends, maxCount, out int count)) AddLog("成功处理" + count + "条");
                            else AddLog("失败");
                        }
                        else if (htmlRadioButton.Checked)
                        {
                            if (wechat.SaveHtmlRecord(msgConn, userBase, userSaveBase, displayname, id, myself, chat, friend, friends, maxCount, out int count, out HashSet<DownloadTask> _emojidown))
                            {
                                AddLog("成功处理" + count + "条");
                                chatList.Add(new DisplayItem() { pic = "Portrait/" + (friend != null ? friend.FindPortrait() : "DefaultProfileHead@2x.png"), text = displayname, link = id + ".html" });
                            }
                            else AddLog("失败");
                            emojidown.UnionWith(_emojidown);
                        }
                    }

                    msgConn.Close();
                }


                if (htmlRadioButton.Checked) BaseWeChat.MakeListHTML(chatList, Path.Combine(userSaveBase, "聊天记录.html"));
                var portraitdir = Path.Combine(userSaveBase, "Portrait");
                Directory.CreateDirectory(portraitdir);
                var downlist = new HashSet<DownloadTask>();
                foreach (var item in friends)
                {
                    var tfriend = item.Value;
                    if (!tfriend.PortraitRequired) continue;
                    if (tfriend.Portrait != null && tfriend.Portrait != "") downlist.Add(new DownloadTask() { url = tfriend.Portrait, filename = tfriend.ID() + ".jpg" });
                    //if (tfriend.PortraitHD != null && tfriend.PortraitHD != "") downlist.Add(new DownloadTask() { url = tfriend.PortraitHD, filename = tfriend.ID() + "_hd.jpg" });
                }
                var downloader = new Downloader(6);
                if (downlist.Count > 0)
                {
                    AddLog("下载" + downlist.Count + "个头像");
                    foreach (var item in downlist)
                    {
                        downloader.AddTask(item.url, Path.Combine(portraitdir, item.filename));
                    }
                    try
                    {
                        File.Copy("res\\DefaultProfileHead@2x.png", Path.Combine(portraitdir, "DefaultProfileHead@2x.png"));
                    }
                    catch (Exception) { }
                }
                var emojidir = Path.Combine(userSaveBase, "Emoji");
                Directory.CreateDirectory(emojidir);
                if (emojidown != null && emojidown.Count > 0)
                {
                    AddLog("下载" + emojidown.Count + "个表情");
                    foreach (var item in emojidown)
                    {
                        downloader.AddTask(item.url, Path.Combine(emojidir, item.filename));
                    }
                }
                uidList.Add(new DisplayItem() { pic = myself.ID() + "/Portrait/" + myself.FindPortrait(), text = myself.DisplayName(), link = myself.ID() + "/聊天记录.html" });
                downloader.StartDownload();
                downloader.WaitToEnd();

                AddLog("完成当前账号");
            }
            if (htmlRadioButton.Checked) BaseWeChat.MakeListHTML(uidList, Path.Combine(saveBase, "聊天记录.html"));
            AddLog("任务结束");
            try
            {
                if (htmlRadioButton.Checked) System.Diagnostics.Process.Start(Path.Combine(saveBase, "聊天记录.html"));
            }
            catch (Exception) { }
            groupBox1.Enabled =  groupBox4.Enabled = true;
            exportButton.Enabled = true;
            wechat = null;
            MessageBox.Show("处理完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
