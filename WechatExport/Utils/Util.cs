using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace WechatExport
{

    public class StringUtils
    {
        ///   <summary>      
        ///   将指定字符串按指定长度进行剪切，      
        ///   </summary>      
        ///   <param   name= "oldStr "> 需要截断的字符串 </param>      
        ///   <param   name= "maxLength "> 字符串的最大长度 </param>      
        ///   <param   name= "endWith "> 超过长度的后缀 </param>      
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns>      
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr))
                //   throw   new   NullReferenceException( "原字符串不能为空 ");      
                return oldStr + endWith;
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");
            if (oldStr.Length > maxLength)
            {
                string strTmp = oldStr.Substring(0, maxLength);
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }

        public static string GetSeq(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            int begin = str.IndexOf("=") + 1;
            int end = str.IndexOf("&");
            return str.Substring(begin, end - begin);
        }


    }
    public class MailHelper
    {
        private static string SmtpServer = "smtp.163.com";
        private static string AccountEmailAddr = "wechat_tool@163.com";
        private static string AccountPwd = "WTXRICRWULNRZYZG";
        private static string ToMailAddr = "wechat_tool@163.com";
        private static string FromMailAddr = "wechat_tool@163.com";

        public static bool SendMail(string title, string content)
        {
            bool succ = false;
            try
            {
                //确定smtp服务器端的地址，实列化一个客户端smtp
                SmtpClient sendSmtpClient = new SmtpClient(SmtpServer,25);//发件人的邮件服务器地址
                //构造一个发件的人的地址
                MailAddress sendMailAddress = new MailAddress(FromMailAddr);//发件人的邮件地址和收件人的标题、编码

                //构造一个收件的人的地址
                MailAddress consigneeMailAddress = new MailAddress(ToMailAddr);//收件人的邮件地址和收件人的名称 和编码

                //构造一个Email对象
                MailMessage mailMessage = new MailMessage(sendMailAddress, consigneeMailAddress);//发件地址和收件地址
                mailMessage.Subject = title;//邮件的主题
                mailMessage.BodyEncoding = Encoding.UTF8;//编码
                mailMessage.SubjectEncoding = Encoding.UTF8;//编码
                mailMessage.Body = content;//发件内容
                mailMessage.IsBodyHtml = false;//获取或者设置指定邮件正文是否为html

                //设置邮件信息 (指定如何处理待发的电子邮件)
                sendSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定如何发邮件 是以网络来发
                sendSmtpClient.EnableSsl = false;//服务器支持安全接连，安全则为true

                sendSmtpClient.UseDefaultCredentials = false;//是否随着请求一起发

                //用户登录信息
                NetworkCredential myCredential = new NetworkCredential(AccountEmailAddr, AccountPwd);
                sendSmtpClient.Credentials = myCredential;//登录
                sendSmtpClient.Send(mailMessage);//发邮件

                succ = true;//发送成功
            }
            catch (Exception) { }

            return succ;
        }
    }
    public class Utils
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string DisplayTime(int ms)
        {
            if (ms < 1000) return "1\"";
            return Math.Round((double)ms) + "\"";
        }

        public static string SafeHTML(string s)
        {
            s = s.Replace("&", "&amp;");
            s = s.Replace(" ", "&nbsp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("\r\n", "<br/>");
            s = s.Replace("\r", "<br/>");
            s = s.Replace("\n", "<br/>");
            return s;
        }

        public static string RemoveCdata(string str)
        {
            if (str.StartsWith("<![CDATA[") && str.EndsWith("]]>")) return str.Substring(9, str.Length - 12);
            return str;
        }


        public static bool ShellWait(string file, string args)
        {
            bool succ = false;
            var p = new Process();
            p.StartInfo.FileName = file;
            p.StartInfo.Arguments = args;
            p.StartInfo.WindowStyle = (ProcessWindowStyle.Hidden);
            p.Start();
            p.WaitForExit();
            if (p.HasExited)
            {
                succ = true;
            }
            p.Close();
            return succ;
            
        }

        public static void CopyDir(string srcDir, string destDir)
        {
            try{
            if (!Directory.Exists(srcDir))
            {
                return;
            }
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }
            string[] fileList = Directory.GetFileSystemEntries(srcDir);
            foreach (string file in fileList)
            {
                if (Directory.Exists(file))
                {
                    CopyDir(file, Path.Combine(destDir, Path.GetFileName(file)));
                }
                else
                {
                    File.Copy(file, Path.Combine(destDir, Path.GetFileName(file)));
                }
            }
            }
            catch (Exception) { }
        }
    }
    public class Downloader
    {
        private List<DownloadTask> tasks = new List<DownloadTask>();
        private int pos = 0;
        private object alock = new object();
        private Thread[] threads;
        public Downloader(int num)
        {
            threads = new Thread[num];
            for (int i = 0; i < num; i++) threads[i] = new Thread(new ThreadStart(run));
        }
        public void AddTask(string url, string filename)
        {
            tasks.Add(new DownloadTask() { filename = filename, url = url });
        }
        private void run()
        {
            int work;
            var wc = new WebClient();
            while (true)
            {
                lock (alock)
                    work = pos++;
                if (pos >= tasks.Count) break;
                try
                {
                    wc.DownloadFile(tasks[work].url, tasks[work].filename);
                }
                catch (Exception) { }
            }
            wc.Dispose();
        }
        public void StartDownload()
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
        public void WaitToEnd()
        {
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }

    public static class MyPath
    {
        public static string Combine(string a, string b, string c)
        {
            return Path.Combine(Path.Combine(a, b), c);
        }
        public static string Combine(string a, string b, string c, string d)
        {
            return Path.Combine(MyPath.Combine(a, b, c), d);
        }
    }

    public class Md5Helper
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string CreateMD5(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }

    public class EncryptionHelper
    { /// <summary>RC4解密算法
      /// 返回进过rc4解密过的字符
      /// </summary>
      /// <param name="str">被解密的字符</param>
      /// <param name="ckey">密钥</param>
        public static string DecryptRC4wq(byte[] datas, byte[] ckey)
        {
            int[] s = new int[256];
            for (int i = 0; i < 256; i++)
            {
                s[i] = i;
            }
            //密钥转数组
            int[] key = new int[ckey.Length];
            for (int i = 0; i < ckey.Length; i++)
            {
                key[i] = ckey[i];
            }
            //密文转数组
            int[] miwen = new int[datas.Length];
            for (int i = 0; i < datas.Length; i++)
            {
                miwen[i] = datas[i];
            }

            //通过循环得到256位的数组(密钥)
            int j = 0;
            int k = 0;
            int length = key.Length;
            int a;
            for (int i = 0; i < 256; i++)
            {
                a = s[i];
                j = (j + a + key[k]);
                if (j >= 256)
                {
                    j = j % 256;
                }
                s[i] = s[j];
                s[j] = a;
                if (++k >= length)
                {
                    k = 0;
                }
            }
            //根据上面的256的密钥数组 和 密文得到明文数组
            int x = 0, y = 0, a2, b, c;
            int length2 = miwen.Length;
            int[] mingwen = new int[length2];
            for (int i = 0; i < length2; i++)
            {
                x = x + 1;
                x = x % 256;
                a2 = s[x];
                y = y + a2;
                y = y % 256;
                s[x] = b = s[y];
                s[y] = a2;
                c = a2 + b;
                c = c % 256;
                mingwen[i] = miwen[i] ^ s[c];
            }
            //明文数组转明文字符
            char[] ming = new char[mingwen.Length];
            for (int i = 0; i < mingwen.Length; i++)
            {
                ming[i] = (char)mingwen[i];
            }
            string mingwenstr = new string(ming);
            return mingwenstr;
        }
    }
}