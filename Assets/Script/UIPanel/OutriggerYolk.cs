using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class OutriggerYolk : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("TryAgain")]    [UnityEngine.Serialization.FormerlySerializedAs("PayGrasp")]public Button OwePolar;
[UnityEngine.Serialization.FormerlySerializedAs("Home")]    [UnityEngine.Serialization.FormerlySerializedAs("Tusk")]public Button Tuck;

    private int OutriggerButton;


    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        PostEventScript.GetInstance().SendEvent("1026", RaftNonself.GetInstance().ActCharacterBread().ToString());
        PostEventScript.GetInstance().SendEvent("1034", RaftNonself.GetInstance().ActCharacterBread().ToString(), RaftNonself.GetInstance().Slowly.ToString());

        string challengeRoll = RaftNonself.GetInstance().ShyFortKill.ToString();
        string challengeRemind = RaftNonself.GetInstance().ShyAscent.ToString();
        string challengeRefresh = RaftNonself.GetInstance().ShyIridium.ToString();

        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        PostEventScript.GetInstance().SendEvent("1030", RaftNonself.GetInstance().ActCharacterBread().ToString(),str.ToString());
        PostEventScript.GetInstance().SendEvent("1039", RaftNonself.GetInstance().ActCharacterBread().ToString(), str.ToString(), RaftNonself.GetInstance().Slowly.ToString());
        if (RaftNonself.GetInstance().MeOutriggerSaguaroYolk)
        {
            OutriggerButton = NetInfoMgr.instance.GameData.Challenge_Revive;
            RaftNonself.GetInstance().MeOutriggerSaguaroYolk = false;
            OwePolar.interactable = true;
        }
        RaftNonself.GetInstance().EmpireStilt = false;
    }

    private void Start()
    {
        OwePolar.onClick.AddListener(CinemaOwePolar);
        Tuck.onClick.AddListener(ItTuck);
    }

    public void CinemaOwePolar()
    {
        ADManager.Instance.playInterstitialAd(104);
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        RaftNonself.GetInstance().EmpireStilt = true;
        PostEventScript.GetInstance().SendEvent("1024", RaftNonself.GetInstance().ActCharacterBread().ToString());
        PostEventScript.GetInstance().SendEvent("1032", RaftNonself.GetInstance().ActCharacterBread().ToString(), RaftNonself.GetInstance().Slowly.ToString());

        string challengeRoll = RaftNonself.GetInstance().ShyFortKill.ToString();
        string challengeRemind = RaftNonself.GetInstance().ShyAscent.ToString();
        string challengeRefresh = RaftNonself.GetInstance().ShyIridium.ToString();
        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        PostEventScript.GetInstance().SendEvent("1028", RaftNonself.GetInstance().ActCharacterBread().ToString(), str.ToString());
        PostEventScript.GetInstance().SendEvent("1037", RaftNonself.GetInstance().ActCharacterBread().ToString(), str.ToString(), RaftNonself.GetInstance().Slowly.ToString());
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy));
        RaftNonself.GetInstance().OrganPreferable(StartChallengeState.FailTryAgain);
    }

    public void ItTuck()
    {
        ADManager.Instance.NoThanksAddCount();
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI(); 
        PostEventScript.GetInstance().SendEvent("1008", "0", RaftNonself.GetInstance().ActCharacterBread().ToString());
        UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
    }
}
