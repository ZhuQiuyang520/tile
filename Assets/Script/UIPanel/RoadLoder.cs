using DG.Tweening;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;

public class RoadLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("GuideObj")]    public GameObject[] IdealLop;
[UnityEngine.Serialization.FormerlySerializedAs("WangzhuanMask")]
    public GameObject ProboscisClaw;
    public GameObject WangzhuanObj;
    public GameObject Coin;
    public Text CoinNumber;
[UnityEngine.Serialization.FormerlySerializedAs("PutongLevel")]
    public GameObject FervorBleak;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeLevel")]
    public GameObject TelescopeBleak;
[UnityEngine.Serialization.FormerlySerializedAs("AwardColor")]
    public Color DreamTract;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeSlider")]    public GameObject TelescopeSocial;
    public Text Award1;
    public Text Award2;
    public Text Award3;

[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    public Image Dream1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    public Image Dream2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    public Image Dream3;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeHandle")]    public Image TelescopeRetire;
[UnityEngine.Serialization.FormerlySerializedAs("ticker")]
    public TavernkeeperPierce Indoor;
    public static RoadLoder instance;
[UnityEngine.Serialization.FormerlySerializedAs("TrunImage")]
    public Image GirlActor;
    private float HayFence;
    private float FurFence;
[UnityEngine.Serialization.FormerlySerializedAs("RemindBtn")]
    public Button ForgetHat;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshBtn")]    public Button BookletHat;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackBtn")]    public Button BeltDareHat;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button UsuallyHat;
[UnityEngine.Serialization.FormerlySerializedAs("Level")]    public Text Bleak;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackAddTip")]
    public GameObject BeltDareLidWax;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackNumberTip")]    public GameObject BeltDareBorrowWax;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackText")]    public Text BeltDareStep;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshAddTip")]
    public GameObject BookletLidWax;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshNumberTip")]    public GameObject BookletBorrowWax;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshText")]    public Text BookletStep;
[UnityEngine.Serialization.FormerlySerializedAs("RemindAddTip")]
    public GameObject ForgetLidWax;
[UnityEngine.Serialization.FormerlySerializedAs("RemindNumberTip")]    public GameObject ForgetBorrowWax;
[UnityEngine.Serialization.FormerlySerializedAs("RemindText")]    public Text ForgetStep;

    //refreshNumber
    private int BookletBorrow;
    //remindNumber
    private int ForgetBorrow;
    //rollbackNumber
    private int BeltDareBorrow;
    private bool OfLieForget;
[UnityEngine.Serialization.FormerlySerializedAs("Niceskeleton")]    public SkeletonGraphic Enterprising;
[UnityEngine.Serialization.FormerlySerializedAs("GreatSkeleton")]    public SkeletonGraphic EquipHomeland;
[UnityEngine.Serialization.FormerlySerializedAs("AwesomeSkeleton")]    public SkeletonGraphic LoyaltyHomeland;
[UnityEngine.Serialization.FormerlySerializedAs("AmazingSkeleton")]    public SkeletonGraphic AmenityHomeland;
[UnityEngine.Serialization.FormerlySerializedAs("LegendarySkeleton")]    public SkeletonGraphic HillbillyHomeland;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
    public GameObject WingThai;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    public Transform SewWay;

    private int TelescopeForgetBorrow;
    private int TelescopeBeltBorrow;
    private int TelescopeBookletBorrow;

    private string[] ChallengeAwardNumber;

    private Sequence WangzhuanScale;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
        if (CommonUtil.IsApple())
        {
            ProboscisClaw.SetActive(false);
            WangzhuanObj.SetActive(false);
            Coin.SetActive(true);
        }
        CoinNumber.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        string ChallengeAward = NetInfoMgr.instance.GameData.Challenge_Reward;
        ChallengeAwardNumber = ChallengeAward.Split('|');
        SqueezeTenuous.GetInstance().LidSeverely<PropType>(MessageCode.BookletBoth, BookletBoth);
    }

    private void OnDestroy()
    {
        SqueezeTenuous.GetInstance().ObtainSeverely<PropType>(MessageCode.BookletBoth, BookletBoth);
    }

    private void BookletBoth(PropType Type)
    {
        RoadBrother.instance.OfForget = true;
        CoinNumber.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        switch (Type)
        {
            case PropType.Roll:
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    TelescopeBeltBorrow--;
                    BeltDareBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    BeltDareBorrow = PlayerPrefs.GetInt(CConfig.RollBackNumber);
                }
                break;
            case PropType.Remind:
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    TelescopeForgetBorrow--;
                    ForgetBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    ForgetBorrow = PlayerPrefs.GetInt(CConfig.RemingNumber);
                }
                break;
            case PropType.Refresh:
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    TelescopeBookletBorrow--;
                    BookletBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                }
                else
                {
                    BookletBorrow = PlayerPrefs.GetInt(CConfig.RefreshNumber);
                }
                break;
            default:
                break;
        }
        BothBlade(Type);
    }

    private void Start()
    {
        ForgetHat.onClick.AddListener(RatifyForget);
        BookletHat.onClick.AddListener(RatifyBooklet);
        BeltDareHat.onClick.AddListener(RatifyBeltDare);
        UsuallyHat.onClick.AddListener(RatifyUsually);
        RoadBrother.instance.OfForget = true;
        OfLieForget = false;
        FurFence = 0;
        HayFence = NetInfoMgr.instance.GameData.Wheel_Config;
        GirlActor.fillAmount = float.MinValue / float.MaxValue;
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        CoinNumber.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        RoadTenuous.GetInstance().ReliefStilt = true;
        BeltDareHat.interactable = true;
        ForgetHat.interactable = true;
        BookletHat.interactable = true;
        TelescopeForgetBorrow = NetInfoMgr.instance.GameData.Challenge_Item ;
        TelescopeBeltBorrow = NetInfoMgr.instance.GameData.Challenge_Item;
        TelescopeBookletBorrow = NetInfoMgr.instance.GameData.Challenge_Item;

        if (RoadTenuous.GetInstance().OfIdeal)
        {
            for (int i = 0; i < IdealLop.Length; i++)
            {
                IdealLop[i].SetActive(false);
                FervorBleak.SetActive(true);
            }
            Bleak.text = "Level" + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
        }
        else
        {
            if (RoadTenuous.GetInstance().OfTelescope)
            {
                FervorBleak.SetActive(false);
                //TelescopeBleak.SetActive(true);
                TelescopeSocial.SetActive(true);
                Award1.text = ChallengeAwardNumber[0];
                Award2.text = ChallengeAwardNumber[1];
                Award3.text = "$" + ChallengeAwardNumber[2];
                BeltDareBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                ForgetBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                BookletBorrow = NetInfoMgr.instance.GameData.Challenge_Initial;
                BothBlade(PropType.Roll);
                BothBlade(PropType.Refresh);
                BothBlade(PropType.Remind);
                switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
                {
                    case 0:
                        TelescopeRetire.fillAmount = 0;
                        break;
                    case 1:
                        TelescopeRetire.fillAmount = 0.2f;
                        Dream1.color = DreamTract;
                        break;
                    case 2:
                        TelescopeRetire.fillAmount = 0.6f;
                        Dream1.color = DreamTract;
                        Dream2.color = DreamTract;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                BookletBorrow = PlayerPrefs.GetInt(CConfig.RefreshNumber);
                ForgetBorrow = PlayerPrefs.GetInt(CConfig.RemingNumber);
                BeltDareBorrow = PlayerPrefs.GetInt(CConfig.RollBackNumber);
                BothBlade(PropType.Roll);
                BothBlade(PropType.Refresh);
                BothBlade(PropType.Remind);
                for (int i = 0; i < IdealLop.Length; i++)
                {
                    IdealLop[i].SetActive(true);
                }
                BleakTenuous.EatBleak = PlayerPrefs.GetInt(CConfig.sv_CurLevel);
                RoadBrother.instance.BeamBleak(PlayerPrefs.GetInt(CConfig.sv_CurLevel));
                TelescopeSocial.SetActive(false);
                //TelescopeBleak.SetActive(false);
                FervorBleak.SetActive(true);
                Bleak.text = "Level" + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
            }

            if (RoadTenuous.GetInstance().OfRadishTelescope)
            {
                if (PlayerPrefs.GetInt(CConfig.OnceChalleng) == 1)
                {
                    //打开挑战弹窗
                    PlayerPrefs.SetInt(CConfig.OnceChalleng, 0);
                    UIManager.GetInstance().ShowUIForms(nameof(TelescopeOrbitLoder));
                }
            }

            if (PlayerPrefs.GetInt(CConfig.FinishWangzhuanGuide) == 0)
            {
                RoadTenuous.GetInstance().ReliefStilt = false;
                ProboscisClaw.SetActive(true);
                WangzhuanScale = DOTween.Sequence();
                WangzhuanScale.Append(WangzhuanObj.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f).SetLoops(10, LoopType.Yoyo))
                    .SetDelay(2)
                    .SetLoops(-1); 
            }
        }
    }

    public bool TheyRift()
    {
        FurFence +=1;
        GirlActor.fillAmount = FurFence / HayFence;
        if (FurFence == HayFence)
        {
            FurFence = 0;
            GirlActor.fillAmount = float.MinValue / float.MaxValue;
            UIManager.GetInstance().ShowUIForms(nameof(GirlNewlyLoder));
            return true;
        }
        return false;
    }

    public void SparkProboscisClaw()
    {
        PostEventScript.GetInstance().SendEvent("1002");
        RoadTenuous.GetInstance().ReliefStilt = true;

        if (!RoadTenuous.GetInstance().OfIdeal && PlayerPrefs.GetInt(CConfig.FinishWangzhuanGuide)==0)
        {
            PlayerPrefs.SetInt(CConfig.FinishWangzhuanGuide, 1);
            ProboscisClaw.SetActive(false);
            WangzhuanScale.Kill();
            WangzhuanObj.transform.localScale = Vector3.one;
        }
    }

    public void AdequacyJob(int Num)
    {
        switch (Num)
        {
            case 1:
                if (Enterprising.gameObject.activeSelf)
                {
                    Enterprising.AnimationState.SetAnimation(4, "nice", false);
                }
                else
                {
                    Enterprising.gameObject.SetActive(true);
                }
                break;
            case 2:
                Enterprising.Initialize(true);
                if (EquipHomeland.gameObject.activeSelf)
                {
                    EquipHomeland.AnimationState.SetAnimation(2, "great", false);
                }
                else
                {
                    EquipHomeland.gameObject.SetActive(true);
                }
                break;
            case 3:
                EquipHomeland.Initialize(true);
                RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Combo3);
                if (LoyaltyHomeland.gameObject.activeSelf)
                {
                    LoyaltyHomeland.AnimationState.SetAnimation(1, "awesome", false);
                }
                else
                {
                    LoyaltyHomeland.gameObject.SetActive(true);
                }
                break;
            case 4:
                LoyaltyHomeland.Initialize(true);
                RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Combo4);
                if (AmenityHomeland.gameObject.activeSelf)
                {
                    AmenityHomeland.AnimationState.SetAnimation(0, "amazing", false);
                }
                else
                {
                    AmenityHomeland.gameObject.SetActive(true);
                }
                break;
            case 5:
                AmenityHomeland.Initialize(true);
                RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Combo5);
                if (HillbillyHomeland.gameObject.activeSelf)
                {
                    HillbillyHomeland.AnimationState.SetAnimation(3, "legendary", false);
                }
                else
                {
                    HillbillyHomeland.gameObject.SetActive(true);
                }
                break;
            default:
                RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_Combo5);
                HillbillyHomeland.Initialize(true);
                HillbillyHomeland.AnimationState.SetAnimation(3, "legendary", false);
                break;
            }
    }

    private void RatifyForget()
    {
        List<SlotBehavior> slotTiles =RoadBrother.instance.MobMidwayThaw();
        List<SlotBehavior> UseSolts = RoadBrother.instance.MobLieDoll();
        int ActivityNumber = UseSolts.Count - slotTiles.Count;
        if (ActivityNumber >= 2)
        {
            OfLieForget = true;
        }
        for (int i = 0; i < slotTiles.Count - 1; i++)
        {
            if (slotTiles[i].ActionTileBehavior().TileData == slotTiles[i + 1].ActionTileBehavior().TileData)
            {
                OfLieForget = true;
                break;
            }
        }
        if (ForgetBorrow > 0)
        {
            if (OfLieForget)
            {
                OatWing(ForgetHat.gameObject.transform, NetInfoMgr.instance.GameData.Wand_Cash);
                OfLieForget = false;
                ForgetBorrow--;
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    if (ForgetBorrow <= 0 && TelescopeForgetBorrow == 0)
                    {
                        ForgetHat.interactable = false;
                        ForgetLidWax.SetActive(false);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(CConfig.RemingNumber, ForgetBorrow);
                }
                BothBlade(PropType.Remind);
                
                RoadBrother.instance.ForgetDrip(false);
            }
            else
            {
                Debug.Log("当前没有足够的存牌区");
            }
        }
        else
        {

            UIManager.GetInstance().ShowUIForms(nameof(LidBothLoder), PropType.Remind);
        }
    }

    private void RatifyUsually()
    {
        UIManager.GetInstance().ShowUIForms(nameof(UsuallyLoder));
    }

    private void RatifyBooklet()
    {
        if (BookletBorrow > 0)
        {
            OatWing(BookletHat.gameObject.transform, NetInfoMgr.instance.GameData.Shuffle_Cash);
            RoadTenuous.GetInstance().UsuallyStuff();
            BookletBorrow--;
            if (RoadTenuous.GetInstance().OfTelescope)
            {
                if (BookletBorrow <= 0 && TelescopeBookletBorrow == 0)
                {
                    BookletHat.interactable = false;
                    BookletLidWax.SetActive(false);
                }
            }
            else
            {
                PlayerPrefs.SetInt(CConfig.RefreshNumber, BookletBorrow);
            }
            BothBlade(PropType.Refresh);
            
            RoadBrother.instance.BookletDrip();
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(LidBothLoder), PropType.Refresh);
        }
    }
    private void RatifyBeltDare()
    {
        if (BeltDareBorrow > 0)
        {
            if (RoadBrother.instance.MobMidwayThaw().Count > 0)
            {
                BeltDareBorrow--;
                if (RoadTenuous.GetInstance().OfTelescope)
                {
                    if (BeltDareBorrow <= 0 && TelescopeBeltBorrow == 0)
                    {
                        BeltDareHat.interactable = false;
                        BeltDareLidWax.SetActive(false);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(CConfig.RollBackNumber, BeltDareBorrow);
                }
                BothBlade(PropType.Roll);
                OatWing(BeltDareHat.gameObject.transform, NetInfoMgr.instance.GameData.Undo_Cash);
                RoadBrother.instance.BeltDareRDrip();
            }
            else
            {
                ToastManager.GetInstance().ShowToast("Irrevocable");
            }
            
        }
        else
        {
            UIManager.GetInstance().ShowUIForms(nameof(LidBothLoder), PropType.Roll);
        }
    }

    private void BothBlade(PropType type)
    {
        switch (type)
        {
            case PropType.Roll:
                if (BeltDareBorrow > 0)
                {
                    BeltDareBorrowWax.SetActive(true);
                    BeltDareLidWax.SetActive(false);
                    BeltDareStep.text = BeltDareBorrow.ToString();
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RollBackNumber, BeltDareBorrow);
                    }
                }
                else
                {
                    BeltDareBorrowWax.SetActive(false);
                    BeltDareLidWax.SetActive(true);
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RollBackNumber, BeltDareBorrow);
                    }
                    else
                    {
                        if (TelescopeBeltBorrow == 0)
                        {
                            BeltDareLidWax.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Remind:
                if (ForgetBorrow > 0)
                {
                    ForgetLidWax.SetActive(false);
                    ForgetBorrowWax.SetActive(true);
                    ForgetStep.text = ForgetBorrow.ToString();
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, ForgetBorrow);
                    } 
                }
                else
                {
                    ForgetBorrowWax.SetActive(false);
                    ForgetLidWax.SetActive(true);
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RemingNumber, ForgetBorrow);
                    }
                    else
                    {
                        if (TelescopeForgetBorrow == 0)
                        {
                            ForgetLidWax.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Refresh:
                if (BookletBorrow > 0)
                {
                    BookletLidWax.SetActive(false);
                    BookletBorrowWax.SetActive(true);
                    BookletStep.text = BookletBorrow.ToString();
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RefreshNumber, BookletBorrow);
                    } 
                }
                else
                {
                    BookletBorrowWax.SetActive(false);
                    BookletLidWax.SetActive(true);
                    if (!RoadTenuous.GetInstance().OfTelescope)
                    {
                        PlayerPrefs.SetInt(CConfig.RefreshNumber, BookletBorrow);
                    }
                    else
                    {
                        if (TelescopeBookletBorrow == 0)
                        {
                            BookletLidWax.SetActive(false);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    private float BorrowPass= 0;
    private void Update()
    {
        if (RoadTenuous.GetInstance().OfTelescope)
        {
            BorrowPass += Time.deltaTime;
            if (BorrowPass >= 4)
            {
                Indoor.LidTavernkeeper("User:" + Random.Range(10, 100) + "****" + Random.Range(10, 100) + " won 2000$");
                BorrowPass = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            CloseUIForm(GetType().Name);
            OpenUIForm(nameof(ElliotLoder));
        }
    }

    public void OatWing(Vector3 StartPosition,double AwardNum)
    {
        AnimationController.GoldMoveBest(WingThai, 10, StartPosition, SewWay.position, () =>
        {
            RoadNeckTenuous.GetInstance().LidYour(AwardNum);
        });
    }

    public void OatWing(Transform StartPostion , double AwardNum )
    {
        if (!CommonUtil.IsApple())
        {
            AnimationController.GoldMoveBest(WingThai, 10, StartPostion, SewWay, () =>
            {
                RoadNeckTenuous.GetInstance().LidYour(AwardNum);
            });
        }
    }
}
