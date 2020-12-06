using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WeChat.Utils;
using WechatExport;
using WinForm.UI.Controls;

namespace WeChat.Adapter.Holder
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/17 14:30:19
    * 说明：
    * ==========================================================
    * */
    public class TextHolder
    {
        private static Font font;
        private static Color backColor = Color.White;
        private static Color TriangleColor = Color.FromArgb(158, 234, 106);
        private static Color TextColor = Color.FromArgb(35, 35, 35);
        private static StringFormat StringFormat;


        static TextHolder()
        {
            font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            StringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center

            };

        }

        internal static void DrawItem(string message, ViewHolder holder, Graphics g)
        {
            WeChatMessage msg = new WeChatMessage() { Content = message };
            DrawItem(msg, holder, g);
        }


        internal static void DrawItem(WeChatMessage msg, ViewHolder holder, Graphics g)
        {
            string content = msg.Content;
            bool IsSend = msg.IsSend;

            content = content.Replace("&lt;", "<").Replace("&gt;", ">");
            Size size = GraphicsUtils.GetStringWidth(content, g, font, 350);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle point = holder.bounds;
            Point[] points = GetPolygon(point, IsSend);
            using (SolidBrush brushes = new SolidBrush(TriangleColor))
            {
                g.FillPolygon(brushes, points);
                Rectangle rect = Rectangle.Empty;
                if (IsSend)
                {
                    rect = new Rectangle(holder.bounds.Width - 95 - size.Width, point.Y + 10, size.Width + 15, size.Height + 15);
                }
                else
                {
                    rect = new Rectangle(70, point.Y + 10, size.Width + 15, size.Height + 15);
                }
                GraphicsUtils.FillRoundRectangle(g, brushes, rect, 4);
                List<string> emojis = IsEmoji(content);
                if (emojis.Count > 0)
                {
                    DrawEmoji(g,content, emojis, rect);
                }
                else
                {
                    brushes.Color = TextColor;
                    g.DrawString(content, font, brushes, rect, StringFormat);
                }

                holder.bounds.Height = rect.Height + 20;
            }
            g.SmoothingMode = SmoothingMode.None;
        }

        private static void DrawEmoji(Graphics g,string content, List<string> emojis, Rectangle rect)
        {
            Point point = new Point();
            point.X = rect.X+5;
            point.Y = rect.Y + 4;
            foreach (string item in emojis)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                Image image = EmojiTools.GetBitmap(item);
                g.DrawImageUnscaled(image, point);
                point.X += image.Width;
            }
            
        }

        private static List<string> IsEmoji(string content)
        {
            List<string> emojis = EmojiTools.IsContainsEmoji(content);
            return emojis;
        }


        public static Point[] GetPolygon(Rectangle point, bool IsSend)
        {
            Point[] points = new Point[3];
            int x = 0, y = 0;
            if (IsSend)
            {
                x = point.Width - 80;
                y = point.Y + 15;
                points[0] = new Point(x, y);

                x = point.Width - 75;
                y = y + 3;
                points[1] = new Point(x, y);

                x = point.Width - 80;
                y = y + 3;
                points[2] = new Point(x, y);
            }
            else
            {
                x = 70;
                y = point.Y + 15;
                points[0] = new Point(x, y);

                x = 65;
                y = y + 3;
                points[1] = new Point(x, y);

                x = 70;
                y = y + 3;
                points[2] = new Point(x, y);
            }
            return points;
        }
    }
}
