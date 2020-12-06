using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatExport
{
    public partial class AndroidExportForm : Form
    {
        private SoftReg softReg = null;

        public AndroidExportForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            softReg = new SoftReg();
        }

        private void AndroidExportForm_Load(object sender, EventArgs e)
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
            FolderBrowserDialog fd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                wechatPathTextBox.Text = fd.SelectedPath;

                //判断选择的Android备份路径是否正确
                if (File.Exists(Path.Combine(fd.SelectedPath, "shared_prefs", "app_brand_global_sp.xml")))
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

        }

        private void resSelectButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                resPathTextBox.Text = fd.SelectedPath;
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
            loglistBox.Items.Clear();
            groupBox1.Enabled  = groupBox4.Enabled = false;
            exportButton.Enabled = false;
            new Thread(new ThreadStart(AndroidRun)).Start();
        }


        void AddLog(string str)
        {
            loglistBox.Items.Add(str);
            loglistBox.TopIndex = loglistBox.Items.Count - 1;
        }
        void AndroidRun()
        {
            int maxCount = int.MaxValue;
            if (!softReg.GetIsReg())
            {
                maxCount = 10;
                MessageBox.Show("非注册用户暂时支持部分导出 \n如果导出全量信息请到https://www.weixinxqm.com/购买注册！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var saveBase = savePathTextBox.Text;
            Directory.CreateDirectory(saveBase);
            AddLog("分析文件夹结构");
            AndroidWeChatInterface wechat = null;

            if (string.IsNullOrEmpty(resPathTextBox.Text)) wechat = new AndroidWeChatInterface(wechatPathTextBox.Text);
            else wechat = new AndroidWeChatInterface(wechatPathTextBox.Text, resPathTextBox.Text);

            wechat.Init();
            AddLog("查找UID");
            var users = wechat.users;
            AddLog("找到" + users.Count + "个账号的消息记录");
            var uidList = new List<DisplayItem>();

            foreach (var user in users)
            {

                user.Init();
                AddLog("开始处理UID: " + user.uid);

                AddLog("打开数据库");
                if (!user.OpenMMSqlite())
                {
                    AddLog("无法打开数据库");
                    continue;
                }

                AddLog("读取账号信息");
                if (!user.GetUserBasics())
                    AddLog("没有找到本人信息，用默认值替代");

                Friend myself = user.myself;
                AddLog("微信号：" + myself.ID() + " 昵称：" + myself.DisplayName());

                AddLog("读取好友列表");
                if (!user.GetFriendsDict(out int friendcount))
                {
                    AddLog("获取好友列表失败，跳过");
                    continue;
                }
                if (!user.GetChatRoomMember(out int chatroomCount))
                {
                    AddLog("获取聊天室用户列表失败，跳过");
                    continue;
                }
                AddLog("找到" + (friendcount - chatroomCount) + "个好友");
                AddLog("找到" + chatroomCount + "个聊天室");

                AddLog("查找对话:");
                user.GetChatSessions(out List<string> chats);
                AddLog("找到" + chats.Count + "个对话");

                var userSaveBase = Path.Combine(saveBase, myself.ID());
                Directory.CreateDirectory(userSaveBase);
                user.userSaveDir = userSaveBase;

                AddLog("导出好友列表:");
                if (user.saveFriends(maxCount, out int exportCount)) AddLog("导出" + exportCount + "个好友");
                else AddLog("导出好友列表出错");

                var emojidown = new HashSet<DownloadTask>();
                var chatList = new List<DisplayItem>();

                if (htmlRadioButton.Checked)
                {
                    try
                    {
                        AddLog("复制头像:");
                        user.CopyResource();
                        File.Copy("res\\DefaultProfileHead@2x.png", Path.Combine(userSaveBase, "avatar", "DefaultProfileHead@2x.png"));
                    }
                    catch (Exception) { }
                }

                foreach (var chat in chats)
                {
                    string displayname = chat;
                    Friend friend = user.GetFriend(chat);
                    if (friend != null)
                    {
                        displayname = friend.DisplayName();
                        AddLog("处理与" + displayname + "的对话");
                    }
                    else AddLog("未找到好友信息，用默认名字代替");

                    if (textRadioButton.Checked)
                    {
                        if (user.SaveTextRecord(chat, maxCount, out int count)) AddLog("成功处理" + count + "条");
                        else AddLog("失败");
                    }
                    else if (htmlRadioButton.Checked)
                    {
                        if (user.SaveHtmlRecord(chat,maxCount, out int count, out HashSet<DownloadTask> _emojidown))
                        {
                            AddLog("成功处理" + count + "条");
                            chatList.Add(new DisplayItem() { pic = "avatar/" + (friend != null ? friend.GetAndroidUserAvatar() : "DefaultProfileHead@2x.png"), text = displayname, link = chat + ".html" });
                        }
                        else AddLog("失败");
                        emojidown.UnionWith(_emojidown);
                    }
                }

                if (htmlRadioButton.Checked) BaseWeChat.MakeListHTML(chatList, Path.Combine(userSaveBase, "聊天记录.html"));

                var downloader = new Downloader(6);
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
                uidList.Add(new DisplayItem() { pic = myself.ID() + "/avatar/" + user.myself.GetAndroidUserAvatar(), text = myself.DisplayName(), link = myself.ID() + "/聊天记录.html" });
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

            groupBox1.Enabled = groupBox4.Enabled = true;
            exportButton.Enabled = true;
            wechat = null;
            MessageBox.Show("处理完成！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
