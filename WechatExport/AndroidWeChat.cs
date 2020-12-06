using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace WechatExport
{
    public class AndroidWeChatUser
    {
        private AndroidWeChatInterface weChatInterface;
        public string uid { get; set; }
        public string userBaseDir { get; set; }
        public string resBaseDir { get; set; }

        public string userSaveDir { get; set; }

        private bool hasRes;

        public Friend myself { get; set; }
        public Dictionary<string, Friend> friends { get; set; }
        private Dictionary<string, Dictionary<string, string>> chatRoomUserDict;
        private SQLiteConnection dbConn;

        public AndroidWeChatUser(AndroidWeChatInterface weChatInterface, string uid)
        {
            this.weChatInterface = weChatInterface;
            this.uid = uid;
            this.hasRes = false;
        }
        public void Init()
        {
            InitUserBaseDir();
            InitResBaseDir();
        }


        public bool CopyResource()
        {
            if (string.IsNullOrEmpty(userSaveDir))
            {
                return false;
            }
            Utils.CopyDir(Path.Combine(userBaseDir, "avatar"), Path.Combine(userSaveDir, "avatar"));
            if (!string.IsNullOrEmpty(resBaseDir))
            {
                Utils.CopyDir(Path.Combine(resBaseDir, "image2"), Path.Combine(userSaveDir, "image2"));

                Directory.CreateDirectory(Path.Combine(userSaveDir, "voice2"));
                //Utils.CopyDir(Path.Combine(resBaseDir, "voice2"), Path.Combine(userSaveDir, "voice2"));
            }
            return true;
        }
        public Friend GetFriend(string usrName)
        {
            if(friends!= null)
            {
                return friends[usrName];
            }
            return null;
        }
        private void InitUserBaseDir()
        {
            string tmp = "mm" + uid;
            userBaseDir =  Path.Combine(weChatInterface.currentBackup, "MicroMsg", Md5Helper.CreateMD5(tmp).ToLower());
        }

        private void InitResBaseDir()
        {
            resBaseDir = null;
            if (string.IsNullOrEmpty(weChatInterface.resourceBackup))
            {
                return;
            }
            bool flag = false;
            string accountPath = Path.Combine(userBaseDir, "account.bin");
            if (File.Exists(accountPath))
            {
                using(FileStream fileStream = new FileStream(accountPath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    byte[] accountBytes = reader.ReadBytes((int)fileStream.Length);
                    if (accountBytes.Length == 4096 || accountBytes.Length == 4112)
                    {
                        byte[] uidBytes = Encoding.ASCII.GetBytes(uid);
                        byte[] allBytes = new byte[4096 + uid.Length];
                        Buffer.BlockCopy(accountBytes, 0, allBytes, 0, 4096);
                        Buffer.BlockCopy(uidBytes, 0, allBytes, 4096, uidBytes.Length);
                        string uiPath = Md5Helper.CreateMD5(allBytes);
                        string fullPath = Path.Combine(weChatInterface.resourceBackup, "MicroMsg", uiPath);
                        if (Directory.Exists(fullPath))
                        {
                            flag = true;
                            resBaseDir = fullPath;
                        }
                    }
                }
            }

            if (!flag)
            {
                string tmp = "mm" + uid;
                string fullPath = Path.Combine(weChatInterface.resourceBackup, "MicroMsg", Md5Helper.CreateMD5(tmp).ToLower());
                if (Directory.Exists(fullPath))
                {
                    resBaseDir = fullPath;
                }
            }

            if (!string.IsNullOrEmpty(resBaseDir))
            {
                hasRes = true;
            }
        }

        private string GetDBPassword(string imei)
        {
            string tmp = imei + uid;
            return Md5Helper.CreateMD5(tmp).Substring(0, 7).ToLower();
        }


        public bool OpenMMSqlite()
        {
            bool succ = false;
            SQLiteConnection conn = null;
            List<string> imeis = new List<string>();
            if (!string.IsNullOrEmpty(weChatInterface.imei))
            {
                imeis.Add(weChatInterface.imei);
            }
            else
            {
                foreach(string str in weChatInterface.imeis){
                    imeis.Add(str);
                }
            }
            foreach (string imei in imeis)
            {
                try
                {
                    string password = GetDBPassword(imei);
                    string dbPath = Path.Combine(userBaseDir, "EnMicroMsg.db");
                    SQLiteConnectionString options2 = new SQLiteConnectionString(dbPath, true,
                                                           key: password,
                                                           postKeyAction: db => db.Execute("PRAGMA cipher_compatibility = 1;"));
                    conn = new SQLiteConnection(options2);
                    int count = conn.ExecuteScalar<int>("SELECT count(*) FROM sqlite_master WHERE type = ?", "table");
                    if (count > 0)
                    {
                        succ = true;
                        dbConn = conn;
                        weChatInterface.imei = imei;
                        break;
                    }
                }
                catch (Exception) { }
            }
            return succ;
        }

        public  bool saveFriends(int maxCount, out int count)
        {
            bool succ = false;
            count = 0;
            try
            {
                string path = Path.Combine(userSaveDir, "好友列表.txt");
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



        public bool GetUserBasics()
        {
            Friend friend = new Friend() { UsrName = uid, NickName = "我", alias = null, PortraitRequired = true };
            bool succ = false;
            try
            {
                var results = dbConn.Table<Userinfo>().ToList();
                foreach (var row in results)
                {
                    if (row.Id == 2)
                    {
                        friend.UsrName = row.Value;
                    }
                    else if (row.Id == 4)
                    {
                        friend.NickName = row.Value;
                    }
                }
                succ = true;
            }
            catch (Exception) { }
            myself = friend;
            return succ;
        }

        public bool GetFriendsDict(out int count)
        {
            count = 0;
            friends = new Dictionary<string, Friend>();

            List<Friend> friendLst = new List<Friend>();
            bool succ = false;
            try
            {
                var results = dbConn.Table<Rcontact>().ToList();
                foreach (var row in results)
                {
                    var friend = new Friend();
                    friend.UsrName = row.Username;
                    friend.ConRemark = row.ConRemark;
                    friend.NickName = row.Nickname;

                    friendLst.Add(friend);
                }

                foreach (var friend in friendLst)
                {
                    count++;
                    friends.AddSafe(friend.UsrName, friend);
                }

                succ = true;
            }
            catch (Exception) { }

            return succ;
        }

        public bool GetChatSessions(out List<string> sessions)
        {
            bool succ = false;
            sessions = new List<string>();
            try
            {
                List<MessageCount> talkers = dbConn.Query<MessageCount>("select talker as Talker,count(1) as MsgCount from message GROUP BY TALKER");
                foreach (var talker in talkers)
                {
                    sessions.Add(talker.Talker);
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool GetChatRoomMember(out int count)
        {
            bool succ = false;
            count = 0;
            chatRoomUserDict = new Dictionary<string, Dictionary<string, string>>();
            try
            {
                var chatrooms = dbConn.Table<Chatroom>().ToList();
                foreach (var chatroom in chatrooms)
                {
                    Dictionary<string, string> roomMembers = new Dictionary<string, string>();
                    var memberlist = chatroom.Memberlist;
                    var displayname = chatroom.Displayname;

                    string[] userLst = memberlist.Split(';');
                    string[] displayLst = displayname.Split('、');
                    for (int i = 0; i < userLst.Length; i++)
                    {
                        string user = userLst[i];
                        string name = displayLst[i];
                        roomMembers.Add(user, name);
                    }
                    chatRoomUserDict.Add(chatroom.Chatroomname, roomMembers);
                    count++;
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }


        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }


        private string GetVoicePath(string imgPath)
        {
            if (!string.IsNullOrEmpty(imgPath))
            {
                string md5 = Md5Helper.CreateMD5(imgPath);
                string path = Path.Combine(resBaseDir,"voice2", md5.Substring(0, 2), md5.Substring(2, 2), string.Format("msg_{0}.amr", imgPath));
                if (File.Exists(path))
                {
                    return path;
                }
            }
            return null;
        }

        private bool GetImagePath(string imgPath,out string thumPath,out string bigPath)
        {
            bool succ = false;
            thumPath = null;
            bigPath = null;
            string[] imgs = imgPath.Split('_');
            if (imgs.Length > 0)
            {
                string img = imgs[imgs.Length - 1];
                string path = Path.Combine(img.Substring(0, 2), img.Substring(2, 2), string.Format("th_{0}", img));
                if (File.Exists(Path.Combine(userSaveDir, "image2", path)))
                {
                    succ = true;
                    thumPath = path;
                }
                path = Path.Combine(img.Substring(0, 2), img.Substring(2, 2), string.Format("th_{0}hd", img));
                if (File.Exists(Path.Combine(userSaveDir, "image2", path)))
                {
                    succ = true;
                    bigPath = path;
                }
            }
            return succ;
        }

        private string GetUserAvatar(string userName)
        {
            string md5 = Md5Helper.CreateMD5(userName);
            return Path.Combine(md5.Substring(0, 2), md5.Substring(2, 2), "user_" + md5 + ".png");
        }

        public bool SaveHtmlRecord(string talker, int maxCount, out int count, out HashSet<DownloadTask> emojidown)
        {
            bool succ = false;
            emojidown = new HashSet<DownloadTask>();
            count = 0;
            try
            {
                Friend friend = friends[talker];
                Dictionary<string, string> chatremark = null;
                if (talker.EndsWith("@chatroom") && chatRoomUserDict != null)
                {
                    if (chatRoomUserDict.ContainsKey(talker))
                        chatremark = chatRoomUserDict[talker];
                }
                var messages = dbConn.Table<Message>().Where(t => t.Talker == talker).OrderByDescending(t => t.CreateTime).ToList();

                using (var sw = new StreamWriter(Path.Combine(userSaveDir, talker + ".html")))
                {
                    sw.WriteLine(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">");
                    sw.WriteLine(@"<html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /><title>" + friend.DisplayName() + " - 微信聊天记录</title></head>");
                    sw.WriteLine(@"<body><table width=""600"" border=""0"" style=""font-size:12px;border-collapse:separate;border-spacing:0px 20px;word-break:break-all;table-layout:fixed;word-wrap:break-word;"" align=""center"">");
                    foreach (var msg in messages)
                    {
                        try
                        {
                            var unixtime = msg.CreateTime;
                            unixtime = unixtime / 1000;
                            var message = msg.Content;
                            var des = msg.IsSend;
                            var type = msg.Type;
                            if (type == 10000)
                            {
                                sw.WriteLine(@"<tr><td width=""80"">&nbsp;</td><td width=""100"">&nbsp;</td><td>系统消息: " + message + @"</td></tr>");
                                continue;
                            }
                            var ts = "";
                            if (talker.EndsWith("@chatroom"))
                            {
                                if (des == 1)
                                {
                                    var txtsender = myself.DisplayName();
                                    if (chatremark.ContainsKeySafe(myself.UsrName)) txtsender = chatremark[myself.UsrName];
                                    else if (chatremark.ContainsKeySafe(myself.alias)) txtsender = chatremark[myself.alias];
                                    ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/" + myself.GetAndroidUserAvatar() + @""" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
                                }
                                else
                                {
                                    var enter = message.IndexOf(":\n");
                                    if (enter > 0 && enter + 2 < message.Length)
                                    {
                                        var txtsender = message.Substring(0, enter);
                                        var senderid = txtsender;
                                        message = message.Substring(enter + 2);
                                        if (chatremark.ContainsKeySafe(txtsender)) txtsender = chatremark[txtsender];
                                        else if (friends.ContainsKeySafe(txtsender)) txtsender = friends[txtsender].DisplayName();
                                        if (friends.ContainsKeySafe(senderid)) ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/" + GetUserAvatar(senderid) + @""" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
                                        else ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/DefaultProfileHead@2x.png"" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
                                    }
                                    else ts += @"<tr><td width=""80"" align=""center"">&nbsp;</td>";
                                }
                            }
                            else
                            {
                                if (des == 1) ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/" + myself.GetAndroidUserAvatar() + @""" width=""50"" height=""50"" /><br />" + myself.DisplayName() + @"</td>";
                                else if (friend != null) ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/" + friend.GetAndroidUserAvatar() + @""" width=""50"" height=""50"" /><br />" + friend.DisplayName() + @"</td>";
                                else ts += @"<tr><td width=""80"" align=""center""><img src=""avatar/DefaultProfileHead@2x.png"" width=""50"" height=""50"" /><br />" + friend.DisplayName() + @"</td>";
                            }
                            if (type == 34)
                            {
                                var voicelen = -1;
                                string[] audioMsg = message.Split(':');
                                if (audioMsg.Length == 3) voicelen = int.Parse(audioMsg[1]);

                                if (hasRes)
                                {
                                    var audiosrc = GetVoicePath(msg.ImgPath);
                                    if (audiosrc == null)
                                    {
                                        message = voicelen == -1 ? "[语音]" : "[语音 " + Utils.DisplayTime(voicelen) + "]";
                                    }
                                    else
                                    {
                                        Utils.ShellWait("lib\\silk_v3_decoder.exe", "\"" + audiosrc + "\" 1.pcm");
                                        Utils.ShellWait("lib\\lame.exe", "-r -s 24000 --preset voice 1.pcm \"" + Path.Combine(userSaveDir, "voice2", msg.MsgId + ".mp3") + "\"");
                                        message = "<audio controls><source src=\"voice2/" + msg.MsgId + ".mp3\" type=\"audio/mpeg\"><a href=\"voice2" + msg.MsgId + ".mp3\">播放</a></audio>";
                                    }
                                }
                                else{
                                    message = voicelen == -1 ? "[语音]" : "[语音 " + Utils.DisplayTime(voicelen) + "]";
                                }


                            }
                            else if (type == 47)
                            {
                                var match = Regex.Match(message, @"cdnurl ?= ?""(.+?)""");
                                if (match.Success)
                                {
                                    var localfile = Utils.RemoveCdata(match.Groups[1].Value);
                                    var match2 = Regex.Match(localfile, @"\/(\w+?)\/\w*$");
                                    if (!match2.Success) localfile = Utils.RandomString(10);
                                    else localfile = match2.Groups[1].Value;
                                    emojidown.Add(new DownloadTask() { url = match.Groups[1].Value, filename = localfile + ".gif" });
                                    message = "<img src=\"Emoji/" + localfile + ".gif\" style=\"max-width:100px;max-height:60px\" />";
                                }
                                else message = "[表情]";
                            }
                            else if (type == 62)
                            {
                                message = "[视频]";
                            }
                            else if (type == 50) message = "[视频/语音通话]";
                            else if (type == 3)
                            {
                                if(hasRes && GetImagePath(msg.ImgPath,out string thumPath, out string bigPath))
                                {
                                    if (thumPath!= null && bigPath != null) message = "<a href=\"image2/" + bigPath + "\"><img src=\"image2/" + thumPath + "\" style=\"max-width:100px;max-height:60px\" /></a>";
                                    else if (thumPath != null) message = "<img src=\"image2/" + thumPath + "\" style=\"max-width:100px;max-height:60px\" />";
                                    else if (bigPath != null) message = "<img src=\"image2/" + bigPath + "\" style=\"max-width:100px;max-height:60px\" />";

                                }
                                else message = "[图片]";
                            }
                            else if (type == 48)
                            {
                                var match1 = Regex.Match(message, @"x ?= ?""(.+?)""");
                                var match2 = Regex.Match(message, @"y ?= ?""(.+?)""");
                                var match3 = Regex.Match(message, @"label ?= ?""(.+?)""");
                                if (match1.Success && match2.Success && match3.Success) message = "[位置 (" + Utils.RemoveCdata(match2.Groups[1].Value) + "," + Utils.RemoveCdata(match1.Groups[1].Value) + ") " + Utils.RemoveCdata(match3.Groups[1].Value) + "]";
                                else message = "[位置]";
                            }
                            else if (type == 49)
                            {
                                if (message.Contains("<type>2001<")) message = "[红包]";
                                else if (message.Contains("<type>2000<")) message = "[转账]";
                                else if (message.Contains("<type>17<")) message = "[实时位置共享]";
                                else if (message.Contains("<type>6<")) message = "[文件]";
                                else
                                {
                                    var match1 = Regex.Match(message, @"<title>(.+?)<\/title>");
                                    var match2 = Regex.Match(message, @"<des>(.*?)<\/des>");
                                    var match3 = Regex.Match(message, @"<url>(.+?)<\/url>");
                                    var match4 = Regex.Match(message, @"<thumburl>(.+?)<\/thumburl>");
                                    if (match1.Success && match3.Success)
                                    {
                                        message = "";
                                        if (match4.Success) message += "<img src=\"" + Utils.RemoveCdata(match4.Groups[1].Value) + "\" style=\"float:left;max-width:100px;max-height:60px\" />";
                                        message += "<a href=\"" + Utils.RemoveCdata(match3.Groups[1].Value) + "\"><b>" + Utils.RemoveCdata(match1.Groups[1].Value) + "</b></a>";
                                        if (match2.Success) message += "<br />" + Utils.RemoveCdata(match2.Groups[1].Value);
                                    }
                                    else message = "[链接]";
                                }
                            }
                            else if (type == 42)
                            {
                                var match1 = Regex.Match(message, "nickname ?= ?\"(.+?)\"");
                                var match2 = Regex.Match(message, "smallheadimgurl ?= ?\"(.+?)\"");
                                if (match1.Success)
                                {
                                    message = "";
                                    if (match2.Success) message += "<img src=\"" + Utils.RemoveCdata(match2.Groups[1].Value) + "\" style=\"float:left;max-width:100px;max-height:60px\" />";
                                    message += "[名片] " + Utils.RemoveCdata(match1.Groups[1].Value);
                                }
                                else message = "[名片]";
                            }
                            else message = Utils.SafeHTML(message);

                            ts += @"<td width=""100"" align=""center"">" + FromUnixTime(unixtime).ToLocalTime().ToString().Replace(" ", "<br />") + "</td>";
                            ts += @"<td>" + message + @"</td></tr>";
                            sw.WriteLine(ts);
                            count++;
                            if (count > maxCount)
                                break;
                        }
                        catch (Exception) { }

                    }
                    sw.WriteLine(@"</body></html>");
                    succ = true;
                }
            }
            catch (Exception) { }
            return succ;
        }

        public bool SaveTextRecord(string talker, int maxCount, out int count)
        {
            bool succ = false;
            count = 0;
            try
            {
                string path = Path.Combine(userSaveDir, talker + ".txt");
                Friend friend = friends[talker];
                Dictionary<string, string> chatremark = null;
                if (talker.EndsWith("@chatroom") && chatRoomUserDict != null)
                {
                    if (chatRoomUserDict.ContainsKey(talker))
                        chatremark = chatRoomUserDict[talker];
                }

                var messages = dbConn.Table<Message>().Where(t => t.Talker == talker).OrderByDescending(t => t.CreateTime).ToList();
                using (var sw = new StreamWriter(path))
                {
                    foreach (var msg in messages)
                    {
                        try
                        {
                            var unixtime = msg.CreateTime;
                            unixtime = unixtime / 1000;
                            var message = msg.Content;
                            var des = msg.IsSend;
                            var type = msg.Type;
                            var txtsender = (type == 10000 ? "[系统消息]" : (des == 0 ? friend.DisplayName() : myself.DisplayName()));
                            if (talker.EndsWith("@chatroom") && type != 10000 && des == 0)
                            {
                                var enter = message.IndexOf(":\n");
                                if (enter > 0 && enter + 2 < message.Length)
                                {
                                    txtsender = message.Substring(0, enter);
                                    message = message.Substring(enter + 2);
                                    if (chatremark.ContainsKey(txtsender))
                                        txtsender = chatremark[txtsender];

                                }
                            }
                            if (talker.EndsWith("@chatroom") && des == 1)
                            {
                                if (chatremark.ContainsKey(myself.UsrName))
                                    txtsender = chatremark[myself.UsrName];
                            }
                            if (type == 34) message = "[语音]";
                            else if (type == 47) message = "[表情]";
                            else if (type == 62) message = "[小视频]";
                            else if (type == 50) message = "[视频/语音通话]";
                            else if (type == 3) message = "[图片]";
                            else if (type == 48) message = "[位置]";
                            else if (type == 49)
                            {
                                if (message.Contains("<type>2001<") || message.Contains("<type><![CDATA[2001]]><")) message = "[红包]";
                                else if (message.Contains("<type>2000<") || message.Contains("<type><![CDATA[2000]]><")) message = "[转账]";
                                else if (message.Contains("<type>17<") || message.Contains("<type><![CDATA[17]]><")) message = "[实时位置共享]";
                                else if (message.Contains("<type>6<") || message.Contains("<type><![CDATA[6]]><")) message = "[文件]";
                                else message = "[链接]";
                            }
                            else if (type == 42) message = "[名片]";

                            sw.WriteLine(txtsender + "(" + FromUnixTime(unixtime).ToLocalTime().ToString() + ")" + ": " + message);
                            count++;
                            if (count > maxCount)
                                break;

                        }
                        catch (Exception) { }
                    }
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }
    }

    public class AndroidWeChatInterface
    {
        public string currentBackup{ get; }
        public string resourceBackup{ get; }
        public List<AndroidWeChatUser> users { get; set; }
        public List<string> imeis { get; set; }
        public string imei { get; set; }

        public AndroidWeChatInterface(string currentBackup)
        {
            this.currentBackup = currentBackup;
            this.resourceBackup = null;
        }

        public AndroidWeChatInterface(string currentBackup,string resourceBackup)
        {
            this.currentBackup = currentBackup;
            this.resourceBackup = resourceBackup;
        }

        public void Init()
        {
            List<string> uids = FindUIDs();
            users = new List<AndroidWeChatUser>();
            foreach (string uid in uids)
            {
                var user = new AndroidWeChatUser(this, uid);
                users.Add(user);
            }
            imeis = GetImeis();
            imei = null;
        }

        private  List<string> FindUIDs()
        {
            var UIDs = new HashSet<string>();
            string filename = Path.Combine(currentBackup, "shared_prefs", "app_brand_global_sp.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNodeList nodelist = xmlDoc.SelectNodes("/map/set");
            foreach (XmlNode xn in nodelist)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("name") == "uin_set")
                {
                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点
                    foreach (XmlNode xn1 in nls)//遍历
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型
                        if (xe2.Name == "string")//如果找到
                        {
                            UIDs.Add(xe2.InnerText);
                        }
                    }
                }
            }
            return UIDs.ToList();
        }

        private bool FindInBinaryByte(byte[] str, byte[] pattern,out int index)
        {
            bool succ = false;
            index = -1;
            for(int i = 0; i < str.Length - pattern.Length; i++)
            {
                for(int j = 0; j < pattern.Length; j++)
                {
                    if (str[i + j] != pattern[j])
                        break;
                    if (j == pattern.Length - 1)
                    {
                        succ = true;
                        index = i;
                        return succ;
                    }
                        
                }
            }
            return succ;
        }

        private List<string> GetImeis()
        {
            HashSet<string> imeis = new HashSet<string>();

            string keyInfoPath = Path.Combine(currentBackup, "files", "KeyInfo.bin");
            if (File.Exists(keyInfoPath))
            {
                FileStream fileStream = new FileStream(keyInfoPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fileStream);
                byte[] buffer = reader.ReadBytes((int)fileStream.Length);
                byte[] keys = Encoding.Default.GetBytes("_wEcHAT_");
                string decryptStr = EncryptionHelper.DecryptRC4wq(buffer, keys);
                if (!string.IsNullOrEmpty(decryptStr))
                {
                    string[] lines = decryptStr.Split('\n');
                    foreach(string line in lines)
                    {
                        if(!string.IsNullOrEmpty(line))
                            imeis.Add(line);
                    }
                }
            }

            string xmlFile = Path.Combine(currentBackup, "shared_prefs", "beacontbs_DENGTA_META.xml");
            if (File.Exists(xmlFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFile);
                XmlNodeList nodelist = xmlDoc.SelectNodes("/map");
                foreach (XmlNode xn in nodelist)
                {
                    XmlElement xe = (XmlElement)xn;
                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点
                    foreach (XmlNode xn1 in nls)//遍历
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型
                        if (xe2.GetAttribute("name") == "IMEI_DENGTA")//如果找到
                        {
                            imeis.Add(xe2.InnerText);
                        }
                    }
                }
            }

            string compatibleInfoPath = Path.Combine(currentBackup, "MicroMsg", "CompatibleInfo.cfg");
            if (File.Exists(compatibleInfoPath))
            {
                byte[] keys = new byte[] { 0x01,0x02,0x74,0x00,0x0F};

                FileStream fileStream = new FileStream(compatibleInfoPath, FileMode.Open,FileAccess.Read);
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);

                if (FindInBinaryByte(buffer, keys, out int index))
                {
                    string imei = Encoding.ASCII.GetString(buffer, index + keys.Length, 15);
                    imeis.Add(imei);
                }
            }

            imeis.Add("1234567890ABCDEF");

            return imeis.ToList();
        }

        
    }
}
