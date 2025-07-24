using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LidBothLoder : BaseUIForms
{
    private int EatWingBorrow;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text WingCyan;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button SparkHat;
[UnityEngine.Serialization.FormerlySerializedAs("TileDesc")]    public Text DripCyan;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Hurl;
[UnityEngine.Serialization.FormerlySerializedAs("GetCoin")]    public Button MobWing;
[UnityEngine.Serialization.FormerlySerializedAs("PropIcon")]    public Image BothThai;
[UnityEngine.Serialization.FormerlySerializedAs("PropSprite")]    //0：撤回 1：魔法棒 2：洗牌
    public Sprite[] BothResume;
[UnityEngine.Serialization.FormerlySerializedAs("PropNumber")]    public Text BothBorrow;
[UnityEngine.Serialization.FormerlySerializedAs("PropDesc")]    public Text BothCyan;
[UnityEngine.Serialization.FormerlySerializedAs("BuyNumber")]
    public Text BuyBorrow;
    
    private PropType Hard;
    private int EatWarmer;
    private int StaffJob;

    
    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        RoadTenuous.GetInstance().ReliefStilt = false;
        Hard = (PropType)uiFormParams;
        EatWingBorrow = PlayerPrefs.GetInt(CConfig.CoinNumber);
        WingCyan.text = EatWingBorrow.ToString();
        switch (Hard)
        {
            case PropType.Roll:
                DripCyan.text = "More Undo ";
                BothCyan.text = "Undo last move";
                BothThai.sprite = BothResume[0];
                
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    StaffJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    StaffJob = NetInfoMgr.instance.GameData.Undo_ad_nums;
                }
                
                BothBorrow.text = "×" + StaffJob.ToString();
                EatWarmer = NetInfoMgr.instance.GameData.Undo_price;
                break;
            case PropType.Remind:
                DripCyan.text = "More Magicwand";
                BothCyan.text = "Clear 3 sets instantly";
                BothThai.sprite = BothResume[1];
               
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    StaffJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    StaffJob = NetInfoMgr.instance.GameData.Wand_ad_nums;
                }
                BothBorrow.text = "×" + StaffJob.ToString();
                EatWarmer = NetInfoMgr.instance.GameData.Wand_price;
                break;
            case PropType.Refresh:
                DripCyan.text = "More shuffle";
                BothCyan.text = "Shuffle all tiles";
                BothThai.sprite = BothResume[2];
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    StaffJob = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    StaffJob = NetInfoMgr.instance.GameData.Shuffle_ad_nums;
                }
                BothBorrow.text = "×" + StaffJob.ToString();
                EatWarmer = NetInfoMgr.instance.GameData.Shuffle_price;
                BuyBorrow.text = EatWarmer.ToString();
                break;
            default:
                break;
        }

        if (EatWingBorrow < EatWarmer)
        {
            MobWing.interactable = false;
        }
        else
        {
            MobWing.interactable = true;
        }
    }

    private void Start()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_PopShow);
        Hurl.onClick.AddListener(RatifyHurl);
        MobWing.onClick.AddListener(RatifyMobWing);
        SparkHat.onClick.AddListener(RatifySpark);
    }

    private void RatifySpark()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        switch (Hard)
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
        CloseUIForm(GetType().Name);
    }

    private void RatifyHurl()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            RoadTenuous.GetInstance().ReliefStilt = true;
            switch (Hard)
            {
                case PropType.Roll:
                    PostEventScript.GetInstance().SendEvent("9007", "1");
                    PostEventScript.GetInstance().SendEvent("1003","1");
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RollBackNumber, StaffJob);
                    }
                    
                    break;
                case PropType.Remind:
                    PostEventScript.GetInstance().SendEvent("9007", "2");
                    PostEventScript.GetInstance().SendEvent("1004", "1");
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, StaffJob);
                    }
                    
                    break;
                case PropType.Refresh:
                    PostEventScript.GetInstance().SendEvent("9007", "3");
                    PostEventScript.GetInstance().SendEvent("1005", "1");
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RefreshNumber, StaffJob);
                    }
                    break;
                default:
                    break;
            }
            SqueezeTenuous.GetInstance().Caucasian(MessageCode.BookletBoth, Hard);
            CloseUIForm(GetType().Name);
        }, "110");
    }

    private void RatifyMobWing()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        EatWingBorrow -= EatWarmer;
        ADManager.Instance.NoThanksAddCount();
        switch (Hard)
        {
            case PropType.Roll:
                PostEventScript.GetInstance().SendEvent("1003", "2");
                PlayerPrefs.SetInt(CConfig.RollBackNumber, StaffJob);
                break;
            case PropType.Remind:
                PostEventScript.GetInstance().SendEvent("1004", "2");
                PlayerPrefs.SetInt(CConfig.RemingNumber, StaffJob);
                break;
            case PropType.Refresh:
                PostEventScript.GetInstance().SendEvent("1005", "2");
                PlayerPrefs.SetInt(CConfig.RefreshNumber, StaffJob);
                break;
            default:
                break;
        }
        SqueezeTenuous.GetInstance().Caucasian(MessageCode.BookletBoth, Hard);
    }
}
