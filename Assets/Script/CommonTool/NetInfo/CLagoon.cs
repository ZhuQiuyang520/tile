/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLagoon
{
    #region 常量字段
    //登录url
    public const string ChafeTop= "/api/client/user/getId?gameCode=";
    //配置url
    public const string ConfigTop= "/api/client/config?gameCode=";
    //时间戳url
    public const string QuitTop= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string ShrimpTop= "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string No_TimidTactOf= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string No_TimidRegimeOf= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string No_WeCopSparse= "sv_IsNewPlayer";

    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string No_InputTrialPenIdeal= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string No_InputTrialLoop= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string No_CopTactClue= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string No_IsleBank= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string No_WintertimeIsleBank= "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string No_Steer= "sv_Token";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string No_WintertimeTusk= "sv_CumulativeCash";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string No_Living= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string No_WintertimeLiving= "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string No_TradeOilyQuit= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string No_GlarePenSteer= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string No_LipBluePinkToxic= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string No_WintertimeStylize= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string No_ReflectPeakFinish= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string No_CopTactClueRedbud= "sv_NewUserStepFinish";
    public const string No_Deem_Piano_Chair= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string No_GlareLowa= "sv_FirstSlot";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string No_ShrimpPale= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string No_At_Night_num= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string No_Adult_At_Man= "sv_total_ad_num";

    public const string No_RyeClump= "sv_CurLevel";

    //保存当前是否开启震动
    public const string LuckIntegrity= "SaveVibration";
    //保存当前是否开启音乐
    public const string LuckHumid= "SaveSound";
    //保存当前是否开启音效
    public const string LuckWhale= "SaveMusic";
    //保存当前是否开启自动收牌
    public const string LuckFancy= "SaveVolun";
    //游戏过程中达到关卡目标开启挑战关卡
    public const string PumpModestly= "OnceChalleng";
    /// <summary>
    /// 提示道具数量
    /// </summary>
    public const string PerishFloral= "RemindNumber";
    /// <summary>
    /// 刷新道具数量
    /// </summary>
    public const string StudentFloral= "RefreshNumber";
    /// <summary>
    /// 撤回道具数量
    /// </summary>
    public const string PeltWarmFloral= "RollBackNumber";
    /// <summary>
    /// 金币数量
    /// </summary>
    public const string BankFloral= "CoinNumber";
    /// <summary>
    /// 金币总数
    /// </summary>
    public const string BankFloral_All= "CoinNumber_All";
    /// <summary>
    /// 语言
    /// </summary>
    public const string Gin_Nystatin= "Language";
    /// <summary>
    /// 记录登出时间
    /// </summary>
    public const string Seem_Evolve_Quit_Wok= "LastLogoutTime";
    /// <summary>
    /// 今日挑战奖励
    /// </summary>
    public const string PerHimSeveralSweet= "NowDayChallenAward";
    /// <summary>
    /// 第一次进入到挑战关卡
    /// </summary>
    public const string PumpIglooAdmission= "OnceChallenge";
    /// <summary>
    /// 是否完成引导关卡
    /// </summary>
    public const string RedbudPenalClump= "FinishGuideLevel";
    /// <summary>
    /// 是否完成网赚引导
    /// </summary>
    public const string RedbudEnclosurePenal= "FinishWangzhuanGuide";

    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string Ox_InsistPear= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string Ox_InsistHatch= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string Ox_ui_Companionship= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string Ox_By_Clarify= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string Ox_By_Aromatic= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string Ox_By_Rebellion= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string Ox_OilyChicago= "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string Ox_OozeDampen_= "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string Ox_SkillfulFiordDampen_= "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string Ox_ClumpSetClumpDampen= "mg_LevelMaxLevelChange";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Fore_IsleBank_Modern= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Fore_Steer_Modern_Dinner= "Art/Tex/UI/jiangli4";

    #endregion
}

