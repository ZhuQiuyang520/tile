using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperFile
{
    [HideInInspector] public static string Shrimp_SatiricBear; //归因渠道名称 由NetInfoMgr的CheckAdjustNetwork方法赋值
    static string Luck_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string ExpertDualBear= "pie"; //正常模式名称
    static string Technical; //距离黑名单位置的距离 打点用
    static string Lordly; //进审理由 打点用
    [HideInInspector] public static string ClueYam= ""; //判断流程 打点用
    public static bool WeSound()
    {
        //测试
        // return true;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Luck_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Luck_AP)) //无本地存档 读取网络数据
            OtherMortarHave();

        if (Luck_AP != "P")
            return true;
        else
            return false;
    }
    public static void OtherMortarHave() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Luck_AP = "P";
        if (SawSelfEke.instance.LagoonHave.apple_pie != ExpertDualBear) //审模式 
        {
            OtherChance = "YES";
            Luck_AP = "A";
            if (string.IsNullOrEmpty(Lordly))
                Lordly = "ApplePie";
        }
        ClueYam = "0:" + Luck_AP;
        //判断运营商信息
        if (SawSelfEke.instance.TactHave != null && SawSelfEke.instance.TactHave.IsHaveApple)
        {
            Luck_AP = "A";
            if (string.IsNullOrEmpty(Lordly))
                Lordly = "HaveApple";
            ClueYam += "1:" + Luck_AP;
        }
        if (SawSelfEke.instance.EnterNose != null)
        {
            //判断经纬度
            LocationData[] LocationDatas = SawSelfEke.instance.EnterNose.LocationList;
            if (LocationDatas != null && LocationDatas.Length > 0 && SawSelfEke.instance.TactHave != null && SawSelfEke.instance.TactHave.lat != 0 && SawSelfEke.instance.TactHave.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = PenBuckskin((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)SawSelfEke.instance.TactHave.lat, (float)SawSelfEke.instance.TactHave.lon);
                    Technical += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Luck_AP = "A";
                        if (string.IsNullOrEmpty(Lordly))
                            Lordly = "Location";
                        break;
                    }
                }
            }
            ClueYam += "2:" + Luck_AP;
            //判断城市
            string[] HeiCityList = SawSelfEke.instance.EnterNose.CityList;
            if (!string.IsNullOrEmpty(SawSelfEke.instance.TactHave.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == SawSelfEke.instance.TactHave.regionName
                    || HeiCityList[i] == SawSelfEke.instance.TactHave.city)
                    {
                        Luck_AP = "A";
                        if (string.IsNullOrEmpty(Lordly))
                            Lordly = "City";
                        break;
                    }
                }
            }
            ClueYam += "3:" + Luck_AP;
            //判断黑名单
            string[] HeiIPs = SawSelfEke.instance.EnterNose.IPList;
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(SawSelfEke.instance.TactHave.query))
            {
                string[] IpNums = SawSelfEke.instance.TactHave.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Luck_AP = "A";
                        if (string.IsNullOrEmpty(Lordly))
                            Lordly = "IP";
                        break;
                    }
                }
            }
            ClueYam += "4:" + Luck_AP;
        }
        //判断自然量
        
        if (!string.IsNullOrEmpty(SawSelfEke.instance.EnterNose.fall_down))
        {
            // if (SawSelfEke.instance.BlockRule.fall_down == "bottom") //仅判断Organic
            // {
            //     if (Adjust_TrackerName == "Organic") //打开自然量 且 归因渠道是Organic 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
            // else if (SawSelfEke.instance.BlockRule.fall_down == "down") //判断Organic + NoUserConsent
            // {
            //     if (Adjust_TrackerName == "Organic" || Adjust_TrackerName == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
        }
        ClueYam += "5:" + Luck_AP;

        //安卓平台特殊屏蔽策略
        if (Application.platform == RuntimePlatform.Android && SawSelfEke.instance.EnterNose != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");

            //判断是否使用VPN
            if (SawSelfEke.instance.EnterNose.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "VPN";
                }
            }
            ClueYam += "6:" + Luck_AP;

            //是否使用模拟器
            if (SawSelfEke.instance.EnterNose.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "Simulator";
                }
            }
            ClueYam += "7:" + Luck_AP;
            //是否root
            if (SawSelfEke.instance.EnterNose.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "Root";
                }
            }
            ClueYam += "8:" + Luck_AP;
            //是否使用开发者模式
            if (SawSelfEke.instance.EnterNose.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "Developer";
                }
            }
            ClueYam += "9:" + Luck_AP;

            //是否使用USB调试
            if (SawSelfEke.instance.EnterNose.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "UsbDebug";
                }
            }
            ClueYam += "10:" + Luck_AP;

            //是否使用sim卡
            if (SawSelfEke.instance.EnterNose.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                {
                    Luck_AP = "A";
                    if (string.IsNullOrEmpty(Lordly))
                        Lordly = "SimCard";
                }
            }
            ClueYam += "11:" + Luck_AP;
        }
        PlayerPrefs.SetString("Save_AP", Luck_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);

        //打点
        if (!string.IsNullOrEmpty(LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf)))
            JumpNever();
    }
    static float PenBuckskin(float lat1, float lon1, float lat2, float lon2)
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void JumpNever()
    {
        //打点
        if (SawSelfEke.instance.TactHave != null)
        {
            string Info1 = "[" + (Luck_AP == "A" ? "审" : "正常") + "] [" + Lordly + "]";
            string Info2 = "[" + SawSelfEke.instance.TactHave.lat + "," + SawSelfEke.instance.TactHave.lon + "] [" + SawSelfEke.instance.TactHave.regionName + "] [" + Technical + "]";
            string Info3 = "[" + SawSelfEke.instance.TactHave.query + "] [Null]";  // [" + Adjust_TrackerName + "]";
            SlayNeverSpiral.PenMonopoly().JumpNever("3000", Info1, Info2, Info3);
        }
        else
            SlayNeverSpiral.PenMonopoly().JumpNever("3000", "No UserData");
        SlayNeverSpiral.PenMonopoly().JumpNever("3001", (Luck_AP == "A" ? "审" : "正常"), ClueYam, SawSelfEke.instance.HaveFish);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }

    // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
    public static bool ReleaseEnterOther()
    {
        if (Application.platform == RuntimePlatform.Android && SawSelfEke.instance.EnterNose != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            string Info = "";
            if (SawSelfEke.instance.EnterNose.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                    Info = "Please turn off your VPN, restart the game and try again.";
            }
            if (SawSelfEke.instance.EnterNose.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                    Info = "This game cannot be run on emulators.";
            }
            if (SawSelfEke.instance.EnterNose.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                    Info = "This game cannot be played on rooted devices.";
            }
            if (SawSelfEke.instance.EnterNose.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                    Info = "Please switch off Developer Option, restart the game and try again.";
            }
            if (SawSelfEke.instance.EnterNose.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                    Info = "Please switch off USB debugging, restart the game and try again.";
            }
            if (SawSelfEke.instance.EnterNose.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                    Info = "Please check if the SIM card is inserted, then restart the game and try again.";
            }
            if (!string.IsNullOrEmpty(Info))
            {
                UIMimetic.PenMonopoly().BlueUIBasin(nameof(EnterToxic)).GetComponent<EnterToxic>().BlueSelf(Info);
                return true;
            }
        }
        return false;
    }

    public static bool WeOnward()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool WeOvertone()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 TimidLyric2PepperLyric(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 PepperLyric2TimidLyric(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 PenFarceDatebaseToGrabVenerable(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
