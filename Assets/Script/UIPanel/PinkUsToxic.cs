using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkUsToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Prowl;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Mill1Modern;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Mill2Modern;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Prowl)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                YieldCramp(index);
            });
        }
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_PopShow);
        for (int i = 0; i < 5; i++)
        {
            Prowl[i].gameObject.GetComponent<Image>().sprite = Mill2Modern;
        }
    }


    private void YieldCramp(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Prowl[i].gameObject.GetComponent<Image>().sprite = i <= index ? Mill1Modern : Mill2Modern;
        }
        SlayNeverSpiral.PenMonopoly().JumpNever("1011", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(BuildToxic());
        } else
        {
            // 跳转到应用商店
            PinkUpMimetic.instance.PearAPCueIgnite();
            StartCoroutine(BuildToxic());
        }
        
        // 打点
        //SlayNeverSpiral.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator BuildToxic(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        HatchUIWork(GetType().Name);
    }
}
