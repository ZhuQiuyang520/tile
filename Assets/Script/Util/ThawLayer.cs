using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThawLayer : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject BlueLayer;

    private GameObject JurassicCrimpBounce;
    private float CultApril= 158f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        JurassicCrimpBounce = BlueLayer.transform.Find("SlotCard_1").gameObject;
        float x = CultApril * 3;
        int multiCount = NetInfoMgr.instance.InitData.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(JurassicCrimpBounce, BlueLayer.transform);
                fangkuai.transform.localPosition = new Vector3(x + CultApril * multiCount * i + CultApril * j, JurassicCrimpBounce.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + NetInfoMgr.instance.InitData.slot_group[j].multi;
            }
        }
    }

    public void OralCrimp()
    {
        BlueLayer.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    public void Food(int index, Action<double> finish)
    {
        MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_OneArmBandit);
        AnimationController.HorizontalScroll(BlueLayer, -(CultApril * 2 + CultApril * NetInfoMgr.instance.InitData.slot_group.Count * 3 + CultApril * (index + 1)), () =>
        {
            finish?.Invoke(NetInfoMgr.instance.InitData.slot_group[index].multi);
        });
    }
}
