using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class JanuarySixth : BaseUIForms
{
    [UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")] [UnityEngine.Serialization.FormerlySerializedAs("SparkHat")]public Button KrillThe;
    [UnityEngine.Serialization.FormerlySerializedAs("Quickly")] [UnityEngine.Serialization.FormerlySerializedAs("Kinfolk")]public Toggle Prosper;
    [UnityEngine.Serialization.FormerlySerializedAs("QuicklyBG")] [UnityEngine.Serialization.FormerlySerializedAs("KinfolkBG")]public GameObject ProsperBG;
    [UnityEngine.Serialization.FormerlySerializedAs("Sound")] [UnityEngine.Serialization.FormerlySerializedAs("Charm")]public Toggle Canal;
    [UnityEngine.Serialization.FormerlySerializedAs("Vibra")] [UnityEngine.Serialization.FormerlySerializedAs("Stuff")]public Toggle Arena;
    [UnityEngine.Serialization.FormerlySerializedAs("Music")] [UnityEngine.Serialization.FormerlySerializedAs("Movie")]public Toggle Bunch;
    [UnityEngine.Serialization.FormerlySerializedAs("Home")] [UnityEngine.Serialization.FormerlySerializedAs("Tusk")]public Button Tuck;
    [UnityEngine.Serialization.FormerlySerializedAs("Rate")] [UnityEngine.Serialization.FormerlySerializedAs("Clue")]public Button Flat;
    [UnityEngine.Serialization.FormerlySerializedAs("Privacy")] [UnityEngine.Serialization.FormerlySerializedAs("Cheapen")]public Button Senator;
    [UnityEngine.Serialization.FormerlySerializedAs("Exit")] [UnityEngine.Serialization.FormerlySerializedAs("Give")]public Button Bust;
    [UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
[UnityEngine.Serialization.FormerlySerializedAs("EraLop")]    public Animator JoyTar;
    [UnityEngine.Serialization.FormerlySerializedAs("QuickObj")]
[UnityEngine.Serialization.FormerlySerializedAs("FloorLop")]    public GameObject PianoTar;
[UnityEngine.Serialization.FormerlySerializedAs("TryBtn")]
    public Button MapCap;

#if UNITY_IOS
    [DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Tuck.gameObject.SetActive(false);
        MapCap.gameObject.SetActive(false);
        PianoTar.SetActive(false);
        if (uiFormParams != null)
        {
            Tuck.gameObject.SetActive(true);
            MapCap.gameObject.SetActive(true);
        }
        RaftNonself.GetInstance().EmpireStilt = false;
        if (PlayerPrefs.GetInt(CConfig.sv_CurLevel) >= NetInfoMgr.instance.GameData.Quickplay_Config && !RaftNonself.GetInstance().MeOutrigger)
        {
            PianoTar.SetActive(true);
        }
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_PopShow);
    }

    private void Start()
    {
        KrillThe.onClick.AddListener(CinemaKrill);
        Tuck.onClick.AddListener(ItTuck);
        Flat.onClick.AddListener(CinemaFlat);
        Senator.onClick.AddListener(CinemaSenator);
        //Give.onClick.AddListener(RatifyGive);
        MapCap.onClick.AddListener(ThreadMapAgain);

        Prosper.onValueChanged.AddListener(CinemaProsper);
        Canal.onValueChanged.AddListener(CinemaCanal);
        Bunch.onValueChanged.AddListener(CinemaBunch);
        Arena.onValueChanged.AddListener(CinemaArena);

        if (PlayerPrefs.GetInt(CConfig.SaveMusic) != 1)
        {
            CinemaBunch(false);
        }
        else
        {
            CinemaBunch(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveSound) != 1)
        {
            CinemaCanal(false);
        }
        else
        {
            CinemaCanal(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveVibration) != 1)
        {
            CinemaArena(false);
        }
        else
        {
            CinemaArena(true);
        }
        if (PlayerPrefs.GetInt(CConfig.SaveVolun) != 1)
        {
            CinemaProsper(false);
        }
        else
        {
            CinemaProsper(true);
        }

    }

    private void CinemaKrill()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        AromaticPamphlet AniManager = JoyTar.gameObject.AddComponent<AromaticPamphlet>();
        AniManager.SodCrease(Krill);
        JoyTar.Play("SettingPanel_end");
    }

    private void Krill()
    {
        CloseUIForm(GetType().Name);
    }

    private void ItTuck()
    {
        ADManager.Instance.NoThanksAddCount();
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = false;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(CoinSixth));
    }

    private void ThreadMapAgain()
    {
        ADManager.Instance.playInterstitialAd(104);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        CloseUIForm(GetType().Name);
        RaftMeeting.instance.SkinGrant(PlayerPrefs.GetInt(CConfig.sv_CurLevel));
    }

    public void CinemaBunch(bool open)
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        if (open)
        {
            RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
            Bunch.isOn = true;
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

    public void CinemaProsper(bool open)
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        RaftNonself.GetInstance().MeCloud = open;
        ProsperBG.SetActive(!open);
        if (open)
        {
            RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
            Prosper.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveVolun, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveVolun, 0);
        }
    }
    public void CinemaCanal(bool open)
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        RaftNonself.GetInstance().MeCanal = open;
        if (open)
        {
            RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
            Canal.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveSound, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveSound, 0);
        }
    }
    public void CinemaArena(bool open)
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        Arena.isOn = open;
        RaftNonself.GetInstance().MeArena = open;
        if (open)
        {
            RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
            Arena.isOn = true;
            PlayerPrefs.SetInt(CConfig.SaveVibration, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.SaveVibration, 0);
        }
    }
    public void CinemaFlat()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        //string toMail = RaftNonself.GetInstance().GetGameConfig().contact_us;
        //string subject = "[USERFEED]wordfarmers v1.1.0";
        //Uri uri = new Uri(string.Format("mailto:{0}?subject={1}&body={2}", toMail, subject, "你好"));
        //Application.OpenURL(uri.AbsoluteUri);
    }
    public void CinemaSenator()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
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
    public void CinemaBust()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

