using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavorBlurNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("AwardDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("DreamCyan")]public Text PeartFlax;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    [UnityEngine.Serialization.FormerlySerializedAs("Wing")]public GameObject Bulb;
[UnityEngine.Serialization.FormerlySerializedAs("Money")]    [UnityEngine.Serialization.FormerlySerializedAs("Sonic")]public GameObject Maple;
[UnityEngine.Serialization.FormerlySerializedAs("Wand")]    [UnityEngine.Serialization.FormerlySerializedAs("Loam")]public GameObject Ride;
[UnityEngine.Serialization.FormerlySerializedAs("Shuffle")]    [UnityEngine.Serialization.FormerlySerializedAs("Fragile")]public GameObject Eyeball;
[UnityEngine.Serialization.FormerlySerializedAs("Rollback")]    [UnityEngine.Serialization.FormerlySerializedAs("Exponent")]public GameObject Recreate;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]
[UnityEngine.Serialization.FormerlySerializedAs("Hurl")]    public Button Item;
[UnityEngine.Serialization.FormerlySerializedAs("Get")]    [UnityEngine.Serialization.FormerlySerializedAs("Mob")]public Button You;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    [UnityEngine.Serialization.FormerlySerializedAs("ThawBG")]public LoadPlace LoadBG;

    private double UsableDrain;
    private RewardPanelData _UsableWeed;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        LoadBG.PineOlive();
        Item.interactable = true;
    }

    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        _UsableWeed = (RewardPanelData)uiFormParams;
        Maple.gameObject.SetActive(false);
        Bulb.gameObject.SetActive(false);
        Eyeball.gameObject.SetActive(false);
        Recreate.gameObject.SetActive(false);
        Ride.gameObject.SetActive(false);
        if (_UsableWeed.ForkNext == "LuckyWheel")
        {
            foreach (var item in _UsableWeed.Lug_Thirty)
            {
                switch (item.Key)
                {
                    case RewardType.shuffle:
                        Eyeball.SetActive(true);
                        UsableDrain = item.Value;
                        break;
                    case RewardType.cash:
                        Maple.SetActive(true);
                        RaftNeedy.instance.AimBulb(Maple.transform, item.Value);
                        UsableDrain = item.Value;
                        break;
                    case RewardType.gold:
                        Bulb.SetActive(true);
                        UsableDrain = item.Value;
                        break;
                    case RewardType.undo:
                        Recreate.SetActive(true);
                        UsableDrain = item.Value;
                        break;
                    case RewardType.wand:
                        Ride.SetActive(true);
                        UsableDrain = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        PeartFlax.text = "+ " + UsableDrain;
    }

    private void Start()
    {
        Item.onClick.AddListener(CinemaItem);
        You.onClick.AddListener(BrantAct);
    }

    private void CinemaItem()
    {
        PostEventScript.GetInstance().SendEvent("1010", "1");
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            if (success)
            {
                Item.interactable = false;
                GrowLoad();
            }
        }, "101");
    }

    private void BrantAct()
    {
        ADManager.Instance.NoThanksAddCount();
        PostEventScript.GetInstance().SendEvent("1010", "0");
        CinemaYou();
    }

    private void CinemaYou()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        foreach (var item in _UsableWeed.Lug_Thirty)
        {
            switch (item.Key)
            {
                case RewardType.shuffle:
                    PlayerPrefs.SetInt(CConfig.RefreshNumber, PlayerPrefs.GetInt(CConfig.RefreshNumber) + (int)UsableDrain);
                    EpisodeNonself.GetInstance().Untouched(MessageCode.SaguaroNose, PropType.Refresh);
                    
                    break;
                case RewardType.undo:
                    PlayerPrefs.SetInt(CConfig.RollBackNumber, PlayerPrefs.GetInt(CConfig.RollBackNumber) + (int)UsableDrain);
                    EpisodeNonself.GetInstance().Untouched(MessageCode.SaguaroNose, PropType.Roll);
                    break;
                case RewardType.wand:
                    PlayerPrefs.SetInt(CConfig.RemingNumber, PlayerPrefs.GetInt(CConfig.RemingNumber) + (int)UsableDrain);
                    EpisodeNonself.GetInstance().Untouched(MessageCode.SaguaroNose, PropType.Remind);
                    break;
                case RewardType.gold:
                    PlayerPrefs.SetInt(CConfig.CoinNumber, PlayerPrefs.GetInt(CConfig.CoinNumber) + (int)UsableDrain);
                    PlayerPrefs.SetInt(CConfig.CoinNumber_All, PlayerPrefs.GetInt(CConfig.CoinNumber_All) + (int)UsableDrain);
                    RaftNeedy.instance.AimBulb(Bulb.transform, UsableDrain);
                    break;
                default:
                    break;
            }
        }
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        RaftWeedNonself.GetInstance().MudVase(UsableDrain);
        RaftNonself.GetInstance().EmpireStilt = true;
        //转完转盘之后，判断是否为挑战 ，不为挑战 判断是否达到自动收牌节点，
        RaftNeedy.instance.OfFecundSoda(false);
        RaftMeeting.instance.OfTriggerQuest();
        CloseUIForm(GetType().Name);
    }

    private int SadLoadOliveAbove()
    {
        int sumWeight = 0;
        foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
        {
            sumWeight += wg.weight;
        }
        int r = Random.Range(0, sumWeight);
        int nowWeight = 0;
        int index = 0;
        foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
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

    private void GrowLoad()
    {
        int index = SadLoadOliveAbove();
        LoadBG.Fray(index, (multi) => {
            // slot结束后的回调
            AnimationController.ChangeNumber(UsableDrain, UsableDrain * multi, 0, PeartFlax, "+", () =>
            {
                UsableDrain = UsableDrain * multi;
                
                PeartFlax.text = "+ " + NumberUtil.DoubleToStr(UsableDrain);
                CinemaYou();
            });
        });
    }
}
