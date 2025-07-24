using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuskLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeArray")]    public GameObject[] TelescopeBroad;
[UnityEngine.Serialization.FormerlySerializedAs("AwardSlider")]
    public Image DreamSocial;
[UnityEngine.Serialization.FormerlySerializedAs("StartBtn")]    public Button StoveHat;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenBtn")]    public Button DiffuseHat;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenBtn1")]    public Button DiffuseHat1;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button UsuallyHat;
[UnityEngine.Serialization.FormerlySerializedAs("LevelDesc")]    public Text BleakCyan;
[UnityEngine.Serialization.FormerlySerializedAs("Award1")]    public Image Dream1;
[UnityEngine.Serialization.FormerlySerializedAs("Award2")]    public Image Dream2;
[UnityEngine.Serialization.FormerlySerializedAs("Award3")]    public Image Dream3;
[UnityEngine.Serialization.FormerlySerializedAs("ChallenTimeDesc")]    public Text DiffusePassCyan;
[UnityEngine.Serialization.FormerlySerializedAs("ListArray")]
    public GameObject[] FireBroad;
[UnityEngine.Serialization.FormerlySerializedAs("AwardIcon")]
    public Sprite[] DreamThai; 

    #region 计算时间

    // 距离下次刷新的剩余时间（秒）
    private float CustodialPass= 0f;
    // 是否正在倒计时
    private bool DyDivisionTell= false;

    private void FixedUpdate()
    {
        if (DyDivisionTell)
        {
            CustodialPass -= Time.deltaTime;
            if (CustodialPass <= 0)
            {
                Booklet();
                OtherwiseChampagnePass();
            }
            else
            {
                DiffusePassCyan.text = RoadTenuous.GetInstance().OxPassWindow(CustodialPass);
            }
        }
    }

    // 计算距离下次午夜0点的剩余时间
    private void OtherwiseChampagnePass()
    {
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        CustodialPass = (float)(nextMidnight - now).TotalSeconds;
        DyDivisionTell = true;

        Debug.Log($"下次刷新时间: {nextMidnight}, 剩余时间: {CustodialPass / 3600:F2} 小时");
    }

    // 执行刷新操作
    private void Booklet()
    {
        DyDivisionTell = false;
        Debug.Log("执行每日刷新!");
        DreamSocial.fillAmount = 0;
        Dream1.sprite = DreamThai[0];
        Dream2.sprite = DreamThai[0];
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, 0);
        TelescopeViscera();
        if (RoadTenuous.GetInstance().OfRadishTelescope)
        {
            if (PlayerPrefs.GetInt(CConfig.OnceChalleng) == 1)
            {
                //打开挑战弹窗
                PlayerPrefs.SetInt(CConfig.OnceChalleng, 0);
                UIManager.GetInstance().ShowUIForms(nameof(TelescopeOrbitLoder));
            }
        }
        // 触发刷新事件
        //OnRefresh?.Invoke();
    }

    // 检查离线期间是否需要刷新
    private void PanicMeanderBooklet()
    {
        // 获取上次登出时间
        DateTime lastLogoutTime = MobCordDuringPass();
        DateTime now = DateTime.Now;

        // 如果是首次登录，记录当前时间并返回
        if (lastLogoutTime == DateTime.MinValue)
        {
            WickDuringPass(now);
            return;
        }

        // 计算上次登出时间到现在经过的天数
        int daysPassed = (int)(now.Date - lastLogoutTime.Date).TotalDays;

        // 如果经过了至少1天，则执行刷新
        if (daysPassed >= 1)
        {
            Debug.Log($"离线期间经过了 {daysPassed} 天，执行离线刷新");
            Booklet();
        }
    }

    // 保存当前时间为登出时间
    public void WickDuringPass()
    {
        WickDuringPass(DateTime.Now);
    }

    // 保存登出时间到PlayerPrefs
    private void WickDuringPass(DateTime time)
    {
        // 将DateTime转换为长整型（Ticks）存储
        Debug.Log(time.Ticks.ToString());
        PlayerPrefs.SetString(CConfig.Last_Logout_Time_Key, time.Ticks.ToString());
        PlayerPrefs.Save();

        Debug.Log($"保存登出时间: {time}");
    }

    // 从PlayerPrefs获取上次登出时间
    private DateTime MobCordDuringPass()
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
    public void During()
    {
        WickDuringPass();
        // 可以添加其他登出逻辑
    }

    #endregion

    private void Start()
    {
        // 检查是否需要执行离线刷新
        PanicMeanderBooklet();

        // 计算距离下次0点的剩余时间
        OtherwiseChampagnePass();
        
        StoveHat.onClick.AddListener(StoveRoad);
        DiffuseHat.onClick.AddListener(BeamTelescopeBleak);
        DiffuseHat1.onClick.AddListener(BeamTelescopeBleak);
        UsuallyHat.onClick.AddListener(RatifyUsually);
        for (int i = 0; i < FireBroad.Length; i++)
        {
            RoadTenuous.GetInstance().ThrustUnpublished(FireBroad[i].GetComponent<RectTransform>());
        }
    }

    private void StoveRoad()
    {
        RoadTenuous.GetInstance().OfTelescope = false;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
        UIManager.GetInstance().ShowUIForms(nameof(RoadLoder), PlayerPrefs.GetInt(CConfig.sv_CurLevel));
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RoadTenuous.GetInstance().ReliefStilt = true;
        BleakCyan.text = "Level " + (PlayerPrefs.GetInt(CConfig.sv_CurLevel) + 1);
        TelescopeViscera();
    }

    private void TelescopeViscera()
    {
        if (RoadTenuous.GetInstance().OfRadishTelescope)
        {
            for (int i = 0; i < TelescopeBroad.Length; i++)
            {
                TelescopeBroad[i].SetActive(true);
            }
            switch (PlayerPrefs.GetInt(CConfig.NowDayChallenAward))
            {
                case 0:
                    DreamSocial.fillAmount = 0f;
                    break;
                case 1:
                    Dream1.sprite = DreamThai[0];
                    DreamSocial.fillAmount = 0.2f;
                    break;
                case 2:
                    Dream2.sprite = DreamThai[0];
                    DreamSocial.fillAmount = 0.5f;
                    break;
                case 3:
                    DreamSocial.fillAmount = 1f;
                    break;
                default:
                    DiffuseHat.interactable = false;
                    DiffuseHat1.interactable = false;
                    break;
            }
        }
    }
    private void RatifyUsually()
    {
        UIManager.GetInstance().ShowUIForms(nameof(UsuallyLoder));
    }
    public void BeamTelescopeBleak()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
        RoadTenuous.GetInstance().OfTelescope = true;
        UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
        RoadTenuous.GetInstance().StoveCrossbones();
    }
}
