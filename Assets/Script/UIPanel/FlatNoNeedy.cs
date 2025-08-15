using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlatNoNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    [UnityEngine.Serialization.FormerlySerializedAs("Merge")]public Button[] Right;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("Pool1Resume")]public Sprite Wire1Awaken;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("Pool2Resume")]public Sprite Wire2Awaken;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Right)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                MouseOrgan(index);
            });
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_PopShow);
        for (int i = 0; i < 5; i++)
        {
            Right[i].gameObject.GetComponent<Image>().sprite = Wire2Awaken;
        }
    }


    private void MouseOrgan(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Right[i].gameObject.GetComponent<Image>().sprite = i <= index ? Wire1Awaken : Wire2Awaken;
        }
        PostEventScript.GetInstance().SendEvent("1011", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(YeastNeedy());
        } else
        {
            // 跳转到应用商店
            RateUsManager.instance.OpenAPPinMarket();
            StartCoroutine(YeastNeedy());
        }
        
        // 打点
        //PostEventScript.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator YeastNeedy(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        CloseUIForm(GetType().Name);
    }
}
