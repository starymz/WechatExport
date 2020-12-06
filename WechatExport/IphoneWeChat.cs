using System;
using System.Collections.Generic;
using System.IO;
using mbdbdump;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization.Plists;
using System.Xml;

namespace WechatExport
{
   
    class IphoneWeChatInterface
    {
        public Dictionary<string, string> fileDict = null;
        private string currentBackup;
        private List<MBFileRecord> files92;
        public IphoneWeChatInterface(string currentBackup, List<MBFileRecord> files92)
        {
            this.currentBackup = currentBackup;
            this.files92 = files92;
        }

        public bool OpenMMSqlite(string userBase, out SQLiteConnection conn)
        {
            bool succ = false;
            conn = null;
            try
            {
                conn = new SQLiteConnection
                {
                    ConnectionString = "data source=" + GetBackupFilePath(MyPath.Combine(userBase, "DB", "MM.sqlite")) + ";version=3"
                };
                conn.Open();
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool OpenWCDBContact(string userBase, out SQLiteConnection conn)
        {
            bool succ = false;
            conn = null;
            try
            {
                conn = new SQLiteConnection
                {
                    ConnectionString = "data source=" + GetBackupFilePath(MyPath.Combine(userBase, "DB", "WCDB_Contact.sqlite")) + ";version=3"
                };
                conn.Open();
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool GetUserBasics(string uid, string userBase, out Friend friend)
        {
            friend = new Friend() { UsrName = uid, NickName = "我", alias = null, PortraitRequired=true };
            bool succ = false;
            try
            {
                var pr = new BinaryPlistReader();
                var mmsetting = GetBackupFilePath(Path.Combine(userBase, "mmsetting.archive"));
                using (var sw = new FileStream(mmsetting, FileMode.Open))
                {
                    var dd = pr.ReadObject(sw);
                    var objs = dd["$objects"] as object[];
                    var dict = GetCFUID(objs[1] as Dictionary<object, object>);
                    if (dict.ContainsKey("UsrName") && dict.ContainsKey("NickName"))
                    {
                        friend.UsrName = objs[dict["UsrName"]] as string;
                        friend.NickName = objs[dict["NickName"]] as string;
                        succ = true;
                    }
                    if (dict.ContainsKey("AliasName"))
                    {
                        friend.alias = objs[dict["AliasName"]] as string;
                    }
                    for(int i = 0; i < objs.Length; i++)
                        if(objs[i].GetType()==typeof(string) && (objs[i] as string).StartsWith("http://wx.qlogo.cn/mmhead/"))
                        {
                            if ((objs[i] as string).EndsWith("/0")) friend.PortraitHD = (objs[i] as string);
                            else if ((objs[i] as string).EndsWith("/132")) friend.Portrait = (objs[i] as string);
                        }
                }
            }
            catch (Exception) { }
            return succ;
        }

        Dictionary<string,int> GetCFUID(Dictionary<object, object> dict)
        {
            var ret = new Dictionary<string, int>();
            foreach (var pair in dict)
            {
                if (pair.Value.GetType() != typeof(Dictionary<string, ulong>)) continue;
                var content = pair.Value as Dictionary<string, ulong>;
                foreach (var pair2 in content)
                {
                    if (pair2.Key != "CF$UID") continue;
                    ret.Add((string)pair.Key, (int)pair2.Value);
                }
            }
            return ret;
        }

        public bool GetFriends(SQLiteConnection conn, Friend myself, out List<Friend> friends)
        {
            bool succ = false;
            friends = new List<Friend>
            {
                myself
            };
            try
            {
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT Friend.UsrName,NickName,ConRemark,ConChatRoomMem,ConStrRes2 FROM Friend JOIN Friend_Ext ON Friend.UsrName=Friend_Ext.UsrName";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            try
                            {
                                var friend = new Friend
                                {
                                    UsrName = reader.GetString(0),
                                    NickName = reader.GetString(1),
                                    ConRemark = reader.GetString(2),
                                    ConChatRoomMem = reader.GetString(3),
                                    ConStrRes2 = reader.GetString(4)
                                };
                                friend.ProcessConStrRes2();
                                friends.Add(friend);
                            }
                            catch (Exception) { }
                    }
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool GetWCDBFriends(SQLiteConnection wcdb, out List<Friend> friends)
        {
            friends = new List<Friend>();
            bool succ = false;
            try
            {
                using(var cmd=new SQLiteCommand(wcdb))
                {
                    var buf = new byte[10000];
                    cmd.CommandText = "SELECT userName,dbContactRemark,dbContactChatRoom,dbContactHeadImage FROM Friend";
                    using (var reader = cmd.ExecuteReader())
                        while(reader.Read())
                            try
                            {
                                var friend = new Friend();
                                var username = reader.GetString(0);
                                var len = reader.GetBytes(1, 0, buf, 0, buf.Length);
                                var data = ReadBlob(buf, 0, (int)len);
                                friend.UsrName = username;
                                if (data.ContainsKey(0x0a)) friend.NickName = data[0x0a];
                                if (data.ContainsKey(0x12)) friend.alias = data[0x12];
                                if (data.ContainsKey(0x1a)) friend.ConRemark = data[0x1a];
                                if(username.EndsWith("@chatroom"))
                                    try
                                    {
                                        //跳过第一个字符，是因为getstring按照utf-8读取，在和二进制混合的文件中，有可能前一个字符表示与它合并，导致读不出来
                                        //（现在还不完全确定这些BLOB当中字符串的存储结构）
                                        var match2 = Regex.Match(reader.GetString(2), @"RoomData>(.*?)<\/RoomData>", RegexOptions.Singleline);
                                        if (match2.Success) friend.dbContactChatRoom = match2.Groups[1].Value;
                                    }
                                    catch (Exception) { }
                                var str = reader.GetString(3);
                                var match = Regex.Match(str, @"(ttps?:\/\/wx.qlogo.cn\/(.+?)\/132)");
                                if (match.Success) friend.Portrait = "h" + match.Groups[1].Value;
                                match = Regex.Match(str, @"(ttps?:\/\/wx.qlogo.cn\/([\w\/_]+?)\/0)");
                                if (match.Success) friend.PortraitHD = "h" + match.Groups[1].Value;
                                friends.Add(friend);
                            }
                            catch (Exception) { }
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool GetFriendsDict(SQLiteConnection conn, SQLiteConnection wcdb, Friend myself, out Dictionary<string,Friend> friends, out int count)
        {
            count = 0;
            friends = new Dictionary<string, Friend>();
            bool succ = GetFriends(conn, myself, out List<Friend> _friends);
            if (wcdb != null)
            {
                succ |= GetWCDBFriends(wcdb, out List<Friend> _friends2);
                _friends.AddRange(_friends2);
            }
            if (succ)
            {
                foreach (var friend in _friends)
                {
                    count++;
                    friends.AddSafe(friend.UsrName, friend);
                    friends.AddSafe(Md5Helper.CreateMD5(friend.UsrName), friend);
                    if (friend.alias != null && friend.alias != "" && !friends.ContainsKeySafe(friend.alias))
                    {
                        friends.AddSafe(friend.alias, friend);
                        friends.AddSafe(Md5Helper.CreateMD5(friend.alias), friend);
                    }
                }
            }
            return succ;
        }

        public bool GetChatSessions(SQLiteConnection conn, out List<string> sessions)
        {
            bool succ = false;
            sessions = new List<string>();
            try
            {
                using(var cmd=new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name";
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                            try
                            {
                                var name = reader.GetString(0);
                                var match = Regex.Match(name, @"^Chat_([0-9a-f]{32})$");
                                if (match.Success) sessions.Add(match.Groups[1].Value);
                            }
                            catch (Exception) { }
                    }
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public bool SaveTextRecord(SQLiteConnection conn, string path, string displayname, string id, Friend myself, string table, Friend friend, Dictionary<string, Friend> friends, int maxCount, out int count)
        {
            bool succ = false;
            count = 0;
            try
            {
                Dictionary<string, string> chatremark = null;
                if (id.EndsWith("@chatroom") && friend!=null && friend.dbContactChatRoom!=null)
                {
                    chatremark = ReadChatRoomRemark(friend.dbContactChatRoom);
                }
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT CreateTime,Message,Des,Type FROM Chat_" + table;
                    using (var reader = cmd.ExecuteReader())
                    using (var sw = new StreamWriter(path))
                    {
                        while (reader.Read())
                            try
                            {
                                var unixtime = reader.GetInt32(0);
                                var message = reader.GetString(1);
                                var des = reader.GetInt32(2);
                                var type = reader.GetInt32(3);
                                var txtsender = (type == 10000 ? "[系统消息]" : (des == 1 ? displayname : myself.DisplayName()));
                                if (id.EndsWith("@chatroom") && type != 10000 && des == 1)
                                {
                                    var enter = message.IndexOf(":\n");
                                    if (enter > 0 && enter + 2 < message.Length)
                                    {
                                        txtsender = message.Substring(0, enter);
                                        message = message.Substring(enter + 2);
                                        if (chatremark.ContainsKey(txtsender)) txtsender = chatremark[txtsender];
                                        else if (friends.ContainsKey(txtsender)) txtsender = friends[txtsender].DisplayName();
                                    }
                                }
                                if(id.EndsWith("@chatroom") && des == 0)
                                {
                                    if (chatremark.ContainsKeySafe(myself.UsrName)) txtsender = chatremark[myself.UsrName];
                                    else if (chatremark.ContainsKeySafe(myself.alias)) txtsender = chatremark[myself.alias];
                                }
                                if (type == 34) message = "[语音]";
                                else if (type == 47) message = "[表情]";
                                else if (type == 62) message = "[小视频]";
                                else if (type == 50) message = "[视频/语音通话]";
                                else if (type == 3) message = "[图片]";
                                else if (type == 48) message = "[位置]";
                                else if (type == 49)
                                {
                                    if (message.Contains("<type>2001<")|| message.Contains("<type><![CDATA[2001]]><")) message = "[红包]";
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

        public bool SaveHtmlRecord(SQLiteConnection conn, string userBase, string path,string displayname,string id, Friend myself, string table, Friend friend, Dictionary<string, Friend> friends,int maxCount, out int count, out HashSet<DownloadTask> emojidown)
        {
            bool succ = false;
            emojidown = new HashSet<DownloadTask>();
            count = 0;
            try
            {
                Dictionary<string, string> chatremark = new Dictionary<string, string>();
                if (id.EndsWith("@chatroom") && friend != null && friend.dbContactChatRoom != null)
                {
                    chatremark = ReadChatRoomRemark(friend.dbContactChatRoom);
                }
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT CreateTime,Message,Des,Type,MesLocalID FROM Chat_" + table;
                    using (var reader = cmd.ExecuteReader())
                    {
                        var assetsdir = Path.Combine(path, id + "_files");
                        Directory.CreateDirectory(assetsdir);
                        using (var sw = new StreamWriter(Path.Combine(path, id + ".html")))
                        {
                            sw.WriteLine(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">");
                            sw.WriteLine(@"<html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /><title>" + displayname + " - 微信聊天记录</title></head>");
                            sw.WriteLine(@"<body><table width=""600"" border=""0"" style=""font-size:12px;border-collapse:separate;border-spacing:0px 20px;word-break:break-all;table-layout:fixed;word-wrap:break-word;"" align=""center"">");
                            while (reader.Read())
                                try
                                {
                                    var unixtime = reader.GetInt32(0);
                                    var message = reader.GetString(1);
                                    var des = reader.GetInt32(2);
                                    var type = reader.GetInt32(3);
                                    var msgid = reader.GetInt32(4);
                                    if (type == 10000)
                                    {
                                        sw.WriteLine(@"<tr><td width=""80"">&nbsp;</td><td width=""100"">&nbsp;</td><td>系统消息: " + message + @"</td></tr>");
                                        continue;
                                    }
                                    var ts = "";
                                    if (id.EndsWith("@chatroom"))
                                    {
                                        if (des == 0)
                                        {
                                            var txtsender = myself.DisplayName();
                                            if (chatremark.ContainsKeySafe(myself.UsrName)) txtsender = chatremark[myself.UsrName];
                                            else if (chatremark.ContainsKeySafe(myself.alias)) txtsender = chatremark[myself.alias];
                                            ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/" + myself.FindPortrait() + @""" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
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
                                                if (friends.ContainsKeySafe(senderid)) ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/" + friends[senderid].FindPortrait() + @""" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
                                                else ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/DefaultProfileHead@2x.png"" width=""50"" height=""50"" /><br />" + txtsender + @"</td>";
                                            }
                                            else ts += @"<tr><td width=""80"" align=""center"">&nbsp;</td>";
                                        }
                                    }
                                    else
                                    {
                                        if (des == 0) ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/" + myself.FindPortrait() + @""" width=""50"" height=""50"" /><br />" + myself.DisplayName() + @"</td>";
                                        else if (friend != null) ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/" + friend.FindPortrait() + @""" width=""50"" height=""50"" /><br />" + friend.DisplayName() + @"</td>";
                                        else ts += @"<tr><td width=""80"" align=""center""><img src=""Portrait/DefaultProfileHead@2x.png"" width=""50"" height=""50"" /><br />" + displayname + @"</td>";
                                    }
                                    if (type == 34)
                                    {
                                        var voicelen = -1;
                                        var match = Regex.Match(message, @"voicelength=""(\d+?)""");
                                        if (match.Success) voicelen = int.Parse(match.Groups[1].Value);
                                        var audiosrc = GetBackupFilePath(MyPath.Combine(userBase, "Audio", table, msgid + ".aud"));
                                        if (audiosrc == null)
                                        {
                                            message = voicelen == -1 ? "[语音]" : "[语音 " + Utils.DisplayTime(voicelen) + "]";
                                        }
                                        else
                                        {
                                            Utils.ShellWait("lib\\silk_v3_decoder.exe", "\"" + audiosrc + "\" 1.pcm");
                                            Utils.ShellWait("lib\\lame.exe", "-r -s 24000 --preset voice 1.pcm \"" + Path.Combine(assetsdir, msgid + ".mp3") + "\"");
                                            message = "<audio controls><source src=\"" + id + "_files/" + msgid + ".mp3\" type=\"audio/mpeg\"><a href=\"" + id + "_files/" + msgid + ".mp3\">播放</a></audio>";
                                        }
                                    }
                                    else if (type == 47)
                                    {
                                        var match = Regex.Match(message, @"cdnurl ?= ?""(.+?)""");
                                        if (match.Success)
                                        {
                                            var localfile = Utils.RemoveCdata( match.Groups[1].Value);
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
                                        var hasthum = RequireResource(MyPath.Combine(userBase, "Video", table, msgid + ".video_thum"), Path.Combine(assetsdir, msgid + "_thum.jpg"));
                                        var hasvid = RequireResource(MyPath.Combine(userBase, "Video", table, msgid + ".mp4"), Path.Combine(assetsdir, msgid + ".mp4"));
                                        if (hasthum && hasvid) message = "<video controls poster=\"" + id + "_files/" + msgid + "_thum.jpg\"><source src=\"" + id + "_files/" + msgid + ".mp4\" type=\"video/mp4\"><a href=\"" + id + "_files/" + msgid + ".mp4\">播放</a></video>";
                                        else if (hasthum) message = "<img src=\"" + id + "_files/" + msgid + "_thum.jpg\" /> （视频丢失）";
                                        else if (hasvid) message = "<video controls><source src=\"" + id + "_files/" + msgid + ".mp4\" type=\"video/mp4\"><a href=\"" + id + "_files/" + msgid + ".mp4\">播放</a></video>";
                                        else message = "[视频]";
                                    }
                                    else if (type == 50) message = "[视频/语音通话]";
                                    else if (type == 3)
                                    {
                                        var hasthum = RequireResource(MyPath.Combine(userBase, "Img", table, msgid + ".pic_thum"), Path.Combine(assetsdir, msgid + "_thum.jpg"));
                                        var haspic = RequireResource(MyPath.Combine(userBase, "Img", table, msgid + ".pic"), Path.Combine(assetsdir, msgid + ".jpg"));
                                        if (hasthum && haspic) message = "<a href=\"" + id + "_files/" + msgid + ".jpg\"><img src=\"" + id + "_files/" + msgid + "_thum.jpg\" style=\"max-width:100px;max-height:60px\" /></a>";
                                        else if (hasthum) message = "<img src=\"" + id + "_files/" + msgid + "_thum.jpg\" style=\"max-width:100px;max-height:60px\" />";
                                        else if (haspic) message = "<img src=\"" + id + "_files/" + msgid + ".jpg\" style=\"max-width:100px;max-height:60px\" />";
                                        else message = "[图片]";
                                    }
                                    else if (type == 48)
                                    {
                                        var match1 = Regex.Match(message, @"x ?= ?""(.+?)""");
                                        var match2 = Regex.Match(message, @"y ?= ?""(.+?)""");
                                        var match3 = Regex.Match(message, @"label ?= ?""(.+?)""");
                                        if (match1.Success && match2.Success && match3.Success) message = "[位置 (" + Utils.RemoveCdata( match2.Groups[1].Value) + "," + Utils.RemoveCdata(match1.Groups[1].Value) + ") " + Utils.RemoveCdata(match3.Groups[1].Value) + "]";
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
                                        var match2=Regex.Match(message, "smallheadimgurl ?= ?\"(.+?)\"");
                                        if (match1.Success)
                                        {
                                            message = "";
                                            if(match2.Success)message+= "<img src=\"" + Utils.RemoveCdata(match2.Groups[1].Value) + "\" style=\"float:left;max-width:100px;max-height:60px\" />";
                                            message += "[名片] " + Utils.RemoveCdata(match1.Groups[1].Value);
                                        }
                                        else message = "[名片]";
                                    }
                                    else message = Utils.SafeHTML(message);

                                    ts += @"<td width=""100"" align=""center"">" + FromUnixTime(unixtime).ToLocalTime().ToString().Replace(" ","<br />") + "</td>";
                                    ts += @"<td>" + message + @"</td></tr>";
                                    sw.WriteLine(ts);
                                    count++;
                                    if (count > maxCount)
                                        break;
                                }
                                catch (Exception) { }
                            sw.WriteLine(@"</body></html>");
                        }
                    }
                }
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public string GetBackupFilePath(string vpath)
        {
            vpath = vpath.Replace('\\', '/');
            if (!fileDict.ContainsKey(vpath)) return null;
            return Path.Combine(currentBackup, fileDict[vpath]);
        }

        public void BuildFilesDictionary()
        {
            var dict = new Dictionary<string, string>();
            foreach (var x in files92)
            {
                dict.Add(x.Path, x.key);
            }
            this.fileDict = dict;
        }


        public bool OpenMessageSqlite(string filePath, out SQLiteConnection conn)
        {
            bool succ = false;
            conn = null;
            try
            {
                conn = new SQLiteConnection
                {
                    ConnectionString = "data source=" + GetBackupFilePath(filePath) + ";version=3"
                };
                conn.Open();
                succ = true;
            }
            catch (Exception) { }
            return succ;
        }

        public List<string> FindMessageDB(string uid)
        {
            var dbs = new HashSet<string>();

            var mmdb = Path.Combine("Documents", uid, "DB", "MM.sqlite");

            mmdb = mmdb.Replace('\\', '/');

            dbs.Add(mmdb);

            string str = string.Format(@"Documents\/{0}\/DB\/message_\d+.sqlite$", uid);

            foreach (var filename in fileDict)
            {
                var match = Regex.Match(filename.Key, str);
                if (match.Success) dbs.Add(filename.Key);
            }

            return dbs.ToList();
        }

        public List<string> FindUIDs()
        {
            var UIDs = new HashSet<string>();
            foreach (var filename in fileDict)
            {
                var match = Regex.Match(filename.Key, @"Documents\/([0-9a-f]{32})\/");
                if (match.Success) UIDs.Add(match.Groups[1].Value);
            }
            var zeros = new string('0', 32);
            if (UIDs.Contains(zeros)) UIDs.Remove(zeros);
            return UIDs.ToList();
        }

        public bool RequireResource(string vpath,string dest)
        {
            vpath = vpath.Replace('\\', '/');
            if (fileDict.ContainsKey(vpath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                if(!File.Exists(dest)) File.Copy(GetBackupFilePath(vpath), dest);
                return true;
            }
            else return false;
        }

        

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static Dictionary<byte,string> ReadBlob(byte[] blob, int offset, int len)
        {
            var ret = new Dictionary<byte, string>();
            var p = offset;
            var end = offset + len;
            while (p < end)
            {
                var abyte = blob[p++];
                if (p >= end) break;
                var asize = blob[p++];
                if (p + asize > end) break;
                var astring = Encoding.UTF8.GetString(blob, p, asize);
                ret.Add(abyte, astring);
                p += asize;
            }
            return ret;
        }

        public static Dictionary<string,string> ReadChatRoomRemark(string str)
        {
            var ret = new Dictionary<string, string>();
            var matches = Regex.Matches(str, @"<Member UserName=""(.+?)""(.+?)<\/Member>");
            foreach (Match match in matches)
            {
                var match2 = Regex.Match(match.Groups[2].Value, @"<DisplayName>(.+?)<\/DisplayName>");
                if (!match2.Success) continue;
                var username = match.Groups[1].Value;
                var displayname = match2.Groups[1].Value;
                ret.Add(username, displayname);
            }
            return ret;
        }       
    }

    

    public static class DictionaryHelper
    {
        public static void AddSafe(this Dictionary<string, Friend> dict, string key, Friend value)
        {
            if (!dict.ContainsKey(key)) dict.Add(key, value);
        }
        public static bool ContainsKeySafe(this Dictionary<string, Friend> dict, string key)
        {
            if (key == null) return false;
            return dict.ContainsKey(key);
        }
        public static bool ContainsKeySafe(this Dictionary<string, string> dict, string key)
        {
            if (key == null) return false;
            return dict.ContainsKey(key);
        }
    }

}
