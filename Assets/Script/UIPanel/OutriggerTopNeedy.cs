using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutriggerTopNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    [UnityEngine.Serialization.FormerlySerializedAs("Era")]public SkeletonGraphic Joy;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        int CurChallenLevel = PlayerPrefs.GetInt(CConfig.NowDayChallenAward);
        
        //过完第一个挑战关卡
        if (CurChallenLevel == 0)
        {
            RaftNonself.GetInstance().GlueMaya(Joy, CinemaKrill,0, "1", false);
        }
        //完成第二个挑战关卡
        else if (CurChallenLevel == 1)
        {
            RaftNonself.GetInstance().GlueMaya(Joy, CinemaKrill, 1, "2", false);
        }
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, CurChallenLevel += 1);
    }

    private void CinemaKrill()
    {
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy));
        RaftNonself.GetInstance().OrganPreferable(StartChallengeState.Win);
    }
}
