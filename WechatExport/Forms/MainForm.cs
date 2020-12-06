using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChat.Adapter;
using WechatExport;
using WinForm.UI.Controls;
using WinForm.UI.Forms;

namespace WeChat
{
    public partial class MainForm : BaseForm
    {
        private LastRContactAdapter LastRContactAdapter;
        private RContactAdapter RContactAdapter;
        private MessageAdapter adapter;
        private WeChatConcat openContact;
        private TaskFactory AsyncTask;
        private WeChatInterface weChatApi;
        /// <summary>
        /// UI线程的同步上下文
        /// </summary>
        private SynchronizationContext m_SyncContext = null;
        public MainForm()
        {
            InitializeComponent();
            //获取UI线程同步上下文
            m_SyncContext = SynchronizationContext.Current;
            AsyncTask = new TaskFactory();
            LastRContactAdapter = new LastRContactAdapter();
            this.LastList.Adapter = LastRContactAdapter;
            RContactAdapter = new RContactAdapter();
            this.ContartList.Adapter = RContactAdapter;
            adapter = new MessageAdapter();
            this.fListView1.Adapter = adapter;
            this.fListView1.IsMouseFeedBack = false;
        }
        public MainForm(WeChatInterface weChatApi) : this()
        {
            this.weChatApi = weChatApi;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadingView1.BringToFront();
            loadingView1.Start();

            HideTable();
            LastList.Dock = DockStyle.Fill;
            LastList.Visible = true;
            pictureBoxSkin1.IsSelected = true;

        }



        /// <summary>
        /// listView 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LastList_ItemClick(object sender, WinForm.UI.Events.ItemClickEventArgs e)
        {
            WeChatConcat rContact = e.ViewHolder.UserData as WeChatConcat;
            if (this.openContact == rContact)
                return;
            adapter.Clear();
            this.openContact = rContact;
            this.lblOpUser.Text = rContact.NickName;
            this.lblOpUser.Visible = true;
            this.MessageContext.Visible = true;
            //加载聊天记录
            AsyncTask.StartNew(LoadMessageHistory);

        }

        private void LoadMessageHistory()
        {
            if (openContact == null)
                return;
            //TODO 根据用户号获取聊天信息
            m_SyncContext.Post(UpdateMessageList, null);
        }

        private void UpdateMessageList(object state)
        {
            if (state is WeChatMessage)
            {
                adapter.Add((WeChatMessage)state);
            }
            else
            {
                List<WeChatMessage> message = state as List<WeChatMessage>;

                adapter.AddItems(message);
            }
            this.fListView1.ScrollBottom();
        }

        
        /// <summary>
        /// 更新当前用户信息
        /// </summary>
        /// <param name="state"></param>
        private void UpdateUser(object state)
        {
            WeChatConcat Self = state as WeChatConcat;
            pbHead.Image = Self.HeadImage;
        }

       

        

        

        

        #region table

        /// <summary>
        /// table切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSkin1_Click(object sender, EventArgs e)
        {
            if (((CirclePictureBox)sender).IsSelected)
                return;

            foreach (Control item in panel5.Controls)
            {
                if (item is CirclePictureBox)
                {
                    ((CirclePictureBox)item).IsSelected = false;
                }
            }
            ((CirclePictureBox)sender).IsSelected = true;
        }

        private void HideTable()
        {
            foreach (Control item in panel6.Controls)
            {
                if (item is FListView)
                {
                    ((FListView)item).Visible = false;
                }
            }
        }

        /// <summary>
        /// table选中改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSkin1_SelectedItem(object sender, EventArgs e)
        {
            CirclePictureBox view = sender as CirclePictureBox;
            int stap = Convert.ToInt32(view.Tag);
            HideTable();
            switch (stap)
            {
                case 0:
                    this.LastList.Visible = true;
                    this.LastList.Dock = DockStyle.Fill;
                    break;
                case 1:
                    this.ContartList.Visible = true;
                    this.ContartList.Dock = DockStyle.Fill;
                    break;
                case 2:
                    //this.Collection.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion


        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            this.Hide();
        }
        /// <summary>
        /// 聊天记录点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fListView1_ItemClick(object sender, WinForm.UI.Events.ItemClickEventArgs e)
        {
            WeChatMessage msg = e.ViewHolder.UserData as WeChatMessage;
            if (msg.MsgType == 3)//图片消息
            {
                string path = string.Empty;
                //TODO 获取图片
                ImageForm form = new ImageForm();
                form.Show(path);
            }
            else if (msg.MsgType == 34)//语音消息
            {
                string path = msg.fileName;
                adapter.Play();
                AsyncTask.StartNew(() =>
                {
                    Thread.Sleep((int)msg.VoiceLength / 1000);
                    adapter.Stop();
                });
            }
        }
    }
}
