using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;

public class OilyToxicIOS : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("CoinNumber")]    public Text BankFloral;

    public static OilyToxicIOS instance;
[UnityEngine.Serialization.FormerlySerializedAs("Clump")]    public Text Clump;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]    public GameObject BankBold;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    public Transform RibLap;
[UnityEngine.Serialization.FormerlySerializedAs("Setting")]    public Button Refiner;
    private bool WeOurFamily= true;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
        BankFloral.text = PlayerPrefs.GetInt(CLagoon.BankFloral).ToString();
    }

    private void Start()
    {
        Refiner.onClick.AddListener(LazuliUsually);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        BankFloral.text = PlayerPrefs.GetInt(CLagoon.BankFloral).ToString();
        OilyMimetic.PenMonopoly().EngineGuess = true;

        SlayNeverSpiral.PenMonopoly().JumpNever("1021", (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1).ToString());

        ClumpMimetic.RyeClump = PlayerPrefs.GetInt(CLagoon.No_RyeClump);
        OilyVillage.instance.ThenClump(PlayerPrefs.GetInt(CLagoon.No_RyeClump));
        Clump.text = "Clump" + (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
    }

    private void LazuliUsually()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(RefinerToxicIOS), "1");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HatchUIWork(GetType().Name);
            PearUIWork(nameof(RedbudToxicIOS));
        }
    }
}
