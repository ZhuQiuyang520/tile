using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoneToxicIOS : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public Button Hatch;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Oven;
    // Start is called before the first frame update
    void Start()
    {
        Hatch.onClick.AddListener(DampenHatch);
        Oven.onClick.AddListener(DampenHome);
    }
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1026", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        }
        OilyMimetic.PenMonopoly().EngineGuess = false;
    }

    public void DampenHome()
    {
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1008", "1", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        }
        else
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1007", "1");
        }
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        ADMimetic.Monopoly.LullGreedyFluid((success) =>
        {
            OilyMimetic.PenMonopoly().EngineGuess = true;
            if (success)
            {
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    SlayNeverSpiral.PenMonopoly().JumpNever("9007", "6");

                }
                else
                {
                    SlayNeverSpiral.PenMonopoly().JumpNever("9007", "5");

                }
                HatchUIWork(GetType().Name);
                OilyVillage.instance.ClotheLowa();
            }
        }, "110");
    }
    public void DampenHatch()
    {
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1008", "0", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        }
        else
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1007", "0");
        }
        ADMimetic.Monopoly.NoDefendBurIdeal();
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        UIMimetic.PenMonopoly().FlakeIceUI();
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxicIOS));
    }
}



