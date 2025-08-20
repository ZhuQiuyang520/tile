using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class FormUIBasin : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("_CurrentUIType")]    //当前（基类）窗口的类型
    public UISpur _SomeoneUISpur= new UISpur();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Build_Fright;
    //属性，当前ui窗体类型
    internal UISpur SomeoneUISpur    {
        set
        {
            _SomeoneUISpur = value;
        }
        get
        {
            return _SomeoneUISpur;
        }
    }
    protected virtual void Awake()
    {
        SourSweepBurSurrender(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Build_Fright = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Build_Fright.onClick.AddListener(() => {
                UIMimetic.PenMonopoly().HatchMeBioticUIBasin(this.GetType().Name);
            });
        }
        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }


    public static void SourSweepBurSurrender(GameObject goParent)
    {
        Transform parent = goParent.transform;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = parent.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() => {

                    WhaleEke.PenMonopoly().JuneOxygen(WhaleSpur.UIMusic.Sound_UIButton);
                });
            }
            
            if (chile.childCount > 0)
            {
                SourSweepBurSurrender(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display(object uiFormParams)
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp && _SomeoneUISpur.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UILimeEke.PenMonopoly().LayLimeInsist(this.gameObject, _SomeoneUISpur.UIForm_LucencyType);
        }
        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_SomeoneUISpur.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    ConestogaAssumption.YewBlue(gameObject, () =>
                    {

                    });
                    break;

            }
            
        }
        if (uiFormParams != null)
        {
            OnMessageReceived(uiFormParams);
        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        //{
        //    UILimeEke.GetInstance().HideMaskWindow();
        //}

        //取消模态窗体调用

        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
        {
            switch (_SomeoneUISpur.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    ConestogaAssumption.YewUtah(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp && _SomeoneUISpur.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UILimeEke.PenMonopoly().SnuglyLimeInsist();
                        }
                        UIMimetic.PenMonopoly().BlueRichYewOf();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp && _SomeoneUISpur.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UILimeEke.PenMonopoly().SnuglyLimeInsist();
                    }
                    UIMimetic.PenMonopoly().BlueRichYewOf();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
            //{
            //    UILimeEke.GetInstance().CancelMaskWindow();
            //}
            finish?.Invoke();
        }
    }

    protected virtual void OnMessageReceived(object uiFormParams)
    {

    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_SomeoneUISpur.UIForms_Type == UIFormType.PopUp)
        {
            UILimeEke.PenMonopoly().LayLimeInsist(this.gameObject, _SomeoneUISpur.UIForm_LucencyType); 
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Evolve()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void MinistrySpeedyReliefNever(string buttonName,NeverProdigyInherent.VoidDelegate delHandle)
    {
        GameObject goButton = LunchRemove.SourDogSweepEast(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            NeverProdigyInherent.Pen(goButton).onGuess = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="uiFormName"></param>
    protected void PearUIWork(string uiFormName)
    {
        UIMimetic.PenMonopoly().BlueUIBasin(uiFormName);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void HatchUIWork(string uiFormName)
    {
        //处理后的uiform名称
        UIMimetic.PenMonopoly().HatchMeBioticUIBasin(uiFormName);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void JumpDeviate(string msgType,string msgName,object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        DeviateDinner.JumpDeviate(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void BarrierDeviate(string messageType,DeviateDinner.DelMessageDelivery handler)
    {
        DeviateDinner.BurRawInherent(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Blue(string id)
    {
        string strResult = string.Empty;
        strResult = DislodgeEke.PenMonopoly().BlueEdit(id);
        return strResult;
    }
}
