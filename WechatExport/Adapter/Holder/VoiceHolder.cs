using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChat.Utils;
using WechatExport;
using WechatExport.Properties;
using WinForm.UI.Controls;

namespace WeChat.Adapter.Holder
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/22 14:18:29
    * 说明：语音
    * ==========================================================
    * */
    public class VoiceHolder
    {
        private static Color TriangleColor = Color.FromArgb(158, 234, 106);
        private const int Height = 24;
        private static Font font;
        static Bitmap animatedImage = Resources.img_play_voice;
        static bool currentlyAnimating = false;

        static Rectangle bounds = Rectangle.Empty;

        static Control owner;


        static EventHandler ImageEvent = new EventHandler(OnFrameChanged);

        static VoiceHolder()
        {
            font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        public static void AnimateImage()
        {
            if (!currentlyAnimating)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(animatedImage, ImageEvent);
                currentlyAnimating = true;
            }
        }

        private static void OnFrameChanged(object sender, EventArgs e)
        {
            if (bounds != Rectangle.Empty)
                Invalidate();
        }

        private static void Invalidate()
        {
            owner.Invalidate(bounds);
        }

        internal static void DrawItem(WeChatMessage msg, ViewHolder holder, Graphics g, Control owner)
        {
            if (holder.isMouseClick)
            {
                bounds = holder.bounds;
            }
            VoiceHolder.owner = owner;
            float Duration = msg.VoiceLength / 1000;//长度
            holder.UserData = msg;
            bool IsSend = msg.IsSend;
            //if (IsSend)
            //{
            //    animatedImage = Resources.img_play_voice;
            //}
            //else
            //{
            //    animatedImage = Resources.img_play_voice_mime;
            //}

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle point = holder.bounds;
            Point[] points = TextHolder.GetPolygon(point, IsSend);
            int Width = 100;
            using (SolidBrush brushes = new SolidBrush(TriangleColor))
            {
                g.FillPolygon(brushes, points);

                Rectangle rect = Rectangle.Empty;
                if (IsSend)
                {
                    rect = new Rectangle(holder.bounds.Width - 95 - Width, point.Y + 10, Width + 15, Height + 15);
                }
                else
                {
                    rect = new Rectangle(70, point.Y + 10, Width + 15, Height + 15);
                }
                GraphicsUtils.FillRoundRectangle(g, brushes, rect, 4);
                ImageAnimator.UpdateFrames();
                g.DrawImage(animatedImage, rect.Location.X + Width / 2, rect.Location.Y + 7);

                brushes.Color = Color.FromArgb(153, 153, 153);
                if (IsSend)
                {
                    g.DrawString(Duration + "\"", font, brushes, holder.bounds.X+ rect.Location.X-40  , rect.Location.Y + 20);
                }
                else
                    g.DrawString(Duration + "\"", font, brushes, rect.Location.X + Width + 30, rect.Location.Y + 20);
            }

            holder.bounds.Height = Height + 20;
            g.SmoothingMode = SmoothingMode.None;
        }


        public static void Play()
        {
            if (!currentlyAnimating)
            {
                AnimateImage();
            }
        }

        public static void Stop()
        {
            bounds = Rectangle.Empty;
            currentlyAnimating = false;
            ImageAnimator.StopAnimate(animatedImage, ImageEvent);
        }

    }
}
