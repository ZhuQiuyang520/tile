using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElliotLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("FinishButton")]    public Button ElliotCanopy;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    public Button Hurl;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    public Text WingCyan;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyDesc")]    public Text SonicCyan;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public ThawLayer ThawBG;
    private double SparseFence;
    private bool PerHusbandWeHat;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyIcon")]
    public Transform SonicThai;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
    public Animator EraLop;

    private string[] ChallengeAwardNumber;
    // Start is called before the first frame update
    void Start()
    {
        ElliotCanopy.onClick.AddListener(RatifySpark);
        Hurl.onClick.AddListener(RatifyHurl);
    }

    protected override void Awake()
    {
        base.Awake();
        string ChallengeAward = NetInfoMgr.instance.GameData.Challenge_Reward;
        ChallengeAwardNumber = ChallengeAward.Split('|');
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Hurl.interactable = true;
        ThawBG.OralCrimp();
        RoadTenuous.GetInstance().UsuallyStuff();
        WingCyan.text = "+" + NetInfoMgr.instance.GameData.win_coins;
        
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 0)
            {
                SonicCyan.text = "+" + ChallengeAwardNumber[0];
            }
            else if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 1)
            {
                SonicCyan.text = "+" + ChallengeAwardNumber[1];
            }
        }
        else
        {
            SparseFence = NetInfoMgr.instance.GameData.Win_Cash;
            SonicCyan.text = "+" + SparseFence;
        }  
    }

    private void RatifyHurl()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        PostEventScript.GetInstance().SendEvent("1006", "1");
        if (DyAimGulf())
        {
            GrowThaw();
        }
        else
        {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    Hurl.interactable = false;
                    PostEventScript.GetInstance().SendEvent("9007", "4");
                    GrowThaw();
                }
            }, "101");
        }
    }

    private void RatifySpark()
    {
        RatifyElliot();
        //AniObj.enabled = true;
        //RotationTasmania AniManager = AniObj.gameObject.AddComponent<RotationTasmania>();
        //AniManager.AddMethod(ChangeFinish);
        //AniObj.Play("FinishPanel_End");
    }
    private void RatifyElliot()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        PostEventScript.GetInstance().SendEvent("1006", "0");
        
        //AniObj.enabled = false;
        CloseUIForm(GetType().Name);
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 2)
            {
                RoadLoder.instance.OatWing(SonicThai, double.Parse( ChallengeAwardNumber[2]));
                UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
            }
            else
            {
                if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 0)
                {
                    RoadLoder.instance.OatWing(SonicThai, double.Parse(ChallengeAwardNumber[0]));
                }
                else if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 1)
                {
                    RoadLoder.instance.OatWing(SonicThai, double.Parse(ChallengeAwardNumber[1]));
                }
                UIManager.GetInstance().ShowUIForms(nameof(TelescopeSunLoder));
            }
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.sv_CurLevel, PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
            SaveDataManager.SetInt(CConfig.sv_ad_trial_num, PlayerPrefs.GetInt(CConfig.sv_CurLevel));
            RoadTenuous.GetInstance().OfRadishTelescope = PlayerPrefs.GetInt(CConfig.sv_CurLevel) > NetInfoMgr.instance.GameData.Daily_Challenge;
            if (PlayerPrefs.GetInt(CConfig.sv_CurLevel) == NetInfoMgr.instance.GameData.RateUs_config)
            {
                UIManager.GetInstance().ShowUIForms(nameof(TuskLoder));
                UIManager.GetInstance().ShowUIForms(nameof(ClueNoLoder));
            }
            else
            {
                UIManager.GetInstance().ShowUIForms(nameof(RoadLoder), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
            }
        }
        RoadLoder.instance.OatWing(SonicThai, NetInfoMgr.instance.GameData.Win_Cash);
    }

    private bool DyAimGulf()
    {
        return !PlayerPrefs.HasKey(CConfig.sv_FirstSlot + "Bool") || SaveDataManager.GetBool(CConfig.sv_FirstSlot);
    }

    private int FadThawCrimpAlarm()
    {
        // 新用户，第一次固定翻5倍
        if (DyAimGulf())
        {
            int index = 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
            {
                if (wg.multi == 5)
                {
                    return index;
                }
                index++;
            }
        }
        else
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

        }
        return 0;
    }

    private void GrowThaw()
    {
        int index = FadThawCrimpAlarm();
        ThawBG.Food(index, (multi) => {
            // slot结束后的回调

            AnimationController.ChangeNumber(SparseFence, SparseFence * multi, 0, SonicCyan, "+", () =>
            {
                SparseFence = SparseFence * multi;
                SonicCyan.text = "+" + NumberUtil.DoubleToStr(SparseFence);
                PerHusbandWeHat = true;
                RatifySpark();
            });
        });

        SaveDataManager.SetBool(CConfig.sv_FirstSlot, false);
    }
}
