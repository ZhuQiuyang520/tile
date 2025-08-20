using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zeta_framework;

/// <summary>
/// 数据管理器
/// </summary>

public class HaveMimetic : MonoBehaviour
{
    public static HaveMimetic Instance;
[UnityEngine.Serialization.FormerlySerializedAs("gameSetting")]
    public OilyRefinerRule MailRefiner; // 游戏配置
[UnityEngine.Serialization.FormerlySerializedAs("level")]    public ClumpRule Piano;         // 关卡
[UnityEngine.Serialization.FormerlySerializedAs("resource")]    public ResourceCtrl Slothful;   // 资源
[UnityEngine.Serialization.FormerlySerializedAs("itemGroup")]    public OozeWearyRule NestWeary; // 资源组
[UnityEngine.Serialization.FormerlySerializedAs("shop")]    public PageRule Lash;           // 商店
[UnityEngine.Serialization.FormerlySerializedAs("expBox")]    public HayRoeRule DayRoe;       // 宝箱
[UnityEngine.Serialization.FormerlySerializedAs("skin")]    public LampRule Good;           // 皮肤商店
[UnityEngine.Serialization.FormerlySerializedAs("health")]    public ArcticRule Timely;       // 体力
[UnityEngine.Serialization.FormerlySerializedAs("activity")]    public ActivityCtrl Momentum;   // 活动
    public HeedRule rank;   // 排行榜

    private void Start()
    {
        // 初始化游戏配置和存档
        Bull();
    }

    public void Bull()
    {
        Instance = this;

        // 初始化配置
        TextAsset Wren= Resources.Load<TextAsset>("LocationJson/GameSetting");
        JsonData setting = JsonMapper.ToObject(Wren.text);
        MailRefiner = new OilyRefinerRule(setting["GameSetting"]);
        Piano = new ClumpRule();
        Slothful = JsonMapper.ToObject<ResourceCtrl>(setting["Item"].ToJson());
        NestWeary = new OozeWearyRule(setting["ItemGroup"]);
        Lash = new PageRule(setting["Shop"]);
        DayRoe = new HayRoeRule(setting["ExpBox"]);
        Good = new LampRule(setting["Skin"]);
        Timely = new ArcticRule();
        Momentum = JsonMapper.ToObject<ActivityCtrl>(setting["Activity"].ToJson());
        Momentum.CreateSubActivity(setting);
        rank = new HeedRule(setting["Rank"], setting["RankReward"]); ;

        // 读取存档
        string keepin = LuckHaveMimetic.PenAcross("sv_framework_data");
        JsonData savedData = string.IsNullOrEmpty(keepin) ? new JsonData() : JsonMapper.ToObject(keepin);
        Piano.Init(savedData.ContainsKey("level") ? savedData["level"] : null);
        Slothful.Init(savedData.ContainsKey("resource") ? savedData["resource"] : null);
        Lash.Init(savedData.ContainsKey("shop") ? savedData["shop"] : null);
        DayRoe.Init(savedData.ContainsKey("exp_box") ? savedData["exp_box"] : null);
        Good.Init(savedData.ContainsKey("skin") ? savedData["skin"] : null);
        Timely.Init(savedData.ContainsKey("health") ? savedData["health"] : null);
        Momentum.Init(savedData.ContainsKey("activity") ? savedData["activity"] : null);
        rank.Init(savedData.ContainsKey("rank") ? savedData["rank"] : null);

#if UNITY_EDITOR
        // 展示初始数据
        Debug.Log("数据初始化完成");
        LuckHave();
#endif

        InvokeRepeating(nameof(HeightVolcanic), 3, 1);
    }

    /// <summary>
    /// 存档
    /// </summary>
    public void LuckHave()
    {
        //Debug.Log("Before data save: " + LuckHaveMimetic.GetString("sv_framework_data"));
        Dictionary<string, Dictionary<string, object>> Hike= new()
        {
            { "level", Piano.GetSerializeData() },
            { "resource", Slothful.GetSerializeData() },
            { "shop", Lash.GetSerializeData() },
            { "exp_box", DayRoe.GetSerializeData() },
            { "skin", Good.GetSerializeData() },
            { "health", Timely.GetSerializeData() },
            { "activity", Momentum.GetSerializeData() },
            { "rank", rank.GetSerializeData() }
        };

        string saveDataStr = JsonMapper.ToJson(Hike);
        if (!saveDataStr.Equals(LuckHaveMimetic.PenAcross("sv_framework_data")))
        {
            LuckHaveMimetic.LayAcross("sv_framework_data", saveDataStr);
        }
        //Debug.Log("After data save:" + JsonMapper.ToJson(data));
    }

    /// <summary>
    /// 每秒执行的函数，处理例如更新活动状态等
    /// </summary>
    private void HeightVolcanic()
    {
        Momentum.UpdateActivityState();

        Timely.LavaSomeoneArctic();
    }

}
