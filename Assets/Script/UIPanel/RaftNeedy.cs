using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;

public class RaftNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ButtonMask")]    public GameObject FecundSoda;
[UnityEngine.Serialization.FormerlySerializedAs("GuideObj")]    [UnityEngine.Serialization.FormerlySerializedAs("IdealLop")]public GameObject[] UntieTar;
[UnityEngine.Serialization.FormerlySerializedAs("WangzhuanMask")]
[UnityEngine.Serialization.FormerlySerializedAs("ProboscisClaw")]    public GameObject IntensiveCall;
[UnityEngine.Serialization.FormerlySerializedAs("WangzhuanObj")]    public GameObject ForefrontDig;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    public GameObject Beef;
[UnityEngine.Serialization.FormerlySerializedAs("CoinNumber")]    public Text BeefMandan;
[UnityEngine.Serialization.FormerlySerializedAs("PutongLevel")]
[UnityEngine.Serialization.FormerlySerializedAs("FervorBleak")]    public GameObject BehalfGrant;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeLevel")]
[UnityEngine.Serialization.FormerlySerializedAs("TelescopeBleak")]    public GameObject OutriggerGrant;
[UnityEngine.Serialization.FormerlySerializedAs("AwardColor")]
[UnityEngine.Serialization.FormerlySerializedAs("DreamTract")]    public Color PeartSolar;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeSlider")]    [UnityEngine.Serialization.FormerlySerializedAs("TelescopeSocial")]public GameObject OutriggerIsrael;
[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    public Text Loder1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    public Text Loder2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    public Text Loder3;

[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream1")]public Image Peart1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream2")]public Image Peart2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream3")]public Image Peart3;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeHandle")]    [UnityEngine.Serialization.FormerlySerializedAs("TelescopeRetire")]public Image OutriggerReveal;
[UnityEngine.Serialization.FormerlySerializedAs("ticker")]
[UnityEngine.Serialization.FormerlySerializedAs("Indoor")]    public SatisfactionDorsal Sulfur;
    public static RaftNeedy instance;
[UnityEngine.Serialization.FormerlySerializedAs("TrunImage")]
[UnityEngine.Serialization.FormerlySerializedAs("GirlActor")]    public Image DarkPeace;
    private float ArtDrain;
    private float BagDrain;
[UnityEngine.Serialization.FormerlySerializedAs("RemindBtn")]
[UnityEngine.Serialization.FormerlySerializedAs("ForgetHat")]    public Button RavineThe;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("BookletHat")]public Button SaguaroThe;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("BeltDareHat")]public Button CostDareThe;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("UsuallyHat")]public Button QuicklyThe;
[UnityEngine.Serialization.FormerlySerializedAs("Level")]    [UnityEngine.Serialization.FormerlySerializedAs("Bleak")]public Text Grant;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackAddTip")]
[UnityEngine.Serialization.FormerlySerializedAs("BeltDareLidWax")]    public GameObject CostFailSodIce;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackNumberTip")]    [UnityEngine.Serialization.FormerlySerializedAs("BeltDareBorrowWax")]public GameObject CostFailButtonIce;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackText")]    [UnityEngine.Serialization.FormerlySerializedAs("BeltDareStep")]public Text CostFailNear;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshAddTip")]
[UnityEngine.Serialization.FormerlySerializedAs("BookletLidWax")]    public GameObject SaguaroSodIce;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshNumberTip")]    [UnityEngine.Serialization.FormerlySerializedAs("BookletBorrowWax")]public GameObject SaguaroButtonIce;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshText")]    [UnityEngine.Serialization.FormerlySerializedAs("BookletStep")]public Text SaguaroNear;
[UnityEngine.Serialization.FormerlySerializedAs("RemindAddTip")]
[UnityEngine.Serialization.FormerlySerializedAs("ForgetLidWax")]    public GameObject RavineSodIce;
[UnityEngine.Serialization.FormerlySerializedAs("RemindNumberTip")]    [UnityEngine.Serialization.FormerlySerializedAs("ForgetBorrowWax")]public GameObject RavineButtonIce;
[UnityEngine.Serialization.FormerlySerializedAs("RemindText")]    [UnityEngine.Serialization.FormerlySerializedAs("ForgetStep")]public Text RavineNear;

    //refreshNumber
    private int SaguaroButton;
    //remindNumber
    private int RavineButton;
    //rollbackNumber
    private int CostFailButton;
    private bool MeTonRavine;
[UnityEngine.Serialization.FormerlySerializedAs("Niceskeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("Enterprising")]public SkeletonGraphic Legitimately;
[UnityEngine.Serialization.FormerlySerializedAs("GreatSkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("EquipHomeland")]public SkeletonGraphic SlothCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("AwesomeSkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("LoyaltyHomeland")]public SkeletonGraphic MelangeCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("AmazingSkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("AmenityHomeland")]public SkeletonGraphic GenericCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("LegendarySkeleton")]    [UnityEngine.Serialization.FormerlySerializedAs("HillbillyHomeland")]public SkeletonGraphic MercilessCetacean;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
[UnityEngine.Serialization.FormerlySerializedAs("WingThai")]    public GameObject BulbSilt;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    [UnityEngine.Serialization.FormerlySerializedAs("SewWay")]public Transform SeaFlu;

    private int OutriggerRavineButton;
    private int OutriggerCostButton;
    private int OutriggerSaguaroButton;

    private string[] CharacterLoderMandan;

    private Sequence ForefrontSplit;

    private int ShyFortKill= 0;
    private int ShyAscent= 0;
    private int ShyIridium= 0;

    private bool OfShyAscent= true;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
        if (CommonUtil.IsApple())
        {
            IntensiveCall.SetActive(false);
            ForefrontDig.SetActive(false);
            Beef.SetActive(true);
        }
        BeefMandan.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        string ChallengeAward = NetInfoMgr.instance.GameData.Challenge_Reward;
        CharacterLoderMandan = ChallengeAward.Split('|');
        EpisodeNonself.GetInstance().SodPastoral<PropType>(MessageCode.SaguaroNose, SaguaroNose);
    }

    private void OnDestroy()
    {
        EpisodeNonself.GetInstance().BalticPastoral<PropType>(MessageCode.SaguaroNose, SaguaroNose);
    }

    private void SaguaroNose(PropType Type)
    {
        RaftMeeting.instance.MeRavine = true;
        BeefMandan.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        switch (Type)
        {
            case PropType.Roll:
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    OutriggerCostButton--;
                    CostFailButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    CostFailButton = PlayerPrefs.GetInt(CConfig.RollBackNumber);
                }
                break;
            case PropType.Remind:
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    OutriggerRavineButton--;
                    RavineButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    RavineButton = PlayerPrefs.GetInt(CConfig.RemingNumber);
                }
                break;
            case PropType.Refresh:
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    OutriggerSaguaroButton--;
                    SaguaroButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    SaguaroButton = PlayerPrefs.GetInt(CConfig.RefreshNumber);
                }
                break;
            default:
                break;
        }
        NoseLocal(Type);
    }

    private void Start()
    {
        RavineThe.onClick.AddListener(CinemaRavine);
        SaguaroThe.onClick.AddListener(CinemaSaguaro);
        CostDareThe.onClick.AddListener(CinemaCostFail);
        QuicklyThe.onClick.AddListener(CinemaQuickly);
        RaftMeeting.instance.MeRavine = true;
        MeTonRavine = false;
        BagDrain = 0;
        ArtDrain = NetInfoMgr.instance.GameData.Wheel_Config;
        DarkPeace.fillAmount = float.MinValue / float.MaxValue;
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        ShyFortKill = 0;
        ShyAscent = 0;
        ShyIridium = 0;
        ForefrontDig.GetComponent<CashOutEnter>().UpdateData();
        FecundSoda.SetActive(false);
        BeefMandan.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        RaftNonself.GetInstance().EmpireStilt = true;
        CostDareThe.interactable = true;
        RavineThe.interactable = true;
        SaguaroThe.interactable = true;
        OutriggerRavineButton = NetInfoMgr.instance.GameData.Challenge_Item ;
        OutriggerCostButton = NetInfoMgr.instance.GameData.Challenge_Item;
        OutriggerSaguaroButton = NetInfoMgr.instance.GameData.Challenge_Item;

        if (RaftNonself.GetInstance().MeUntie)
        {
            for (int i = 0; i < UntieTar.Length; i++)
            {
                UntieTar[i].SetActive(false);
                BehalfGrant.SetActive(true);
            }
            Grant.text = "Level" + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
        }
        else
        {
            Debug.Log(RaftNonself.GetInstance().MeOutrigger);
            if (RaftNonself.GetInstance().MeOutrigger)
            {
                PostEventScript.GetInstance().SendEvent("1022", RaftNonself.GetInstance().ActCharacterBread().ToString());
                BehalfGrant.SetActive(false);
                //TelescopeBleak.SetActive(true);
                OutriggerIsrael.SetActive(true);
                Loder1.text = CharacterLoderMandan[0];
                Loder2.text = CharacterLoderMandan[1];
                Loder3.text = "$" + CharacterLoderMandan[2];
                CostFailButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                RavineButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                SaguaroButton = NetInfoMgr.instance.GameData.Challenge_Initial;
                NoseLocal(PropType.Roll);
                NoseLocal(PropType.Refresh);
                NoseLocal(PropType.Remind);
                switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
                {
                    case 0:
                        OutriggerReveal.fillAmount = 0;
                        break;
                    case 1:
                        OutriggerReveal.fillAmount = 0.2f;
                        Peart1.color = PeartSolar;
                        break;
                    case 2:
                        OutriggerReveal.fillAmount = 0.6f;
                        Peart1.color = PeartSolar;
                        Peart2.color = PeartSolar;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                PostEventScript.GetInstance().SendEvent("1021", (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1).ToString());
                SaguaroButton = PlayerPrefs.GetInt(CConfig.RefreshNumber);
                RavineButton = PlayerPrefs.GetInt(CConfig.RemingNumber);
                CostFailButton = PlayerPrefs.GetInt(CConfig.RollBackNumber);
                NoseLocal(PropType.Roll);
                NoseLocal(PropType.Refresh);
                NoseLocal(PropType.Remind);
                for (int i = 0; i < UntieTar.Length; i++)
                {
                    UntieTar[i].SetActive(true);
                }
                GrantNonself.BayGrant = PlayerPrefs.GetInt(CConfig.sv_CurLevel);
                RaftMeeting.instance.SkinGrant(PlayerPrefs.GetInt(CConfig.sv_CurLevel));
                OutriggerIsrael.SetActive(false);
                //TelescopeBleak.SetActive(false);
                BehalfGrant.SetActive(true);
                Grant.text = "Level" + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
            }

            if (RaftNonself.GetInstance().MeExtentOutrigger)
            {
                if (PlayerPrefs.GetInt(CConfig.OnceChalleng) == 1)
                {
                    //打开挑战弹窗
                    PlayerPrefs.SetInt(CConfig.OnceChalleng, 0);
                    UIManager.GetInstance().ShowUIForms(nameof(OutriggerRiverNeedy));
                }
            }

            if (PlayerPrefs.GetInt(CConfig.FinishWangzhuanGuide) == 0)
            {
                RaftNonself.GetInstance().EmpireStilt = false;
                IntensiveCall.SetActive(true);
                ForefrontSplit = DOTween.Sequence();
                ForefrontSplit.Append(ForefrontDig.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f).SetLoops(10, LoopType.Yoyo))
                    .SetDelay(2)
                    .SetLoops(-1); 
            }
        }
    }

    public bool DomeShoe()
    {
        BagDrain +=1;
        DarkPeace.fillAmount = BagDrain / ArtDrain;
        if (BagDrain == ArtDrain)
        {
            BagDrain = 0;
            DarkPeace.fillAmount = float.MinValue / float.MaxValue;
            UIManager.GetInstance().ShowUIForms(nameof(DarkOceanNeedy));
            return true;
        }
        return false;
    }

    public void KrillIntensiveCall()
    {
        RaftNonself.GetInstance().EmpireStilt = true;

        if (!RaftNonself.GetInstance().MeUntie && PlayerPrefs.GetInt(CConfig.FinishWangzhuanGuide)==0)
        {
            PostEventScript.GetInstance().SendEvent("1002");
            PlayerPrefs.SetInt(CConfig.FinishWangzhuanGuide, 1);
            IntensiveCall.SetActive(false);
            ForefrontSplit.Kill();
            ForefrontDig.transform.localScale = Vector3.one;
        }
    }

    public void LuncheonLug(int Num)
    {
        switch (Num)
        {
            case 1:
                if (Legitimately.gameObject.activeSelf)
                {
                    Legitimately.AnimationState.SetAnimation(4, "nice", false);
                }
                else
                {
                    Legitimately.gameObject.SetActive(true);
                }
                break;
            case 2:
                Legitimately.Initialize(true);
                if (SlothCetacean.gameObject.activeSelf)
                {
                    SlothCetacean.AnimationState.SetAnimation(2, "great", false);
                }
                else
                {
                    SlothCetacean.gameObject.SetActive(true);
                }
                break;
            case 3:
                SlothCetacean.Initialize(true);
                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Combo3);
                if (MelangeCetacean.gameObject.activeSelf)
                {
                    MelangeCetacean.AnimationState.SetAnimation(1, "awesome", false);
                }
                else
                {
                    MelangeCetacean.gameObject.SetActive(true);
                }
                break;
            case 4:
                MelangeCetacean.Initialize(true);
                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Combo4);
                if (GenericCetacean.gameObject.activeSelf)
                {
                    GenericCetacean.AnimationState.SetAnimation(0, "amazing", false);
                }
                else
                {
                    GenericCetacean.gameObject.SetActive(true);
                }
                break;
            case 5:
                GenericCetacean.Initialize(true);
                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Combo5);
                if (MercilessCetacean.gameObject.activeSelf)
                {
                    MercilessCetacean.AnimationState.SetAnimation(3, "legendary", false);
                }
                else
                {
                    MercilessCetacean.gameObject.SetActive(true);
                }
                break;
            default:
                RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_Combo5);
                MercilessCetacean.Initialize(true);
                MercilessCetacean.AnimationState.SetAnimation(3, "legendary", false);
                break;
            }
    }

    private void CinemaRavine()
    {
        if (OfShyAscent)
        {
            List<SlotBehavior> slotTiles = RaftMeeting.instance.YouGovernLoad();
            List<SlotBehavior> UseSolts = RaftMeeting.instance.YouTonDime();
            int ActivityNumber = UseSolts.Count - slotTiles.Count;
            if (ActivityNumber >= 2)
            {
                MeTonRavine = true;
            }
            for (int i = 0; i < slotTiles.Count - 1; i++)
            {
                if (slotTiles[i].ActionTileBehavior().TileData == slotTiles[i + 1].ActionTileBehavior().TileData)
                {
                    MeTonRavine = true;
                    break;
                }
            }
            if (RavineButton > 0)
            {
                if (MeTonRavine)
                {
                    OfShyAscent = false;
                    AimBulb(RavineThe.gameObject.transform, NetInfoMgr.instance.GameData.Wand_Cash);
                    MeTonRavine = false;
                    RavineButton--;
                    RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
                    if (RaftNonself.GetInstance().MeOutrigger)
                    {
                        ShyAscent++;
                        RaftNonself.GetInstance().ShyAscent = ShyAscent;
                        PostEventScript.GetInstance().SendEvent("1019", RaftNonself.GetInstance().ActCharacterBread().ToString(), ShyAscent.ToString());
                        if (RavineButton <= 0 && OutriggerRavineButton == 0)
                        {
                            RavineThe.interactable = false;
                            RavineSodIce.SetActive(false);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, RavineButton);
                    }
                    NoseLocal(PropType.Remind);

                    RaftMeeting.instance.RavineBoat(false);
                }
                else
                {
                    ToastManager.GetInstance().ShowToast("Not enough space");
                }
            }
            else
            {

                UIManager.GetInstance().ShowUIForms(nameof(SodNoseNeedy), PropType.Remind);
            }
        }
    }

    public void OregonAscent()
    {
        OfShyAscent = true;
    }

    private void CinemaQuickly()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        UIManager.GetInstance().ShowUIForms(nameof(QuicklyNeedy),"1");
    }

    private void CinemaSaguaro()
    {
        if (SaguaroButton > 0)
        {
            AimBulb(SaguaroThe.gameObject.transform, NetInfoMgr.instance.GameData.Shuffle_Cash);
            RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
            SaguaroButton--;
            if (RaftNonself.GetInstance().MeOutrigger)
            {
                ShyIridium++;
                RaftNonself.GetInstance().ShyIridium = ShyIridium;
                PostEventScript.GetInstance().SendEvent("1020", RaftNonself.GetInstance().ActCharacterBread().ToString(), ShyIridium.ToString());
                if (SaguaroButton <= 0 && OutriggerSaguaroButton == 0)
                {
                    SaguaroThe.interactable = false;
                    SaguaroSodIce.SetActive(false);
                }
            }
            else
            {
                PlayerPrefs.SetInt(CConfig.RefreshNumber, SaguaroButton);
            }
            NoseLocal(PropType.Refresh);
            
            RaftMeeting.instance.SaguaroBoat();
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(SodNoseNeedy), PropType.Refresh);
        }
    }
    private void CinemaCostFail()
    {
        if (CostFailButton > 0)
        {
            if (RaftMeeting.instance.YouGovernLoad().Count > 0)
            {
                CostFailButton--;
                RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
                if (RaftNonself.GetInstance().MeOutrigger)
                {
                    ShyFortKill++;
                    RaftNonself.GetInstance().ShyFortKill = ShyFortKill;
                    PostEventScript.GetInstance().SendEvent("1018",RaftNonself.GetInstance().ActCharacterBread().ToString(), ShyFortKill.ToString());
                    if (CostFailButton <= 0 && OutriggerCostButton == 0)
                    {
                        CostDareThe.interactable = false;
                        CostFailSodIce.SetActive(false);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(CConfig.RollBackNumber, CostFailButton);
                }
                NoseLocal(PropType.Roll);
                AimBulb(CostDareThe.gameObject.transform, NetInfoMgr.instance.GameData.Undo_Cash);
                RaftMeeting.instance.CostFailRBoat();
            }
            else
            {
                ToastManager.GetInstance().ShowToast("Irrevocable");
            }
            
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(SodNoseNeedy), PropType.Roll);
        }
    }

    private void NoseLocal(PropType type)
    {
        switch (type)
        {
            case PropType.Roll:
                if (CostFailButton > 0)
                {
                    CostFailButtonIce.SetActive(true);
                    CostFailSodIce.SetActive(false);
                    CostFailNear.text = CostFailButton.ToString();
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RollBackNumber, CostFailButton);
                    }
                }
                else
                {
                    CostFailButtonIce.SetActive(false);
                    CostFailSodIce.SetActive(true);
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RollBackNumber, CostFailButton);
                    }
                    else
                    {
                        if (OutriggerCostButton == 0)
                        {
                            CostFailSodIce.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Remind:
                if (RavineButton > 0)
                {
                    RavineSodIce.SetActive(false);
                    RavineButtonIce.SetActive(true);
                    RavineNear.text = RavineButton.ToString();
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, RavineButton);
                    } 
                }
                else
                {
                    RavineButtonIce.SetActive(false);
                    RavineSodIce.SetActive(true);
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, RavineButton);
                    }
                    else
                    {
                        if (OutriggerRavineButton == 0)
                        {
                            RavineSodIce.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Refresh:
                if (SaguaroButton > 0)
                {
                    SaguaroSodIce.SetActive(false);
                    SaguaroButtonIce.SetActive(true);
                    SaguaroNear.text = SaguaroButton.ToString();
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RefreshNumber, SaguaroButton);
                    } 
                }
                else
                {
                    SaguaroButtonIce.SetActive(false);
                    SaguaroSodIce.SetActive(true);
                    if (!RaftNonself.GetInstance().MeOutrigger)
                    {
                        PlayerPrefs.SetInt(CConfig.RefreshNumber, SaguaroButton);
                    }
                    else
                    {
                        if (OutriggerSaguaroButton == 0)
                        {
                            SaguaroSodIce.SetActive(false);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    private float ButtonTern= 0;
    private void Update()
    {
        if (RaftNonself.GetInstance().MeOutrigger)
        {
            ButtonTern += Time.deltaTime;
            if (ButtonTern >= 4)
            {
                Sulfur.SodSatisfaction("User:" + Random.Range(10, 100) + "****" + Random.Range(10, 100) + " won 2000$");
                ButtonTern = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CloseUIForm(GetType().Name);
            OpenUIForm(nameof(CattleNeedy));
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            UIManager.GetInstance().ShowUIForms(nameof(DarkOceanNeedy));
        }
    }

    public void AimBulb(Vector3 StartPosition,double AwardNum)
    {
        if (!CommonUtil.IsApple())
        {
            AnimationController.GoldMoveBest(BulbSilt, 10, StartPosition, SeaFlu.position, () =>
            {
                RaftWeedNonself.GetInstance().SodKiln(AwardNum);
            });
        }   
    }

    public void AimBulb(Transform StartPostion , double AwardNum )
    {
        if (!CommonUtil.IsApple())
        {
            AnimationController.GoldMoveBest(BulbSilt, 10, StartPostion, SeaFlu, () =>
            {
                RaftWeedNonself.GetInstance().SodKiln(AwardNum);
            });
        }
    }

    public void OfFecundSoda(bool open)
    {
        FecundSoda.SetActive(open);
    }
}
