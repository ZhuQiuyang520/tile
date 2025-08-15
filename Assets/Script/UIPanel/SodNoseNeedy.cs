using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodNoseNeedy : BaseUIForms
{
    private int BayBulbButton;
[UnityEngine.Serialization.FormerlySerializedAs("LeftTopCoin")]    public GameObject HaulGinBeef;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("WingCyan")]public Text BulbFlax;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("SparkHat")]public Button KrillThe;
[UnityEngine.Serialization.FormerlySerializedAs("TileDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("DripCyan")]public Text BoatFlax;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    [UnityEngine.Serialization.FormerlySerializedAs("Hurl")]public Button Item;
[UnityEngine.Serialization.FormerlySerializedAs("GetCoin")]    [UnityEngine.Serialization.FormerlySerializedAs("MobWing")]public Button YouBulb;
[UnityEngine.Serialization.FormerlySerializedAs("PropIcon")]    [UnityEngine.Serialization.FormerlySerializedAs("BothThai")]public Image NoseSilt;
[UnityEngine.Serialization.FormerlySerializedAs("PropSprite")]    //0：撤回 1：魔法棒 2：洗牌
[UnityEngine.Serialization.FormerlySerializedAs("BothResume")]    public Sprite[] NoseAwaken;
[UnityEngine.Serialization.FormerlySerializedAs("PropNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("BothBorrow")]public Text NoseButton;
[UnityEngine.Serialization.FormerlySerializedAs("PropDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("BothCyan")]public Text NoseFlax;
[UnityEngine.Serialization.FormerlySerializedAs("BuyNumber")]
[UnityEngine.Serialization.FormerlySerializedAs("BuyBorrow")]    public Text YamButton;
    
    private PropType Next;
    private int BayFodder;
    private int AtlasJob;

    
    
    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        RaftNonself.GetInstance().EmpireStilt = false;
        Next = (PropType)uiFormParams;
        
        BayBulbButton = PlayerPrefs.GetInt(CConfig.CoinNumber);
        BulbFlax.text = BayBulbButton.ToString();
        switch (Next)
        {
            case PropType.Roll:
                BoatFlax.text = "More Undo ";
                NoseFlax.text = "Undo last move";
                NoseSilt.sprite = NoseAwaken[0];
                
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Undo_ad_nums;
                }
                
                NoseButton.text = "×" + AtlasJob.ToString();
                BayFodder = NetInfoMgr.instance.GameData.Undo_price;
                YamButton.text = BayFodder.ToString();
                break;
            case PropType.Remind:
                BoatFlax.text = "More Magicwand";
                NoseFlax.text = "Clear 3 sets instantly";
                NoseSilt.sprite = NoseAwaken[1];
               
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Wand_ad_nums;
                }
                NoseButton.text = "×" + AtlasJob.ToString();
                BayFodder = NetInfoMgr.instance.GameData.Wand_price;
                YamButton.text = BayFodder.ToString();
                break;
            case PropType.Refresh:
                BoatFlax.text = "More shuffle";
                NoseFlax.text = "Shuffle all tiles";
                NoseSilt.sprite = NoseAwaken[2];
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    AtlasJob = NetInfoMgr.instance.GameData.Shuffle_ad_nums;
                }
                
                NoseButton.text = "×" + AtlasJob.ToString();
                BayFodder = NetInfoMgr.instance.GameData.Shuffle_price;
                YamButton.text = BayFodder.ToString();
                break;
            default:
                break;
        }
        if (BayBulbButton < BayFodder)
        {
            YouBulb.interactable = false;
        }
        else
        {
            YouBulb.interactable = true;
        }
    }

    private void Start()
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_PopShow);
        Item.onClick.AddListener(CinemaItem);
        YouBulb.onClick.AddListener(CinemaYouBulb);
        KrillThe.onClick.AddListener(CinemaKrill);

        if (CommonUtil.IsApple())
        {
            YouBulb.gameObject.SetActive(true);
            HaulGinBeef.SetActive(true);
        }
        else
        {
            Item.gameObject.SetActive(true);
        }
    }

    private void CinemaKrill()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            switch (Next)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("1040", "0", RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("1041", "0", RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("1042", "0", RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (Next)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("1003", "0");
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("1004", "0");
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("1005", "0");
                    break;
                default:
                    break;
            }
        }
        
        CloseUIForm(GetType().Name);
    }

    private void CinemaItem()
    {
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            switch (Next)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("1040", "1",RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("1041", "1", RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("1042", "1", RaftNonself.GetInstance().ActCharacterBread().ToString());
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (Next)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("1003", "1");
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("1004", "1");
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("1005", "1");
                    break;
                default:
                    break;
            }
        }
       
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            RaftNonself.GetInstance().EmpireStilt = true;
            if (success)
            {
                switch (Next)
                {
                    case PropType.Roll:
                        if (RaftNonself.GetInstance().MeOutrigger)
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "8");
                        }
                        else
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "1");
                        }
                        

                        if (!RaftNonself.GetInstance().MeOutrigger)
                        {
                            PlayerPrefs.SetInt(CConfig.RollBackNumber, AtlasJob);
                        }

                        break;
                    case PropType.Remind:
                        if (RaftNonself.GetInstance().MeOutrigger)
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "9");
                        }
                        else
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "2");
                        }

                        if (!RaftNonself.GetInstance().MeOutrigger)
                        {
                            PlayerPrefs.SetInt(CConfig.RemingNumber, AtlasJob);
                        }

                        break;
                    case PropType.Refresh:
                        if (RaftNonself.GetInstance().MeOutrigger)
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "10");
                        }
                        else
                        {
                            PostEventScript.GetInstance().SendEvent("9007", "3");
                        }

                        if (!RaftNonself.GetInstance().MeOutrigger)
                        {
                            PlayerPrefs.SetInt(CConfig.RefreshNumber, AtlasJob);
                        }
                        break;
                    default:
                        break;
                }
                
                EpisodeNonself.GetInstance().Untouched(MessageCode.SaguaroNose, Next);
                CloseUIForm(GetType().Name);
            }
        }, "110");
    }

    private void CinemaYouBulb()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().EmpireStilt = true;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        BayBulbButton -= BayFodder;
        PlayerPrefs.SetInt(CConfig.CoinNumber, BayBulbButton);
        //ADManager.Instance.NoThanksAddCount();
        if (!RaftNonself.GetInstance().MeOutrigger)
        {
            switch (Next)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("1003", "2");
                    PlayerPrefs.SetInt(CConfig.RollBackNumber, AtlasJob);
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("1004", "2");
                    PlayerPrefs.SetInt(CConfig.RemingNumber, AtlasJob);
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("1005", "2");
                    PlayerPrefs.SetInt(CConfig.RefreshNumber, AtlasJob);
                    break;
                default:
                    break;
            }
        }
        EpisodeNonself.GetInstance().Untouched(MessageCode.SaguaroNose, Next);
        CloseUIForm(GetType().Name);
    }
}
