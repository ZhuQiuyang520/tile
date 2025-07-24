using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarmonyLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("slider")]    public Slider Guinea;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text SpillageStep;
[UnityEngine.Serialization.FormerlySerializedAs("SliderHandle")]    public GameObject SocialRetire;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    public GameObject[] FireBroad;
    // Start is called before the first frame update
    void Start()
    {
        Guinea.value = 0;
        SpillageStep.text = "0%";
        PostEventScript.GetInstance().SendEvent("1001");
        //for (int i = 0; i < FireBroad.Length; i++)
        //{
        //    RoadTenuous.GetInstance().ThrustUnpublished(FireBroad[i].GetComponent<RectTransform>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Guinea.value <= 0.8f || NetInfoMgr.instance.ready && CashOutManager.GetInstance().Ready)
        {
            Guinea.value += Time.deltaTime * 0.2f;
            SpillageStep.text ="LOADING... " + (int)(Guinea.value * 100) + "%";
            if (Guinea.value >= 1)
            {
                CommonUtil.IsApple();
                Destroy(transform.parent.gameObject);
                DramTenuous.instance.VoteBlue();
            }
        }
        SocialRetire.transform.Rotate(new Vector3(0, 0, -1));
    }
}
