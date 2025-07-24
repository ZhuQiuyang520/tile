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
        RoadTenuous.GetInstance().ReliefStilt = false;
    }

    public void RatifyHurl()
    {
        
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            RoadTenuous.GetInstance().ReliefStilt = true;
            if (RoadTenuous.GetInstance().OfTelescope)
            {
                PostEventScript.GetInstance().SendEvent("9007", "6");
                PostEventScript.GetInstance().SendEvent("1008", "1");
            }
            else
            {
                PostEventScript.GetInstance().SendEvent("9007", "5");
                PostEventScript.GetInstance().SendEvent("1007", "1");
            }
            CloseUIForm(GetType().Name);
            RoadBrother.instance.UpwindThaw();
        }, "110");
    }
    public void RatifySpark()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        PostEventScript.GetInstance().SendEvent("1007", "0");
        UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
    }
}
