using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LimeVillage : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform What;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public BeefCast Watercraft;
    private void Awake()
    {
        Watercraft.OnBeefDampen = Everywhere;
    }

    void Everywhere(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        What.GetComponent<RectTransform>().position = pos;
    }
}
