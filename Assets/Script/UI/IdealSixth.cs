using UnityEngine;
using UnityEngine.UI;

/// <summary> 屏蔽界面 阻止玩家操作 退出游戏 </summary>
public class IdealSixth : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("InfoText")]    public Text BombGolf;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button MoldCap;

    private void Start()
    {
        MoldCap.onClick.AddListener(Application.Quit);
    }

    public void GoalBomb(string info)
    {
        BombGolf.text = info;
    }
}
