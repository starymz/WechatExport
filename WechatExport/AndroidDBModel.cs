using SQLite;
using System;
using System.Linq;

namespace WechatExport
{
	public class AndroidBackup
    {
		public string DisplayName;
		public DateTime LastBackupDate;
		public string path;                 // backup path

		public override string ToString()
		{
			string str = DisplayName + " (" + LastBackupDate + ")";
			return str;
		}
	}
	public class MessageCount
	{
		public string Talker { get; set; }
		public int MsgCount { get; set; }
		
	}

	[Table("rcontact")]
	public partial class Rcontact
	{
		[Column("username"), PrimaryKey, NotNull] public string Username { get; set; } // text(max)
		[Column("alias")] public string Alias { get; set; } // text(max)
		[Column("conRemark")] public string ConRemark { get; set; } // text(max)
		[Column("domainList")] public string DomainList { get; set; } // text(max)
		[Column("nickname")] public string Nickname { get; set; } // text(max)
		[Column("pyInitial")] public string PyInitial { get; set; } // text(max)
		[Column("quanPin")] public string QuanPin { get; set; } // text(max)
		[Column("showHead")] public long? ShowHead { get; set; } // integer
		[Column("type")] public long? Type { get; set; } // integer
		[Column("weiboFlag")] public long? WeiboFlag { get; set; } // integer
		[Column("weiboNickname")] public string WeiboNickname { get; set; } // text(max)
		[Column("conRemarkPYFull")] public string ConRemarkPYFull { get; set; } // text(max)
		[Column("conRemarkPYShort")] public string ConRemarkPYShort { get; set; } // text(max)
		[Column("lvbuff")] public byte[] Lvbuff { get; set; } // blob
		[Column("verifyFlag")] public long? VerifyFlag { get; set; } // integer
		[Column("encryptUsername")] public string EncryptUsername { get; set; } // text(max)
		[Column("chatroomFlag")] public long? ChatroomFlag { get; set; } // integer
		[Column("deleteFlag")] public long? DeleteFlag { get; set; } // integer
		[Column("contactLabelIds")] public string ContactLabelIds { get; set; } // text(max)
		[Column("descWordingId")] public string DescWordingId { get; set; } // text(max)
		[Column("openImAppid")] public string OpenImAppid { get; set; } // text(max)
		[Column("sourceExtInfo")] public string SourceExtInfo { get; set; } // text(max)
		[Column("ticket")] public string Ticket { get; set; } // text(max)
	}


	[Table("userinfo")]
	public partial class Userinfo
	{
		[Column("id"), PrimaryKey, NotNull] public long Id { get; set; } // integer
		[Column("type")] public int? Type { get; set; } // int
		[Column("value")] public string Value { get; set; } // text(max)
	}

	[Table("message")]
	public partial class Message
	{
		[Column("msgId"), PrimaryKey, NotNull] public long MsgId { get; set; } // integer
		[Column("msgSvrId")] public long? MsgSvrId { get; set; } // integer
		[Column("type")] public int? Type { get; set; } // int
		[Column("status")] public int? Status { get; set; } // int
		[Column("isSend")] public int? IsSend { get; set; } // int
		[Column("isShowTimer")] public long? IsShowTimer { get; set; } // integer
		[Column("createTime")] public long CreateTime { get; set; } // integer
		[Column("talker")] public string Talker { get; set; } // text(max)
		[Column("content")] public string Content { get; set; } // text(max)
		[Column("imgPath")] public string ImgPath { get; set; } // text(max)
		[Column("reserved")] public string Reserved { get; set; } // text(max)
		[Column("lvbuffer")] public byte[] Lvbuffer { get; set; } // blob
		[Column("transContent")] public string TransContent { get; set; } // text(max)
		[Column("transBrandWording")] public string TransBrandWording { get; set; } // text(max)
		[Column("talkerId")] public long? TalkerId { get; set; } // integer
		[Column("bizClientMsgId")] public string BizClientMsgId { get; set; } // text(max)
		[Column("bizChatId")] public long? BizChatId { get; set; } // integer
		[Column("bizChatUserId")] public string BizChatUserId { get; set; } // text(max)
		[Column("msgSeq")] public long? MsgSeq { get; set; } // integer
		[Column("flag")] public int? Flag { get; set; } // int
		[Column("solitaireFoldInfo")] public byte[] SolitaireFoldInfo { get; set; } // blob
		[Column("historyId")] public string HistoryId { get; set; } // text(max)
	}

	[Table("chatroom")]
	public partial class Chatroom
	{
		[Column("chatroomname"), PrimaryKey, NotNull] public string Chatroomname { get; set; } // text(max)
		[Column("addtime")] public long? Addtime { get; set; } // long
		[Column("memberlist")] public string Memberlist { get; set; } // text(max)
		[Column("displayname")] public string Displayname { get; set; } // text(max)
		[Column("chatroomnick")] public string Chatroomnick { get; set; } // text(max)
		[Column("roomflag")] public long? Roomflag { get; set; } // integer
		[Column("roomowner")] public string Roomowner { get; set; } // text(max)
		[Column("roomdata")] public byte[] Roomdata { get; set; } // blob
		[Column("isShowname")] public long? IsShowname { get; set; } // integer
		[Column("selfDisplayName")] public string SelfDisplayName { get; set; } // text(max)
		[Column("style")] public long? Style { get; set; } // integer
		[Column("chatroomdataflag")] public long? Chatroomdataflag { get; set; } // integer
		[Column("modifytime")] public long? Modifytime { get; set; } // long
		[Column("chatroomnotice")] public string Chatroomnotice { get; set; } // text(max)
		[Column("chatroomVersion")] public long? ChatroomVersion { get; set; } // integer
		[Column("chatroomnoticeEditor")] public string ChatroomnoticeEditor { get; set; } // text(max)
		[Column("chatroomnoticePublishTime")] public long? ChatroomnoticePublishTime { get; set; } // long
		[Column("chatroomLocalVersion")] public long? ChatroomLocalVersion { get; set; } // long
		[Column("chatroomStatus")] public long? ChatroomStatus { get; set; } // integer
		[Column("memberCount")] public long? MemberCount { get; set; } // integer
		[Column("chatroomfamilystatusmodifytime")] public long? Chatroomfamilystatusmodifytime { get; set; } // long
		[Column("oldChatroomVersion")] public long? OldChatroomVersion { get; set; } // integer
		[Column("openIMRoomMigrateStatus")] public long? OpenIMRoomMigrateStatus { get; set; } // integer
		[Column("handleByteVersion")] public string HandleByteVersion { get; set; } // text(max)
		[Column("associateOpenIMRoomName")] public string AssociateOpenIMRoomName { get; set; } // text(max)
		[Column("saveByteVersion")] public string SaveByteVersion { get; set; } // text(max)
		[Column("roomInfoDetailResByte")] public byte[] RoomInfoDetailResByte { get; set; } // blob
	}
}
