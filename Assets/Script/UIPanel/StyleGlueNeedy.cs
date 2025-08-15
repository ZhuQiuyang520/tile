using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleGlueNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("SparkHat")]public Button KrillThe;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]    [UnityEngine.Serialization.FormerlySerializedAs("EraLop")]public Animator JoyTar;
    // Start is called before the first frame update
    void Start()
    {
        KrillThe.onClick.AddListener(GlueAromaticKrill);
    }

    private void GlueAromaticKrill()
    {
        RaftNonself.GetInstance().EmpireStilt = true;
        CloseUIForm(GetType().Name);
    }
}
