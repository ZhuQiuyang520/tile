using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class RefinerToxicIOS : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button HatchCab;
[UnityEngine.Serialization.FormerlySerializedAs("Quickly")]    public Toggle Sulfide;
[UnityEngine.Serialization.FormerlySerializedAs("QuicklyBG")]    public GameObject SulfideBG;
[UnityEngine.Serialization.FormerlySerializedAs("Sound")]    public Toggle Humid;
[UnityEngine.Serialization.FormerlySerializedAs("Vibra")]    public Toggle Coral;
[UnityEngine.Serialization.FormerlySerializedAs("Music")]    public Toggle Whale;
[UnityEngine.Serialization.FormerlySerializedAs("Home")]    public Button Oven;
[UnityEngine.Serialization.FormerlySerializedAs("Rate")]    public Button Pink;
[UnityEngine.Serialization.FormerlySerializedAs("Privacy")]    public Button Cyanide;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
    public Animator ZooIce;
[UnityEngine.Serialization.FormerlySerializedAs("QuickObj")]
    public GameObject BuyerIce;
[UnityEngine.Serialization.FormerlySerializedAs("TryBtn")]
    public Button LopCab;
#if UNITY_IOS
    [DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Oven.gameObject.SetActive(false);
        LopCab.gameObject.SetActive(false);
        BuyerIce.SetActive(false);
        if (uiFormParams != null)
        {
            Oven.gameObject.SetActive(true);
            LopCab.gameObject.SetActive(true);
        }
        OilyMimetic.PenMonopoly().EngineGuess = false;
        if (PlayerPrefs.GetInt(CLagoon.No_RyeClump) >= SawSelfEke.instance.OilyHave.Quickplay_Config && !OilyMimetic.PenMonopoly().WeAdmission)
        {
            BuyerIce.SetActive(true);
        }
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_PopShow);
    }

    private void Start()
    {
        HatchCab.onClick.AddListener(DampenHatch);
        Oven.onClick.AddListener(WeOven);
        Pink.onClick.AddListener(DampenPink);
        Cyanide.onClick.AddListener(DampenCyanide);
        //Exit.onClick.AddListener(ChangeExit);
        LopCab.onClick.AddListener(DampenLopShade);
        Sulfide.onValueChanged.AddListener(DampenSulfide);
        Humid.onValueChanged.AddListener(DampenHumid);
        Whale.onValueChanged.AddListener(DampenWhale);
        Coral.onValueChanged.AddListener(DampenCoral);

        if (PlayerPrefs.GetInt(CLagoon.LuckWhale) != 1)
        {
            DampenWhale(false);
        }
        else
        {
            DampenWhale(true);
        }
        if (PlayerPrefs.GetInt(CLagoon.LuckHumid) != 1)
        {
            DampenHumid(false);
        }
        else
        {
            DampenHumid(true);
        }
        if (PlayerPrefs.GetInt(CLagoon.LuckIntegrity) != 1)
        {
            DampenCoral(false);
        }
        else
        {
            DampenCoral(true);
        }
        if (PlayerPrefs.GetInt(CLagoon.LuckFancy) != 1)
        {
            DampenSulfide(false);
        }
        else
        {
            DampenSulfide(true);
        }
    }

    private void DampenHatch()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        DislodgeRecorder AniManager = ZooIce.gameObject.AddComponent<DislodgeRecorder>();
        AniManager.BurBubbly(Hatch);
        ZooIce.Play("SettingPanel_end");
    }

    private void Hatch()
    {
        HatchUIWork(GetType().Name);
    }

    private void WeOven()
    {
        ADMimetic.Monopoly.NoDefendBurIdeal();
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = false;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        UIMimetic.PenMonopoly().FlakeIceUI();
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxicIOS));
    }

    private void DampenLopShade()
    {
        ADMimetic.Monopoly.LullPreservationTo(104);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        HatchUIWork(GetType().Name);
        OilyVillage.instance.ThenClump(PlayerPrefs.GetInt(CLagoon.No_RyeClump));
    }

    public void DampenWhale(bool open)
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        if (open)
        {
            OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
            Whale.isOn = true;
            //继续播放，如果没有BGM就从头播放
            WhaleEke.PenMonopoly().DieAshFifteenSunQuit();
            PlayerPrefs.SetInt(CLagoon.LuckWhale, 1);
        }
        else
        {
            //暂停
            WhaleEke.PenMonopoly().DieAshHatchSunQuit();
            PlayerPrefs.SetInt(CLagoon.LuckWhale, 0);
        }
    }

    public void DampenSulfide(bool open)
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        OilyMimetic.PenMonopoly().WeFancy = open;
        SulfideBG.SetActive(!open);
        if (open)
        {
            OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
            Sulfide.isOn = true;
            PlayerPrefs.SetInt(CLagoon.LuckFancy, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CLagoon.LuckFancy, 0);
        }
    }
    public void DampenHumid(bool open)
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        OilyMimetic.PenMonopoly().WeHumid = open;

        if (open)
        {
            OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
            Humid.isOn = true;
            PlayerPrefs.SetInt(CLagoon.LuckHumid, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CLagoon.LuckHumid, 0);
        }
    }
    public void DampenCoral(bool open)
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        Coral.isOn = open;
        OilyMimetic.PenMonopoly().WeCoral = open;

        if (open)
        {
            OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
            Coral.isOn = true;
            PlayerPrefs.SetInt(CLagoon.LuckIntegrity, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CLagoon.LuckIntegrity, 0);
        }
    }
    public void DampenPink()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        //string toMail = OilyMimetic.GetInstance().GetGameConfig().contact_us;
        //string subject = "[USERFEED]wordfarmers v1.1.0";
        //Uri uri = new Uri(string.Format("mailto:{0}?subject={1}&body={2}", toMail, subject, "你好"));
        //Application.OpenURL(uri.AbsoluteUri);
    }
    public void DampenCyanide()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        if (!string.IsNullOrEmpty(SawSelfEke.instance.OilyHave.Privacy_Policy))
        {
            string url = SawSelfEke.instance.OilyHave.Privacy_Policy;
#if UNITY_ANDROID || UNITY_EDITOR
            Application.OpenURL(url);
#elif UNITY_IOS
       openUrl(url);
#endif
        }
    }
    public void DampenYarn()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}


