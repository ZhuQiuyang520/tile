using System;
using System.Collections.Generic;
using UnityEngine;

public class AUIModule : ASingletonBehaviour<AUIModule>
{
    public Camera UICamera;
    public Canvas UICanvas;
    public Transform BottomLayer;
    public Transform UILayer;
    public Transform TopLayer;
    public Transform TipsLayer;
    public Transform SystemLayer;
    
    private List<AUIWindow> _uiStack;
    private string uiPathPre = "AGame/Prefabs/UIPanel/";
    
    public const int WINDOW_HIDE_LAYER = 2; // Ignore Raycast
    public const int WINDOW_SHOW_LAYER = 5; // UI

    protected override void OnLoad()
    {
        base.OnLoad();
        ADebug.Log("UI模块初始化");
        _uiStack = new List<AUIWindow>();
    }

    public AUIWindow ShowUI(Type type, params System.Object[] userDatas)
    {
        return ShowUIImp(type, userDatas);
    }

    private AUIWindow ShowUIImp(Type type, params System.Object[] userDatas)
    {
        var windowName = type.FullName;
        if (!TryGetWindow(windowName, out AUIWindow window, userDatas))
        {
            window = CreateInstance(type);
            window.Init(windowName, userDatas);
            Push(window); //首次压入
            window.OnCreate();
            window.OnRefresh();
            OnSetWindowVisible();
        }
        return window;
    }

    public AUIWindow ShowUI<T>(params System.Object[] userDatas) where T : AUIWindow, new()
    {
        Type type = typeof(T);
        return ShowUIImp(type, userDatas);
    }

    /// <summary>
    /// 关闭窗口。
    /// </summary>
    /// <typeparam name="T">窗口类型</typeparam>
    public void CloseUI<T>() where T : AUIWindow
    {
        CloseUI(typeof(T));
    }
    
    public void CloseUI(Type type)
    {
        string windowName = type.FullName;
        var window = GetWindow(windowName);
        if (window == null)
            return;
        
        window.OnClose();
        Pop(window);
        Destroy(window.gameObject);
        OnSetWindowVisible();
    }
    
    private bool TryGetWindow(string windowName,out AUIWindow window, params System.Object[] userDatas)
    {
        window = null;
        if (IsContains(windowName))
        {
            window = GetWindow(windowName);
            window.Init(windowName, userDatas);
            Pop(window); //弹出窗口
            Push(window); //重新压入
            // window.OnCreate();
            window.OnRefresh();
            OnSetWindowVisible();
            return true;
        }
        return false;
    }
    
    private AUIWindow GetWindow(string windowName)
    {
        for (int i = 0; i < _uiStack.Count; i++)
        {
            AUIWindow window = _uiStack[i];
            if (window.WindowName == windowName)
            {
                return window;
            }
        }

        return null;
    }

    private AUIWindow CreateInstance(Type type)
    {
        var prefab = Resources.Load<GameObject>(uiPathPre + type.FullName);
        if (prefab == null)
        {
            ADebug.LogError($"未找到UI {uiPathPre}{type.FullName}");
            return null;
        }
        var go = GameObject.Instantiate(prefab);
        var window = go.GetComponent<AUIWindow>();
        if (window == null)
        {
            throw new Exception($"UI {uiPathPre}{type.FullName} 没有 AUIWindow 组件");
        }

        return window;
    }

    private void Push(AUIWindow window)
    {
        // 如果已经存在
        if (IsContains(window.WindowName))
        {
            throw new Exception($"Window {window.WindowName} is exist.");
        }
        switch (window.WindowLayer)
        {
            case AUILayer.Bottom:
                window.transform.SetParent(BottomLayer, false);
                break;
            case AUILayer.UI:
                window.transform.SetParent(UILayer, false);
                break;
            case AUILayer.Top:
                window.transform.SetParent(TopLayer, false);
                break;
            case AUILayer.Tips:
                window.transform.SetParent(TipsLayer, false);
                break;
            case AUILayer.System:
                window.transform.SetParent(SystemLayer, false);
                break;
            default:
                ADebug.LogError($"UI {uiPathPre}{window.WindowName} 没有设置 Layer");
                return;
        }
        window.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        window.transform.localScale = Vector3.one;
        window.transform.SetAsLastSibling();
        window.gameObject.SetActive(true);
        
        // 获取插入到所属层级的位置
        int insertIndex = -1;
        for (int i = 0; i < _uiStack.Count; i++)
        {
            if (window.WindowLayer == _uiStack[i].WindowLayer)
            {
                insertIndex = i + 1;
            }
        }

        // 如果没有所属层级，找到相邻层级
        if (insertIndex == -1)
        {
            for (int i = 0; i < _uiStack.Count; i++)
            {
                if (window.WindowLayer > _uiStack[i].WindowLayer)
                {
                    insertIndex = i + 1;
                }
            }
        }

        // 如果是空栈或没有找到插入位置
        if (insertIndex == -1)
        {
            insertIndex = 0;
        }

        // 最后插入到堆栈
        _uiStack.Insert(insertIndex, window);
    }
    
    private void Pop(AUIWindow window)
    {
        // 从堆栈里移除
        _uiStack.Remove(window);
    }
    
    private bool IsContains(string windowName)
    {
        for (int i = 0; i < _uiStack.Count; i++)
        {
            AUIWindow window = _uiStack[i];
            if (window.WindowName == windowName)
            {
                return true;
            }
        }

        return false;
    }
    
    private void OnSetWindowVisible()
    {
        bool isHideNext = false;
        for (int i = _uiStack.Count - 1; i >= 0; i--)
        {
            AUIWindow window = _uiStack[i];
            if (isHideNext == false)
            {
                window.Visible = true;
                if (window.FullScreen)
                {
                    isHideNext = true;
                }
            }
            else
            {
                window.Visible = false;
            }
        }
    }
}