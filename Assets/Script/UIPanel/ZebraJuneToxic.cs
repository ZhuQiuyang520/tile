using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZebraJuneToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button HatchCab;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]    public Animator ZooIce;
    // Start is called before the first frame update
    void Start()
    {
        HatchCab.onClick.AddListener(JuneAnimatorHatch);
    }

    private void JuneAnimatorHatch()
    {
        OilyMimetic.PenMonopoly().EngineGuess = true;
        HatchUIWork(GetType().Name);
    }
}
