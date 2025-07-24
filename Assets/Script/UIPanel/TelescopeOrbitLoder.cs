using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelescopeOrbitLoder : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("DownTime")]    public Text TellPass;
[UnityEngine.Serialization.FormerlySerializedAs("Close")]    public Button Spark;
[UnityEngine.Serialization.FormerlySerializedAs("PlayBtn")]    public Button LikeHat;

    private float CustodialPass= 0f;

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);
        RoadTenuous.GetInstance().ReliefStilt = false;
        DateTime now = DateTime.Now;
        DateTime nextMidnight = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        // 如果当前时间已经过了今天的0点，则计算明天的0点
        if (now > nextMidnight)
        {
            nextMidnight = nextMidnight.AddDays(1);
        }

        // 计算剩余时间（秒）
        CustodialPass = (float)(nextMidnight - now).TotalSeconds;
    }

    private void Start()
    {
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_PopShow);
        LikeHat.onClick.AddListener(RatifyLike);
        Spark.onClick.AddListener(RatifySpark);
    }

    public void RatifyLike()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        UIManager.GetInstance().ClearAllUI();
        RoadTenuous.GetInstance().OfTelescope = true;
        UIManager.GetInstance().ShowUIForms(nameof(RoadLoder));
        PlayerPrefs.SetInt(CConfig.NowDayChallenAward, 0);
        RoadTenuous.GetInstance().StoveCrossbones();
    }

    public void RatifySpark()
    {
        RoadTenuous.GetInstance().ReliefStilt = true;
        RoadTenuous.GetInstance().UsuallyCharm(MusicType.UIMusic.Sound_UIButton);
        CloseUIForm(GetType().Name);
    }

    private void FixedUpdate()
    {
        CustodialPass -= Time.deltaTime;
        TellPass.text = RoadTenuous.GetInstance().OxPassWindow(CustodialPass);
    }
}
