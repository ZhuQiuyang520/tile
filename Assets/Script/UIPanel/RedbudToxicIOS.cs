using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RedbudToxicIOS : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("FinishButton")]    public Button RedbudSpeedy;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Oven;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text BankDesc;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyDesc")]    public Text TwainLowa;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public LowaWeary LowaBG;
    private double TundraNerve;
    private bool SkyShutterToCab;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyIcon")]
    public Transform TwainBold;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
    public Animator ZooIce;

    private string[] AdmissionSweetFloral;
    // Start is called before the first frame update
    void Start()
    {
        RedbudSpeedy.onClick.AddListener(PenHatch);
        Oven.onClick.AddListener(DampenHome);
    }

    protected override void Awake()
    {
        base.Awake();
        DislodgeRecorder AniManager = ZooIce.gameObject.AddComponent<DislodgeRecorder>();
        AniManager.BurBubbly(BurAnger);
        string AdmissionSweet= SawSelfEke.instance.OilyHave.Challenge_Reward;
        AdmissionSweetFloral = AdmissionSweet.Split('|');
    }

    private void BurAnger()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.Success);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        CashOutManager.PenMonopoly().AddTaskValue("Clump", 1);
        Oven.interactable = true;
        LowaBG.CostPlaza();
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.Success);


        TundraNerve = SawSelfEke.instance.OilyHave.Win_Cash;
        TwainLowa.text = "+" + TundraNerve;
    }

    private void DampenHome()
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1035", "1");
        }
        else
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1006", "1");
        }

        if (ByCopTact())
        {
            VoteMeal();
        }
        else
        {
            ADMimetic.Monopoly.LullGreedyFluid((success) =>
            {
                if (success)
                {
                    Oven.interactable = false;

                    VoteMeal();
                }
            }, "101");
        }
    }

    private void PenHatch()
    {
        ADMimetic.Monopoly.NoDefendBurIdeal();
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1035", "0");
        }
        else
        {
            SlayNeverSpiral.PenMonopoly().JumpNever("1006", "0");
        }
        DampenHatch();
    }

    private void DampenHatch()
    {
        if (TemperFile.WeSound())
        {
            PlayerPrefs.SetInt(CLagoon.BankFloral, PlayerPrefs.GetInt(CLagoon.BankFloral) + (int)TundraNerve);
            PlayerPrefs.SetInt(CLagoon.BankFloral_All, PlayerPrefs.GetInt(CLagoon.BankFloral_All) + (int)TundraNerve);
        }

        LazuliColumn();

        //AniObj.enabled = true;
        //RotationTasmania AniManager = AniObj.gameObject.AddComponent<RotationTasmania>();
        //AniManager.AddMethod(ChangeFinish);
        //AniObj.Play("FinishPanel_End");
    }
    private void LazuliColumn()
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);

        //AniObj.enabled = false;
        HatchUIWork(GetType().Name);
        PlayerPrefs.SetInt(CLagoon.No_RyeClump, PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
        LuckHaveMimetic.LaySon(CLagoon.No_At_Night_num, PlayerPrefs.GetInt(CLagoon.No_At_Night_num) + 1);
        OilyMimetic.PenMonopoly().WeVirginAdmission = PlayerPrefs.GetInt(CLagoon.No_RyeClump) > SawSelfEke.instance.OilyHave.Daily_Challenge;
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxicIOS), PlayerPrefs.GetInt(CLagoon.No_RyeClump));
    }

    private bool ByCopTact()
    {
        return !PlayerPrefs.HasKey(CLagoon.No_GlareLowa + "Bool") || LuckHaveMimetic.PenKeep(CLagoon.No_GlareLowa);
    }

    private int SeaMealStudyTower()
    {
        // 新用户，第一次固定翻5倍
        if (ByCopTact())
        {
            int index = 0;
            foreach (SlotItem wg in SawSelfEke.instance.BullHave.slot_group)
            {
                if (wg.multi == 7)
                {
                    return index;
                }
                index++;
            }
        }
        else
        {
            int sumWeight = 0;
            foreach (SlotItem wg in SawSelfEke.instance.BullHave.slot_group)
            {
                sumWeight += wg.weight;
            }
            int r = Random.Range(0, sumWeight);
            int nowWeight = 0;
            int index = 0;
            foreach (SlotItem wg in SawSelfEke.instance.BullHave.slot_group)
            {
                nowWeight += wg.weight;
                if (nowWeight > r)
                {
                    return index;
                }
                index++;
            }

        }
        return 0;
    }

    private void VoteMeal()
    {
        int index = SeaMealStudyTower();
        LowaBG.Gear(index, (multi) => {
            // slot结束后的回调
            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "4");
            ConestogaAssumption.DampenFloral(TundraNerve, TundraNerve * multi, 0, TwainLowa, "+", () =>
            {
                TundraNerve = TundraNerve * multi;
                TwainLowa.text = "+" + FloralFile.ZigzagMyBuy(TundraNerve);

                SkyShutterToCab = true;
                DampenHatch();
            });
        });

        LuckHaveMimetic.LayKeep(CLagoon.No_GlareLowa, false);
    }
}



