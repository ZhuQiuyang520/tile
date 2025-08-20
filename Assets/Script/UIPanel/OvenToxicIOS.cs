using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenToxicIOS : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("StartBtn")]    public Button CrampCab;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button RefinerCab;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]    public Text ClumpLowa;
    

    private void Start()
    {
        CrampCab.onClick.AddListener(CrampOily);
        RefinerCab.onClick.AddListener(DampenRefiner);
    }

    private void CrampOily()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        HatchUIWork(GetType().Name);
        OilyMimetic.PenMonopoly().WeAdmission = false;
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxicIOS), PlayerPrefs.GetInt(CLagoon.No_RyeClump));
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        ClumpLowa.text = "Clump " + (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
    }

    
    private void DampenRefiner()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(RefinerToxicIOS));
    }
}

