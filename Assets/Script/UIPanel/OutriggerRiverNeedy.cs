using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutriggerRiverNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("DownTime")]    [UnityEngine.Serialization.FormerlySerializedAs("TellPass")]public Text RiskTern;
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    [UnityEngine.Serialization.FormerlySerializedAs("Spark")]public Button Krill;
[UnityEngine.Serialization.FormerlySerializedAs("PlayBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("LikeHat")]public Button GlueThe;

    private float CertaintyTern= 0f;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RaftNonself.GetInstance().EmpireStilt = false;
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        CertaintyTern = (float)(nextMidnight - now).TotalSeconds;
    }

    private void Start()
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_PopShow);
        GlueThe.onClick.AddListener(CinemaGlue);
        Krill.onClick.AddListener(CinemaKrill);
    }

    public void CinemaGlue()
    {
        RaftNonself.GetInstance().MeOutrigger = true;
        PostEventScript.GetInstance().SendEvent("1012","1");
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        
        CloseUIForm(GetType().Name);
        CloseUIForm(nameof(TuckNeedy));
        CloseUIForm(nameof(RaftNeedy));
        UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy));
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, 0);
        RaftNonself.GetInstance().OrganPreferable(StartChallengeState.Pop);
    }

    public void CinemaKrill()
    {
        PostEventScript.GetInstance().SendEvent("1012", "0");
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
    }

    private void FixedUpdate()
    {
        CertaintyTern -= Time.deltaTime;
        RiskTern.text = RaftNonself.GetInstance().OxTernVenice(CertaintyTern);
    }
}
