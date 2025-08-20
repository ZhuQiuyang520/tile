using System;
using UnityEngine.UI;

public class ASettlementPanel : AUIWindow
{
    public Text GoldText;
    public Text ScoreText;
    public Text ScoreBestText;
    public Button GetButton;
    public Button ADButton;
    private Action OnNext;
    private int goldNum;
    private int scoreNum;
    
    public override void OnCreate()
    {
        base.OnCreate();
        
        GetButton.onClick.AddListener(() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            AGameManager.Instance.ChangeGold(goldNum);
            OnNext?.Invoke();
            CloseUI();
        });
        
        ADButton.onClick.AddListener(() =>
        {
            A_AudioManager.Instance.PlaySound("ClickBtn");
            A_ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    AGameManager.Instance.ChangeGold(goldNum * 2);
                    OnNext?.Invoke();
                    CloseUI();
                }
            }, "123");
        });
        
        // A_AudioManager.Instance.PlaySound("Over");
    }

    public override void OnRefresh()
    {
        base.OnRefresh();
        goldNum = (int)UserDatas[0];
        scoreNum = (int)UserDatas[1];
        OnNext = (Action)UserDatas[2];
        GoldText.text = $"x {goldNum}";
        ScoreText.text = $"{scoreNum}";
        ScoreBestText.text = $"BEST: {AGameManager.Instance.HighScore}";
    }
}