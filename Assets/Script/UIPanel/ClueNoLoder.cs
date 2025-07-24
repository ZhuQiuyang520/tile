using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueNoLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Merge;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Pool1Resume;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Pool2Resume;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Merge)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                MilkyStove(index);
            });
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_PopShow);
        for (int i = 0; i < 5; i++)
        {
            Merge[i].gameObject.GetComponent<Image>().sprite = Pool2Resume;
        }
    }


    private void MilkyStove(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Merge[i].gameObject.GetComponent<Image>().sprite = i <= index ? Pool1Resume : Pool2Resume;
        }
        PostEventScript.GetInstance().SendEvent("1009", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(CloseLoder());
        } else
        {
            // 跳转到应用商店
            RateUsManager.instance.OpenAPPinMarket();
            StartCoroutine(CloseLoder());
        }
        
        // 打点
        //PostEventScript.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator CloseLoder(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        CloseUIForm(GetType().Name);
    }
}
