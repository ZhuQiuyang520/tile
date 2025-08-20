using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class ATipsPanel : AUIWindow
{
    public Text m_TipsText;
    
    private CancellationTokenSource m_cts;
    
    public override void OnRefresh()
    {
        base.OnRefresh();
        m_TipsText.text = (string)UserData;
        m_cts?.Cancel();
        m_cts = new CancellationTokenSource();
        Close(1.5f, m_cts.Token).Forget();
    }

    public async UniTaskVoid Close(float time, CancellationToken cancellationToken)
    {
        await UniTask.Delay((int)(time * 1000), cancellationToken: cancellationToken);
        AUIModule.Instance.CloseUI<ATipsPanel>();
    }

    public override void OnClose()
    {
        base.OnClose();
        m_cts?.Cancel();
    }
}