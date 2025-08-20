using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spear : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text SpearEdit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        SpearEdit.text = uiFormParams.ToString();
        StartCoroutine(nameof(DoorHatchSpear));
    }

    private IEnumerator DoorHatchSpear()
    {
        yield return new WaitForSeconds(2);
        HatchUIWork(GetType().Name);
    }

}
