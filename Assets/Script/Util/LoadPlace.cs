using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlace : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("BlueLayer")]public GameObject FreePlace;

    private GameObject DaughterOliveTravel;
    private float NoteBowel= 158f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        DaughterOliveTravel = FreePlace.transform.Find("SlotCard_1").gameObject;
        float x = NoteBowel * 3;
        int multiCount = NetInfoMgr.instance.InitData.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(DaughterOliveTravel, FreePlace.transform);
                fangkuai.transform.localPosition = new Vector3(x + NoteBowel * multiCount * i + NoteBowel * j, DaughterOliveTravel.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + NetInfoMgr.instance.InitData.slot_group[j].multi;
            }
        }
    }

    public void PineOlive()
    {
        FreePlace.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    public void Fray(int index, Action<double> finish)
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_OneArmBandit);
        AnimationController.HorizontalScroll(FreePlace, -(NoteBowel * 2 + NoteBowel * NetInfoMgr.instance.InitData.slot_group.Count * 3 + NoteBowel * (index + 1)), () =>
        {
            finish?.Invoke(NetInfoMgr.instance.InitData.slot_group[index].multi);
        });
    }
}
