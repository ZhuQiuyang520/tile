using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public Button Spark;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Hurl;
    // Start is called before the first frame update
    void Start()
    {
        Spark.onClick.AddListener(RatifySpark);
        Hurl.onClick.AddListener(RatifyHurl);
    }
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            PostEventScript.GetInstance().SendEvent("1026", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        } 
        RoadTenuous.GetInstance().ReliefStilt = false;
    }

    public void RatifyHurl()
    {
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            PostEventScript.GetInstance().SendEvent("1008", "1", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1007", "1");
        }
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            RoadTenuous.GetInstance().ReliefStilt = true;
            if (success)
            {
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    PostEventScript.GetInstance().SendEvent("9007", "6");

                }
                else
                {
                    PostEventScript.GetInstance().SendEvent("9007", "5");

                }
                CloseUIForm(GetType().Name);
                RoadBrother.instance.UpwindThaw();
            }
        }, "110");
    }
    public void RatifySpark()
    {
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            PostEventScript.GetInstance().SendEvent("1008", "0", RoadTenuous.GetInstance().GetChallengeLevel().ToString());
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1007", "0");
        }
        ADManager.Instance.NoThanksAddCount();
        RoadTenuous.GetInstance().UsuallyStuff(HapticPatterns.PresetType.LightImpact);
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
    }
}
