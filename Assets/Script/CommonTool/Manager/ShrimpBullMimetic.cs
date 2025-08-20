using System;
using System.Collections;
using com.adjust.sdk;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShrimpBullMimetic : MonoBehaviour
{
    public static ShrimpBullMimetic Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string StrictID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string No_ADWolfBullSpur= "sv_ADJustInitType";

    //adjust 时间戳
    private string No_ADWolfQuit= "sv_ADJustTime";

    //adjust行为计数器
    public int _PrudentIdeal{ get; private set; }

    public double _PrudentSwiftly{ get; private set; }

    double StrictBullToSwiftly= 0;


    private void Awake()
    {
        Instance = this;
        LuckHaveMimetic.LayAcross(No_ADWolfQuit, LoopFile.Someone().ToString());

#if UNITY_IOS
        LuckHaveMimetic.LayAcross(No_ADWolfBullSpur, AdjustStatus.OpenAsAct.ToString());
        ShrimpBull();
#endif
    }

    private void Start()
    {
        _PrudentIdeal = 0;
    }


    void ShrimpBull()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(StrictID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);

        StartCoroutine(LuckShrimpPale());
    }

    private IEnumerator LuckShrimpPale()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                LuckHaveMimetic.LayAcross(CLagoon.No_ShrimpPale, adjustAdid);
                SawSelfEke.instance.JumpShrimpPale();
                yield break;
            }
        }
    }

    public string PenShrimpPale()
    {
        return LuckHaveMimetic.PenAcross(CLagoon.No_ShrimpPale);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string PenShrimpVenice()
    {
        return LuckHaveMimetic.PenAcross(No_ADWolfBullSpur);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void BullShrimpHave(bool isOldUser = false)
    {
        #if UNITY_IOS
            return;
        #endif
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(SawSelfEke.instance.LagoonHave.adjust_init_act_position) || int.Parse(SawSelfEke.instance.LagoonHave.adjust_init_act_position) <= 0)
        {
            LuckHaveMimetic.LayAcross(No_ADWolfBullSpur, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + LuckHaveMimetic.PenAcross(No_ADWolfBullSpur));
        //用户二次登录 根据标签初始化
        if (LuckHaveMimetic.PenAcross(No_ADWolfBullSpur) == AdjustStatus.OldUser.ToString() || LuckHaveMimetic.PenAcross(No_ADWolfBullSpur) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            ShrimpBull();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void BurGapIdeal(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (LuckHaveMimetic.PenAcross(No_ADWolfBullSpur) != "") return;
        _PrudentIdeal++;
        print(" add up to :" + _PrudentIdeal);
        if (string.IsNullOrEmpty(SawSelfEke.instance.LagoonHave.adjust_init_act_position) || _PrudentIdeal == int.Parse(SawSelfEke.instance.LagoonHave.adjust_init_act_position))
        {
            ThenShrimpNoGap(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void BurToIdeal(string countryCode, double revenue)
    {
#if UNITY_IOS
            return;
#endif
        //if (LuckHaveMimetic.GetString(sv_ADJustInitType) != "") return;

        _PrudentIdeal++;
        _PrudentSwiftly += revenue;
        print(" Ads count: " + _PrudentIdeal + ", Revenue sum: " + _PrudentSwiftly);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(SawSelfEke.instance.LagoonHave.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(SawSelfEke.instance.LagoonHave.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                StrictBullToSwiftly = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(SawSelfEke.instance.LagoonHave.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_PrudentIdeal == int.Parse(SawSelfEke.instance.LagoonHave.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _PrudentSwiftly >= StrictBullToSwiftly)
        )
        {
            ThenShrimpNoGap();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void ThenShrimpNoGap(string param2 = "")
    {
        if (LuckHaveMimetic.PenAcross(No_ADWolfBullSpur) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(SawSelfEke.instance.LagoonHave.adjust_init_rate_act) || int.Parse(SawSelfEke.instance.LagoonHave.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            LuckHaveMimetic.LayAcross(No_ADWolfBullSpur, AdjustStatus.OpenAsAct.ToString());
            ShrimpBull();

            // 上报点位 新用户达成 且 初始化
            SlayNeverSpiral.PenMonopoly().JumpNever("1091", PenShrimpQuit(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            LuckHaveMimetic.LayAcross(No_ADWolfBullSpur, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            SlayNeverSpiral.PenMonopoly().JumpNever("1092", PenShrimpQuit(), param2);
        }
    }

    
    /*
     * API
     *  重置当前次数
     */
    public void AlloyGapIdeal()
    {
        print("clear current ");
        _PrudentIdeal = 0;
    }


    // 获取启动时间
    private string PenShrimpQuit()
    {
        return LoopFile.Someone() - long.Parse(LuckHaveMimetic.PenAcross(No_ADWolfQuit)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}