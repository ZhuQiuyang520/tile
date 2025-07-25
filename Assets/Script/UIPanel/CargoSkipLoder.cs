using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoSkipLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("AwardDesc")]    public Text DreamCyan;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    public GameObject Wing;
[UnityEngine.Serialization.FormerlySerializedAs("Money")]    public GameObject Sonic;
[UnityEngine.Serialization.FormerlySerializedAs("Wand")]    public GameObject Loam;
[UnityEngine.Serialization.FormerlySerializedAs("Shuffle")]    public GameObject Fragile;
[UnityEngine.Serialization.FormerlySerializedAs("Rollback")]    public GameObject Exponent;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]
    public Button Hurl;
[UnityEngine.Serialization.FormerlySerializedAs("Get")]    public Button Mob;
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public ThawLayer ThawBG;

    private double SparseFence;
    private RewardPanelData _SparseNeck;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ThawBG.OralCrimp();
        Hurl.interactable = true;
    }

    protected override void OnMessageReceived(object uiFormParams)
    {
        base.OnMessageReceived(uiFormParams);
        _SparseNeck = (RewardPanelData)uiFormParams;
        Sonic.gameObject.SetActive(false);
        Wing.gameObject.SetActive(false);
        Fragile.gameObject.SetActive(false);
        Exponent.gameObject.SetActive(false);
        Loam.gameObject.SetActive(false);
        Debug.Log(_SparseNeck.NoseHard);
        if (_SparseNeck.NoseHard == "LuckyWheel")
        {
            foreach (var item in _SparseNeck.Rim_Marlin)
            {
                Debug.Log(item.Key);
                switch (item.Key)
                {
                    case RewardType.shuffle:
                        Fragile.SetActive(true);
                        SparseFence = item.Value;
                        break;
                    case RewardType.cash:
                        Sonic.SetActive(true);
                        RoadLoder.instance.OatWing(Sonic.transform, item.Value);
                        SparseFence = item.Value;
                        break;
                    case RewardType.gold:
                        Wing.SetActive(true);
                        SparseFence = item.Value;
                        break;
                    case RewardType.undo:
                        Exponent.SetActive(true);
                        SparseFence = item.Value;
                        break;
                    case RewardType.wand:
                        Loam.SetActive(true);
                        SparseFence = item.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        DreamCyan.text = "+ " + SparseFence;
    }

    private void Start()
    {
        Hurl.onClick.AddListener(RatifyHurl);
        Mob.onClick.AddListener(RatifyMob);
    }

    private void RatifyHurl()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        ADManager.Instance.playRewardVideo((success) =>
        {
            if (success)
            {
                Hurl.interactable = false;
                GrowThaw();
            }
        }, "101");
    }

    private void RatifyMob()
    {
        foreach (var item in _SparseNeck.Rim_Marlin)
        {
            switch (item.Key)
            {
                case RewardType.shuffle:
                    PlayerPrefs.SetInt(CConfig.RefreshNumber, PlayerPrefs.GetInt(CConfig.RefreshNumber) + (int)SparseFence);
                    SqueezeTenuous.GetInstance().Caucasian(MessageCode.BookletBoth, PropType.Refresh);
                    
                    break;
                case RewardType.undo:
                    PlayerPrefs.SetInt(CConfig.RollBackNumber, PlayerPrefs.GetInt(CConfig.RollBackNumber) + (int)SparseFence);
                    SqueezeTenuous.GetInstance().Caucasian(MessageCode.BookletBoth, PropType.Roll);
                    break;
                case RewardType.wand:
                    PlayerPrefs.SetInt(CConfig.RemingNumber, PlayerPrefs.GetInt(CConfig.RemingNumber) + (int)SparseFence);
                    SqueezeTenuous.GetInstance().Caucasian(MessageCode.BookletBoth, PropType.Remind);
                    break;
                case RewardType.gold:
                    RoadLoder.instance.OatWing(Wing.transform, SparseFence);
                    break;
                default:
                    break;
            }
        }
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        RoadNeckTenuous.GetInstance().addWild(SparseFence);
        RoadTenuous.GetInstance().ReliefStilt = true;
        CloseUIForm(GetType().Name);
    }

    private int FadThawCrimpAlarm()
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

    private void GrowThaw()
    {
        int index = FadThawCrimpAlarm();
        ThawBG.Food(index, (multi) => {
            // slot结束后的回调
            AnimationController.ChangeNumber(SparseFence, SparseFence * multi, 0, DreamCyan, "+", () =>
            {
                SparseFence = SparseFence * multi;
                
                DreamCyan.text = "+ " + NumberUtil.DoubleToStr(SparseFence);
                RatifyMob();
            });
        });
    }
}
