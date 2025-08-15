using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CattleNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("FinishButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ElliotCanopy")]public Button CattleSister;
[UnityEngine.Serialization.FormerlySerializedAs("Free")]    [UnityEngine.Serialization.FormerlySerializedAs("Hurl")]public Button Item;
[UnityEngine.Serialization.FormerlySerializedAs("CoinDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("WingCyan")]public Text BulbFlax;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("SonicCyan")]public Text MapleFlax;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    [UnityEngine.Serialization.FormerlySerializedAs("ThawBG")]public LoadPlace LoadBG;
    private double UsableDrain;
    private bool CanUntwistIfThe;
[UnityEngine.Serialization.FormerlySerializedAs("MoneyIcon")]
[UnityEngine.Serialization.FormerlySerializedAs("SonicThai")]    public Transform MapleSilt;
[UnityEngine.Serialization.FormerlySerializedAs("AniObj")]
[UnityEngine.Serialization.FormerlySerializedAs("EraLop")]    public Animator JoyTar;

    private string[] CharacterLoderMandan;
    // Start is called before the first frame update
    void Start()
    {
        CattleSister.onClick.AddListener(ActYeast);
        Item.onClick.AddListener(CinemaItem);
    }

    protected override void Awake()
    {
        base.Awake();
        AromaticPamphlet AniManager = JoyTar.gameObject.AddComponent<AromaticPamphlet>();
        AniManager.SodCrease(RunSweep);
        string ChallengeAward = NetInfoMgr.instance.GameData.Challenge_Reward;
        CharacterLoderMandan = ChallengeAward.Split('|');
    }

    private void RunSweep()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.Success);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RaftNeedy.instance.OfFecundSoda(false);
        CashOutManager.GetInstance().AddTaskValue("Level", 1);
        Item.interactable = true;
        LoadBG.PineOlive();
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.Success);


        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1023", RaftNonself.GetInstance().ActCharacterBread().ToString());
            PostEventScript.GetInstance().SendEvent("1031", RaftNonself.GetInstance().ActCharacterBread().ToString(),RaftNonself.GetInstance().Slowly.ToString());
            string challengeRoll = RaftNonself.GetInstance().ShyFortKill.ToString();
            string challengeRemind = RaftNonself.GetInstance().ShyAscent.ToString();
            string challengeRefresh = RaftNonself.GetInstance().ShyIridium.ToString();
            StringBuilder str = new StringBuilder();
            str.Append(challengeRoll);
            str.Append(challengeRemind);
            str.Append(challengeRefresh);
            PostEventScript.GetInstance().SendEvent("1027", RaftNonself.GetInstance().ActCharacterBread().ToString(), str.ToString());
            PostEventScript.GetInstance().SendEvent("1036", RaftNonself.GetInstance().ActCharacterBread().ToString(), str.ToString(), RaftNonself.GetInstance().Slowly.ToString());
            if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 0)
            {
                MapleFlax.text = "+" + CharacterLoderMandan[0];
                UsableDrain = double.Parse( CharacterLoderMandan[0]);
            }
            else if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 1)
            {
                MapleFlax.text = "+" + CharacterLoderMandan[1];
                UsableDrain = double.Parse(CharacterLoderMandan[1]);
            }
            else if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 2)
            {
                MapleFlax.text = "+" + CharacterLoderMandan[2];
                UsableDrain = double.Parse(CharacterLoderMandan[2]);
            }
        }
        else
        {
            if (CommonUtil.IsApple())
            {
                UsableDrain = NetInfoMgr.instance.GameData.win_coins;
            }
            else
            {
                UsableDrain = NetInfoMgr.instance.GameData.Win_Cash;
            }
            MapleFlax.text = "+" + UsableDrain;
        }  
    }

    private void CinemaItem()
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1035", "1");
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1006", "1");
        }
        
        if (ByGapTime())
        {
            Item.interactable = false;
            GrowLoad();
        }
        else
        {
            ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    Item.interactable = false;
                    GrowLoad();
                }
            }, "101");
        }
    }

    private void ActYeast()
    {
        ADManager.Instance.NoThanksAddCount();
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            PostEventScript.GetInstance().SendEvent("1035", "0");
        }
        else
        {
            PostEventScript.GetInstance().SendEvent("1006", "0");
        }
        CinemaKrill();
    }

    private void CinemaKrill()
    {
        if (CommonUtil.IsApple())
        {
            PlayerPrefs.SetInt(CConfig.CoinNumber, PlayerPrefs.GetInt(CConfig.CoinNumber) + (int)UsableDrain);
            PlayerPrefs.SetInt(CConfig.CoinNumber_All, PlayerPrefs.GetInt(CConfig.CoinNumber_All) + (int)UsableDrain);
        }
        
        CinemaCattle();
        
        //AniObj.enabled = true;
        //AromaticPamphlet AniManager = AniObj.gameObject.AddComponent<AromaticPamphlet>();
        //AniManager.AddMethod(ChangeFinish);
        //AniObj.Play("FinishPanel_End");
    }
    private void CinemaCattle()
    {
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        
        //AniObj.enabled = false;
        CloseUIForm(GetType().Name);
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            if (PlayerPrefs.GetInt(CConfig.NowDayChallenAward) == 2)
            {
                UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
            }
            else
            {
                UIManager.GetInstance().ShowUIForms(nameof(OutriggerTopNeedy));
            }
        }
        else
        {
            PlayerPrefs.SetInt(CConfig.sv_CurLevel, PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
            SaveDataManager.SetInt(CConfig.sv_ad_trial_num, PlayerPrefs.GetInt(CConfig.sv_ad_trial_num) + 1);
            RaftNonself.GetInstance().MeExtentOutrigger = PlayerPrefs.GetInt(CConfig.sv_CurLevel) > NetInfoMgr.instance.GameData.Daily_Challenge;
            //审核模式继续玩  普通模式判断是否跳到好评
            if (CommonUtil.IsApple())
            {
                UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
            }
            else
            {
                if (PlayerPrefs.GetInt(CConfig.sv_CurLevel) == NetInfoMgr.instance.GameData.RateUs_config)
                {
                    UIManager.GetInstance().ShowUIForms(nameof(TuckNeedy));
                    UIManager.GetInstance().ShowUIForms(nameof(FlatNoNeedy));
                }
                else
                {
                    UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
                }
            }
            
        }
        RaftNeedy.instance.AimBulb(MapleSilt, UsableDrain);
    }

    private bool ByGapTime()
    {
        return !PlayerPrefs.HasKey(CConfig.sv_FirstSlot + "Bool") || SaveDataManager.GetBool(CConfig.sv_FirstSlot);
    }

    private int SadLoadOliveAbove()
    {
        // 新用户，第一次固定翻5倍
        if (ByGapTime())
        {
            int index = 0;
            foreach (SlotItem wg in NetInfoMgr.instance.InitData.slot_group)
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

    private void GrowLoad()
    {
        int index = SadLoadOliveAbove();
        LoadBG.Fray(index, (multi) => {
            // slot结束后的回调
            PostEventScript.GetInstance().SendEvent("9007", "4");
            AnimationController.ChangeNumber(UsableDrain, UsableDrain * multi, 0, MapleFlax, "+", () =>
            {
                UsableDrain = UsableDrain * multi;
                MapleFlax.text = "+" + NumberUtil.DoubleToStr(UsableDrain);
                
                CanUntwistIfThe = true;
                CinemaKrill();
            });
        });

        SaveDataManager.SetBool(CConfig.sv_FirstSlot, false);
    }
}
