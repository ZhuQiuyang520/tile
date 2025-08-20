using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmissionInputToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("DownTime")]    public Text RentQuit;
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public Button Hatch;
[UnityEngine.Serialization.FormerlySerializedAs("PlayBtn")]    public Button JuneCab;

    private float MercilessQuit= 0f;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        OilyMimetic.PenMonopoly().EngineGuess = false;
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        MercilessQuit = (float)(nextMidnight - now).TotalSeconds;
    }

    private void Start()
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_PopShow);
        JuneCab.onClick.AddListener(DampenJune);
        Hatch.onClick.AddListener(DampenHatch);
    }

    public void DampenJune()
    {
        SlayNeverSpiral.PenMonopoly().JumpNever("1012", "1");
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        UIMimetic.PenMonopoly().FlakeIceUI();
        OilyMimetic.PenMonopoly().WeAdmission = true;
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic));
        PlayerPrefs.SetInt(CLagoon.PerHimSeveralSweet, 0);
        OilyMimetic.PenMonopoly().CrampPerceptual(StartChallengeState.Pop);
    }

    public void DampenHatch()
    {
        SlayNeverSpiral.PenMonopoly().JumpNever("1012", "0");
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        HatchUIWork(GetType().Name);
    }

    private void FixedUpdate()
    {
        MercilessQuit -= Time.deltaTime;
        RentQuit.text = OilyMimetic.PenMonopoly().MyQuitStrive(MercilessQuit);
    }
}
