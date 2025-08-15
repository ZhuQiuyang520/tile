using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSixth : BaseUIForms
{
    [UnityEngine.Serialization.FormerlySerializedAs("StartBtn")] [UnityEngine.Serialization.FormerlySerializedAs("StoveHat")]public Button OrganThe;
    [UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")] [UnityEngine.Serialization.FormerlySerializedAs("UsuallyHat")]public Button QuicklyThe;
    [UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")] [UnityEngine.Serialization.FormerlySerializedAs("BleakCyan")]public Text GrantFlax;

    private void Start()
    {

        OrganThe.onClick.AddListener(OrganRaft);
        //DiffuseHat1.onClick.AddListener(BeamTelescopeBleak);
        QuicklyThe.onClick.AddListener(CinemaQuickly);
        QuicklyThe.onClick.AddListener(CinemaQuickly);
    }

    private void OrganRaft()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().MeOutrigger = false;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(WhipSixth), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RaftNonself.GetInstance().EmpireStilt = true;
        GrantFlax.text = "Level " + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
    }
    private void CinemaQuickly()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        UIManager.GetInstance().ShowUIForms(nameof(JanuarySixth));
    }
}

