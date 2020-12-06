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
    * 创建时间：2018/01/18 11:22:51
    * 说明：
    * ==========================================================
    * */
    public class ImageHolder
    {
        internal static void DrawItem(WeChatMessage msg, ViewHolder holder, Graphics g)
        {
            string path = msg.fileName;
            bool IsSend = msg.IsSend;
            if (!File.Exists(path))
            {
                TextHolder.DrawItem("获取图片失败", holder, g);
                return;
            }
            Image image = Image.FromFile(path);
            Point point = holder.bounds.Location;
            Rectangle rec = new Rectangle();
            rec.Width = image.Width;
            rec.Height = image.Height;
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
