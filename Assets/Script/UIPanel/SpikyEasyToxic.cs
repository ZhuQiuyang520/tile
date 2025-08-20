using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikyEasyToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("AwardDesc")]    public Text SweetLowa;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    public GameObject Bank;
[UnityEngine.Serialization.FormerlySerializedAs("Money")]    public GameObject Twain;
[UnityEngine.Serialization.FormerlySerializedAs("Wand")]    public GameObject Spar;
[UnityEngine.Serialization.FormerlySerializedAs("Shuffle")]    public GameObject Harmful;
[UnityEngine.Serialization.FormerlySerializedAs("Rollback")]    public GameObject Currency;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]
    public Button Oven;
[UnityEngine.Serialization.FormerlySerializedAs("Get")]    public Button Pen;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public LowaWeary LowaBG;

    private double TundraNerve;
    private RewardPanelData _TundraHave;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        LowaBG.CostPlaza();
        Oven.interactable = true;
    }

    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        _TundraHave = (RewardPanelData)uiFormParams;
        Twain.gameObject.SetActive(false);
        Bank.gameObject.SetActive(false);
        Harmful.gameObject.SetActive(false);
        Currency.gameObject.SetActive(false);
        Spar.gameObject.SetActive(false);
        if (_TundraHave.FameSpur == "LuckyWheel")
        {
            foreach (var item in _TundraHave.Cut_Greedy)
            {
                switch (item.Key)
                {
                    case RewardType.shuffle:
                        Harmful.SetActive(true);
                        TundraNerve = item.Value;
                        break;
                    case RewardType.cash:
                        Twain.SetActive(true);
                        OilyToxic.instance.LysBank(Twain.transform, item.Value);
                        TundraNerve = item.Value;
                        break;
                    case RewardType.gold:
                        Bank.SetActive(true);
                        TundraNerve = item.Value;
                        break;
                    case RewardType.undo:
                        Currency.SetActive(true);
                        TundraNerve = item.Value;
                        break;
                    case RewardType.wand:
                        Spar.SetActive(true);
                        TundraNerve = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        SweetLowa.text = "+ " + TundraNerve;
    }

    private void Start()
    {
        Oven.onClick.AddListener(DampenHome);
        Pen.onClick.AddListener(GuessPen);
    }

    private void DampenHome()
    {
        SlayNeverSpiral.PenMonopoly().JumpNever("1010", "1");
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        ADMimetic.Monopoly.LullGreedyFluid((success) =>
        {
            if (success)
            {
                Oven.interactable = false;
                LullLowa();
            }
        }, "101");
    }
    private void GuessPen()
    {
        SlayNeverSpiral.PenMonopoly().JumpNever("1010", "0");
        ADMimetic.Monopoly.NoDefendBurIdeal();
        DampenPen();
    }

    private void DampenPen()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        foreach (var item in _TundraHave.Cut_Greedy)
        {
            switch (item.Key)
            {
                case RewardType.shuffle:
                    PlayerPrefs.SetInt(CLagoon.StudentFloral, PlayerPrefs.GetInt(CLagoon.StudentFloral) + (int)TundraNerve);
                    DeviateMimetic.PenMonopoly().Dramatize(MessageCode.StudentRead, PropType.Refresh);
                    break;
                case RewardType.undo:
                    PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, PlayerPrefs.GetInt(CLagoon.PeltWarmFloral) + (int)TundraNerve);
                    DeviateMimetic.PenMonopoly().Dramatize(MessageCode.StudentRead, PropType.Roll);
                    break;
                case RewardType.wand:
                    PlayerPrefs.SetInt(CLagoon.PerishFloral, PlayerPrefs.GetInt(CLagoon.PerishFloral) + (int)TundraNerve);
                    DeviateMimetic.PenMonopoly().Dramatize(MessageCode.StudentRead, PropType.Remind);
                    
                    break;
                case RewardType.gold:
                    PlayerPrefs.SetInt(CLagoon.BankFloral, PlayerPrefs.GetInt(CLagoon.BankFloral) + (int)TundraNerve);
                    PlayerPrefs.SetInt(CLagoon.BankFloral_All, PlayerPrefs.GetInt(CLagoon.BankFloral_All) + (int)TundraNerve);
                    OilyToxic.instance.LysBank(Bank.transform, TundraNerve);
                    break;
                default:
                    break;
            }
        }
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        OilyHaveMimetic.PenMonopoly().RayIsle(TundraNerve);
        OilyMimetic.PenMonopoly().EngineGuess = true;

        //转完转盘之后，判断是否为挑战 ，不为挑战 判断是否达到自动收牌节点，
        OilyToxic.instance.WeSpeedyLime(false);
        OilyVillage.instance.WeProdigyFancy();

        HatchUIWork(GetType().Name);
    }

    private int PenLowaPlazaNaive()
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
        return 0;
    }

    private void LullLowa()
    {
        int index = PenLowaPlazaNaive();
        LowaBG.Gear(index, (multi) => {
            // slot结束后的回调
            ConestogaAssumption.DampenFloral(TundraNerve, TundraNerve * multi, 0, SweetLowa, "+", () =>
            {
                TundraNerve = TundraNerve * multi;
                
                SweetLowa.text = "+ " + FloralFile.ZigzagMyBuy(TundraNerve);
                DampenPen();
            });
        });
    }
}
