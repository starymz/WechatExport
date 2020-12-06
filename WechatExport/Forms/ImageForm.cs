using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using WeChat.Utils;
using WinForm.UI.Forms;

namespace WeChat
{
    public partial class ImageForm : BaseForm
    {

        public ImageForm()
        {
            InitializeComponent();
        }



        private void ImageForm_Load(object sender, EventArgs e)
        {
            //pbImage.ImageLocation = @"C:\Users\yuanj\Pictures\Saved Pictures\869200649642939266.jpg";
        }

        public void Show(string path)
        {
            if (File.Exists(path))
            {
                Image image = Image.FromFile(path);
                int Width = image.Width;
                int Height = image.Height;//2
                Image result = null;
                if (image.Width > 500 || image.Height > 740)
                {
                    result = GetSmall(image, 2);
                }
                else
                {
                    result = image;
                }
                this.pbImage.Image = result;

                if (result.Width < 332 && result.Height < 429)
                {

                }
                else if (result.Height > 870)
                {
                    this.Width = result.Width;
                    this.Height = 870 + 60 + 30;
                }else
                {
                    this.Width = result.Width;
                    this.Height = result.Height + 60 + 30;
                }

                
            }
            else
            {
                this.pbImage.Visible = false;
                this.label1.Visible = true;
            }
            Show();
        }

        //private void LoadImage(string url)
        //{
        //    if (!backgroundWorker1.IsBusy)
        //        backgroundWorker1.RunWorkerAsync(url);
        //}


        /// <summary>
        /// 获取缩小后的图片
        /// </summary>
        /// <param name="bm">要缩小的图片</param>
        /// <param name="times">要缩小的倍数</param>
        /// <returns></returns>
        private Bitmap GetSmall(Image bm, double times)
        {
            int nowWidth = (int)(bm.Width / times);
            int nowHeight = (int)(bm.Height / times);
            Bitmap newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片

            if (times >= 1 && times <= 1.1)
            {
                newbm = (Bitmap)bm;
            }
            else
            {
                Graphics g = Graphics.FromImage(newbm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bm, new Rectangle(0, 0, nowWidth, nowHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            return newbm;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Image image = pbImage.Image;
            if (image == null)
                return;
            string ext = GraphicsUtils.GetImageExtension(image);
            string fileName = "微信_" + DateTime.Now.Ticks + ext;
            saveFileDialog1.FileName = fileName;
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                string path = saveFileDialog1.FileName;
                image.Save(path);
            }
        }
        /// <summary>
        /// 旋转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotate_Click(object sender, EventArgs e)
        {
            Image image = pbImage.Image;
            if (image == null)
                return;
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbImage.Invalidate();
        }
        //放大
        private void btnEnlarge_Click(object sender, EventArgs e)
        {

        }


        private void ShowToast(string message)
        {
            Toast.MakeText(this, message).Show();
        }



        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    string url = e.Argument.ToString();
        //    Image image = m_Service.GetMsgImage(url);
        //    int Width = image.Width;
        //    int Height = image.Height;//2
        //    Image result = null;
        //    if (image.Width > 500 || image.Height > 740)
        //    {
        //        result = GetSmall(image, 2);
        //    }
        //    else
        //    {
        //        result = image;
        //    }
        //    e.Result = result;
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Result == null)
        //    {
        //        label1.Visible = true;
        //        pbImage.Visible = false;
        //        return;
        //    }
        //    Image image = e.Result as Image;
        //    this.pbImage.Image = image;
        //    this.Width = image.Width;
        //    this.Height = image.Height + 60 + 30;
        //    //居中

        //    int x = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
        //    int y = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
        //    this.Location = new Point(x,y);        
        //}


    }
}
