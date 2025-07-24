using System.Collections;
using System.Collections.Generic;
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
        //ADManager.Instance.playRewardVideo((success) =>
        //{
        //    RoadTenuous.GetInstance().ReliefStilt = true;
        //    TelescopeBorrow--;
        //    if (TelescopeBorrow == 0)
        //    {
        //        PayGrasp.interactable = false;
        //    }
        //    PostEventScript.GetInstance().SendEvent("9007", "6");
        //    PostEventScript.GetInstance().SendEvent("1008", "1");

        //    CloseUIForm(GetType().Name);
        //    RoadBrother.instance.UpwindThaw();
        //}, "110");
        RoadTenuous.GetInstance().ReliefStilt = true;
        CloseUIForm(GetType().Name);
        RoadTenuous.GetInstance().StoveCrossbones();
    }

    public void ToTusk()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        UIManager.GetInstance().ClearAllUI(); 
        PostEventScript.GetInstance().SendEvent("1008", "0");
        UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
    }
}
