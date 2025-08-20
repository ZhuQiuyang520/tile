public class AUIPanel : AUIBase
{
    public override void OnCreate()
    {
        base.OnCreate();
        ADebug.Log($"创建界面 {name}");
    }

    public void OnShow()
    {
        ADebug.Log($"显示界面 {name}");
    }

    public void OnHide()
    {
        ADebug.Log($"隐藏界面 {name}");
    }

    public override void OnClose()
    {
        base.OnClose();
        ADebug.Log($"关闭界面 {name}");
    }
}