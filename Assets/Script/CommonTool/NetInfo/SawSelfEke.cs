/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
//using MoreMountains.NiceVibrations;

public class SawSelfEke : MonoBehaviour
{

    public static SawSelfEke instance;
[UnityEngine.Serialization.FormerlySerializedAs("BlockRule")]
    public BlockRuleData EnterNose;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string HaveFish; //数据来源 打点用
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string FormTop;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string FormChafeTop;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string FormLagoonTop;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string FormQuitTop;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string FormShrimpTop;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string OilyDime= "20000";
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]
    //channel渠道平台
#if UNITY_IOS
    public string Flatter= "AppStore";
#elif UNITY_ANDROID
    public string Channel = "GooglePlay";
#else
    public string Channel = "Other";
#endif
    //工程包名
    private string OceaniaBear{ get { return Application.identifier; } }
    //登录url
    private string ChafeTop= "";
    //配置url
    private string ConfigTop= "";
    //更新AdjustId url
    private string ShrimpTop= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Ecology= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData LagoonHave;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init BullHave;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    public Game_Data OilyHave;
[UnityEngine.Serialization.FormerlySerializedAs("LevelList")]    public LevelConfigInfo ClumpPlug;
[UnityEngine.Serialization.FormerlySerializedAs("ChallengeList")]    public ChallengeElementData AdmissionPlug;
[UnityEngine.Serialization.FormerlySerializedAs("TaskData")]    public Task_Data HurtHave;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADMimetic
    public GameObject AtMimetic;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Five;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Any;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Toil;
    int Visit_Chair= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Visit= false;
[UnityEngine.Serialization.FormerlySerializedAs("CashOut_Data")]
    //提现相关后台数据
    public CashOutData TuskShy_Have;

    //ios 获取idfa函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif
    void Awake()
    {
        instance = this;
        ChafeTop = FormChafeTop + OilyDime + "&channel=" + Flatter + "&version=" + Application.version;
        ConfigTop = FormLagoonTop + OilyDime + "&channel=" + Flatter + "&version=" + Application.version;
        ShrimpTop = FormShrimpTop + OilyDime;
    }
    private void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            //Login();
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            LuckHaveMimetic.LayAcross("idfv", idfv);
#endif
        }
        else
        {
            Chafe();           //编辑器登录
        }
        //获取config数据
        PenLagoonHave();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Five = gaid_str; 
        if (Five == null || Five == "")
        {
            Five = LuckHaveMimetic.PenAcross("gaid");
        }
        else
        {
            LuckHaveMimetic.LayAcross("gaid", Five);
        }
        Visit_Chair++;
        if (Visit_Chair == 2)
        {
            Chafe();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Any = aid_str;
        if (Any == null || Any == "")
        {
            Any = LuckHaveMimetic.PenAcross("aid");
        }
        else
        {
            LuckHaveMimetic.LayAcross("aid", Any);
        }
        Visit_Chair++;
        if (Visit_Chair == 2)
        {
            Chafe();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        Toil = message;
        LuckHaveMimetic.LayAcross("idfa", Toil);
        Chafe();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Toil = LuckHaveMimetic.PenAcross("idfa");
        Chafe();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Chafe()
    {
        //提现登录
        CashOutManager.PenMonopoly().Login();
        //获取本地缓存的Local用户ID
        string localId = LuckHaveMimetic.PenAcross(CLagoon.No_TimidTactOf);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            LuckHaveMimetic.LayAcross(CLagoon.No_TimidTactOf, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = ChafeTop + "&" + "randomKey" + "=" + localId + "&idfa=" + Toil + "&packageName=" + OceaniaBear;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = ChafeTop + "&" + "randomKey" + "=" + localId + "&gaid=" + Five + "&androidId=" + Any + "&packageName=" + OceaniaBear;
        }
        else //编辑器
        {
            url = ChafeTop + "&" + "randomKey" + "=" + localId + "&packageName=" + OceaniaBear;
        }

        //获取国家信息
        PenEmpathy(() => {
            url += "&country=" + Ecology;
            //登录请求
            SawBreaMimetic.PenMonopoly().BothPen(url,
                (data) => {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    LuckHaveMimetic.LayAcross("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    LuckHaveMimetic.LayAcross(CLagoon.No_TimidRegimeOf, serverUserData.data.ToString());

                    JumpShrimpPale();
                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(TemperFile.ClueYam))
                        TemperFile.JumpNever();
                },
                () => {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void PenEmpathy(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Ecology))
        {
            SawBreaMimetic.PenMonopoly().BothPen("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Ecology = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Ecology);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
                if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(TemperFile.ClueYam))
                    TemperFile.JumpNever();
            },
            () => {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Ecology = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void PenLagoonHave()
    {
        Debug.Log("GetConfigData:" + ConfigTop);

        //获取并存入Config
        SawBreaMimetic.PenMonopoly().BothPen(ConfigTop,
        (data) => {
            HaveFish = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            LuckHaveMimetic.LayAcross("OnlineData", data.downloadHandler.text);
            LayLagoonHave(data.downloadHandler.text);
        },
        () => {
            Debug.Log("ConfigData 失败");
            PenComputerHave();
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void PenComputerHave()
    {
        //是否有缓存
        if (LuckHaveMimetic.PenAcross("OnlineData") == "" || LuckHaveMimetic.PenAcross("OnlineData").Length == 0)
        {
            HaveFish = "LocalData_Updated"; //已联网更新过的数据
            Debug.Log("本地数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            LayLagoonHave(json.text);
        }
        else
        {
            HaveFish = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            LayLagoonHave(LuckHaveMimetic.PenAcross("OnlineData"));
        }
    }


    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void LayLagoonHave(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (LagoonHave == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            LagoonHave = rootData.data;

            switch (LuckHaveMimetic.PenAcross(CLagoon.Gin_Nystatin))
            {
                case "Russian":
                    BullHave = JsonMapper.ToObject<Init>(LagoonHave.init_ru);
                    HurtHave = JsonMapper.ToObject<Task_Data>(LagoonHave.task_data_ru);
                    break;
                case "Portuguese (Brazil)":
                    BullHave = JsonMapper.ToObject<Init>(LagoonHave.init_br);
                    HurtHave = JsonMapper.ToObject<Task_Data>(LagoonHave.task_data_br);
                    break;
                case "Japanese":
                    BullHave = JsonMapper.ToObject<Init>(LagoonHave.init_jp);
                    HurtHave = JsonMapper.ToObject<Task_Data>(LagoonHave.task_data_jp);
                    break;
                case "English":
                    BullHave = JsonMapper.ToObject<Init>(LagoonHave.init_us);
                    HurtHave = JsonMapper.ToObject<Task_Data>(LagoonHave.task_data_us);
                    break;
                default:
                    BullHave = JsonMapper.ToObject<Init>(LagoonHave.init);
                    HurtHave = JsonMapper.ToObject<Task_Data>(LagoonHave.task_data);
                    break;
            }
            OilyHave = JsonMapper.ToObject<Game_Data>(LagoonHave.game_data);
            TuskShy_Have = JsonMapper.ToObject<CashOutData>(LagoonHave.CashOut_Data);
            ClumpPlug = JsonMapper.ToObject<LevelConfigInfo>(LagoonHave.level_change);
            AdmissionPlug = JsonMapper.ToObject<ChallengeElementData>(LagoonHave.challenge_num);
            if (!string.IsNullOrEmpty(LagoonHave.BlockRule))
                EnterNose = JsonMapper.ToObject<BlockRuleData>(LagoonHave.BlockRule);
            if (!string.IsNullOrEmpty(LagoonHave.CashOut_Data))
                TuskShy_Have = JsonMapper.ToObject<CashOutData>(LagoonHave.CashOut_Data);
            PenTactSelf();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void OilyBleak()
    {
        //打开admanager
        // AtMimetic.SetActive(true);
        //进度条可以继续
        Visit = true;
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]
    //获取用户信息
    public string TactHaveBuy= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData TactHave;
    int PenTactSelfIdeal= 0;
    void PenTactSelf()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            OilyBleak();
            return;
        }


        //检查归因渠道信息
        //CheckAdjustNetwork();
        //获取用户信息
        string CheckUrl = FormTop + "/api/client/user/checkUser";
        SawBreaMimetic.PenMonopoly().BothPen(CheckUrl,
        (data) =>
        {
            TactHaveBuy = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + TactHaveBuy);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(TactHaveBuy);
            TactHave = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (TactHaveBuy.Contains("apple")
            || TactHaveBuy.Contains("Apple")
            || TactHaveBuy.Contains("APPLE"))
                TactHave.IsHaveApple = true;
            OilyBleak();
        }, () => { });
        Invoke(nameof(RePenTactSelf), 1);
    }
    void RePenTactSelf()
    {
        if (!Visit)
        {
            PenTactSelfIdeal++;
            if (PenTactSelfIdeal < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + PenTactSelfIdeal);
                PenTactSelf();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                OilyBleak();
            }
        }
    }


    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void JumpShrimpPale()
    {
        string serverId = LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf);
        string adjustId = ShrimpBullMimetic.Instance.PenShrimpPale();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = ShrimpTop + "&serverId=" + serverId + "&adid=" + adjustId;
        SawBreaMimetic.PenMonopoly().BothPen(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
        CashOutManager.PenMonopoly().ReportAdjustID();
    }
}
