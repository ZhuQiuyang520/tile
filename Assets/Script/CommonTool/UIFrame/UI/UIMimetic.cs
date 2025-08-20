/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIMimetic : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas VentBuffer;
    private static UIMimetic _Monopoly= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _CutBasinBrain;
    //缓存所有的ui窗体
    private Dictionary<string, FormUIBasin> _CutALLUIBasin;
    //栈结构标识当前ui窗体的集合
    private Stack<FormUIBasin> _StaSomeoneUIBasin;
    //当前显示的ui窗体
    private Dictionary<string, FormUIBasin> _CutSomeoneBlueUIBasin;
    //临时关闭窗口
    private List<UIFormParams> _WaitUIBasin;
    //ui根节点
    private Transform _KeyBufferTreasurer= null;
    //全屏幕显示的节点
    private Transform _KeyExpert= null;
    //固定显示的节点
    private Transform _KeyShock= null;
    //弹出节点
    private Transform _KeyPopOf= null;
    //ui特效节点
    private Transform _Wax= null;
    //ui管理脚本的节点
    private Transform _KeyUIExclude= null;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("_TraUICamera")]    public Transform _KeyUICarpet= null;
    public Camera UICarpet{ get; private set; }
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string ToxicBear;
    List<string> ToxicBearPlug;
    public List<UIFormParams> WaitUIBasin    {
        get
        {
            return _WaitUIBasin;
        }
    }
    //得到实例
    public static UIMimetic PenMonopoly()
    {
        if (_Monopoly == null)
        {
            _Monopoly = new GameObject("_UIManager").AddComponent<UIMimetic>();
            
        }
        return _Monopoly;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        ToxicBearPlug = new List<string>();
        //字段初始化
        _CutALLUIBasin = new Dictionary<string, FormUIBasin>();
        _CutSomeoneBlueUIBasin = new Dictionary<string, FormUIBasin>();
        _WaitUIBasin = new List<UIFormParams>();
        _CutBasinBrain = new Dictionary<string, string>();
        _StaSomeoneUIBasin = new Stack<FormUIBasin>();
        //初始化加载（根ui窗体）canvas预设
        BullStagBufferNovelty();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _KeyBufferTreasurer = GameObject.FindGameObjectWithTag(PigSector.SYS_TAG_CANVAS).transform;
        _KeyExpert = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject,PigSector.SYS_NORMAL_NODE);
        _KeyShock = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject, PigSector.SYS_FIXED_NODE);
        _KeyPopOf = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject,PigSector.SYS_POPUP_NODE);
        _Wax = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject, PigSector.SYS_TOP_NODE);
        _KeyUIExclude = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject,PigSector.SYS_SCRIPTMANAGER_NODE);
        _KeyUICarpet = LunchRemove.SourDogSweepEast(_KeyBufferTreasurer.gameObject, PigSector.SYS_UICAMERA_NODE);
        //把本脚本作为“根ui窗体”的子节点
        LunchRemove.BurSweepEastMyGlassyEast(_KeyUIExclude, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_KeyBufferTreasurer);
        //初始化ui窗体预设路径数据
        BullUIBasinBrainHave();
        //初始化UI相机参数，主要是解决URP管线下UI相机的问题
        BullCarpet();
    }
    private void BurToxic(string name)
    {
        if (!ToxicBearPlug.Contains(name))
        {
            ToxicBearPlug.Add(name);
            ToxicBear = name;
        }
    }
    private void SubToxic(string name)
    {
        if (ToxicBearPlug.Contains(name))
        {
            ToxicBearPlug.Remove(name);
        }
        if (ToxicBearPlug.Count == 0)
        {
            ToxicBear = "";
        }
        else
        {
            ToxicBear = ToxicBearPlug[0];
        }
    }
    //初始化加载（根ui窗体）canvas预设
    private void BullStagBufferNovelty()
    {
        VentBuffer = ExistenceEke.PenMonopoly().ThenAgain(PigSector.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="uiFormName">ui窗体预设的名称</param>
    public GameObject BlueUIBasin(string uiFormName, object uiFormParams = null)
    {
        //参数的检查
        if (string.IsNullOrEmpty(uiFormName)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        FormUIBasin baseUIForms = ThenBasinMyALLUIBasinTrove(uiFormName);
        if (baseUIForms == null) return null;

        BurToxic(uiFormName);
        
        //判断是否清空“栈”结构体集合
        if (baseUIForms.SomeoneUISpur.WeFlakeMachineDampen)
        {
            FlakeStoryCarol();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.SomeoneUISpur.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                IglooUIBasinComer(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.ReverseChange:
                LureUIBasin(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.HideOther:
                IglooUIEitherMyComerUtahCuban(uiFormName, uiFormParams);
                break;
            case UIFormShowMode.Wait:
                IglooUIBasinComerTrayHatch(uiFormName, uiFormParams);
                break;
            default:
                break;
        }
        return baseUIForms.gameObject;
    }

    //关闭所有UI界面
    public void FlakeIceUI()
    {
        foreach (var panel in PenRoadbedResist(true))
        {
            HatchMeBioticUIBasin(panel.name);
        }
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void HatchMeBioticUIBasin(string strUIFormsName)
    {
        SubToxic(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        FormUIBasin baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _CutALLUIBasin.TryGetValue(strUIFormsName,out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.SomeoneUISpur.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                YarnUIBasinComer(strUIFormsName);
                break;
            
            case UIFormShowMode.ReverseChange:
                YewUIBasin();
                break;
            case UIFormShowMode.HideOther:
                YarnUIBasinFishComerEatBlueCuban(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                YarnUIBasinComer(strUIFormsName);
                break;
            default:
                break;
        }
        
    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void BlueRichYewOf()
    {
        if (_WaitUIBasin.Count > 0)
        {
            BlueUIBasin(_WaitUIBasin[0].ByWorkBear, _WaitUIBasin[0].ByWorkAboard);
            _WaitUIBasin.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void FlakeTrayUIBasin()
    {
        if (_WaitUIBasin.Count > 0)
        {
            _WaitUIBasin = new List<UIFormParams>();
        }
    }
     /// <summary>
     /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
      /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
      /// </summary>
      /// <param name="uiFormsName">UI窗体（预设）的名称</param>
      /// <returns></returns>
    private FormUIBasin ThenBasinMyALLUIBasinTrove(string uiFormName)
    {
        //加载的返回ui窗体基类
        FormUIBasin baseUIResult = null;
        _CutALLUIBasin.TryGetValue(uiFormName, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = ThenUIWork(uiFormName);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="uiFormName">UI窗体名称</param>
    private FormUIBasin ThenUIWork(string uiFormName)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        FormUIBasin baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _CutBasinBrain.TryGetValue(uiFormName, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
           goCloneUIPrefabs= ExistenceEke.PenMonopoly().ThenAgain(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if(_KeyBufferTreasurer!=null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<FormUIBasin>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName="+uiFormName);
                return null;
            }
            switch (baseUIForm.SomeoneUISpur.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_KeyExpert, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_KeyShock, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_KeyPopOf, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Wax, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _CutALLUIBasin.Add(uiFormName, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数uiFormName=" + uiFormName);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 uiFormName=" + uiFormName);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void IglooUIBasinComer(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        FormUIBasin baseUIForm;
        //从所有窗体集合中得到的窗体
        FormUIBasin baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _CutSomeoneBlueUIBasin.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _CutALLUIBasin.TryGetValue(uiFormName, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _CutSomeoneBlueUIBasin.Add(uiFormName, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display(uiFormParams);
            
        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void YarnUIBasinComer(string strUIFormsName)
    {
        //ui窗体基类
        FormUIBasin baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _CutSomeoneBlueUIBasin.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _CutSomeoneBlueUIBasin.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void IglooUIEitherMyComerUtahCuban(string strUIFormsName, object uiFormParams)
    {
        //窗体基类
        FormUIBasin baseUIForms;
        //所有窗体集合中的窗体基类
        FormUIBasin baseUIFormsFromAllCache;
        _CutSomeoneBlueUIBasin.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<FormUIBasin> ShowUIFormsList = new List<FormUIBasin>(_CutSomeoneBlueUIBasin.Values);
        foreach (FormUIBasin baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                YarnUIBasinFishComerEatBlueCuban(baseUIFormsItem.GetType().Name);
            }
        }
        List<FormUIBasin> CurrentUIFormsList = new List<FormUIBasin>(_StaSomeoneUIBasin);
        foreach (FormUIBasin baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            YarnUIBasinFishComerEatBlueCuban(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _CutALLUIBasin.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _CutSomeoneBlueUIBasin.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display(uiFormParams);
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="uiFormName">窗体预设的名字</param>
    private void IglooUIBasinComerTrayHatch(string uiFormName, object uiFormParams)
    {
        //ui窗体基类
        FormUIBasin baseUIForm;
        //从所有窗体集合中得到的窗体
        FormUIBasin baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _CutSomeoneBlueUIBasin.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (FormUIBasin uiforms in _CutSomeoneBlueUIBasin.Values)
        {
            if (uiforms.SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _CutALLUIBasin.TryGetValue(uiFormName, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _CutSomeoneBlueUIBasin.Add(uiFormName, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display(uiFormParams);

            }
        }
        else
        {
            _WaitUIBasin.Add(new UIFormParams() { ByWorkBear = uiFormName, ByWorkAboard = uiFormParams });
        }
        
    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void YarnUIBasinFishComerEatBlueCuban(string strUIFormsName)
    {
        //ui窗体基类
        FormUIBasin baseUIForms;
        _CutSomeoneBlueUIBasin.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _CutSomeoneBlueUIBasin.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (FormUIBasin baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (FormUIBasin baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void LureUIBasin(string strUIFormsName, object uiFormParams)
    {
        //ui预设窗体
        FormUIBasin baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_StaSomeoneUIBasin.Count > 0)
        {
            FormUIBasin topUIForms = _StaSomeoneUIBasin.Peek();
            topUIForms.Evolve();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _CutALLUIBasin.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display(uiFormParams);
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _StaSomeoneUIBasin.Push(baseUI);
       
    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void YewUIBasin()
    {

        if (_StaSomeoneUIBasin.Count >= 2)
        {
            //出栈逻辑
            FormUIBasin topUIForms = _StaSomeoneUIBasin.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() => {
                //出栈窗体的下一个窗体逻辑
                FormUIBasin nextUIForms = _StaSomeoneUIBasin.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_StaSomeoneUIBasin.Count == 1)
        {
            FormUIBasin topUIForms = _StaSomeoneUIBasin.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void BullUIBasinBrainHave()
    {
        ILagoonMimetic configMgr = new LagoonMimeticOnJean(PigSector.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_CutBasinBrain != null)
        {
            _CutBasinBrain = configMgr.FinRefiner;
        }
    }

    /// <summary>
    /// 初始化UI相机参数
    /// </summary>
    private void BullCarpet()
    {
        //当渲染管线为URP时，将UI相机的渲染方式改为Overlay，并加入主相机堆栈
        RenderPipelineAsset currentPipeline = GraphicsSettings.renderPipelineAsset;
        if (currentPipeline != null && currentPipeline.name == "UniversalRenderPipelineAsset")
        {
            UICarpet = _KeyUICarpet.GetComponent<Camera>();
            UICarpet.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_KeyUICarpet.GetComponent<Camera>());
        }
        _KeyUICarpet.GetComponent<Camera>().orthographicSize = 0.5f;    //兼容新框架
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool FlakeStoryCarol()
    {
        if(_StaSomeoneUIBasin!=null && _StaSomeoneUIBasin.Count >= 1)
        {
            _StaSomeoneUIBasin.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<FormUIBasin> PenSomeoneWorkStory()
    {
        return _StaSomeoneUIBasin;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="uiFormName"></param>
    /// <returns></returns>
    public GameObject PenToxicOnBear(string uiFormName)
    {
        //ui窗体基类
        FormUIBasin baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _CutALLUIBasin.TryGetValue(uiFormName, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> PenRoadbedResist(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<FormUIBasin> allUIFormsList = new List<FormUIBasin>(_CutALLUIBasin.Values);
        foreach(FormUIBasin panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._SomeoneUISpur.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
}

public class UIFormParams
{
    public string ByWorkBear;   // 窗体名称
    public object ByWorkAboard; // 窗体参数
}
