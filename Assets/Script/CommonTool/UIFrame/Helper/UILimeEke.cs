/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILimeEke : MonoBehaviour
{
    private static UILimeEke _Monopoly= null;
    //ui根节点对象
    private GameObject _GoBufferStag= null;
    //ui脚本节点对象
    private Transform _KeyUIExcludeEast= null;
    //顶层面板
    private GameObject _WeMyToxic;
    //遮罩面板
    private GameObject _WeLimeToxic;
    //ui摄像机
    private Camera _UICarpet;
    //ui摄像机原始的层深
    private float _ProspectUICarpetWidth;
    //获取实例
    public static UILimeEke PenMonopoly()
    {
        if (_Monopoly == null)
        {
            _Monopoly = new GameObject("_UIMaskMgr").AddComponent<UILimeEke>();
        }
        return _Monopoly;
    }
    private void Awake()
    {
        _GoBufferStag = GameObject.FindGameObjectWithTag(PigSector.SYS_TAG_CANVAS);
        _KeyUIExcludeEast = LunchRemove.SourDogSweepEast(_GoBufferStag, PigSector.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        LunchRemove.BurSweepEastMyGlassyEast(_KeyUIExcludeEast, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _WeMyToxic = _GoBufferStag;
        _WeLimeToxic = LunchRemove.SourDogSweepEast(_GoBufferStag, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UICarpet = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UICarpet != null)
        {
            //得到ui相机原始的层深
            _ProspectUICarpetWidth = _UICarpet.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void LayLimeInsist(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _WeMyToxic.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _WeLimeToxic.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _WeLimeToxic.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _WeLimeToxic.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _WeLimeToxic.GetComponent<Image>().color = newColor2;
                DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_InsistPear);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _WeLimeToxic.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _WeLimeToxic.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_WeLimeToxic.activeInHierarchy)
                {
                    _WeLimeToxic.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _WeLimeToxic.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UICarpet != null)
        {
            _UICarpet.depth = _UICarpet.depth + 100;
        }
    }
    public void UtahLimeInsist()
    {
        if (UIMimetic.PenMonopoly().WaitUIBasin.Count > 0 || UIMimetic.PenMonopoly().PenSomeoneWorkStory().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_WeLimeToxic.GetComponent<Image>().color.r, _WeLimeToxic.GetComponent<Image>().color.g, _WeLimeToxic.GetComponent<Image>().color.b,0);
        _WeLimeToxic.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void SnuglyLimeInsist()
    {
        if (UIMimetic.PenMonopoly().WaitUIBasin.Count > 0 || UIMimetic.PenMonopoly().PenSomeoneWorkStory().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIMimetic.PenMonopoly().PenRoadbedResist(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<FormUIBasin>();
            if (baseUIForm != null && baseUIForm.SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _WeLimeToxic.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _WeMyToxic.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_WeLimeToxic.activeInHierarchy)
            {
                _WeLimeToxic.SetActive(false);
                DeviateCenterChurn.PenMonopoly().Jump(CLagoon.Ox_InsistHatch);
            }
            //恢复当前ui摄像机的层深
            if (_UICarpet != null)
            {
                _UICarpet.depth = _ProspectUICarpetWidth;
            }
        }
    }
}
