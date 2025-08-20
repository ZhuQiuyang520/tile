using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurReadToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("LeftTopCoin")]    public GameObject PostWaxBank;
    private int RyeBankFloral;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text BankDesc;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button HatchCab;
[UnityEngine.Serialization.FormerlySerializedAs("TileDesc")]    public Text CanyLowa;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Oven;
[UnityEngine.Serialization.FormerlySerializedAs("GetCoin")]    public Button PenBank;
[UnityEngine.Serialization.FormerlySerializedAs("PropIcon")]    public Image ReadBold;
[UnityEngine.Serialization.FormerlySerializedAs("PropSprite")]    //0：撤回 1：魔法棒 2：洗牌
    public Sprite[] ReadModern;
[UnityEngine.Serialization.FormerlySerializedAs("PropNumber")]    public Text ReadFloral;
[UnityEngine.Serialization.FormerlySerializedAs("PropDesc")]    public Text ReadLowa;
[UnityEngine.Serialization.FormerlySerializedAs("BuyNumber")]
    public Text MudFloral;
    
    private PropType Spur;
    private int RyeIndium;
    private int RadioYew;

    
    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        OilyMimetic.PenMonopoly().EngineGuess = false;
        Spur = (PropType)uiFormParams;
        RyeBankFloral = PlayerPrefs.GetInt(CLagoon.BankFloral);
        BankDesc.text = RyeBankFloral.ToString();

        switch (Spur)
        {
            case PropType.Roll:
                CanyLowa.text = "More Undo ";
                ReadLowa.text = "Undo last move";
                ReadBold.sprite = ReadModern[0];
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Undo_ad_nums;
                }
                
                ReadFloral.text = "×" + RadioYew.ToString();
                RyeIndium = SawSelfEke.instance.OilyHave.Undo_price;
                break;
            case PropType.Remind:
                CanyLowa.text = "More Magicwand";
                ReadLowa.text = "Clear 3 sets instantly";
                ReadBold.sprite = ReadModern[1];
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Wand_ad_nums;
                }
                ReadFloral.text = "×" + RadioYew.ToString();
                RyeIndium = SawSelfEke.instance.OilyHave.Wand_price;
                break;
            case PropType.Refresh:
                CanyLowa.text = "More shuffle";
                ReadLowa.text = "Shuffle all tiles";
                ReadBold.sprite = ReadModern[2];
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    RadioYew = SawSelfEke.instance.OilyHave.Shuffle_ad_nums;
                }
                ReadFloral.text = "×" + RadioYew.ToString();
                RyeIndium = SawSelfEke.instance.OilyHave.Shuffle_price;
                break;
            default:
                break;
        }

        MudFloral.text = RyeIndium.ToString();

        if (RyeBankFloral < RyeIndium)
        {
            PenBank.interactable = false;
        }
        else
        {
            PenBank.interactable = true;
        }
    }

    private void Start()
    {
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_PopShow);
        Oven.onClick.AddListener(DampenHome);
        PenBank.onClick.AddListener(DampenPenBank);
        HatchCab.onClick.AddListener(DampenHatch);

        Oven.gameObject.SetActive(true);
    }

    private void DampenHatch()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            switch (Spur)
            {
                case PropType.Roll:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1040", "0", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                case PropType.Remind:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1041", "0", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                case PropType.Refresh:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1042", "0", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (Spur)
            {
                case PropType.Roll:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1003", "0");
                    break;
                case PropType.Remind:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1004", "0");
                    break;
                case PropType.Refresh:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1005", "0");
                    break;
                default:
                    break;
            }
        }
        
        HatchUIWork(GetType().Name);
    }

    private void DampenHome()
    {
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            switch (Spur)
            {
                case PropType.Roll:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1040", "1", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                case PropType.Remind:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1041", "1", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                case PropType.Refresh:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1042", "1", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (Spur)
            {
                case PropType.Roll:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1003", "1");
                    break;
                case PropType.Remind:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1004", "1");
                    break;
                case PropType.Refresh:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1005", "1");
                    break;
                default:
                    break;
            }
        }
       
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        ADMimetic.Monopoly.LullGreedyFluid((success) =>
        {
            if (success)
            {
                switch (Spur)
                {
                    case PropType.Roll:
                        
                        if (OilyMimetic.PenMonopoly().WeAdmission)
                        {
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "8");
                        }
                        else
                        {
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "1");
                            PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, RadioYew);
                        }

                        break;
                    case PropType.Remind:
                       
                        if (OilyMimetic.PenMonopoly().WeAdmission)
                        {
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "9");
                        }
                        else
                        {
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "2");
                            PlayerPrefs.SetInt(CLagoon.PerishFloral, RadioYew);
                        }

                        break;
                    case PropType.Refresh:
                        
                        if (!OilyMimetic.PenMonopoly().WeAdmission)
                        {
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "10");
                        }
                        else
                        {
                            PlayerPrefs.SetInt(CLagoon.StudentFloral, RadioYew);
                            SlayNeverSpiral.PenMonopoly().JumpNever("9007", "3");
                        }
                        break;
                    default:
                        break;
                }
                OilyMimetic.PenMonopoly().EngineGuess = true;
                DeviateMimetic.PenMonopoly().Dramatize(MessageCode.StudentRead, Spur);
                HatchUIWork(GetType().Name);
            }

        }, "110");
    }

    private void DampenPenBank()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().EngineGuess = true;
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        RyeBankFloral -= RyeIndium;
        PlayerPrefs.SetInt(CLagoon.BankFloral, RyeBankFloral);
        //ADMimetic.Instance.NoThanksAddCount();
        if (!OilyMimetic.PenMonopoly().WeAdmission)
        {
            switch (Spur)
            {
                case PropType.Roll:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1003", "2");
                    PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, RadioYew);
                    break;
                case PropType.Remind:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1004", "2");
                    PlayerPrefs.SetInt(CLagoon.PerishFloral, RadioYew);
                    break;
                case PropType.Refresh:
                    SlayNeverSpiral.PenMonopoly().JumpNever("1005", "2");
                    PlayerPrefs.SetInt(CLagoon.StudentFloral, RadioYew);
                    break;
                default:
                    break;
            }
        }
        
        DeviateMimetic.PenMonopoly().Dramatize(MessageCode.StudentRead, Spur);
        HatchUIWork(GetType().Name);
    }
}
