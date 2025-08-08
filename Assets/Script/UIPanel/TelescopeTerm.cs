using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TelescopeTerm : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("TryAgain")]    public Button PayGrasp;
[UnityEngine.Serialization.FormerlySerializedAs("Home")]    public Button Tusk;

    private int TelescopeBorrow;


    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        PostEventScript.GetInstance().SendEvent("1026", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        PostEventScript.GetInstance().SendEvent("1034", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), RoadTenuous.GetInstance().Revive.ToString());

        string challengeRoll = RoadTenuous.GetInstance().UseRollBack.ToString();
        string challengeRemind = RoadTenuous.GetInstance().UseRemind.ToString();
        string challengeRefresh = RoadTenuous.GetInstance().UseRefresh.ToString();

        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        PostEventScript.GetInstance().SendEvent("1030", RoadTenuous.GetInstance().GetChallengeLevel().ToString(),str.ToString());
        PostEventScript.GetInstance().SendEvent("1039", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), str.ToString(), RoadTenuous.GetInstance().Revive.ToString());
        if (RoadTenuous.GetInstance().OfTelescopeBookletTerm)
        {
            TelescopeBorrow = NetInfoMgr.instance.GameData.Challenge_Revive;
            RoadTenuous.GetInstance().OfTelescopeBookletTerm = false;
            PayGrasp.interactable = true;
        }
        RoadTenuous.GetInstance().ReliefStilt = false;
    }

    private void Start()
    {
        PayGrasp.onClick.AddListener(RatifyPayGrasp);
        Tusk.onClick.AddListener(ToTusk);
    }

    public void RatifyPayGrasp()
    {
        ADManager.Instance.playInterstitialAd(104);
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RoadTenuous.GetInstance().ReliefStilt = true;
        PostEventScript.GetInstance().SendEvent("1024", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        PostEventScript.GetInstance().SendEvent("1032", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), RoadTenuous.GetInstance().Revive.ToString());

        string challengeRoll = RoadTenuous.GetInstance().UseRollBack.ToString();
        string challengeRemind = RoadTenuous.GetInstance().UseRemind.ToString();
        string challengeRefresh = RoadTenuous.GetInstance().UseRefresh.ToString();
        StringBuilder str = new StringBuilder();
        str.Append(challengeRoll);
        str.Append(challengeRemind);
        str.Append(challengeRefresh);
        PostEventScript.GetInstance().SendEvent("1028", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), str.ToString());
        PostEventScript.GetInstance().SendEvent("1037", RoadTenuous.GetInstance().GetChallengeLevel().ToString(), str.ToString(), RoadTenuous.GetInstance().Revive.ToString());
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
        RoadTenuous.GetInstance().StoveCrossbones(StartChallengeState.FailTryAgain);
    }

    public void ToTusk()
    {
        ADManager.Instance.NoThanksAddCount();
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI(); 
        PostEventScript.GetInstance().SendEvent("1008", "0", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
    }
}
