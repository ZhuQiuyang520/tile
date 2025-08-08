using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class UsuallyLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button SparkHat;
[UnityEngine.Serialization.FormerlySerializedAs("Quickly")]    public Toggle Kinfolk;
[UnityEngine.Serialization.FormerlySerializedAs("QuicklyBG")]    public GameObject KinfolkBG;
[UnityEngine.Serialization.FormerlySerializedAs("Sound")]    public Toggle Charm;
[UnityEngine.Serialization.FormerlySerializedAs("Vibra")]    public Toggle Stuff;
[UnityEngine.Serialization.FormerlySerializedAs("Music")]    public Toggle Movie;
[UnityEngine.Serialization.FormerlySerializedAs("Home")]    public Button Tusk;
[UnityEngine.Serialization.FormerlySerializedAs("Rate")]    public Button Clue;
[UnityEngine.Serialization.FormerlySerializedAs("Privacy")]    public Button Cheapen;
[UnityEngine.Serialization.FormerlySerializedAs("Exit")]    public Button Give;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
    public Animator EraLop;
[UnityEngine.Serialization.FormerlySerializedAs("QuickObj")]
    public GameObject FloorLop;

    public Button TryBtn;

#if UNITY_IOS
    [DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Tusk.gameObject.SetActive(false);
        TryBtn.gameObject.SetActive(false);
        FloorLop.SetActive(false);
        if (uiFormParams != null)
        {
            Tusk.gameObject.SetActive(true);
            TryBtn.gameObject.SetActive(true);
        }
        RoadTenuous.GetInstance().ReliefStilt = false;
        if (PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config && !RoadTenuous.GetInstance().OfTelescope)
        {
            FloorLop.SetActive(true);
        }
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_PopShow);
    }

    private void Start()
    {
        SparkHat.onClick.AddListener(RatifySpark);
        Tusk.onClick.AddListener(ToTusk);
        Clue.onClick.AddListener(RatifyClue);
        Cheapen.onClick.AddListener(RatifyCheapen);
        //Give.onClick.AddListener(RatifyGive);
        TryBtn.onClick.AddListener(ChangeTryAgain);

        Kinfolk.onValueChanged.AddListener(RatifyKinfolk);
        Charm.onValueChanged.AddListener(RatifyCharm);
        Movie.onValueChanged.AddListener(RatifyMovie);
        Stuff.onValueChanged.AddListener(RatifyStuff);

        if (PlayerPrefs.GetInt(CConfig.SaveMusic) != 1)
        {
            RatifyMovie(false);
        }
        else
        {
            RatifyMovie(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveSound) != 1)
        {
            RatifyCharm(false);
        }
        else
        {
            RatifyCharm(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveVibration) != 1)
        {
            RatifyStuff(false);
        }
        else
        {
            RatifyStuff(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveVolun) != 1)
        {
            RatifyKinfolk(false);
        }
        else
        {
            RatifyKinfolk(true);
        }
       
    }

    private void RatifySpark()
    {
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RotationTasmania AniManager = EraLop.gameObject.AddComponent<RotationTasmania>();
        AniManager.LidBasalt(Spark);
        EraLop.Play("SettingPanel_end");
    }

    private void Spark()
    {
        CloseUIForm(GetType().Name);
    }

    private void ToTusk()
    {
        ADManager.Instance.NoThanksAddCount();
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().ReliefStilt = false;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
    }

    private void ChangeTryAgain()
    {
        ADManager.Instance.playInterstitialAd(104);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().ReliefStilt = true;
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            PostEventScript.GetInstance().SendEvent("1025", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
            PostEventScript.GetInstance().SendEvent("1033", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), RoadTenuous.GetInstance().Revive.ToString());

            string challengeRoll = RoadTenuous.GetInstance().UseRollBack.ToString();
            string challengeRemind = RoadTenuous.GetInstance().UseRemind.ToString();
            string challengeRefresh = RoadTenuous.GetInstance().UseRefresh.ToString();
            StringBuilder str = new StringBuilder();
            str.Append(challengeRoll);
            str.Append(challengeRemind);
            str.Append(challengeRefresh);
            PostEventScript.GetInstance().SendEvent("1029", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), str.ToString());
            PostEventScript.GetInstance().SendEvent("1038", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), str.ToString(), RoadTenuous.GetInstance().Revive.ToString());
            UIManager.GetInstance().ClearAllUI();
            UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
            RoadTenuous.GetInstance().StoveCrossbones(StartChallengeState.SettingTryAgain);
        }
        else
        {
            CloseUIForm(GetType().Name);
            RoadBrother.instance.BeamBleak(PlayerPrefs.GetInt(CConfig.sv_CurLevel));
        }
    }

    public void RatifyMovie(bool open)
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        if (open)
        {
            RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
            Movie.isOn = true;
            //继续播放，如果没有BGM就从头播放
            MusicMgr.GetInstance().setBgmReplaceOneTime();
            PlayerPrefs.SetInt(CConfig.SaveMusic, 1);
        }
        else
        {
            //暂停
            MusicMgr.GetInstance().setBgmCloseOneTime();
            PlayerPrefs.SetInt(CConfig.SaveMusic, 0);
        }
    }

    public void RatifyKinfolk(bool open)
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RoadTenuous.GetInstance().OfPearl = open;
        KinfolkBG.SetActive(!open);
        if (open)
        {
            RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
            Kinfolk.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveVolun, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveVolun, 0);
        }
    }
    public void RatifyCharm(bool open)
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RoadTenuous.GetInstance().OfCharm = open;
        if (open)
        {
            RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
            Charm.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveSound, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveSound, 0);
        }
    }
    public void RatifyStuff(bool open)
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        Stuff.isOn = open;
        RoadTenuous.GetInstance().OfStuff = open;
        if (open)
        {
            RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
            Stuff.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveVibration, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveVibration, 0);
        }
    }
    public void RatifyClue()
    {
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        //string toMail = RoadTenuous.GetInstance().GetGameConfig().contact_us;
        //string subject = "[USERFEED]wordfarmers v1.1.0";
        //Uri uri = new Uri(string.Format("mailto:{0}?subject={1}&body={2}", toMail, subject, "你好"));
        //Application.OpenURL(uri.AbsoluteUri);
    }
    public void RatifyCheapen()
    {
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        if (!string.IsNullOrEmpty(NetInfoMgr.instance.GameData.Privacy_Policy))
        {
            if (!string.IsNullOrEmpty(NetInfoMgr.instance.GameData.Privacy_Policy))
            {
                string url = NetInfoMgr.instance.GameData.Privacy_Policy;
#if UNITY_ANDROID || UNITY_EDITOR
                Application.OpenURL(url);
#elif UNITY_IOS
       openUrl(url);
#endif
                //Application.OpenURL(NetInfoMgr.instance.GameData.Privacy_Policy);
            }
        }
    }
    public void RatifyGive()
    {
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
