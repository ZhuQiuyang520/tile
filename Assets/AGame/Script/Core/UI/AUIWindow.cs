
public class AUIWindow : AUIBase
{
    public AUILayer WindowLayer = AUILayer.UI;
    
    public override UIType Type => UIType.Window;

    /// <summary>
    /// 窗口名称。
    /// </summary>
    public string WindowName { private set; get; }
    
    /// <summary>
    /// 是否为全屏窗口。
    /// </summary>
    public virtual bool FullScreen { private set; get; } = false;
    
    /// <summary>
    /// 窗口可见性。
    /// </summary>
    public bool Visible
    {
        get
        {
            return gameObject.activeSelf;
        }

        set
        {
            gameObject.SetActive(value);
            OnSetVisible(value);
        }
    }

    public void Init(string windowName, params System.Object[] userDatas)
    {
        WindowName = windowName;
        _userDatas = userDatas;
        gameObject.name = WindowName;
    }

    public override void OnCreate()
    {
        base.OnCreate();
        ADebug.Log($"创建窗口：{WindowName}，FullScreen：{FullScreen}");
    }

    public override void OnClose()
    {
        base.OnClose();
        ADebug.Log("关闭窗口：" + WindowName);
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        ADebug.Log("刷新窗口：" + WindowName);
    }

    /// <summary>
    /// 当因为全屏遮挡触或者窗口可见性触发窗口的显隐。
    /// </summary>
    protected virtual void OnSetVisible(bool visible)
    {
        // ADebug.Log("窗口可见性：" + WindowName + "，" + visible);
    }

    protected void CloseUI()
    {
        AUIModule.Instance.CloseUI(this.GetType());
    }

    protected void CloseUI<T>()
    {
        AUIModule.Instance.CloseUI(typeof(T));
    }

    protected AUIWindow ShowUI<T>(params System.Object[] userDatas) where T : AUIWindow, new()
    {
        return AUIModule.Instance.ShowUI<T>(userDatas);
    }
    
}