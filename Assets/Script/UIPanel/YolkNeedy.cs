using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YolkNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    [UnityEngine.Serialization.FormerlySerializedAs("Spark")]public Button Krill;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    [UnityEngine.Serialization.FormerlySerializedAs("Hurl")]public Button Item;
    // Start is called before the first frame update
    void Start()
    {
        Krill.onClick.AddListener(CinemaKrill);
        Item.onClick.AddListener(CinemaItem);
    }
    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1026", RaftNonself.GetInstance().ActCharacterBread().ToString());
        } 
        RaftNonself.GetInstance().EmpireStilt = false;
    }

    public void CinemaItem()
    {
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1008", "1", RaftNonself.GetInstance().ActCharacterBread().ToString());
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1007", "1");
        }
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            RaftNonself.GetInstance().EmpireStilt = true;
            if (success)
            {
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    PostEventScript.GetInstance().SendEvent("9007", "6");

                }
                else
                {
                    PostEventScript.GetInstance().SendEvent("9007", "5");

                }
                CloseUIForm(GetType().Name);
                RaftMeeting.instance.DivineLoad();
            }
        }, "110");
    }
    public void CinemaKrill()
    {
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1008", "0", RaftNonself.GetInstance().ActCharacterBread().ToString());
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1007", "0");
        }
        ADManager.Instance.NoThanksAddCount();
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
    }
}
