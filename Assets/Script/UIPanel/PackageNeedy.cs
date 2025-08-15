using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("slider")]    [UnityEngine.Serialization.FormerlySerializedAs("Guinea")]public Slider Banana;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    [UnityEngine.Serialization.FormerlySerializedAs("SpillageStep")]public Text StamfordNear;
[UnityEngine.Serialization.FormerlySerializedAs("SliderHandle")]    [UnityEngine.Serialization.FormerlySerializedAs("SocialRetire")]public GameObject IsraelReveal;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
[UnityEngine.Serialization.FormerlySerializedAs("FireBroad")]    public GameObject[] LifeGlean;
[UnityEngine.Serialization.FormerlySerializedAs("BackGround")]
    public Sprite KillGalaxy;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBackGround")]    public Sprite HuntKillGalaxy;
[UnityEngine.Serialization.FormerlySerializedAs("SlotAD")]    public Sprite HuntAD;
[UnityEngine.Serialization.FormerlySerializedAs("BG")]

    public Image BG;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public SpriteRenderer HuntBG;
[UnityEngine.Serialization.FormerlySerializedAs("QI")]    public GameObject QI;
[UnityEngine.Serialization.FormerlySerializedAs("AD")]    public SpriteRenderer AD;

    // Start is called before the first frame update
    void Start()
    {
        Banana.value = 0;
        StamfordNear.text = "0%";
        PostEventScript.GetInstance().SendEvent("1001");
        PostEventScript.GetInstance().sendGameProgress();
        CashOutManager.GetInstance().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Banana.value <= 0.8f || (NetInfoMgr.instance.ready && CashOutManager.GetInstance().Ready))
        {
            Banana.value += Time.deltaTime * 0.2f;
            StamfordNear.text ="LOADING... " + (int)(Banana.value * 100) + "%";
            
            if (Banana.value >= 1)
            {
                // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (CommonUtil.AndroidBlockCheck())
                    return;
                CommonUtil.IsApple();

                if (CommonUtil.IsApple())
                {
                    BG.sprite = KillGalaxy;
                    HuntBG.sprite = HuntKillGalaxy;
                    AD.sprite = HuntAD;
                    QI.SetActive(false);
                }
                Destroy(transform.parent.gameObject);
                GramNonself.instance.PeruFree();
                CashOutManager.GetInstance().ReportEvent_LoadingTime();
            }
        }
        IsraelReveal.transform.Rotate(new Vector3(0, 0, -2));
    }
}
