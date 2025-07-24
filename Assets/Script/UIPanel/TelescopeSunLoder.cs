using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelescopeSunLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    public SkeletonGraphic Era;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        int CurChallenLevel = PlayerPrefs.GetInt(CConfig.NowDayChallenAward);
        
        //过完第一个挑战关卡
        if (CurChallenLevel == 0)
        {
            RoadTenuous.GetInstance().LikeLace(Era, RatifySpark,0, "1", false);
        }
        //完成第二个挑战关卡
        else if (CurChallenLevel == 1)
        {
            RoadTenuous.GetInstance().LikeLace(Era, RatifySpark, 1, "2", false);
        }
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, CurChallenLevel += 1);
    }

    private void RatifySpark()
    {
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
        RoadTenuous.GetInstance().StoveCrossbones();
    }
}
