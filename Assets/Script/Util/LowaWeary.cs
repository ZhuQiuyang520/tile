using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowaWeary : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject BullWeary;

    private GameObject IndebtedPlazaRelief;
    private float NestDecay= 158f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        IndebtedPlazaRelief = BullWeary.transform.Find("SlotCard_1").gameObject;
        float x = NestDecay * 3;
        int multiCount = SawSelfEke.instance.BullHave.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(IndebtedPlazaRelief, BullWeary.transform);
                fangkuai.transform.localPosition = new Vector3(x + NestDecay * multiCount * i + NestDecay * j, IndebtedPlazaRelief.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + SawSelfEke.instance.BullHave.slot_group[j].multi;
            }
        }
    }

    public void CostPlaza()
    {
        BullWeary.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    public void Gear(int index, Action<double> finish)
    {
        WhaleEke.PenMonopoly().JuneOxygen(WhaleSpur.UIMusic.Sound_OneArmBandit);
        ConestogaAssumption.DisabilityThresh(BullWeary, -(NestDecay * 2 + NestDecay * SawSelfEke.instance.BullHave.slot_group.Count * 3 + NestDecay * (index + 1)), () =>
        {
            finish?.Invoke(SawSelfEke.instance.BullHave.slot_group[index].multi);
        });
    }
}
