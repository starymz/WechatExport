using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WechatExport.Properties;

namespace WeChat.Utils
{
    /***
    * ===========================================================
    * 创建人：yuanj
    * 创建时间：2018/01/19 15:05:14
    * 说明：
    * ==========================================================
    * */
    public class EmojiTools
    {
        public static string face = "[微笑],[撇嘴],[色],[发呆],[得意],[流泪],[害羞],[闭嘴],[睡],[大哭],[尴尬],[发怒],[调皮],[呲牙],[惊讶],[难过],[酷],[冷汗],[抓狂],[吐],[偷笑],[愉快],[白眼],[傲慢],[饥饿],[困],[惊恐],[流汗],[憨笑],[悠闲],[奋斗],[咒骂],[疑问],[嘘],[晕],[疯了],[衰],[骷髅],[敲打],[再见],[擦汗],[抠鼻],[鼓掌],[糗大了],[坏笑],[左哼哼],[右哼哼],[哈欠],[鄙视],[委屈],[快哭了],[阴险],[亲亲],[吓],[可怜],[菜刀],[西瓜],[啤酒],[篮球],[乒乓],[咖啡],[饭],[猪头],[玫瑰],[凋谢],[嘴唇],[爱心],[心碎],[蛋糕],[闪电],[炸弹],[刀],[足球],[瓢虫],[便便],[月亮],[太阳],[礼物],[拥抱],[强],[弱],[握手],[胜利],[抱拳],[勾引],[拳头],[差劲],[爱你],[NO],[OK],[爱情],[飞吻],[跳跳],[发抖],[怄火],[转圈],[磕头],[回头],[跳绳],[投降],[激动],[乱舞],[献吻],[左太极],[右太极]";

        public static string[] location = new string[]{"0,0","29,0","58,0","87,0","116,0","145,0","174,0","203,0","232,0","261,0","290,0","319,0","348,0","377,0","406,0","0,29","29,29","58,29","87,29",
        "116,29","145,29","174,29","203,29","232,29","261,29","290,29","319,29","348,29","377,29","406,29","0,58","29,58","58,58","87,58","116,58","145,58","174,58","203,58","232,58","261,58",
        "290,58","319,58","348,58","377,58","406,58","0,87","29,87","58,87","87,87","116,87","145,87","174,87","203,87","232,87","261,87","290,87","319,87","348,87","377,87","406,87","0,116",
        "29,116","58,116","87,116","116,116","145,116","174,116","203,116","232,116","261,116","290,116","319,116","348,116","377,116","406,116","0,145","29,145","58,145","87,145","116,145","145,145",
        "174,145","203,145","232,145","261,145","290,145","319,145","348,145","377,145","406,145","0,174","29,174","58,174","87,174","116,174","145,174","174,174","203,174","232,174","261,174",
        "290,174","319,174","348,174","377,174","406,174"};


        //1f604:,1f60a:,1f603:,263a:,1f609:,1f60d:,1f618:,1f61a:,1f633:,1f63c:,1f60c:,1f61c:,1f445:,1f612:,1f60f:,1f613:,1f640:,1f64f:,1f61e:,1f616:,1f625:,1f630:,1f628:,1f62b:,1f622:,1f62d:,1f602:,1f632:,1f631:,1f620:,1f63e:,1f62a:,1f637:,1f47f:,1f47d:,2764:,1f494:,1f498:,2728:,1f31f:,2755:,2754:,1f4a4:,1f4a6:,1f3b5:,1f525:,1f4a9:,1f44d:,1f44e:,1f44a:,270c:,1f446:,1f447:,1f449:,1f448:,261d:,1f4aa:,1f48f:,1f491:,1f466:,1f467:,1f469:,1f468:,1f47c:,1f480:,1f48b:,2600:,2614:,2601:,26c4:,1f319:,26a1:,1f30a:,1f431:,1f429:,1f42d:,1f439:,1f430:,1f43a:,1f438:,1f42f:,1f428:,1f43b:,1f437:,1f42e:,1f417:,1f435:,1f434:,1f40d:,1f426:,1f414:,1f427:,1f41b:,1f419:,1f420:,1f433:,1f42c:,1f339:,1f33a:,1f334:,1f335:,1f49d:,1f383:,1f47b:,1f385:,1f384:,1f381:,1f514:,1f389:,1f388:,1f4bf:,1f4f7:,1f3a5:,1f4bb:,1f4fa:,1f4de:,1f513:,1f512:,1f511:,1f528:,1f4a1:,1f4eb:,1f6c0:,1f4b2:,1f4a3:,1f52b:,1f48a:,1f3c8:,1f3c0:,26bd:,26be:,26f3:,1f3c6:,1f47e:,1f3a4:,1f3b8:,1f459:,1f451:,1f302:,1f45c:,1f484:,1f48d:,1f48e:,2615:,1f37a:,1f37b:,1f377:,1f354:,1f35f:,1f35d:,1f363:,1f35c:,1f373:,1f366:,1f382:,1f34f:,2708:,1f680:,1f6b2:,1f684:,26a0:,1f3c1:,1f6b9:,1f6ba:,2b55:,274e:,a9:,ae:,2122:'
        //笑脸:1f604,开心:1f60a,大笑:1f603,热情:263a,眨眼:1f609,色:1f60d,接吻:1f618,亲吻:1f61a,脸红:1f633,露齿笑:1f63c,满意:1f60c,戏弄:1f61c,吐舌:1f445,无语:1f612,得意:1f60f,汗:1f613,失望:1f640,合十:1f64f,低落:1f61e,呸:1f616,焦虑:1f625,担心:1f630,震惊:1f628,悔恨:1f62b,眼泪:1f622,哭:1f62d,破涕为笑:1f602,晕:1f632,恐惧:1f631,心烦:1f620,生气:1f63e,睡觉:1f62a,生病:1f637,恶魔:1f47f,外星人:1f47d,心:2764,心碎:1f494,丘比特:1f498,闪烁:2728,星星:1f31f,叹号:2755,问号:2754,睡着:1f4a4,水滴:1f4a6,音乐:1f3b5,火:1f525,便便:1f4a9,强:1f44d,弱:1f44e,拳头:1f44a,胜利:270c,上:1f446,下:1f447,右:1f449,左:1f448,第一:261d,强壮:1f4aa,吻:1f48f,热恋:1f491,男孩:1f466,女孩:1f467,女士:1f469,男士:1f468,天使:1f47c,骷髅:1f480,红唇:1f48b,太阳:2600,下雨:2614,多云:2601,雪人:26c4,月亮:1f319,闪电:26a1,海浪:1f30a,猫:1f431,小狗:1f429,老鼠:1f42d,仓鼠:1f439,兔子:1f430,狗:1f43a,青蛙:1f438,老虎:1f42f,考拉:1f428,熊:1f43b,猪:1f437,牛:1f42e,野猪:1f417,猴子:1f435,马:1f434,蛇:1f40d,鸽子:1f426,鸡:1f414,企鹅:1f427,毛虫:1f41b,章鱼:1f419,鱼:1f420,鲸鱼:1f433,海豚:1f42c,玫瑰:1f339,花:1f33a,棕榈树:1f334,仙人掌:1f335,礼盒:1f49d,南瓜灯:1f383,鬼魂:1f47b,圣诞老人:1f385,圣诞树:1f384,礼物:1f381,铃:1f514,庆祝:1f389,气球:1f388,CD:1f4bf,相机:1f4f7,录像机:1f3a5,电脑:1f4bb,电视:1f4fa,电话:1f4de,解锁:1f513,锁:1f512,钥匙:1f511,成交:1f528,灯泡:1f4a1,邮箱:1f4eb,浴缸:1f6c0,钱:1f4b2,炸弹:1f4a3,手枪:1f52b,药丸:1f48a,橄榄球:1f3c8,篮球:1f3c0,足球:26bd,棒球:26be,高尔夫:26f3,奖杯:1f3c6,入侵者:1f47e,唱歌:1f3a4,吉他:1f3b8,比基尼:1f459,皇冠:1f451,雨伞:1f302,手提包:1f45c,口红:1f484,戒指:1f48d,钻石:1f48e,咖啡:2615,啤酒:1f37a,干杯:1f37b,鸡尾酒:1f377,汉堡:1f354,薯条:1f35f,意面:1f35d,寿司:1f363,面条:1f35c,煎蛋:1f373,冰激凌:1f366,蛋糕:1f382,苹果:1f34f,飞机:2708,火箭:1f680,自行车:1f6b2,高铁:1f684,警告:26a0,旗:1f3c1,男人:1f6b9,女人:1f6ba,O:2b55,X:274e,版权:a9,注册商标:ae,商标:2122,

        public static string[] emoji_ = new string[] { "[笑脸]", "[生病]", "[破涕为笑]", "[吐舌]", "[脸红]", "[恐惧]", "[失望]", "[无语]",
            "[嘿哈]", "[捂脸]", "[奸笑]", "[机智]", "[皱眉]", "[耶]", "[鬼魂]", "[合十]", "[强壮]", "[庆祝]", "[礼物]", "[红包]", "[鸡]",
            "[开心]", "[大笑]", "[热情]", "[眨眼]", "[色]", "[接吻]", "[亲吻]", "[露齿笑]", "[满意]", "[戏弄]", "[得意]", "[汗]", "[低落]",
            "[呸]", "[焦虑]", "[担心]", "[震惊]", "[悔恨]", "[眼泪]", "[哭]", "[晕]", "[心烦]", "[生气]", "[睡觉]", "[恶魔]", "[外星人]",
            "[心]", "[心碎]", "[丘比特]", "[闪烁]", "[星星]", "[叹号]", "[问号]", "[睡着]", "[水滴]", "[音乐]", "[火]", "[便便]", "[强]",
            "[弱]", "[拳头]", "[胜利]", "[上]", "[下]", "[右]", "[左]", "[第一]", "[吻]", "[热恋]", "[男孩]", "[女孩]", "[女士]", "[男士]",
            "[天使]", "[骷髅]", "[红唇]", "[太阳]", "[下雨]", "[多云]", "[雪人]", "[月亮]", "[闪电]", "[海浪]", "[猫]", "[小狗]", "[老鼠]",
            "[仓鼠]", "[兔子]", "[狗]", "[青蛙]", "[老虎]", "[考拉]", "[熊]", "[猪]", "[牛]", "[野猪]", "[猴子]", "[马]", "[蛇]", "[鸽子]",
            "[鸡]", "[企鹅]", "[毛虫]", "[章鱼]", "[鱼]", "[鲸鱼]", "[海豚]", "[玫瑰]", "[花]", "[棕榈树]", "[仙人掌]", "[礼盒]", "[南瓜灯]",
            "[圣诞老人]", "[圣诞树]", "[铃]", "[气球]", "[CD]", "[相机]", "[录像机]", "[电脑]", "[电视]", "[电话]", "[解锁]", "[锁]", "[钥匙]",
            "[成交]", "[灯泡]", "[邮箱]", "[浴缸]", "[钱]", "[炸弹]", "[手枪]", "[药丸]", "[橄榄球]", "[篮球]", "[足球]", "[棒球]", "[高尔夫]",
            "[奖杯]", "[入侵者]", "[唱歌]", "[吉他]", "[比基尼]", "[皇冠]", "[雨伞]", "[手提包]", "[口红]", "[戒指]", "[钻石]", "[咖啡]",
            "[啤酒]", "[干杯]", "[鸡尾酒]", "[汉堡]", "[薯条]", "[意面]", "[寿司]", "[面条]", "[煎蛋]", "[冰激凌]", "[蛋糕]", "[苹果]",
            "[飞机]", "[火箭]", "[自行车]", "[高铁]", "[警告]", "[旗]", "[男人]", "[女人]", "[O]", "[X]", "[版权]", "[注册商标]", "[商标]" };

        //public static string emoji_0 = ",,,,,,,,[嘿哈],[捂脸],[奸笑],[机智],[皱眉],[耶],,,,,,[红包],[鸡],,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
        public static string[] emoji_1 = new string[] { "1f604", "1f637", "1f639", "1f61d", "1f633", "1f631", "1f64d", "1f612",
            "[嘿哈]", "[捂脸]", "[奸笑]", "[机智]", "[皱眉]", "[耶]", "1f47b", "1f64f", "1f4aa", "1f389", "1f4e6", "[红包]", "[鸡]",
            "1f60a", "1f63a", "263a", "1f609", "1f63b", "1f63d", "1f61a", "1f63c", "1f60c", "1f61c", "1f60f", "1f613", "1f61e", "1f4ab",
            "1f625", "1f630", "1f628", "1f62b", "1f63f", "1f62d", "1f632", "1f620", "1f64e", "1f62a", "1f47f", "1f47d", "2764", "1f494",
            "1f498", "2747", "1f31f", "2755", "2754", "1f4a4", "1f4a7", "1f3b5", "1f525", "1f4a9", "1f44d", "1f44e", "1f44a", "270c",
            "1f446", "1f447", "1f449", "1f448", "261d", "1f48f", "1f491", "1f466", "1f467", "1f469", "1f468", "1f47c", "1f480", "1f48b",
            "2600", "2614", "2601", "26c4", "1f31b", "26a1", "1f30a", "1f431", "1f436", "1f42d", "1f439", "1f430", "1f43a", "1f438",
            "1f42f", "1f428", "1f43b", "1f43d", "1f42e", "1f417", "1f435", "1f434", "1f40d", "1f426", "1f414", "1f427", "1f41b",
            "1f419", "1f420", "1f433", "1f42c", "1f339", "1f33a", "1f334", "1f335", "1f49d", "1f383", "1f385", "1f384", "1f514",
            "1f388", "1f4bf", "1f4f7", "1f4f9", "1f4bb", "1f4fa", "1f4de", "1f513", "1f510", "1f511", "1f528", "1f4a1", "1f4eb",
            "1f6c0", "1f4b5", "1f4a3", "1f52b", "1f48a", "1f3c8", "1f3c0", "26bd", "26be", "26f3", "1f3c6", "1f47e", "1f3a4",
            "1f3b8", "1f459", "1f451", "1f302", "1f45c", "1f484", "1f48d", "1f48e", "2615", "1f37a", "1f37b", "1f379", "1f354",
            "1f35f", "1f35d", "1f363", "1f35c", "1f373", "1f366", "1f382", "1f34f", "2708", "1f680", "1f6b2", "1f684", "26a0",
            "1f3c1", "1f6b9", "1f6ba", "2b55", "2716", "a9", "ae", "2122" };
        public static string[] emoji_2 = new string[] { "😄", "😷", "", "😝", "😳", "😱", "", "😒",
            "[嘿哈]", "[捂脸]", "[奸笑]", "[机智]", "[皱眉]", "[耶]", "👻", "", "💪", "🎉", "", "[红包]", "[鸡]",
            "😊", "", "", "😉", "", "", "😚", "", "😌", "😜", "😏", "😓", "😞", "", "😥", "😰", "😨", "",
            "", "😭", "😲", "😠", "", "😪", "", "👽", "", "💔", "💘", "", "🌟", "", "", "💤", "", "🎵",
            "🔥", "💩", "👍", "👎", "👊", "", "👆", "👇", "👉", "👈", "", "💏", "💑", "👦", "👧", "👩", "👨", "👼",
            "💀", "💋", "", "", "", "", "", "", "🌊", "", "🐶", "🐭", "🐹", "🐰", "🐺", "🐸", "🐯", "🐨",
            "🐻", "", "🐮", "🐗", "🐵", "🐴", "🐍", "🐦", "🐔", "🐧", "🐛", "🐙", "🐠", "🐳", "🐬", "🌹", "🌺", "🌴",
            "🌵", "💝", "🎃", "🎅", "🎄", "🔔", "🎈", "💿", "📷", "", "💻", "📺", "", "🔓", "", "🔑", "🔨", "💡",
            "📫", "🛀", "", "💣", "🔫", "💊", "🏈", "🏀", "", "", "", "🏆", "👾", "🎤", "🎸", "👙", "👑", "🌂",
            "👜", "💄", "💍", "💎", "", "🍺", "🍻", "", "🍔", "🍟", "🍝", "🍣", "🍜", "🍳", "🍦", "🎂", "", "",
            "🚀", "🚲", "🚄", "", "🏁", "🚹", "🚺", "", "", "", "", "" };
        public static string[] emoji_3 = new string[] { "[e]笑脸[/e]", "[e]生病[/e]", "[e]破涕为笑[/e]", "[e]吐舌[/e]", "[e]脸红[/e]", "[e]恐惧[/e]", "[e]失望[/e]", "[e]无语[/e]",
            "[e]嘿哈[/e]", "[e]捂脸[/e]", "[e]奸笑[/e]", "[e]机智[/e]", "[e]皱眉[/e]", "[e]耶[/e]", "[e]鬼魂[/e]", "[e]合十[/e]", "[e]强壮[/e]", "[e]庆祝[/e]", "[e]礼物[/e]", "[e]红包[/e]", "[e]鸡[/e]",
            "[e]开心[/e]", "[e]大笑[/e]", "[e]热情[/e]", "[e]眨眼[/e]", "[e]色[/e]", "[e]接吻[/e]", "[e]亲吻[/e]", "[e]露齿笑[/e]", "[e]满意[/e]", "[e]戏弄[/e]", "[e]得意[/e]", "[e]汗[/e]", "[e]低落[/e]",
            "[e]呸[/e]", "[e]焦虑[/e]", "[e]担心[/e]", "[e]震惊[/e]", "[e]悔恨[/e]", "[e]眼泪[/e]", "[e]哭[/e]", "[e]晕[/e]", "[e]心烦[/e]", "[e]生气[/e]", "[e]睡觉[/e]", "[e]恶魔[/e]", "[e]外星人[/e]",
            "[e]心[/e]", "[e]心碎[/e]", "[e]丘比特[/e]", "[e]闪烁[/e]", "[e]星星[/e]", "[e]叹号[/e]", "[e]问号[/e]", "[e]睡着[/e]", "[e]水滴[/e]", "[e]音乐[/e]", "[e]火[/e]", "[e]便便[/e]", "[e]强[/e]",
            "[e]弱[/e]", "[e]拳头[/e]", "[e]胜利[/e]", "[e]上[/e]", "[e]下[/e]", "[e]右[/e]", "[e]左[/e]", "[e]第一[/e]", "[e]吻[/e]", "[e]热恋[/e]", "[e]男孩[/e]", "[e]女孩[/e]", "[e]女士[/e]", "[e]男士[/e]",
            "[e]天使[/e]", "[e]骷髅[/e]", "[e]红唇[/e]", "[e]太阳[/e]", "[e]下雨[/e]", "[e]多云[/e]", "[e]雪人[/e]", "[e]月亮[/e]", "[e]闪电[/e]", "[e]海浪[/e]", "[e]猫[/e]", "[e]小狗[/e]", "[e]老鼠[/e]",
            "[e]仓鼠[/e]", "[e]兔子[/e]", "[e]狗[/e]", "[e]青蛙[/e]", "[e]老虎[/e]", "[e]考拉[/e]", "[e]熊[/e]", "[e]猪[/e]", "[e]牛[/e]", "[e]野猪[/e]", "[e]猴子[/e]", "[e]马[/e]", "[e]蛇[/e]", "[e]鸽子[/e]",
            "[e]鸡[/e]", "[e]企鹅[/e]", "[e]毛虫[/e]", "[e]章鱼[/e]", "[e]鱼[/e]", "[e]鲸鱼[/e]", "[e]海豚[/e]", "[e]玫瑰[/e]", "[e]花[/e]", "[e]棕榈树[/e]", "[e]仙人掌[/e]", "[e]礼盒[/e]", "[e]南瓜灯[/e]",
            "[e]圣诞老人[/e]", "[e]圣诞树[/e]", "[e]铃[/e]", "[e]气球[/e]", "[e]CD[/e]", "[e]相机[/e]", "[e]录像机[/e]", "[e]电脑[/e]", "[e]电视[/e]", "[e]电话[/e]", "[e]解锁[/e]", "[e]锁[/e]", "[e]钥匙[/e]",
            "[e]成交[/e]", "[e]灯泡[/e]", "[e]邮箱[/e]", "[e]浴缸[/e]", "[e]钱[/e]", "[e]炸弹[/e]", "[e]手枪[/e]", "[e]药丸[/e]", "[e]橄榄球[/e]", "[e]篮球[/e]", "[e]足球[/e]", "[e]棒球[/e]", "[e]高尔夫[/e]",
            "[e]奖杯[/e]", "[e]入侵者[/e]", "[e]唱歌[/e]", "[e]吉他[/e]", "[e]比基尼[/e]", "[e]皇冠[/e]", "[e]雨伞[/e]", "[e]手提包[/e]", "[e]口红[/e]", "[e]戒指[/e]", "[e]钻石[/e]", "[e]咖啡[/e]",
            "[e]啤酒[/e]", "[e]干杯[/e]", "[e]鸡尾酒[/e]", "[e]汉堡[/e]", "[e]薯条[/e]", "[e]意面[/e]", "[e]寿司[/e]", "[e]面条[/e]", "[e]煎蛋[/e]", "[e]冰激凌[/e]", "[e]蛋糕[/e]", "[e]苹果[/e]",
            "[e]飞机[/e]", "[e]火箭[/e]", "[e]自行车[/e]", "[e]高铁[/e]", "[e]警告[/e]", "[e]旗[/e]", "[e]男人[/e]", "[e]女人[/e]", "[e]O[/e]", "[e]X[/e]", "[e]版权[/e]", "[e]注册商标[/e]", "[e]商标[/e]"};
        public static string[] location_ = new string[] { "0,0","29,0","58,0","87,0","116,0","145,0","174,0","203,0","232,0","261,0",
            "290,0","319,0","348,0","377,0","406,0","0,29","29,29","58,29","87,29","116,29","145,29","174,29","203,29","232,29","261,29",
            "290,29","319,29","348,29","377,29","406,29","0,58","29,58","58,58","87,58","116,58","145,58","174,58","203,58","232,58",
            "261,58","290,58","319,58","348,58","377,58","406,58","0,87","29,87","58,87","87,87","116,87","145,87","174,87","203,87",
            "232,87","261,87","290,87","319,87","348,87","377,87","406,87","0,116","29,116","58,116","87,116","116,116","145,116","174,116",
            "203,116","232,116","261,116","290,116","319,116","348,116","377,116","406,116","0,145","29,145","58,145","87,145","116,145",
            "145,145","174,145","203,145","232,145","261,145","290,145","319,145","348,145","377,145","406,145","0,174","29,174","58,174",
            "87,174","116,174","145,174","174,174","203,174","232,174","261,174","290,174","319,174","348,174","377,174","406,174","0,203",
            "29,203","58,203","87,203","116,203","145,203","174,203","203,203","232,203","261,203","290,203","319,203","348,203","377,203",
            "406,203","0,232","29,232","58,232","87,232","116,232","145,232","174,232","203,232","232,232","261,232","290,232","319,232",
            "348,232","377,232","406,232","0,261","29,261","58,261","87,261","116,261","145,261","174,261","203,261","232,261","261,261",
            "290,261","319,261","348,261","377,261","406,261","0,290","29,290","58,290","87,290","116,290","145,290","174,290","203,290",
            "232,290","261,290","290,290","319,290","348,290","377,290","406,290","0,319","29,319","58,319","87,319","116,319","145,319",
            "174,319","203,319","232,319","261,319","290,319","319,319"};

        public static Image image_ = Resources.img_emoji_2;
        public static Image image = Resources.img_emoji;



        public static Bitmap GetEmojiBitmap(string key)
        {
            string[] array = emoji_3;
            for (int i = 0; i < array.Length; i++)
            {
                string item = array[i];
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                if (item == key)
                {
                    string[] loc = location_[i].Split(',');
                    Point pos = new Point(Convert.ToInt32(loc[0]), Convert.ToInt32(loc[1]));
                    Bitmap bit = GetPart(image_, 0, 0, 28, 28, pos.X, pos.Y);
                    return bit;
                }
            }
            return null;
        }


        public static Bitmap GetBitmap(string key)
        {
            string[] array = face.Split(',');
            for (int i = 0; i < array.Length; i++)
            {
                string item = array[i];
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                if (item == key)
                {
                    string[] loc = location[i].Split(',');
                    Point pos = new Point(Convert.ToInt32(loc[0]), Convert.ToInt32(loc[1]));
                    Bitmap bit = GetPart(image, 0, 0, 28, 28, pos.X, pos.Y);
                    return bit;
                }
            }
            return null;
        }


        public static string GetEmojiSendStr(string mess)
        {
            try
            {
                for (int i = 0; i < emoji_3.Length; i++)
                {
                    mess = mess.Replace(emoji_3[i], emoji_2[i]);
                }
                return mess;
            }
            catch (Exception)
            {

                return "";
            }
        }


        /// <summary>
        ///
        /// 获取图片指定部分
        /// </summary>
        /// <param name="originalImg">图片</param>
        /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为0)</param>
        /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为0)</param>
        /// <param name="pPartWidth">目标图片的宽度</param>
        /// <param name="pPartHeight">目标图片的高度</param>
        /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
        /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
        public static System.Drawing.Bitmap GetPart(System.Drawing.Image originalImg, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {

            System.Drawing.Bitmap partImg = new System.Drawing.Bitmap(pPartWidth, pPartHeight);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(partImg);
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(new System.Drawing.Point(pPartStartPointX, pPartStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//目标位置
            System.Drawing.Rectangle origRect = new System.Drawing.Rectangle(new System.Drawing.Point(pOrigStartPointX, pOrigStartPointY), new System.Drawing.Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

            graphics.DrawImage(originalImg, destRect, origRect, System.Drawing.GraphicsUnit.Pixel);

            return partImg;
        }

        public static List<string> IsContainsEmoji(string EmojiStr)
        {
            List<string> emojs = new List<string>();
            if (string.IsNullOrEmpty(EmojiStr))
            {
                return emojs;
            }
            string[] icon = face.Split(',');
            foreach (string item in icon)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                int index= EmojiStr.IndexOf(item);
                if (index != -1)
                {
                    emojs.Add(item);
                }
            }
            return emojs;
        }


        public static string[] returnText(string text)
        {
            string[] icon = face.Split(',');
            if (text == "" || text == null)
            {
                return null;
            }
            for (var j = 0; j < icon.Length; j++)
            {
                string ss = icon[j];
                text = text.Replace(ss, "㍿[images]:" + ss + "㍿");
            }
            text = GetEmoji(text);
            text = text.Replace("[Smart]", "[机智]").Replace("[Smirk]", "[奸笑]").Replace("[Facepalm]", "[捂脸]"); ;
            for (int i = 0; i < emoji_3.Length; i++)
            {
                text = text.Replace(emoji_1[i], "㍿" + emoji_3[i] + "㍿")
                    .Replace(emoji_3[i], "㍿" + emoji_3[i] + "㍿")
                    .Replace(emoji_2[i], "㍿" + emoji_3[i] + "㍿");
            }
            string[] str = text.Split('㍿');
            return str;
        }




        public static string GetEmoji(string paramContent)
        {
            //1f639
            string paramContentR = paramContent.Replace("<span class=\"emoji emoji", "").Replace("\"></span>", "");
            return paramContentR;
        }

        public static string GetEmojiMess(string paramContent)
        {
            //1f639
            string paramContentR = paramContent.Replace("<span class=\"emoji emoji", "").Replace("\"></span>", "");

            for (int i = 0; i < emoji_1.Length; i++)
            {
                paramContentR = paramContentR.Replace(emoji_1[i], emoji_3[i]).Replace(emoji_2[i], emoji_3[i]);
            }
            return paramContentR;
        }

        static string emojistr = "[e]1f604[/e],[e]1f637[/e],[e]1f639[/e],[e]1f61d[/e],[e]1f633[/e],[e]1f631[/e],[e]1f64d[/e],[e]1f612[/e],嘿哈,捂脸,奸笑,机智,皱眉,耶,[e]1f47b[/e],[e]1f64f[/e],[e]1f4aa[/e],[e]1f389[/e],[e]1f4e6[/e],红包,鸡,[e]1f60a[/e],[e]1f63a[/e],[e]263a[/e],[e]1f609[/e],[e]1f63b[/e],[e]1f63d[/e],[e]1f61a[/e],[e]1f63c[/e],[e]1f60c[/e],[e]1f61c[/e],[e]1f60f[/e],[e]1f613[/e],[e]1f61e[/e],[e]1f4ab[/e],[e]1f625[/e],[e]1f630[/e],[e]1f628[/e],[e]1f62b[/e],[e]1f63f[/e],[e]1f62d[/e],[e]1f632[/e],[e]1f620[/e],[e]1f64e[/e],[e]1f62a[/e],[e]1f47f[/e],[e]1f47d[/e],[e]2764[/e],[e]1f494[/e],[e]1f498[/e],[e]2747[/e],[e]1f31f[/e],[e]2755[/e],[e]2754[/e],[e]1f4a4[/e],[e]1f4a7[/e],[e]1f3b5[/e],[e]1f525[/e],[e]1f4a9[/e],[e]1f44d[/e],[e]1f44e[/e],[e]1f44a[/e],[e]270c[/e],[e]1f446[/e],[e]1f447[/e],[e]1f449[/e],[e]1f448[/e],[e]261d[/e],[e]1f48f[/e],[e]1f491[/e],[e]1f466[/e],[e]1f467[/e],[e]1f469[/e],[e]1f468[/e],[e]1f47c[/e],[e]1f480[/e],[e]1f48b[/e],[e]2600[/e],[e]2614[/e],[e]2601[/e],[e]26c4[/e],[e]1f31b[/e],[e]26a1[/e],[e]1f30a[/e],[e]1f431[/e],[e]1f436[/e],[e]1f42d[/e],[e]1f439[/e],[e]1f430[/e],[e]1f43a[/e],[e]1f438[/e],[e]1f42f[/e],[e]1f428[/e],[e]1f43b[/e],[e]1f43d[/e],[e]1f42e[/e],[e]1f417[/e],[e]1f435[/e],[e]1f434[/e],[e]1f40d[/e],[e]1f426[/e],[e]1f414[/e],[e]1f427[/e],[e]1f41b[/e],[e]1f419[/e],[e]1f420[/e],[e]1f433[/e],[e]1f42c[/e],[e]1f339[/e],[e]1f33a[/e],[e]1f334[/e],[e]1f335[/e],[e]1f49d[/e],[e]1f383[/e],[e]1f385[/e],[e]1f384[/e],[e]1f514[/e],[e]1f388[/e],[e]1f4bf[/e],[e]1f4f7[/e],[e]1f4f9[/e],[e]1f4bb[/e],[e]1f4fa[/e],[e]1f4de[/e],[e]1f513[/e],[e]1f510[/e],[e]1f511[/e],[e]1f528[/e],[e]1f4a1[/e],[e]1f4eb[/e],[e]1f6c0[/e],[e]1f4b5[/e],[e]1f4a3[/e],[e]1f52b[/e],[e]1f48a[/e],[e]1f3c8[/e],[e]1f3c0[/e],[e]26bd[/e],[e]26be[/e],[e]26f3[/e],[e]1f3c6[/e],[e]1f47e[/e],[e]1f3a4[/e],[e]1f3b8[/e],[e]1f459[/e],[e]1f451[/e],[e]1f302[/e],[e]1f45c[/e],[e]1f484[/e],[e]1f48d[/e],[e]1f48e[/e],[e]2615[/e],[e]1f37a[/e],[e]1f37b[/e],[e]1f379[/e],[e]1f354[/e],[e]1f35f[/e],[e]1f35d[/e],[e]1f363[/e],[e]1f35c[/e],[e]1f373[/e],[e]1f366[/e],[e]1f382[/e],[e]1f34f[/e],[e]2708[/e],[e]1f680[/e],[e]1f6b2[/e],[e]1f684[/e],[e]26a0[/e],[e]1f3c1[/e],[e]1f6b9[/e],[e]1f6ba[/e],[e]2b55[/e],[e]2716[/e],[e]a9[/e],[e]ae[/e],[e]2122[/e]";
        public static string GetEmojiStr(string paramContent)
        {
            paramContent = emojistr;


            var unicodehex = new char[6] { '0', '0', '0', '0', '0', '0' };

            StringBuilder newString = new StringBuilder(2000);
            StringBuilder tempEmojiSB = new StringBuilder(20);
            StringBuilder tmps = new StringBuilder(5);

            int ln = paramContent.Length;
            for (int index = 0; index < ln; index++)
            {
                int i = index; //把指针给一个临时变量,方便出错时,现场恢复.
                try
                {

                    if (paramContent[i] == '[')
                    {
                        //预测
                        if (paramContent[i + 1] == 'e')
                        {
                            if (paramContent[i + 2] == ']') //[e]的后面4位是 unicode 的16进制数值.
                            {
                                i = i + 3; //前进3位 

                                i = ChangUnicodeToUTF16(paramContent, tempEmojiSB, tmps, i);

                                if (paramContent[i] == '-')//向前探测1位 看看是否双字符 形如1f1e7-1f1ea 
                                {
                                    i++;
                                    i = ChangUnicodeToUTF16(paramContent, tempEmojiSB, tmps, i);

                                };

                                if (paramContent[i] == '[')
                                {
                                    if (paramContent[i + 1] == '/')
                                    {
                                        if (paramContent[i + 2] == 'e')
                                        {
                                            if (paramContent[i + 3] == ']')
                                            {
                                                i = i + 3; //再前进4位

                                                index = i;                             //识别转换成功
                                                newString.Append(tempEmojiSB.ToString());   //识别转换成功
                                                tempEmojiSB.Clear();
                                                continue;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                    index = i;

                }
                catch (Exception)
                {
                    //解析失败仍然继续吃.
                }
                newString.Append(paramContent[index]);

            }
            return newString.ToString();
        }


        public static int ChangUnicodeToUTF16(string paramContent, StringBuilder tempSB, StringBuilder tmps, int i)
        {
            for (int maxln = 0; maxln < 20; maxln++)
            {
                if (paramContent[i] != '-' && paramContent[i] != '[')
                {  //向前探测1位
                    tmps.Append(paramContent[i]);
                    i++;
                }
                else
                {
                    break;
                }
            }


            tempSB.Append(EmojiCodeToUTF16String(tmps.ToString()));

            tmps.Clear();
            return i;
        }

        public static Int32 EmojiToUTF16(Int32 V, bool LowHeight = true)
        {

            Int32 Vx = V - 0x10000;

            Int32 Vh = Vx >> 10;//取高10位部分
            Int32 Vl = Vx & 0x3ff; //取低10位部分
            //Response.Write("Vh:"); Response.Write(Convert.ToString(Vh, 2)); Response.Write("<br/>"); //2进制显示
            //Response.Write("Vl:"); Response.Write(Convert.ToString(Vl, 2)); Response.Write("<br/>"); //2进制显示

            Int32 wh = 0xD800; //結果的前16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            Int32 wl = 0xDC00; //結果的後16位元初始值,这个地方应该是根据Unicode的编码规则总结出来的数值.
            wh = wh | Vh;
            wl = wl | Vl;
            //Response.Write("wh:"); Response.Write(Convert.ToString(wh, 2)); Response.Write("<br/>");//2进制显示
            //Response.Write("wl:"); Response.Write(Convert.ToString(wl, 2)); Response.Write("<br/>");//2进制显示
            if (LowHeight)
            {
                return wl << 16 | wh;   //低位左移16位以后再把高位合并起来 得到的结果是UTF16的编码值   //适合低位在前的操作系统 
            }
            else
            {
                return wh << 16 | wl; //高位左移16位以后再把低位合并起来 得到的结果是UTF16的编码值   //适合高位在前的操作系统
            }


        }

        /// <summary>
        /// 字符串形式的 Emoji 16进制Unicode编码  转换成 UTF16字符串 能够直接输出到客户端
        /// </summary>
        /// <param name="EmojiCode"></param>
        /// <returns></returns>
        public static string EmojiCodeToUTF16String(string EmojiCode)
        {
            if (EmojiCode.Length != 4 && EmojiCode.Length != 5)
            {
                throw new ArgumentException("错误的 EmojiCode 16进制数据长度.一般为4位或5位");
            }
            //1f604
            int EmojiUnicodeHex = int.Parse(EmojiCode, System.Globalization.NumberStyles.HexNumber);

            //1f604对应 utf16 编码的int
            Int32 EmojiUTF16Hex = EmojiToUTF16(EmojiUnicodeHex, true);             //这里字符的低位在前.高位在后.
            //Response.Write(Convert.ToString(lon, 16)); Response.Write("<br/>"); //这里字符的低位在前.高位在后. 
            var emojiBytes = BitConverter.GetBytes(EmojiUTF16Hex);                     //把整型值变成Byte[]形式. Int64的话 丢掉高位的空白0000000   

            return Encoding.Unicode.GetString(emojiBytes);
        }
    }
}
