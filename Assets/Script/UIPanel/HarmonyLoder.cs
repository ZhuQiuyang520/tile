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
        PostEventScript.GetInstance().sendGameProgress();
        CashOutManager.GetInstance().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        //for (int i = 0; i < FireBroad.Length; i++)
        //{
        //    RoadTenuous.GetInstance().ThrustUnpublished(FireBroad[i].GetComponent<RectTransform>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Guinea.value <= 0.8f || (NetInfoMgr.instance.ready && CashOutManager.GetInstance().Ready))
        {
            Guinea.value += Time.deltaTime * 0.2f;
            SpillageStep.text ="LOADING... " + (int)(Guinea.value * 100) + "%";
            
            if (Guinea.value >= 1)
            {
                //// 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (CommonUtil.AndroidBlockCheck())
                    return;
                CommonUtil.IsApple();
                Destroy(transform.parent.gameObject);
                DramTenuous.instance.VoteBlue();
                CashOutManager.GetInstance().ReportEvent_LoadingTime();
            }
        }
        SocialRetire.transform.Rotate(new Vector3(0, 0, -2));
    }
}
