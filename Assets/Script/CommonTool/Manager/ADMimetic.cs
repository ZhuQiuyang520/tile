using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.adjust.sdk;
using LitJson;

public class ADMimetic : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool ByBush= false;
    public static ADMimetic Monopoly{ get; private set; }

    private int CrudeFreight;   // 广告加载失败后，重新加载广告次数
    private bool ByImpulseTo;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int RelyJuneQuitDrawing{ get; private set; }   // 距离上次广告的时间间隔
    public int Contest101{ get; private set; }     // 定时插屏(101)计数器
    public int Contest102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Contest103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string TundraInfancyBear;
    private Action<bool> TundraDoseWarmBeluga;    // 激励视频回调
    private bool TundraUrgency;     // 激励视频是否成功收到奖励
    private string TundraNaive;     // 激励视频的打点

    private string SimultaneousInfancyBear;
    private int SimultaneousSpur;      // 当前播放的插屏类型，101/102/103
    private string SimultaneousNaive;     // 插屏广告的的打点
    public bool NovelQuitPreservation{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> AtLicenseLivestock;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long AchievementDauntMeltwater;     // 切后台时的时间戳
    private Ad_CustomData GreedyToBottleHave; //激励视频自定义数据
    private Ad_CustomData PreservationToBottleHave; //插屏自定义数据

    private void Awake()
    {
        Monopoly = this;
    }

    private void OnEnable()
    {
        NovelQuitPreservation = false;
        ByImpulseTo = false;
        RelyJuneQuitDrawing = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        TundraUrgency = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(PenSystemHave.DecryptDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = LuckHaveMimetic.GetString(CLagoon.sv_AdjustAdid);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            LuckHaveMimetic.SetString(CLagoon.sv_AdjustAdid, adjustId);
        }
        else
        {
            StartCoroutine(setAdjustAdid());
        }
#else
        MaxSdk.SetSdkKey(PenSystemHave.WrestleDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(LuckHaveMimetic.PenAcross(CLagoon.No_TimidTactOf));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            DepartmentDisperseBag();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(RepeatBubbly), 1, 1);
        };
    }

    IEnumerator DieShrimpPale()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (TemperFile.WeOnward())
            {
                MaxSdk.SetUserId(LuckHaveMimetic.PenAcross(CLagoon.No_TimidTactOf));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    LuckHaveMimetic.LayAcross(CLagoon.No_ShrimpPale, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(LuckHaveMimetic.PenAcross(CLagoon.No_TimidTactOf));
            MaxSdk.InitializeSdk();
        }
    }

    public void DepartmentDisperseBag()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        ThenDisperseTo();

        // Load the first interstitial
        ThenPreservation();
    }

    private void ThenDisperseTo()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void ThenPreservation()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        CrudeFreight = 0;
        TundraInfancyBear = adInfo.NetworkName;

        GreedyToBottleHave = new Ad_CustomData();
        GreedyToBottleHave.user_id = CashOutManager.PenMonopoly().Data.UserID;
        GreedyToBottleHave.version = Application.version;
        GreedyToBottleHave.request_id = CashOutManager.PenMonopoly().EcpmRequestID();
        GreedyToBottleHave.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        CrudeFreight++;
        double retryDelay = Math.Pow(2, Math.Min(6, CrudeFreight));

        Invoke(nameof(ThenDisperseTo), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        WhaleEke.PenMonopoly().SoWhaleHinder = !WhaleEke.PenMonopoly().SoWhaleHinder;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        ThenDisperseTo();
        ByImpulseTo = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        WhaleEke.PenMonopoly().SoWhaleHinder = !WhaleEke.PenMonopoly().SoWhaleHinder;
#endif

        ByImpulseTo = false;
        ThenDisperseTo();
        if (TundraUrgency)
        {
            TundraUrgency = false;
            TundraDoseWarmBeluga?.Invoke(true);

            MotifToJuneUrgency(ADType.Rewarded);
            //SlayNeverSpiral.GetInstance().SendEvent("9007", rewardIndex);
        }
        else
        {
            TundraDoseWarmBeluga?.Invoke(false);
        }

        // 上报ecpm
        CashOutManager.PenMonopoly().ReportEcpm(adInfo, GreedyToBottleHave.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        TundraUrgency = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SlayNeverSpiral.PenMonopoly().JumpNever("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //ShrimpBullMimetic.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = ShrimpBullMimetic.Instance.PenShrimpPale();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        CrudeFreight = 0;
        SimultaneousInfancyBear = adInfo.NetworkName;

        PreservationToBottleHave = new Ad_CustomData();
        PreservationToBottleHave.user_id = CashOutManager.PenMonopoly().Data.UserID;
        PreservationToBottleHave.version = Application.version;
        PreservationToBottleHave.request_id = CashOutManager.PenMonopoly().EcpmRequestID();
        PreservationToBottleHave.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        CrudeFreight++;
        double retryDelay = Math.Pow(2, Math.Min(6, CrudeFreight));

        Invoke(nameof(ThenPreservation), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        WhaleEke.PenMonopoly().SoWhaleHinder = !WhaleEke.PenMonopoly().SoWhaleHinder;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        ThenPreservation();
        ByImpulseTo = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SlayNeverSpiral.PenMonopoly().JumpNever("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //ShrimpBullMimetic.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(ShrimpBullMimetic.Instance.PenShrimpPale()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = ShrimpBullMimetic.Instance.PenShrimpPale();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        WhaleEke.PenMonopoly().SoWhaleHinder = !WhaleEke.PenMonopoly().SoWhaleHinder;
#endif
        ThenPreservation();

        MotifToJuneUrgency(ADType.Interstitial);
        SlayNeverSpiral.PenMonopoly().JumpNever("9107", SimultaneousNaive);
        // 上报ecpm
        CashOutManager.PenMonopoly().ReportEcpm(adInfo, PreservationToBottleHave.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void LullGreedyFluid(Action<bool> callBack, string index)
    {
        if (ByBush)
        {
            callBack(true);
            MotifToJuneUrgency(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        TundraDoseWarmBeluga = callBack;
        if (rewardVideoReady)
        {
            // 打点
            TundraNaive = index;
            //SlayNeverSpiral.GetInstance().SendEvent("9002", index);
            ByImpulseTo = true;
            TundraUrgency = false;
            string placement = index + "_" + TundraInfancyBear;
            GreedyToBottleHave.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(GreedyToBottleHave));
        }
        else
        {
            SpearMimetic.PenMonopoly().BlueSpear("No ads right now, please try it later.");
            TundraDoseWarmBeluga(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void LullPreservationTo(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        LullPreservation(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void LullPreservation(int index, int customIndex = 0)
    {
        SimultaneousSpur = index;

        if (ByImpulseTo)
        {
            return;
        }

        //这个参数很少有游戏会用 需要的时候自己再打开
        // 当用户过关数 < trial_MaxNum时，不弹插屏广告
        // int sv_trialNum = LuckHaveMimetic.GetInt(CLagoon.sv_ad_trial_num);
        // int trial_MaxNum = int.Parse(SawSelfEke.instance.ConfigData.trial_MaxNum);
        // if (sv_trialNum < trial_MaxNum)
        // {
        //     return;
        // }

        // 时间间隔低于阈值，不播放广告
        if (RelyJuneQuitDrawing < int.Parse(SawSelfEke.instance.LagoonHave.inter_freq))
        {
            return;
        }

        if (ByBush)
        {
            MotifToJuneUrgency(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            ByImpulseTo = true;
            // 打点
            string point = index.ToString();
            if (customIndex > 0)
            {
                point += customIndex.ToString().PadLeft(2, '0');
            }
            SimultaneousNaive = point;
            SlayNeverSpiral.PenMonopoly().JumpNever("9102", point);
            string placement = point + "_" + SimultaneousInfancyBear;
            PreservationToBottleHave.placement_id = placement;
            MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(PreservationToBottleHave));
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void RepeatBubbly()
    {
        RelyJuneQuitDrawing++;

        int relax_interval = int.Parse(SawSelfEke.instance.LagoonHave.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || ByImpulseTo)
        {
            return;
        }
        else
        {
            Contest101++;
            if (Contest101 >= relax_interval && !NovelQuitPreservation)
            {
                LullPreservation(101);
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void NoDefendBurIdeal(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(SawSelfEke.instance.LagoonHave.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Contest102 = LuckHaveMimetic.PenSon("NoThanksCount") + 1;
            LuckHaveMimetic.LaySon("NoThanksCount", Contest102);
            if (Contest102 >= nextlevel_interval)
            {
                LullPreservation(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!ByImpulseTo)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (AchievementDauntMeltwater > 0)
                {
                    RelyJuneQuitDrawing += (int)(LoopFile.Someone() - AchievementDauntMeltwater);
                    AchievementDauntMeltwater = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(SawSelfEke.instance.LagoonHave.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Contest103++;
                    if (Contest103 >= inter_b2f_count)
                    {
                        LullPreservation(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            AchievementDauntMeltwater = LoopFile.Someone();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void DauntQuitPreservation()
    {
        NovelQuitPreservation = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void MonkeyQuitPreservation()
    {
        NovelQuitPreservation = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void HazardSedgeYew(int num)
    {
        LuckHaveMimetic.LaySon(CLagoon.No_At_Night_num, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void ScavengeJuneForelimb(Action<ADType> callback)
    {
        if (AtLicenseLivestock == null)
        {
            AtLicenseLivestock = new List<Action<ADType>>();
        }

        if (!AtLicenseLivestock.Contains(callback))
        {
            AtLicenseLivestock.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void MotifToJuneUrgency(ADType adType)
    {
        ByImpulseTo = false;
        // 播放间隔计数器清零
        RelyJuneQuitDrawing = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (SimultaneousSpur == 101)
            {
                Contest101 = 0;
            }
            else if (SimultaneousSpur == 102)
            {
                Contest102 = 0;
                LuckHaveMimetic.LaySon("NoThanksCount", 0);
            }
            else if (SimultaneousSpur == 103)
            {
                Contest103 = 0;
            }
        }

        // 看广告总数+1
        LuckHaveMimetic.LaySon(CLagoon.No_Adult_At_Man + adType.ToString(), LuckHaveMimetic.PenSon(CLagoon.No_Adult_At_Man + adType.ToString()) + 1);
        // 真提现任务 
        if (adType == ADType.Rewarded)
            CashOutManager.PenMonopoly().AddTaskValue("Ad",1);

        // 回调
        if (AtLicenseLivestock != null && AtLicenseLivestock.Count > 0)
        {
            foreach (Action<ADType> callback in AtLicenseLivestock)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int PenTradeToYew(ADType adType)
    {
        return LuckHaveMimetic.PenSon(CLagoon.No_Adult_At_Man + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}