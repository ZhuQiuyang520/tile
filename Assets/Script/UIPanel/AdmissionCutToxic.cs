using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdmissionCutToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    public SkeletonGraphic Zoo;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        int CurChallenLevel = PlayerPrefs.GetInt(CLagoon.PerHimSeveralSweet);
        
        //过完第一个挑战关卡
        if (CurChallenLevel == 0)
        {
            OilyMimetic.PenMonopoly().JuneAcre(Zoo, DampenHatch,0, "1", false);
        }
        //完成第二个挑战关卡
        else if (CurChallenLevel == 1)
        {
            OilyMimetic.PenMonopoly().JuneAcre(Zoo, DampenHatch, 1, "2", false);
        }
        PlayerPrefs.SetInt(CLagoon.PerHimSeveralSweet, CurChallenLevel += 1);
    }

    private void DampenHatch()
    {
        HatchUIWork(GetType().Name);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic));
        OilyMimetic.PenMonopoly().CrampPerceptual(StartChallengeState.Win);
    }
}
