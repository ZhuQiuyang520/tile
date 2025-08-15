using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;

public class WhipSixth : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CoinNumber")]    public Text BeefMandan;

    public static WhipSixth instance;
    [UnityEngine.Serialization.FormerlySerializedAs("Level")] [UnityEngine.Serialization.FormerlySerializedAs("Bleak")]public Text Grant;
    [UnityEngine.Serialization.FormerlySerializedAs("Niceskeleton")] [UnityEngine.Serialization.FormerlySerializedAs("Enterprising")]public SkeletonGraphic Legitimately;
    [UnityEngine.Serialization.FormerlySerializedAs("GreatSkeleton")] [UnityEngine.Serialization.FormerlySerializedAs("EquipHomeland")]public SkeletonGraphic SlothCetacean;
    [UnityEngine.Serialization.FormerlySerializedAs("AwesomeSkeleton")] [UnityEngine.Serialization.FormerlySerializedAs("LoyaltyHomeland")]public SkeletonGraphic MelangeCetacean;
    [UnityEngine.Serialization.FormerlySerializedAs("AmazingSkeleton")] [UnityEngine.Serialization.FormerlySerializedAs("AmenityHomeland")]public SkeletonGraphic GenericCetacean;
    [UnityEngine.Serialization.FormerlySerializedAs("LegendarySkeleton")] [UnityEngine.Serialization.FormerlySerializedAs("HillbillyHomeland")]public SkeletonGraphic MercilessCetacean;
    [UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
[UnityEngine.Serialization.FormerlySerializedAs("WingThai")]    public GameObject BulbSilt;
    [UnityEngine.Serialization.FormerlySerializedAs("EndPos")] [UnityEngine.Serialization.FormerlySerializedAs("SewWay")]public Transform SeaFlu;
[UnityEngine.Serialization.FormerlySerializedAs("Setting")]    public Button January;
    private bool OfShyAscent= true;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
        BeefMandan.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
    }

    private void Start()
    {
        RaftMeeting.instance.MeRavine = true;
        January.onClick.AddListener(CinemaQuickly);
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        BeefMandan.text = PlayerPrefs.GetInt(CConfig.CoinNumber).ToString();
        RaftNonself.GetInstance().EmpireStilt = true;

        Debug.Log(RaftNonself.GetInstance().MeOutrigger);
        PostEventScript.GetInstance().SendEvent("1021", (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1).ToString());

        GrantNonself.BayGrant = PlayerPrefs.GetInt(CConfig.sv_CurLevel);
        RaftMeeting.instance.SkinGrant(PlayerPrefs.GetInt(CConfig.sv_CurLevel));
        Grant.text = "Level" + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
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

    private void CinemaQuickly()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        UIManager.GetInstance().ShowUIForms(nameof(JanuarySixth), "1");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CloseUIForm(GetType().Name);
            OpenUIForm(nameof(PenSixth));
        }
    }

    public void AimBulb(Vector3 StartPosition, double AwardNum)
    {
        if (!CommonUtil.IsApple())
        {
            AnimationController.GoldMoveBest(BulbSilt, 10, StartPosition, SeaFlu.position, () =>
            {
                RaftWeedNonself.GetInstance().SodKiln(AwardNum);
            });
        }
    }

    public void AimBulb(Transform StartPostion, double AwardNum)
    {
        if (!CommonUtil.IsApple())
        {
            AnimationController.GoldMoveBest(BulbSilt, 10, StartPostion, SeaFlu, () =>
            {
                RaftWeedNonself.GetInstance().SodKiln(AwardNum);
            });
        }
    }
}

