using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatExport;
using WinForm.UI.Controls;

namespace WeChat.Adapter.Holder
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/17 14:35:32
    * 说明：表情包 47
    * ==========================================================
    * */
    public class ClownHolder
    {
        internal static void DrawItem(WeChatMessage msg, ViewHolder holder, Graphics g)
        {
            string path = msg.fileName;
            bool IsSend = msg.IsSend;
            if (!File.Exists(path))
            {
                TextHolder.DrawItem("获取表情失败", holder, g);
                return;
            }
            Image image = Image.FromFile(path);

            Point point = holder.bounds.Location;
            Rectangle rec = new Rectangle();
            rec.Width = image.Width;
            rec.Height = image.Height;
            if (image.Width > 200)
            {
                rec.Width = 200;
            }
            if (image.Height > 200)
            {
                rec.Height = 200;
            }
            rec.Y = point.Y + 10;
            if (IsSend)
            {
                rec.X = holder.bounds.Width - 95 - rec.Width;
            }
            else
            {
                rec.X = 70;
            }
            g.DrawImage(image, rec, new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            holder.bounds.Height = rec.Height + 10;
            image.Dispose();
        }
    }
}
