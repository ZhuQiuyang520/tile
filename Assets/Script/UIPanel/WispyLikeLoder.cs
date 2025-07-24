using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WispyLikeLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button SparkHat;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]    public Animator EraLop;
    // Start is called before the first frame update
    void Start()
    {
        SparkHat.onClick.AddListener(LikeRotationSpark);
    }

    private void LikeRotationSpark()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        CloseUIForm(GetType().Name);
    }
}
