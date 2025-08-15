using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuckNeedy : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeArray")]    [UnityEngine.Serialization.FormerlySerializedAs("TelescopeBroad")]public GameObject[] OutriggerGlean;
[UnityEngine.Serialization.FormerlySerializedAs("AwardSlider")]
[UnityEngine.Serialization.FormerlySerializedAs("DreamSocial")]    public Image PeartIsrael;
[UnityEngine.Serialization.FormerlySerializedAs("StartBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("StoveHat")]public Button OrganThe;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("DiffuseHat")]public Button HectareThe;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenBtn1")]    [UnityEngine.Serialization.FormerlySerializedAs("DiffuseHat1")]public Button HectareThe1;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("UsuallyHat")]public Button QuicklyThe;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("BleakCyan")]public Text GrantFlax;
[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream1")]public Image Peart1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream2")]public Image Peart2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    [UnityEngine.Serialization.FormerlySerializedAs("Dream3")]public Image Peart3;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenTimeDesc")]    [UnityEngine.Serialization.FormerlySerializedAs("DiffusePassCyan")]public Text HectareTernFlax;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
[UnityEngine.Serialization.FormerlySerializedAs("FireBroad")]    public GameObject[] LifeGlean;
[UnityEngine.Serialization.FormerlySerializedAs("AwardIcon")]
[UnityEngine.Serialization.FormerlySerializedAs("DreamThai")]    public Sprite[] PeartSilt;
[UnityEngine.Serialization.FormerlySerializedAs("enter1")]
    public CashOutEnter Sense1;

    #region 计算时间

    // 距离下次刷新的剩余时间（秒）
    private float CertaintyTern= 0f;
    // 是否正在倒计时
    private bool ByMinstrelRisk= false;

    private void FixedUpdate()
    {
        if (ByMinstrelRisk)
        {
            CertaintyTern -= Time.deltaTime;
            if (CertaintyTern <= 0)
            {
                Saguaro();
                DeterrentAvoidableTern();
            }
            else
            {
                HectareTernFlax.text = RaftNonself.GetInstance().OxTernVenice(CertaintyTern);
            }
        }
    }

    // 计算距离下次午夜0点的剩余时间
    private void DeterrentAvoidableTern()
    {
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        CertaintyTern = (float)(nextMidnight - now).TotalSeconds;
        ByMinstrelRisk = true;

        Debug.Log($"下次刷新时间: {nextMidnight}, 剩余时间: {CertaintyTern / 3600:F2} 小时");
    }

    // 执行刷新操作
    private void Saguaro()
    {
        ByMinstrelRisk = false;
        Debug.Log("执行每日刷新!");
        PeartIsrael.fillAmount = 0;
        Peart1.sprite = PeartSilt[1];
        Peart2.sprite = PeartSilt[1];
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, 0);
        OutriggerCenotes();
        if (RaftNonself.GetInstance().MeExtentOutrigger)
        {
            //打开挑战弹窗
            PlayerPrefs.SetInt(CConfig.OnceChalleng, 0);
            UIManager.GetInstance().ShowUIForms(nameof(OutriggerRiverNeedy));
            
        }
    }

    // 检查离线期间是否需要刷新
    private void StillUnaidedSaguaro()
    {
        // 获取上次登出时间
        DateTime lastLogoutTime = YouAfarPatronTern();
        DateTime now = DateTime.Now;

        // 如果是首次登录，记录当前时间并返回
        if (lastLogoutTime == DateTime.MinValue)
        {
            TapePatronTern(now);
            return;
        }
        Debug.Log(lastLogoutTime.Date);
        Debug.Log(now.Date);
        // 计算上次登出时间到现在经过的天数
        int daysPassed = (int)(now.Date - lastLogoutTime.Date).TotalDays;

        // 如果经过了至少1天，则执行刷新
        if (daysPassed >= 1)
        {
            Debug.Log($"离线期间经过了 {daysPassed} 天，执行离线刷新");
            Saguaro();
        }
    }

    // 保存当前时间为登出时间
    public void TapePatronTern()
    {
        TapePatronTern(DateTime.Now);
    }

    // 保存登出时间到PlayerPrefs
    private void TapePatronTern(DateTime time)
    {
        // 将DateTime转换为长整型（Ticks）存储
        PlayerPrefs.SetString(CConfig.Last_Logout_Time_Key, time.Ticks.ToString());
        PlayerPrefs.Save();

        Debug.Log($"保存登出时间: {time}");
    }

    // 从PlayerPrefs获取上次登出时间
    private DateTime YouAfarPatronTern()
    {
        if (PlayerPrefs.HasKey(CConfig.Last_Logout_Time_Key))
        {
            long ticks = long.Parse(PlayerPrefs.GetString(CConfig.Last_Logout_Time_Key));
            return new DateTime(ticks);
        }

        // 如果没有记录，返回DateTime.MinValue
        return DateTime.MinValue;
    }

    // 提供给外部调用的登出方法
    public void Patron()
    {
        TapePatronTern();
        // 可以添加其他登出逻辑
    }

    #endregion

    private void Awake()
    {
        if (!CommonUtil.IsApple())
        {
            Sense1.gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        // 检查是否需要执行离线刷新
        StillUnaidedSaguaro();

        // 计算距离下次0点的剩余时间
        DeterrentAvoidableTern();
        
        OrganThe.onClick.AddListener(OrganRaft);
        HectareThe.onClick.AddListener(SkinOutriggerGrant);
        //DiffuseHat1.onClick.AddListener(BeamTelescopeBleak);
        QuicklyThe.onClick.AddListener(CinemaQuickly);
        for (int i = 0; i < LifeGlean.Length; i++)
        {
            RaftNonself.GetInstance().PlaguePomegranate(LifeGlean[i].GetComponent<RectTransform>());
        }
    }

    private void OrganRaft()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().MeOutrigger = false;
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        Sense1.UpdateData();
        RaftNonself.GetInstance().EmpireStilt = true;
        GrantFlax.text = "Level " + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
        OutriggerCenotes();
    }

    private void OutriggerCenotes()
    {
        if (RaftNonself.GetInstance().MeExtentOutrigger)
        {
            for (int i = 0; i < OutriggerGlean.Length; i++)
            {
                OutriggerGlean[i].SetActive(true);
            }
            switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
            {
                case 0:
                    PeartIsrael.fillAmount = 0f;
                    break;
                case 1:
                    Peart1.sprite = PeartSilt[0];
                    PeartIsrael.fillAmount = 0.2f;
                    break;
                case 2:
                    Peart1.sprite = PeartSilt[0];
                    Peart2.sprite = PeartSilt[0];
                    PeartIsrael.fillAmount = 0.5f;
                    break;
                case 3:
                    PeartIsrael.fillAmount = 1f;
                    break;
                default:
                    HectareThe.interactable = false;
                    HectareThe1.interactable = false;
                    break;
            }
        }
    }
    private void CinemaQuickly()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        UIManager.GetInstance().ShowUIForms(nameof(QuicklyNeedy));
    }
    public void SkinOutriggerGrant()
    {
        RaftNonself.GetInstance().QuicklyArena(HapticPatterns.PresetType.LightImpact);
        RaftNonself.GetInstance().QuicklyCanal(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
        RaftNonself.GetInstance().MeOutrigger = true;
        UIManager.GetInstance().ShowUIForms(nameof(RaftNeedy));
        RaftNonself.GetInstance().OrganPreferable(StartChallengeState.Challenge);
    }
}
