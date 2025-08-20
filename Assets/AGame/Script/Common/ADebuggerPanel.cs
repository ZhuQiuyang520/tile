using UnityEngine;
using UnityEngine.UI;

public class ADebuggerPanel : AUIWindow
{
    public Button SwitchBtn;
    public GameObject Root;
    public Button EventBtn;
    public Button GoldBtn;
    public InputField GoldInput;
    public InputField EventInput;

    public override bool FullScreen => false;

    public override void OnCreate()
    {
        base.OnCreate();
        SwitchBtn.onClick.AddListener(() =>
        {
            Root.SetActive(!Root.activeSelf);
        });
        EventBtn.onClick.AddListener(OnSendEvent);
        GoldBtn.onClick.AddListener(OnAddGold);
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        Root.SetActive(false);
    }

    private void OnAddGold()
    {
        var gold = int.Parse(GoldInput.text);
        AGameManager.Instance.ChangeGold(gold);
    }

    private void OnSendEvent()
    {
        AEventModule.Send((AEventType)int.Parse(EventInput.text));
    }

    public override void OnClose()
    {
        base.OnClose();
        EventInput.text = string.Empty;
        GoldInput.text = string.Empty;
        SwitchBtn.onClick.RemoveAllListeners();
        EventBtn.onClick.RemoveAllListeners();
        GoldBtn.onClick.RemoveAllListeners();
    }
    
    
}