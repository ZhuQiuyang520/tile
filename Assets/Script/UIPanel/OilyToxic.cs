using DG.Tweening;
using Lofelt.NiceVibrations;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Watermelon;

public class OilyToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("ButtonMask")]    public GameObject SpeedyLime;
[UnityEngine.Serialization.FormerlySerializedAs("GuideObj")]    public GameObject[] PenalIce;
[UnityEngine.Serialization.FormerlySerializedAs("WangzhuanMask")]
    public GameObject EnclosureLime;
[UnityEngine.Serialization.FormerlySerializedAs("WangzhuanObj")]    public GameObject EnclosureIce;
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]    public GameObject Bank;
[UnityEngine.Serialization.FormerlySerializedAs("CoinNumber")]    public Text BankFloral;
[UnityEngine.Serialization.FormerlySerializedAs("PutongLevel")]
    public GameObject ValleyClump;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeLevel")]
    public GameObject AdmissionClump;
[UnityEngine.Serialization.FormerlySerializedAs("AwardColor")]
    public Color SweetTread;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeSlider")]    public GameObject AdmissionIcebox;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeHandle")]    
    public Image AdmissionHeight;
[UnityEngine.Serialization.FormerlySerializedAs("Award1")]
    public Image Sweet1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    public Image Sweet2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    public Image Sweet3;
[UnityEngine.Serialization.FormerlySerializedAs("AwardNumber1")]    public Text SweetFloral1;
[UnityEngine.Serialization.FormerlySerializedAs("AwardNumber2")]    public Text SweetFloral2;
[UnityEngine.Serialization.FormerlySerializedAs("AwardNumber3")]    public Text SweetFloral3;
[UnityEngine.Serialization.FormerlySerializedAs("ticker")]
    public CoordinationClause Tissue;
    public static OilyToxic instance;
[UnityEngine.Serialization.FormerlySerializedAs("TrunImage")]
    public Image PlowLabor;
    private float SetNerve;
    private float FanNerve;
[UnityEngine.Serialization.FormerlySerializedAs("RemindBtn")]
    public Button FamilyCab;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshBtn")]    public Button StudentCab;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackBtn")]    public Button PeltWarmCab;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button RefinerCab;
[UnityEngine.Serialization.FormerlySerializedAs("Clump")]    public Text Clump;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackAddTip")]
    public GameObject PeltWarmBurTip;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackNumberTip")]    public GameObject PeltWarmFloralMan;
[UnityEngine.Serialization.FormerlySerializedAs("RollBackText")]    public Text PeltWarmEdit;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshAddTip")]
    public GameObject StudentBurMan;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshNumberTip")]    public GameObject StudentFloralMan;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshText")]    public Text StudentEdit;
[UnityEngine.Serialization.FormerlySerializedAs("RemindAddTip")]
    public GameObject FamilyBurMan;
[UnityEngine.Serialization.FormerlySerializedAs("RemindNumberTip")]    public GameObject FamilyFloralMan;
[UnityEngine.Serialization.FormerlySerializedAs("RemindText")]    public Text FamilyEdit;

    private int StudentFloral;
    private int FamilyFloral;
    private int PeltWarmFloral;
    private bool WeFamily;
[UnityEngine.Serialization.FormerlySerializedAs("Niceskeleton")]    public SkeletonGraphic Hypothetical;
[UnityEngine.Serialization.FormerlySerializedAs("GreatSkeleton")]    public SkeletonGraphic RigidGenerous;
[UnityEngine.Serialization.FormerlySerializedAs("AwesomeSkeleton")]    public SkeletonGraphic DarlingGenerous;
[UnityEngine.Serialization.FormerlySerializedAs("AmazingSkeleton")]    public SkeletonGraphic RevivalGenerous;
[UnityEngine.Serialization.FormerlySerializedAs("LegendarySkeleton")]    public SkeletonGraphic AstronomyGenerous;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
    public GameObject BankBold;
[UnityEngine.Serialization.FormerlySerializedAs("EndPos")]    public Transform RibLap;

    private int OurPeltWarm= 0;
    private int OurFamily= 0;
    private int OurStudent= 0;

    private string[] AdmissionSweet;
    private Sequence EnclosurePlethora;

    private int AdmissionFamilyFloral;
    private int AdmissionPeltFloral;
    private int AdmissionStudentFloral;

    private bool WeOurFamily;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        if (TemperFile.WeSound())
        {
            EnclosureLime.SetActive(false);
            EnclosureIce.SetActive(false);
            Bank.SetActive(true);
        }
        BankFloral.text = PlayerPrefs.GetInt(CLagoon.BankFloral).ToString();
        string ChallengeAwardArray = SawSelfEke.instance.OilyHave.Challenge_Reward;
        AdmissionSweet = ChallengeAwardArray.Split('|');
        DeviateMimetic.PenMonopoly().BurInherent<PropType>(MessageCode.StudentRead, StudentRead);
    }

    private void OnDestroy()
    {
        DeviateMimetic.PenMonopoly().HyksosInherent<PropType>(MessageCode.StudentRead, StudentRead);
    }

    private void StudentRead(PropType Type)
    {
        OilyMimetic.PenMonopoly().EngineGuess = true;
        BankFloral.text = PlayerPrefs.GetInt(CLagoon.BankFloral).ToString();
        switch (Type)
        {
            case PropType.Roll:
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    AdmissionPeltFloral--;
                    PeltWarmFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    PeltWarmFloral = PlayerPrefs.GetInt(CLagoon.PeltWarmFloral);
                }
                break;
            case PropType.Remind:
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    AdmissionFamilyFloral--;
                    FamilyFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    FamilyFloral = PlayerPrefs.GetInt(CLagoon.PerishFloral);
                }
                break;
            case PropType.Refresh:
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    AdmissionStudentFloral--;
                    StudentFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                }
                else
                {
                    StudentFloral = PlayerPrefs.GetInt(CLagoon.StudentFloral);
                }
                break;
            default:
                break;
        }
        ReadFiord(Type);
    }

    private void Start()
    {
        FamilyCab.onClick.AddListener(DampenFamily);
        StudentCab.onClick.AddListener(DampenStudent);
        PeltWarmCab.onClick.AddListener(DampenPeltWarm);
        RefinerCab.onClick.AddListener(DampenRefiner);
        OilyVillage.instance.WeFamily = true;
        WeFamily = false;

        FanNerve = 0;
        SetNerve = SawSelfEke.instance.OilyHave.Wheel_Config;
        PlowLabor.fillAmount = float.MinValue / float.MaxValue;
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        OurPeltWarm = 0;
        OurFamily = 0;
        OurStudent = 0;
        EnclosureIce.GetComponent<CashOutEnter>().UpdateData();
        SpeedyLime.SetActive(false);
        BankFloral.text = PlayerPrefs.GetInt(CLagoon.BankFloral).ToString();
        OilyMimetic.PenMonopoly().EngineGuess = true;
        PeltWarmCab.interactable = true;
        FamilyCab.interactable = true;
        StudentCab.interactable = true;
        AdmissionFamilyFloral = SawSelfEke.instance.OilyHave.Challenge_Item;
        AdmissionPeltFloral = SawSelfEke.instance.OilyHave.Challenge_Item;
        AdmissionStudentFloral = SawSelfEke.instance.OilyHave.Challenge_Item;

        if (OilyMimetic.PenMonopoly().WePenal)
        {
            for (int i = 0; i < PenalIce.Length; i++)
            {
                PenalIce[i].SetActive(false);
                ValleyClump.SetActive(true);
            }
            Clump.text = "Level" + (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
        }
        else
        {
            if (OilyMimetic.PenMonopoly().WeAdmission)
            {
                SlayNeverSpiral.PenMonopoly().JumpNever("1022", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString());
                ValleyClump.SetActive(false);
                AdmissionIcebox.SetActive(true);
                SweetFloral1.text = AdmissionSweet[0];
                SweetFloral2.text = AdmissionSweet[1];
                SweetFloral3.text = "$" + AdmissionSweet[2];
                
                PeltWarmFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                FamilyFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                StudentFloral = SawSelfEke.instance.OilyHave.Challenge_Initial;
                ReadFiord(PropType.Roll);
                ReadFiord(PropType.Refresh);
                ReadFiord(PropType.Remind);
                switch (PlayerPrefs.GetInt(CLagoon.PerHimSeveralSweet))
                {
                    case 0:
                        AdmissionHeight.fillAmount = 0;
                        break;
                    case 1:
                        AdmissionHeight.fillAmount = 0.2f;
                        Sweet1.color = SweetTread;
                        break;
                    case 2:
                        AdmissionHeight.fillAmount = 0.6f;
                        Sweet1.color = SweetTread;
                        Sweet2.color = SweetTread;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                SlayNeverSpiral.PenMonopoly().JumpNever("1021", (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1).ToString());
                StudentFloral = PlayerPrefs.GetInt(CLagoon.StudentFloral);
                FamilyFloral = PlayerPrefs.GetInt(CLagoon.PerishFloral);
                PeltWarmFloral = PlayerPrefs.GetInt(CLagoon.PeltWarmFloral);
                ReadFiord(PropType.Roll);
                ReadFiord(PropType.Refresh);
                ReadFiord(PropType.Remind);
                for (int i = 0; i < PenalIce.Length; i++)
                {
                    PenalIce[i].SetActive(true);
                }
                ClumpMimetic.RyeClump = PlayerPrefs.GetInt(CLagoon.No_RyeClump);
                OilyVillage.instance.ThenClump(PlayerPrefs.GetInt(CLagoon.No_RyeClump));
                AdmissionIcebox.SetActive(false);
                //ChallengeLevel.SetActive(false);
                ValleyClump.SetActive(true);
                Clump.text = "Level" + (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
            }

            if (OilyMimetic.PenMonopoly().WeVirginAdmission)
            {
                if (PlayerPrefs.GetInt(CLagoon.PumpModestly) == 1)
                {
                    //打开挑战弹窗
                    PlayerPrefs.SetInt(CLagoon.PumpModestly, 0);
                    UIMimetic.PenMonopoly().BlueUIBasin(nameof(AdmissionInputToxic));
                }
            }

            if (PlayerPrefs.GetInt(CLagoon.RedbudEnclosurePenal) == 0)
            {
                OilyMimetic.PenMonopoly().EngineGuess = false;
                EnclosureLime.SetActive(true);
                EnclosurePlethora = DOTween.Sequence();
                EnclosurePlethora.Append(EnclosureIce.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.3f).SetLoops(10, LoopType.Yoyo))
                    .SetDelay(2)
                    .SetLoops(-1);
            }
        }
    }

    public bool PearBust()
    {
        FanNerve += 1;
        PlowLabor.fillAmount = FanNerve / SetNerve;
        if (FanNerve == SetNerve)
        {
            FanNerve = 0;
            PlowLabor.fillAmount = float.MinValue / float.MaxValue;
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(PlowBrantToxic));
            return true;
        }
        return false;
    }

    public void HatchEnclosureLime()
    {
        OilyMimetic.PenMonopoly().EngineGuess = true;

        if (!OilyMimetic.PenMonopoly().WePenal && PlayerPrefs.GetInt(CLagoon.RedbudEnclosurePenal) == 0)
        {

            SlayNeverSpiral.PenMonopoly().JumpNever("1002");
            PlayerPrefs.SetInt(CLagoon.RedbudEnclosurePenal, 1);
            EnclosureLime.SetActive(false);
            EnclosurePlethora.Kill();
            EnclosureIce.transform.localScale = Vector3.one;
        }
    }

    public void SoftnessYew(int Num)
    {
        switch (Num)
        {
            case 1:
                if (Hypothetical.gameObject.activeSelf)
                {
                    Hypothetical.AnimationState.SetAnimation(4, "nice", false);
                }
                else
                {
                    Hypothetical.gameObject.SetActive(true);
                }
                break;
            case 2:
                Hypothetical.Initialize(true);
                if (RigidGenerous.gameObject.activeSelf)
                {
                    RigidGenerous.AnimationState.SetAnimation(2, "great", false);
                }
                else
                {
                    RigidGenerous.gameObject.SetActive(true);
                }
                break;
            case 3:
                RigidGenerous.Initialize(true);
                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Combo3);
                if (DarlingGenerous.gameObject.activeSelf)
                {
                    DarlingGenerous.AnimationState.SetAnimation(1, "awesome", false);
                }
                else
                {
                    DarlingGenerous.gameObject.SetActive(true);
                }
                break;
            case 4:
                DarlingGenerous.Initialize(true);
                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Combo4);
                if (RevivalGenerous.gameObject.activeSelf)
                {
                    RevivalGenerous.AnimationState.SetAnimation(0, "amazing", false);
                }
                else
                {
                    RevivalGenerous.gameObject.SetActive(true);
                }
                break;
            case 5:
                RevivalGenerous.Initialize(true);
                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Combo5);
                if (AstronomyGenerous.gameObject.activeSelf)
                {
                    AstronomyGenerous.AnimationState.SetAnimation(3, "legendary", false);
                }
                else
                {
                    AstronomyGenerous.gameObject.SetActive(true);
                }
                break;
            default:
                OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_Combo5);
                AstronomyGenerous.Initialize(true);
                AstronomyGenerous.AnimationState.SetAnimation(3, "legendary", false);
                break;
        }
    }

    private void DampenFamily()
    {
        if (WeOurFamily)
        {
            List<SlotBehavior> slotTiles = OilyVillage.instance.PenBattleLowa();
            List<SlotBehavior> UseSolts = OilyVillage.instance.PenOurArid();
            int ActivityNumber = UseSolts.Count - slotTiles.Count;
            if (ActivityNumber >= 2)
            {
                WeFamily = true;
            }
            for (int i = 0; i < slotTiles.Count - 1; i++)
            {
                if (slotTiles[i].ActionTileBehavior().TileData == slotTiles[i + 1].ActionTileBehavior().TileData)
                {
                    WeFamily = true;
                    break;
                }
            }
            if (FamilyFloral > 0)
            {
                if (WeFamily)
                {
                    WeOurFamily = false;
                    LysBank(FamilyCab.gameObject.transform, SawSelfEke.instance.OilyHave.Wand_Cash);
                    WeFamily = false;
                    FamilyFloral--;
                    OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
                    if (OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        OurFamily++;
                        OilyMimetic.PenMonopoly().OurFamily = OurFamily;
                        SlayNeverSpiral.PenMonopoly().JumpNever("1019", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), OurFamily.ToString());
                        if (FamilyFloral <= 0 && AdmissionFamilyFloral == 0)
                        {
                            FamilyCab.interactable = false;
                            FamilyBurMan.SetActive(false);
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt(CLagoon.PerishFloral, FamilyFloral);
                    }
                    ReadFiord(PropType.Remind);

                    OilyVillage.instance.FamilyCany(false);
                }
                else
                {
                    SpearMimetic.PenMonopoly().BlueSpear("Not enough space");
                    Debug.Log("当前没有足够的存牌区");
                }
            }
            else
            {

                UIMimetic.PenMonopoly().BlueUIBasin(nameof(BurReadToxic), PropType.Remind);
            }
        }
    }

    public void BelugaFamily()
    {
        WeOurFamily = true;
    }

    private void DampenRefiner()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(RefinerToxic),1);
    }

    private void DampenStudent()
    {
        if (StudentFloral > 0)
        {
            LysBank(StudentCab.gameObject.transform, SawSelfEke.instance.OilyHave.Shuffle_Cash);
            OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
            StudentFloral--;
            if (OilyMimetic.PenMonopoly().WeAdmission)
            {
                OurStudent++;
                OilyMimetic.PenMonopoly().OurStudent = OurStudent;
                SlayNeverSpiral.PenMonopoly().JumpNever("1020", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), OurStudent.ToString());
                if (StudentFloral <= 0 && AdmissionStudentFloral == 0)
                {
                    StudentCab.interactable = false;
                    StudentBurMan.SetActive(false);
                }
                
            }
            else
            {
                PlayerPrefs.SetInt(CLagoon.StudentFloral, StudentFloral);
            }
            ReadFiord(PropType.Refresh);
            OilyVillage.instance.StudentCany();
        }
        else
        {
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(BurReadToxic), PropType.Refresh);
        }
    }
    private void DampenPeltWarm()
    {
        if (PeltWarmFloral > 0)
        {
            if (OilyVillage.instance.PenBattleLowa().Count > 0)
            {
                PeltWarmFloral--;
                OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
                if (OilyMimetic.PenMonopoly().WeAdmission)
                {
                    OurPeltWarm++;
                    OilyMimetic.PenMonopoly().OurPeltWarm = OurPeltWarm;
                    SlayNeverSpiral.PenMonopoly().JumpNever("1018", OilyMimetic.PenMonopoly().PenAdmissionClump().ToString(), OurPeltWarm.ToString());
                    if (PeltWarmFloral <= 0 && AdmissionPeltFloral == 0)
                    {
                        PeltWarmCab.interactable = false;
                        PeltWarmBurTip.SetActive(false);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, PeltWarmFloral);
                }
                ReadFiord(PropType.Roll);
                LysBank(PeltWarmCab.gameObject.transform, SawSelfEke.instance.OilyHave.Undo_Cash);
                
                OilyVillage.instance.PeltWarmRCany();
            }
            else
            {
                SpearMimetic.PenMonopoly().BlueSpear("Irrevocable");
            }

        }
        else
        {
            UIMimetic.PenMonopoly().BlueUIBasin(nameof(BurReadToxic), PropType.Roll);
        }
    }

    private void ReadFiord(PropType type)
    {
        switch (type)
        {
            case PropType.Roll:
                if (PeltWarmFloral > 0)
                {
                    PeltWarmFloralMan.SetActive(true);
                    PeltWarmBurTip.SetActive(false);
                    PeltWarmEdit.text = PeltWarmFloral.ToString();
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, PeltWarmFloral);
                    }
                }
                else
                {
                    PeltWarmFloralMan.SetActive(false);
                    PeltWarmBurTip.SetActive(true);
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.PeltWarmFloral, PeltWarmFloral);
                    }
                    else
                    {
                        if (AdmissionPeltFloral == 0)
                        {
                            PeltWarmBurTip.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Remind:
                if (FamilyFloral > 0)
                {
                    FamilyBurMan.SetActive(false);
                    FamilyFloralMan.SetActive(true);
                    FamilyEdit.text = FamilyFloral.ToString();
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.PerishFloral, FamilyFloral);
                    }
                }
                else
                {
                    FamilyFloralMan.SetActive(false);
                    FamilyBurMan.SetActive(true);
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.PerishFloral, FamilyFloral);
                    }
                    else
                    {
                        if (AdmissionFamilyFloral == 0)
                        {
                            FamilyBurMan.SetActive(false);
                        }
                    }
                }
                break;
            case PropType.Refresh:
                if (StudentFloral > 0)
                {
                    StudentBurMan.SetActive(false);
                    StudentFloralMan.SetActive(true);
                    StudentEdit.text = StudentFloral.ToString();
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.StudentFloral, StudentFloral);
                    }
                }
                else
                {
                    StudentFloralMan.SetActive(false);
                    StudentBurMan.SetActive(true);
                    if (!OilyMimetic.PenMonopoly().WeAdmission)
                    {
                        PlayerPrefs.SetInt(CLagoon.StudentFloral, StudentFloral);
                    }
                    else
                    {
                        if (AdmissionStudentFloral == 0)
                        {
                            StudentBurMan.SetActive(false);
                        }
                    }
                }
                break;
            default:
                break;
        }
    }

    private float FloralQuit= 0;
    private void Update()
    {
        if (OilyMimetic.PenMonopoly().WeAdmission)
        {
            FloralQuit += Time.deltaTime;
            if (FloralQuit >= 4)
            {
                Tissue.BurCoordination("User:" + Random.Range(10, 100) + "****" + Random.Range(10, 100) + " won 2000$");
                FloralQuit = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            HatchUIWork(GetType().Name);
            PearUIWork(nameof(RedbudToxic));
        }
    }
    public void LysBank(Vector3 StartPostion, double AwardNum)
    {
        if (!TemperFile.WeSound())
        {
            ConestogaAssumption.IsleAsiaThaw(BankBold, 10, StartPostion, RibLap.position, () =>
            {
                OilyHaveMimetic.PenMonopoly().BurTusk(AwardNum);
            });
        }  
    }

    public void LysBank(Transform StartPostion, double AwardNum)
    {
        if (!TemperFile.WeSound())
        {
            ConestogaAssumption.IsleAsiaThaw(BankBold, 10, StartPostion, RibLap, () =>
            {
                OilyHaveMimetic.PenMonopoly().BurTusk(AwardNum);
            });
        }
    }

    public void WeSpeedyLime(bool open)
    {
        SpeedyLime.SetActive(open);
    }
}
