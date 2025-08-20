using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AdmissionHone : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("TryAgain")]    public Button LopShade;
[UnityEngine.Serialization.FormerlySerializedAs("Home")]    public Button Oven;

    private int AdmissionFloral;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        SlayNeverSpiral.PenMonopoly().JumpNever("1026", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        SlayNeverSpiral.PenMonopoly().JumpNever("1034", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), OilyMimetic.PenMonopoly().Clothe.ToString());

        string challengeRoll = OilyMimetic.PenMonopoly().OurPeltWarm.ToString();
        string challengeRemind = OilyMimetic.PenMonopoly().OurFamily.ToString();
        string challengeRefresh = OilyMimetic.PenMonopoly().OurStudent.ToString();

        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        SlayNeverSpiral.PenMonopoly().JumpNever("1030", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), str.ToString());
        SlayNeverSpiral.PenMonopoly().JumpNever("1039", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), str.ToString(), OilyMimetic.PenMonopoly().Clothe.ToString());
        if (OilyMimetic.PenMonopoly().WeAdmissionStudentHone)
        {
            AdmissionFloral = SawSelfEke.instance.OilyHave.Challenge_Revive;
            OilyMimetic.PenMonopoly().WeAdmissionStudentHone = false;
            LopShade.interactable = true;
        }
        OilyMimetic.PenMonopoly().EngineGuess = false;
    }

    private void Start()
    {
        LopShade.onClick.AddListener(DampenLopShade);
        Oven.onClick.AddListener(WeOven);
    }

    public void DampenLopShade()
    {
        ADMimetic.Monopoly.LullPreservationTo(104);
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        SlayNeverSpiral.PenMonopoly().JumpNever("1024", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        SlayNeverSpiral.PenMonopoly().JumpNever("1032", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), OilyMimetic.PenMonopoly().Clothe.ToString());

        string challengeRoll = OilyMimetic.PenMonopoly().OurPeltWarm.ToString();
        string challengeRemind = OilyMimetic.PenMonopoly().OurFamily.ToString();
        string challengeRefresh = OilyMimetic.PenMonopoly().OurStudent.ToString();
        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        SlayNeverSpiral.PenMonopoly().JumpNever("1028", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), str.ToString());
        SlayNeverSpiral.PenMonopoly().JumpNever("1037", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), str.ToString(), OilyMimetic.PenMonopoly().Clothe.ToString());
        UIMimetic.PenMonopoly().FlakeIceUI();
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic));
        OilyMimetic.PenMonopoly().CrampPerceptual(StartChallengeState.FailTryAgain);
    }

    public void WeOven()
    {
        ADMimetic.Monopoly.NoDefendBurIdeal();
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        UIMimetic.PenMonopoly().FlakeIceUI();
        SlayNeverSpiral.PenMonopoly().JumpNever("1008", "0", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OvenToxic));
    }
}
