using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoveltyToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("slider")]    public Slider Debris;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text ChlorateEdit;
[UnityEngine.Serialization.FormerlySerializedAs("SliderHandle")]    public GameObject IceboxHeight;
[UnityEngine.Serialization.FormerlySerializedAs("BackGround")]
    public Sprite WarmRemind;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBackGround")]    public Sprite LowaWarmRemind;
[UnityEngine.Serialization.FormerlySerializedAs("SlotAD")]    public Sprite LowaAD;
[UnityEngine.Serialization.FormerlySerializedAs("BG")]
    public Image BG;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public SpriteRenderer LowaBG;
[UnityEngine.Serialization.FormerlySerializedAs("QI")]    public GameObject QI;
[UnityEngine.Serialization.FormerlySerializedAs("AD")]    public SpriteRenderer AD;

    // Start is called before the first frame update
    void Start()
    {
        Debris.value = 0;
        ChlorateEdit.text = "0%";
        SlayNeverSpiral.PenMonopoly().JumpNever("1001");
        SlayNeverSpiral.PenMonopoly().ErieOilyPortugal();
        CashOutManager.PenMonopoly().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        //for (int i = 0; i < ListArray.Length; i++)
        //{
        //    OilyMimetic.GetInstance().PepperFashionable(ListArray[i].GetComponent<RectTransform>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Debris.value <= 0.8f || (SawSelfEke.instance.Visit && CashOutManager.PenMonopoly().Ready))
        {
            Debris.value += Time.deltaTime * 0.2f;
            ChlorateEdit.text = "LOADING... " + (int)(Debris.value * 100) + "%";
            if (Debris.value >= 1)
            {
                // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (TemperFile.ReleaseEnterOther())
                {
                    this.enabled = false;
                    return;
                }
                    
                TemperFile.WeSound();

                if (TemperFile.WeSound())
                {
                    SceneManager.LoadScene("AGame");
                    return;
                }
                if (TemperFile.WeSound())
                {
                    BG.sprite = WarmRemind;
                    LowaBG.sprite = LowaWarmRemind;
                    AD.sprite = LowaAD;
                    QI.SetActive(false);
                }

                Destroy(transform.parent.gameObject);
                VentMimetic.instance.MailBull();
                CashOutManager.PenMonopoly().ReportEvent_LoadingTime();
            }
        }
        IceboxHeight.transform.Rotate(new Vector3(0, 0, -1));
    }
}
