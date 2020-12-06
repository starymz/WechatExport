using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WechatExport
{

    public interface WeChatInterface
    {
        List<WeChatConcat> GetFriends();
        WeChatConcat GetUserInfo();

        List<WeChatConcat> GetContacts();

        List<WeChatMessage> GetMessage(string talker);
    }

    public class WeChatMessage
    {
        public string FromContactID { get; set; }
        public string ToContactD;
        public string Content { get; set; }
        public int MsgType { get; set; }
        public bool IsSend { get; set; }
        public string fileName { get; set; }
        public string FileSize { get; set; }

        public string MsgId { get; set; }
        public long VoiceLength { get; set; }

        public WeChatConcat Remote { get; set; }
        public WeChatConcat Mime { get; set; }

    }

    public class WeChatConcat
    {
        public string Uin { get; set; }
        public string UsrName { get; set; }
        public string NickName { get; set; }
        public string RemarkName { get; set; }
        public Image HeadImage { get; set; }

        public int MessageCount { get; set; }
        public DateTime? LastMessageTime { get; set; }
    }

    public class Friend
    {
        public string UsrName;
        public string NickName;
        public string ConRemark;
        public string ConChatRoomMem;
        public string dbContactChatRoom;
        public string ConStrRes2;
        public string Portrait;
        public string PortraitHD;
        public bool PortraitRequired;

        public string alias = "";
        public void ProcessConStrRes2()
        {
            var match = Regex.Match(ConStrRes2, @"<alias>(.*?)<\/alias>");
            alias = match.Success ? match.Groups[1].Value : null;
            match = Regex.Match(ConStrRes2, @"<HeadImgUrl>(.+?)<\/HeadImgUrl>");
            if (match.Success) Portrait = match.Groups[1].Value;
            match = Regex.Match(ConStrRes2, @"<HeadImgHDUrl>(.+?)<\/HeadImgHDUrl>");
            if (match.Success) PortraitHD = match.Groups[1].Value;
        }
        public string DisplayName()
        {
            if (ConRemark != null && ConRemark != "") return ConRemark;
            if (NickName != null && NickName != "") return NickName;
            return ID();
        }
        public string ID()
        {
            if (alias != null && alias != "") return alias;
            if (UsrName != null && UsrName != "") return UsrName;
            return null;
        }
        public string FindPortrait()
        {
            PortraitRequired = true;
            if (Portrait != null && Portrait != "") return ID() + ".jpg";
            return "DefaultProfileHead@2x.png";
        }
        public string FindPortraitHD()
        {
            PortraitRequired = true;
            if (PortraitHD != null && PortraitHD != "") return ID() + "_hd.jpg";
            return FindPortrait();
        }

        public string GetAndroidUserAvatar()
        {
            string md5 = Md5Helper.CreateMD5(UsrName);
            return Path.Combine(md5.Substring(0, 2), md5.Substring(2, 2), "user_" + md5 + ".png");
        }
    }
    public class DownloadTask : IEquatable<DownloadTask>
    {
        public string url;
        public string filename;

        public bool Equals(DownloadTask other)
        {
            return url == other.url && filename == other.filename;
        }

        public override bool Equals(object other)
        {
            return other is DownloadTask && Equals((DownloadTask)other);
        }

        public override int GetHashCode()
        {
            return url.GetHashCode() * 53 + filename.GetHashCode();
        }
    }

    public class DisplayItem
    {
        public string pic { get; set; }
        public string text { get; set; }
        public string link { get; set; }
    }
    class BaseWeChat
    {
        public static void MakeListHTML(List<DisplayItem> list, string path)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">");
                sw.WriteLine(@"<html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /><title>微信聊天记录</title></head>");
                sw.WriteLine(@"<body><table width=""400"" border=""0"" style=""font-size:12px;border-collapse:separate;border-spacing:0px 20px;word-break:break-all;table-layout:fixed;word-wrap:break-word;"" align=""center"">");
                foreach (var item in list)
                {
                    sw.Write(@"<tr><td width=""100"" align=""center""><img src=""" + item.pic + @""" style=""float:left;max-width:60px;max-height:60px"" /></td>");
                    sw.WriteLine(@"<td><a href=""" + item.link + @""">" + item.text + @"</a></td></tr>");
                }
                sw.WriteLine(@"</body></html>");
            }
        }

        public static bool saveFriends(string path, Dictionary<string, Friend> friends, int maxCount, out int count)
        {
            bool succ = false;
            count = 0;
            try
            {
                HashSet<Friend> friendLst = new HashSet<Friend>();
                foreach (Friend friend in friends.Values)
                {
                    if (friend.UsrName.EndsWith("@chatroom") || friend.UsrName.EndsWith("@app"))
                        continue;

                    friendLst.Add(friend);
                }
                using (var sw = new StreamWriter(path))
                {
                    sw.WriteLine("username,nickname,conRemark");
                    foreach (Friend friend in friendLst)
                    {
                        sw.WriteLine("{0},{1},{2}", friend.UsrName, friend.NickName, friend.ConRemark);
                        count++;
                        if (count > maxCount)
                            break;
                    }
                }
                succ = true;
            }
            catch (Exception) { }

            return succ;

        }
    }
}
