using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatExport;
using WechatExport.Properties;
using WinForm.UI.Controls;

namespace WeChat.Adapter
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/17 13:29:28
    * 说明：好友列表
    * ==========================================================
    * */
    public class RContactAdapter : BaseAdapter<WeChatConcat>
    {
        private Image defaultImage;
        private Font font;
        private Color SubItemSelectColor = Color.FromArgb(198, 197, 197);
        private Color ItemMouseOnColor = Color.FromArgb(205, 209, 216);

        public RContactAdapter()
        {
            font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            defaultImage = Resources.default_head;
        }

        public override void GetView(int position, ViewHolder holder, Graphics g)
        {
            WeChatConcat item = GetItem(position);
            holder.UserData = item;
            holder.bounds.Height = 62;
            Color bg = Color.Empty;
            if (holder.isMouseClick)
            {
                bg = SubItemSelectColor;
            }
            else if (holder.isMouseMove)
            {
                bg = ItemMouseOnColor;
            }
            if (bg != Color.Empty)
                g.FillRectangle(new SolidBrush(bg), holder.bounds);

            Point point = holder.bounds.Location;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            Rectangle rec = new Rectangle(10, point.Y + 8, 40, 40);
            if (item.HeadImage != null)
                defaultImage = item.HeadImage;
            g.DrawImage(defaultImage, rec, new Rectangle(0, 0, defaultImage.Width, defaultImage.Height), GraphicsUnit.Pixel);

            using (SolidBrush brushes = new SolidBrush(Color.Black))
            {
                g.DrawString(GetDisplayName(item), font, brushes, rec.X + rec.Width + 6, rec.Y + (15));
            }
        }

        private string GetDisplayName(WeChatConcat item)
        {
            string RemarkName = string.Empty;
            if (string.IsNullOrEmpty(item.RemarkName))
                RemarkName = item.NickName;
            else
                RemarkName = item.RemarkName;

            return StringUtils.StringTruncat(RemarkName, 9, "...");
        }

    }
}
