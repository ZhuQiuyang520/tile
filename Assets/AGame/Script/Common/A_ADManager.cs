using UnityEngine;
using System;

public class A_ADManager : MonoBehaviour
{
    public string SdkKey = "";
    public string MAX_REWARD_ID = "8cc44f23f3a78029";
    public string MAX_INTER_ID = "6e02aadb78d3ce0c";
    public bool isTest = false;
    public static A_ADManager Instance { get; private set; }

    // 广告加载状态
    private bool hasRewardAdLoaded = false;
    private bool hasInterstitialAdLoaded = false;

    Action<bool> OnRewardAdCompleted;
    bool isRewardAdCompleted = false;


    private void Awake()
    {
        Instance = this;
        InitMaxSDK();
    }

    // 初始化MAX SDK
    private void InitMaxSDK()
    {
        MaxSdk.SetSdkKey(AUtility.Crypto.DecryptDES(SdkKey));
        MaxSdkCallbacks.OnSdkInitializedEvent += (config) =>
        {
            ADebug.Log("MAX SDK 初始化完成");
            // 初始化广告
            InitializeRewardAds();
            InitializeInterstitialAds();
        };
        ADebug.Log("MAX SDK 初始化中");
        MaxSdk.InitializeSdk();
    }
    // byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    // string DecryptDES()
    // {
    //     byte[] rgbKey = Encoding.UTF8.GetBytes(Application.identifier.Substring(0, 8));
    //     byte[] rgbIV = Keys;
    //     byte[] inputByteArray = Convert.FromBase64String(SdkKey);
    //     DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
    //     MemoryStream mStream = new MemoryStream();
    //     CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
    //     cStream.Write(inputByteArray, 0, inputByteArray.Length);
    //     cStream.FlushFinalBlock();
    //     cStream.Close();
    //     return Encoding.UTF8.GetString(mStream.ToArray());
    // }

    #region Reward Ad Methods
    private void InitializeRewardAds()
    {
        // 激励广告回调
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardAdLoaded;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardAdLoadFailed;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardAdHidden;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardAdReceived;

        LoadRewardAd();
    }

    private void LoadRewardAd()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void OnRewardAdLoaded(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        hasRewardAdLoaded = true;
        ADebug.Log("激励视频加载完成");
    }

    private void OnRewardAdLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        hasRewardAdLoaded = false;
        ADebug.Error($"激励视频加载失败: {errorInfo.Message}");
        // 重新尝试加载
        Invoke(nameof(LoadRewardAd), 5f);
    }

    public void playRewardVideo(Action<bool> OnRewardAdCompleted, string index)
    {
        this.OnRewardAdCompleted = OnRewardAdCompleted;
        if (hasRewardAdLoaded)
        {
            if (isTest)
            {
                OnRewardAdCompleted?.Invoke(true);
                return;
            }

            MaxSdk.ShowRewardedAd(MAX_REWARD_ID);
        }
        else
        {
            ADebug.LogWarning("激励视频未加载");
            AUIModule.Instance.ShowUI<ATipsPanel>("No ads right now, please try it later.");
            OnRewardAdCompleted?.Invoke(false);
            LoadRewardAd();
        }
    }

    private void OnRewardAdReceived(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        isRewardAdCompleted = true;
    }

    private void OnRewardAdHidden(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        OnRewardAdCompleted?.Invoke(isRewardAdCompleted);
        OnRewardAdCompleted = null;
        hasRewardAdLoaded = false;
        isRewardAdCompleted = false;
        LoadRewardAd();
    }
    #endregion

    #region Interstitial Ad Methods
    private void InitializeInterstitialAds()
    {
        // 插页广告回调
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoaded;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailed;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHidden;

        LoadInterstitialAd();
    }

    private void LoadInterstitialAd()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnInterstitialLoaded(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        hasInterstitialAdLoaded = true;
        ADebug.Log("插屏广告加载完成");
    }

    private void OnInterstitialLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        hasInterstitialAdLoaded = false;
        ADebug.Error($"插屏广告加载失败: {errorInfo.Message}");
        Invoke(nameof(LoadInterstitialAd), 5f);
    }

    public void ShowInterstitialAd()
    {
        if (hasInterstitialAdLoaded)
        {
            MaxSdk.ShowInterstitial(MAX_INTER_ID);
        }
        else
        {
            ADebug.LogWarning("插屏广告未加载");
            LoadInterstitialAd();
        }
    }

    private void OnInterstitialHidden(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        hasInterstitialAdLoaded = false;
        LoadInterstitialAd();
    }
    #endregion
}