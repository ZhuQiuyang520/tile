using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeArray")]    public GameObject[] AdmissionCarol;
[UnityEngine.Serialization.FormerlySerializedAs("AwardSlider")]
    public Image SweetIcebox;
[UnityEngine.Serialization.FormerlySerializedAs("StartBtn")]    public Button CrampCab;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenBtn")]    public Button SeveralCab;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button RefinerCab;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]    public Text ClumpLowa;
[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    public Image Sweet1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    public Image Sweet2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    public Image Sweet3;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    public GameObject[] PlugCarol;
[UnityEngine.Serialization.FormerlySerializedAs("AwardIcon")]
    public Sprite[] SweetBold;
[UnityEngine.Serialization.FormerlySerializedAs("enter1")]
    public CashOutEnter Agree1;

    #region 计算时间

    // 距离下次刷新的剩余时间（秒）
    private float MercilessQuit= 0f;
    // 是否正在倒计时
    private bool ByMediocreRent= false;

    private void FixedUpdate()
    {
        if (ByMediocreRent)
        {
            MercilessQuit -= Time.deltaTime;
            if (MercilessQuit <= 0)
            {
                Student();
                PersonnelSupremelyQuit();
            }
        }
    }

    // 计算距离下次午夜0点的剩余时间
    private void PersonnelSupremelyQuit()
    {
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        MercilessQuit = (float)(nextMidnight - now).TotalSeconds;
        ByMediocreRent = true;

        Debug.Log($"下次刷新时间: {nextMidnight}, 剩余时间: {MercilessQuit / 3600:F2} 小时");
    }

    // 执行刷新操作
    private void Student()
    {
        ByMediocreRent = false;
        Debug.Log("执行每日刷新!");
        SweetIcebox.fillAmount = 0;
        Sweet1.sprite = SweetBold[0];
        Sweet2.sprite = SweetBold[0];
        PlayerPrefs.SetInt(CLagoon.PerHimSeveralSweet, 0);
        AdmissionPlastic();
        if (OilyMimetic.PenMonopoly().WeVirginAdmission)
        {
            if (PlayerPrefs.GetInt(CLagoon.PumpModestly) == 1)
            {
                //打开挑战弹窗
                PlayerPrefs.SetInt(CLagoon.PumpModestly, 0);
                UIMimetic.PenMonopoly().BlueUIBasin(nameof(AdmissionInputToxic));
            }
        }
        // 触发刷新事件
        //OnRefresh?.Invoke();
    }

    // 检查离线期间是否需要刷新
    private void OtherConciseStudent()
    {
        // 获取上次登出时间
        DateTime lastLogoutTime = PenSeemEvolveQuit();
        DateTime now = DateTime.Now;

        // 如果是首次登录，记录当前时间并返回
        if (lastLogoutTime == DateTime.MinValue)
        {
            LuckEvolveQuit(now);
            return;
        }

        // 计算上次登出时间到现在经过的天数
        int daysPassed = (int)(now.Date - lastLogoutTime.Date).TotalDays;

        // 如果经过了至少1天，则执行刷新
        if (daysPassed >= 1)
        {
            Debug.Log($"离线期间经过了 {daysPassed} 天，执行离线刷新");
            Student();
        }
    }

    // 保存当前时间为登出时间
    public void LuckEvolveQuit()
    {
        LuckEvolveQuit(DateTime.Now);
    }

    // 保存登出时间到PlayerPrefs
    private void LuckEvolveQuit(DateTime time)
    {
        // 将DateTime转换为长整型（Ticks）存储
        Debug.Log(time.Ticks.ToString());
        PlayerPrefs.SetString(CLagoon.Seem_Evolve_Quit_Wok, time.Ticks.ToString());
        PlayerPrefs.Save();

        Debug.Log($"保存登出时间: {time}");
    }

    // 从PlayerPrefs获取上次登出时间
    private DateTime PenSeemEvolveQuit()
    {
        if (PlayerPrefs.HasKey(CLagoon.Seem_Evolve_Quit_Wok))
        {
            long ticks = long.Parse(PlayerPrefs.GetString(CLagoon.Seem_Evolve_Quit_Wok));
            return new DateTime(ticks);
        }

        // 如果没有记录，返回DateTime.MinValue
        return DateTime.MinValue;
    }

    // 提供给外部调用的登出方法
    public void Evolve()
    {
        LuckEvolveQuit();
        // 可以添加其他登出逻辑
    }

    #endregion

    private void Awake()
    {
        if (!TemperFile.WeSound())
        {
            Agree1.gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        // 检查是否需要执行离线刷新
        OtherConciseStudent();

        // 计算距离下次0点的剩余时间
        PersonnelSupremelyQuit();
        
        CrampCab.onClick.AddListener(CrampOily);
        SeveralCab.onClick.AddListener(ThenAdmissionClump);
        //ChallenBtn1.onClick.AddListener(LoadChallengeLevel);
        RefinerCab.onClick.AddListener(DampenRefiner);
        //for (int i = 0; i < ListArray.Length; i++)
        //{
        //    OilyMimetic.GetInstance().PepperFashionable(ListArray[i].GetComponent<RectTransform>());
        //}
    }

    private void CrampOily()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        HatchUIWork(GetType().Name);
        OilyMimetic.PenMonopoly().WeAdmission = false;
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic), PlayerPrefs.GetInt(CLagoon.No_RyeClump));
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Agree1.UpdateData();
        OilyMimetic.PenMonopoly().EngineGuess = true;
        ClumpLowa.text = "Level " + (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1);
        AdmissionPlastic();
    }

    private void AdmissionPlastic()
    {
        if (OilyMimetic.PenMonopoly().WeVirginAdmission)
        {
            for (int i = 0; i < AdmissionCarol.Length; i++)
            {
                AdmissionCarol[i].SetActive(true);
            }
            switch (PlayerPrefs.GetInt(CLagoon.PerHimSeveralSweet))
            {
                case 0:
                    SweetIcebox.fillAmount = 0f;
                    break;
                case 1:
                    Sweet1.sprite = SweetBold[0];
                    SweetIcebox.fillAmount = 0.2f;
                    break;
                case 2:
                    Sweet2.sprite = SweetBold[0];
                    Sweet1.sprite = SweetBold[0];
                    SweetIcebox.fillAmount = 0.5f;
                    break;
                case 3:
                    SweetIcebox.fillAmount = 1f;
                    break;
                default:
                    SeveralCab.interactable = false;
                    break;
            }
        }
    }
    private void DampenRefiner()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(RefinerToxic));
    }
    public void ThenAdmissionClump()
    {
        OilyMimetic.PenMonopoly().RefinerCoral(HapticPatterns.PresetType.LightImpact);
        OilyMimetic.PenMonopoly().RefinerHumid(WhaleSpur.UIMusic.Sound_UIButton);
        HatchUIWork(GetType().Name);
        OilyMimetic.PenMonopoly().WeAdmission = true;
        UIMimetic.PenMonopoly().BlueUIBasin(nameof(OilyToxic));
        OilyMimetic.PenMonopoly().CrampPerceptual(StartChallengeState.Challenge);
    }
}
